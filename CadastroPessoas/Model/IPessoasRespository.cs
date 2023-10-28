﻿namespace CadastroPessoas.Model
{
    public interface IPessoasRespository
    {
        void Add(Pessoas pessoas);
        void Update(Pessoas pessoas);
        void Delete(int pessoaId);
        List<Pessoas> GetByName(string nome);

        List<Pessoas> Get();

        Pessoas? Get(int pessoaId);
    }
}
