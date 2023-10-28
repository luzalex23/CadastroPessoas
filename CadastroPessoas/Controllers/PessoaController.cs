using CadastroPessoas.Application.ViewModel;
using CadastroPessoas.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroPessoas.Controllers
{
    [ApiController]
    [Route("api/v1/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoasRespository _pessoasRespository;

        public PessoaController(IPessoasRespository pessoasRespository)
        {
            _pessoasRespository = pessoasRespository ?? throw new ArgumentNullException(nameof(pessoasRespository));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] PessoaViewModel pessoaView)
        {
            var filePath = Path.Combine("Storage", pessoaView.Photo.FileName);
            var p = new Pessoas(pessoaView.Name, pessoaView.Age, filePath);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            pessoaView.Photo.CopyTo(fileStream);



            _pessoasRespository.Add(p);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public IActionResult FindAll()
        {
            var p = _pessoasRespository.Get();
            return Ok(p);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Update(int pessoaId, PessoaViewModel pessoaView)
        {
            var existingPessoa = _pessoasRespository.Get().FirstOrDefault(p => p.idPessoa == pessoaId);

            if (existingPessoa == null)
            {
                return NotFound(); // Retorna 404 Not Found se a pessoa não existir.
            }


            _pessoasRespository.Update(existingPessoa);

            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int pessoaId)
        {
            var existingPessoa = _pessoasRespository.Get().FirstOrDefault(p => p.idPessoa == pessoaId);

            if (existingPessoa == null)
            {
                return NotFound(); // Retorna 404 Not Found se a pessoa não existir.
            }

            _pessoasRespository.Delete(pessoaId);

            return Ok();
        }
        [Authorize]
        [HttpGet]
        [Route("GetByName")]
        public IActionResult GetByName(string nome)
        {
            var pessoas = _pessoasRespository.GetByName(nome);
            return Ok(pessoas);
        }
        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var pessoa = _pessoasRespository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(pessoa.photo);

            return File(dataBytes, "image/png");
        }
    }
}
