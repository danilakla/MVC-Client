using System.ComponentModel.DataAnnotations;

namespace MVC_Client.DTO.Server;

public  class GroupDTO
{
    [Range(1, 4, ErrorMessage = "NumberCourse must be between 1 and 4")]

    public int NumberCourse { get; set; }
    [Range(1, 12, ErrorMessage = "NumberCourse must be between 1 and 12")]

    public int NumberGroup { get; set; }
    [Required(ErrorMessage = "ProfessionName is required")]

    public string ProfessionName { get; set; }

}
