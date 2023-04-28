using System.ComponentModel.DataAnnotations;

namespace MVC_Client.Models.ViewModels;

public class CreateFacultieViewModel
{
    [Required(ErrorMessage = "FacultieName is required")]

    public string FacultieName { get; set; }
}
