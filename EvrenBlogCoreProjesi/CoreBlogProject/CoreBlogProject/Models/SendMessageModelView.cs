using System;

namespace CoreBlogProject.Models
{
    public class SendMessageModelView
    {
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
