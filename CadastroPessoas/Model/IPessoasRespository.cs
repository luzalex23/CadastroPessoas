namespace CadastroPessoas.Model
{
    public interface IPessoasRespository
    {
        void Add(Pessoas pessoas);
        List<Pessoas> Get();
    }
}
