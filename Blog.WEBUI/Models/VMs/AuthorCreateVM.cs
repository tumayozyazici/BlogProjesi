using System.ComponentModel.DataAnnotations;

namespace Blog.WEBUI.Models.VMs
{
    public class AuthorCreateVM
    {
        [Display(Name = "Kullanıcı adınız:")]
        public string UserName { get; set; }

        [Display(Name = "Emailiniz:")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Şifreniz:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
