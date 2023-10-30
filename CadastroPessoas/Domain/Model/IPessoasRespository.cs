using CadastroPessoas.Domain.DTOs;

namespace CadastroPessoas.Domain.Model
{
    public interface IPessoasRespository
    {
        void Add(Pessoas pessoas);
        void Update(Pessoas pessoas);
        void Delete(int pessoaId);
        List<Pessoas> GetByName(string nome);

        List<PessoasDTO> Get(int pageNumber, int pageQuantity);

        Pessoas? Get(int pessoaId);
    }
}
