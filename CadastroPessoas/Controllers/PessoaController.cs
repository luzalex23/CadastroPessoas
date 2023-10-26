using CadastroPessoas.Model;
using CadastroPessoas.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Controllers
{
    [ApiController]
    [Route("api/vc/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoasRespository _pessoasRespository;

        public PessoaController(IPessoasRespository pessoasRespository)
        {
            _pessoasRespository = pessoasRespository ?? throw new ArgumentNullException(nameof(pessoasRespository)); 
        }

        [HttpPost]
        public IActionResult Add(PessoaViewModel pessoaView)
        {
            var p = new Pessoas(pessoaView.Name, pessoaView.Age, null);
            _pessoasRespository.Add(p);
            return Ok();
        }
        [HttpGet]
         public IActionResult FindAll() 
        {
            var p = _pessoasRespository.Get();
            return Ok(p);
        }
    }
}
