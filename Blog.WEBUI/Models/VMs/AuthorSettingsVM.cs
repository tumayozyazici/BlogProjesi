using System.ComponentModel;

namespace Blog.WEBUI.Models.VMs
{
    public class AuthorSettingsVM
    {
        [DisplayName("Emailiniz:")]
        public string Email { get; set; }

        [DisplayName("Kullanıcı Adınız:")]
        public string UserName {  get; set; }

        [DisplayName("Adınız:")]
        public string? FirstName { get; set; }

        [DisplayName("Soyadınız:")]
        public string? LastName { get; set; }

        [DisplayName("Resminiz:")]
        public string? Photo { get; set; }
    }
}
