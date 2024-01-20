using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hypta_Projekt.Models
{
    [Table("Zamowienia")]
    public class Zamowienie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZamowienieID { get; set; }

        [Required]
        public DateTime DataZamowienia { get; set; }

        [Required]
        public string? StatusZamowienia { get; set; }

        [ForeignKey("Produkt")]
        public int ProduktID { get; set; }
        public Produkt? Produkt { get; set; }

        [ForeignKey("Klient")]
        public int KlientID { get; set; }
        public Klient? Klient { get; set; }
    }
}
