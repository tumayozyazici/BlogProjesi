using System.ComponentModel.DataAnnotations;

namespace Blog.WEBUI.Models.VMs
{
    public class ConfirmationCodeVM
    {
        [Display(Name = "Onay Kodu:")]
        public string ConfirmationCode { get; set; }
    }
}
