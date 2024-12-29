using CoreBlogProject.Areas.AreaWriter.Models;
using CoreBlogProject.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        
        //Rolleri Listelediğim Ve Atama Yaptığım yer olacak 
        //sadece admin statüsündeki yetkililer bu alanda işlem yapıp 
        //role atamaları gerçekleştirecekler
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager= userManager;
            _roleManager= roleManager;
        }
        public IActionResult Index()
        {
            //Role Listesi
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult AddRole()
        {   
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleModel)
        {
            //Role Ekleme İşlemi
            //1->RoleViewModel Oluştur
            //Gerekli işlemleri yap

            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = roleModel.roleName
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    foreach(var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var roleFind = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
                RoleUpdateViewModel roleModel = new RoleUpdateViewModel()
                {
                    roleId = roleFind.Id,
                    roleName= roleFind.Name
                };
            return View(roleModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleUpdateViewModel roleModel)
        {
            var roleFind = _roleManager.Roles.FirstOrDefault(x => x.Id == roleModel.roleId);
            roleFind.Name= roleModel.roleName;
            var result = await _roleManager.UpdateAsync(roleFind);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Role");
            }
            return View(roleModel);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var RoleFind = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result=await _roleManager.DeleteAsync(RoleFind);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            return View();
        }
        public IActionResult UserList()
        {
            var userlist = _userManager.Users.ToList();
            return View(userlist);
        }
        [HttpGet]
        public  async Task<IActionResult> UserRoleAssing(int id)
        {
            var UserFind = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles=_roleManager.Roles.ToList();
            TempData["userId"] = UserFind.Id;
            var userRoles =await _userManager.GetRolesAsync(UserFind);
            //Bulduğum kullanıcıdaki atanan rolleri çağır
            List<UserAssingRoleViewModel>model=new List<UserAssingRoleViewModel>();
            foreach(var x in roles)
            {
                UserAssingRoleViewModel assingModel = new UserAssingRoleViewModel();
                assingModel.roleId = x.Id;
                assingModel.roleName= x.Name;
                assingModel.exists = userRoles.Contains(x.Name);
                model.Add(assingModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UserRoleAssing(List<UserAssingRoleViewModel> assingModel)
        {
            var userid = TempData["userId"];
            var finduser = _userManager.Users.FirstOrDefault(x => x.Id == (int)userid);
            foreach(var x in assingModel)
            {
                if (x.exists)
                {
                    await _userManager.AddToRoleAsync(finduser, x.roleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(finduser, x.roleName);
                }
            }
            return RedirectToAction("UserList", "Role");
        }
    }
}
