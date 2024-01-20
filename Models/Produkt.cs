using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hypta_Projekt.Models
{
    [Table("Produkty")]
        public class Produkt
        {
            [Required]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int ProduktID { get; set; }

            [Required]
            public string? Nazwa { get; set; }

            [Required]
            public decimal Cena { get; set; }

            [Required]
            public string? Opis { get; set; }

            public ICollection<ProduktKategoria> ProduktKategorie { get; set; } = new List<ProduktKategoria>();
    }
    }