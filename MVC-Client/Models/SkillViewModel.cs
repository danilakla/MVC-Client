using System.ComponentModel.DataAnnotations;

namespace MVC_Client.Models;

public class SkillViewModel
{
    public int SkillId { get; set; }
    [Required(ErrorMessage = "Date is required")]

    public string Text { get; set; }
}
