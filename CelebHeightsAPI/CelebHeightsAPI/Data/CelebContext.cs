using Microsoft.EntityFrameworkCore;
using CelebHeightsAPI.Models;
using CelebHeightsAPI.Models.CelebHeightsAPI.Models;
using System.Collections.Generic;

namespace CelebHeightsAPI.Data
{
    public class CelebContext : DbContext
    {
        public CelebContext(DbContextOptions<CelebContext> options) : base(options)
        {
        }

        public DbSet<Celebrity> Celebrities { get; set; }
    }
}
