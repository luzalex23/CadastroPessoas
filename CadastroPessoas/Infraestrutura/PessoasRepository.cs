using CadastroPessoas.Model;

namespace CadastroPessoas.Infraestrutura
{
    public class PessoasRepository : IPessoasRespository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Pessoas pessoas)
        {
            _context.Pessoas.Add(pessoas);
            _context.SaveChanges();
         }

        public List<Pessoas> Get()
        {
            return _context.Pessoas.ToList();
        }
    }
}
