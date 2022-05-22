using Microsoft.EntityFrameworkCore;
using Loja_.Models.Entitys;

namespace Loja_.Context
{
    public class LojaContext: DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        { }
        public DbSet<Produto> Produtos { get; set; }
    }
}
