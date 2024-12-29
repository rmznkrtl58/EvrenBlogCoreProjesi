using BusinessLogicLayer.Concrete;
using CoreBlogProject.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Controllers
{    
    public class MessageController : Controller
    {   
        private readonly UserManager<AppUser> _userManager;
        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        MessageManager mm = new MessageManager(new EfMessageDal());
        public async Task<IActionResult> Index()
        {   //alıcının Id'sine göre listele 
            //alıcı kim authantice olan kullanıcı
            var findUser =await _userManager.FindByNameAsync(User.Identity.Name);
            var UserId = findUser.Id;
            var messageList = mm.GetMessageByReceiver(UserId);
            return View(messageList);
        }
        public async Task<IActionResult> SendBox()
        {   //Göndericini biz olduğumuz mesajları listeleyeceğiz
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var UserId = findUser.Id;
            var messageList=mm.GetMessageBySender(UserId);
            return View(messageList);
        }
        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(SendMessageModelView model)
        {
            //Authontice olan kullanıcıyı sender'a eşitleme
            var findUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId=findUser.Id;
            string receiverName = model.Receiver;
            int findReceiverId = _userManager.Users.Where(x => x.UserName == receiverName).Select(x => x.Id).FirstOrDefault();
            Message m = new Message()
            {
                SenderId = userId,
                ReceiverId = findReceiverId,
                MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                DeleteStatus=true,
                Content= model.Content,
                Subject=model.Subject
            };
            mm.TInsert(m);
            return RedirectToAction("SendBox", "Message");
        }
        public IActionResult DeleteMessage(int id)
        {
            var findMessage = mm.TGetById(id);
            findMessage.DeleteStatus = false;
            mm.TUpdate(findMessage);
            return RedirectToAction("Index","Message");
        }
        public IActionResult MessageContent(int id)
        {
            var findMessage=mm.GetValueById(id);
            ViewBag.name = findMessage.SenderUser.NameSurname;
            return View(findMessage);
        }
    }
}

