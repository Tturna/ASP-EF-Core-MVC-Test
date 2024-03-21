using System.ComponentModel.DataAnnotations;

namespace ASP_ER_Core_MVC_Test.Models;

public class BobModel
{
    [Required]
    public int ID { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Name { get; set; }
    
    public BrainModel Brain { get; set; }
    public int BrainID { get; set; }
}