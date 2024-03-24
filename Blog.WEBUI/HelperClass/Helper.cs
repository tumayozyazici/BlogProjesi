using Blog.DATA.Concrete;
using System.Net.Mail;
using System.Net;
using Blog.WEBUI.Models.VMs;

namespace Blog.WEBUI.HelperClass
{
    public static class Helper
    {
        public static void SendMail(Author user, AuthorCreateVM vm, int confirmationCode)
        {


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("burgershop12@outlook.com", "BurgerShop");
            mail.To.Add(vm.Email);
            mail.Subject = "BurgerShop Doğrulama Kodu";
            mail.IsBodyHtml = true;
            mail.Body = "BurgerShop'a hoşgeldiniz. İşte doğrulama kodun: " + confirmationCode;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.outlook.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("burgershop12@outlook.com", "Admin..1234");

            smtpClient.Send(mail);
            smtpClient.Timeout = 100;
        }

        public static string AddPhoto(IFormFile file, IWebHostEnvironment _webHostEnvironment)
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var filestream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(filestream);
            }

            string relativeFilePath = Path.Combine("/img", uniqueFileName);
            return relativeFilePath;
        }
    }
}
