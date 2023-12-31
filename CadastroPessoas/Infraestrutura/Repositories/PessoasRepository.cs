﻿using CadastroPessoas.Domain.DTOs;
using CadastroPessoas.Domain.Model;

namespace CadastroPessoas.Infraestrutura.Repositories
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
        public void Update(Pessoas pessoas)
        {
            _context.Pessoas.Update(pessoas);
            _context.SaveChanges();
        }
        public void Delete(int pessoaId)
        {
            var pessoa = _context.Pessoas.Find(pessoaId);
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                _context.SaveChanges();
            }
        }

        public List<Pessoas> GetByName(string nome)
        {
            return _context.Pessoas.Where(p => p.name == nome).ToList();
        }

        public Pessoas? Get(int pessoaId)
        {
            return _context.Pessoas.Find(pessoaId);
        }

        public List<PessoasDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Pessoas.Skip(pageNumber * pageQuantity).Take(pageQuantity)
                .Select(p => new PessoasDTO()
                {
                    PessoaId = p.idPessoa,
                    NomePessoa = p.name,
                    Photo = p.photo,
                })
                .ToList();
        }
    }
}
