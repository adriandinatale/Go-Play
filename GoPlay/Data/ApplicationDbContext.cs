using System;
using System.Collections.Generic;
using System.Text;
using GoPlay.Controllers;
using GoPlay.Models;
using GoPlay.web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoPlay.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ListaReproduccion> ListaReproducciones { get; set; }



    }
}
