using System.ComponentModel.DataAnnotations;

namespace Blog.WEBUI.Models.VMs
{
    public class AuthorLoginVM
    {
        [Display(Name = "Emailiniz:")]
        public string UserName { get; set; }

        [Display(Name = "Şifreniz:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
