using System.ComponentModel.DataAnnotations;

namespace MVC_Client.DTO.Client;

public class CreateProfessionDTO
{
    [Required(ErrorMessage = "ProfessionName is required")]

    public string ProfessionName { get; set; }
}
