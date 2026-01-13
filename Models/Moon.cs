using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelestialBodies_MVC.Models;

[Table("Moon")]
class Moon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("PK_MoonId")]
    public int Id { get; set; }

    [Column("Name")]
    public string? Name { get; set; }

    [ForeignKey("Planet")]
    public int PlanetId { get; set; }
    public Planet? Planet { get; set; }
}
