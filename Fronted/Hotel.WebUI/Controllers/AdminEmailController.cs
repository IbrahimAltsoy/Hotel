using Hotel.WebUI.Models.Email;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace Hotel.WebUI.Controllers
{
    public class AdminEmailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminEmailViewModel viewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotelier", "altsoyibrahim5@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", viewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = viewModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = viewModel.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587,false);            
            smtpClient.Authenticate("altsoyibrahim5@gmail.com", "pxbzmywhgsubozmz");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
