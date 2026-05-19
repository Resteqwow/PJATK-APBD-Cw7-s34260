using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_Cw7_s34260.Models;
[Table("Components")]
public class Components
{
    
    [Key, Column(TypeName = "char(10)")]
    public string Code { get; set; }
    [MaxLength(300)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }



    public IEnumerable<PcComponents> PCComponents { get; set; } = [];

    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentTypes ComponentTypes { get; set; } = null!;
    
    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturers ComponentManufacturers { get; set; } = null!;
}