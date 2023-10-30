using AutoMapper;
using CadastroPessoas.Domain.DTOs;
using CadastroPessoas.Domain.Model;

namespace CadastroPessoas.Application.Mapping
{
    public class DomainToDTOMapping :Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Pessoas, PessoasDTO>()
                .ForMember(dest => dest.NomePessoa, m => m.MapFrom(orig => orig.name));
        }
    }
}
