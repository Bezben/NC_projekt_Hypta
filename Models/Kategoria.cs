using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hypta_Projekt.Models
{
    [Table("Kategorie")]
    public class Kategoria
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int KategoriaID { get; set; }

        [Required]
        public string? Nazwa { get; set; }

        public ICollection<ProduktKategoria> ProduktKategorie { get; set; } = new List<ProduktKategoria>();
    }
}
