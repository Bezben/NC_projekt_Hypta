using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hypta_Projekt.Models
{
    [Table("ProduktKategorie")]
    public class ProduktKategoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProduktKategoriaID { get; set; }

        [ForeignKey("Kategoria")]
        public int KategoriaID { get; set; }
        public Kategoria? Kategoria { get; set; }

        [ForeignKey("Produkt")]
        public int ProduktID { get; set; }
        public Produkt? Produkt { get; set; }
    }
}
