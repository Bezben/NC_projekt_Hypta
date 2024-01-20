using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hypta_Projekt.Models;

namespace Hypta_Projekt.Data
{
    public class Hypta_ProjektContext : DbContext
    {
        public Hypta_ProjektContext (DbContextOptions<Hypta_ProjektContext> options)
            : base(options)
        {
        }

        public DbSet<Hypta_Projekt.Models.Produkt> Produkt { get; set; } = default!;
        public DbSet<Hypta_Projekt.Models.Kategoria> Kategoria { get; set; } = default!;
        public DbSet<Hypta_Projekt.Models.Zamowienie> Zamowienie { get; set; } = default!;
        public DbSet<Hypta_Projekt.Models.ProduktKategoria> ProduktKategoria { get; set; } = default!;
        public DbSet<Hypta_Projekt.Models.Klient> Klient { get; set; } = default!;
    }
}
