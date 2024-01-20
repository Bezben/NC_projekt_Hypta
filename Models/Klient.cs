using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hypta_Projekt.Models
{
    [Table("Klienci")]
    public class Klient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlientID { get; set; }

        [Required]
        public string? Imie { get; set; }

        [Required]
        public string? Nazwisko { get; set; }

        public ICollection<Zamowienie> Zamowienia { get; set; } = new List<Zamowienie>();
    }
}
