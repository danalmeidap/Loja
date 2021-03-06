using Microsoft.EntityFrameworkCore;
using Loja_.Models.Entitys;

namespace Loja_.Context
{
    public class LojaContext: DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CartaoCredito> cartaoCreditos { get; set; }
        public DbSet<Pagamento> pagamentos { get; set; }
    }
}
