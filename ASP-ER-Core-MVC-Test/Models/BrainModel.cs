using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_ER_Core_MVC_Test.Models;

public enum BrainSize
{
    Microscopic,
    Small,
    Medium,
    Big,
    Mega,
    Gigantic
}

public class BrainModel
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }
    [Required]
    public BrainSize BrainSize { get; set; }
    [Range(0, 100)]
    public int BrainSmoothness { get; set; }
    
    public BobModel Bob { get; set; }
}