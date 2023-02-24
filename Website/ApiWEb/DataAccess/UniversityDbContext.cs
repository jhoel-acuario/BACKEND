using ApiWEb.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ApiWEb.DataAccess
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options): base(options)
        {

        }
        //TODO: Agregra las tablas de la DB
        //Aca va todos los modelos para crear las tablas
        public DbSet<User>? Users { get; set; }
        
    }
}
