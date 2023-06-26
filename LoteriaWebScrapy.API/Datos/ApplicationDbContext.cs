using LoteriaWebScrapy.API.Datos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace LoteriaWebScrapy.API.Datos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        DbSet<Loteria> loteria { get; set; }
        DbSet<ResultadoQuiniela> resultadoQuiniela { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            Loteria[] loterias = new Loteria[]
            {
                new Loteria(){IdLoteria = "GanaMas", NombreLoteria = "GanaMas"},
                new Loteria(){IdLoteria = "LoteriaNacional", NombreLoteria = "LoteriaNacional"},
                new Loteria(){IdLoteria = "Pega3Mas", NombreLoteria = "Pega3Mas"},
                new Loteria(){IdLoteria = "QuinielaLeidsa", NombreLoteria = "QuinielaLeidsa"},
                new Loteria(){IdLoteria = "QuinielaReal", NombreLoteria = "QuinielaReal"},
                new Loteria(){IdLoteria = "LaPrimera", NombreLoteria = "LaPrimera"}
            };


            modelBuilder.Entity<Loteria>()
                        .HasData(loterias);



            base.OnModelCreating(modelBuilder);
        }



    }
}
