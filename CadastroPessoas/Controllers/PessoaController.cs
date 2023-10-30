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
        private readonly ILogger<PessoaController> _logger;


        public PessoaController(IPessoasRespository pessoasRespository, ILogger<PessoaController> logger)
        {
            _pessoasRespository = pessoasRespository ?? throw new ArgumentNullException(nameof(pessoasRespository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
        [HttpGet]
        public IActionResult FindAll(int pageNumber, int pageQuantity)
        {
            var p = _pessoasRespository.Get(pageNumber, pageQuantity);
            return Ok(p);
        }
        [Authorize]
        [HttpPut]
        public IActionResult Update([FromForm] PessoaViewModel pessoaView, int pessoaId)
        {
            var filePath = Path.Combine("Storage", pessoaView.Photo.FileName);
            //var p = new Pessoas(pessoaView.Name, pessoaView.Age, filePath);
            var existingPessoa = _pessoasRespository.Get(pessoaId);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            pessoaView.Photo.CopyTo(fileStream);



            if (existingPessoa == null)
            {
                _logger.Log(LogLevel.Error, "Pessoa não encontrarda");
                _logger.LogInformation("Error:");


                return NotFound(); // Retorna 404 Not Found se a pessoa não existir.
            }

            _pessoasRespository.Update(existingPessoa);

            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int pessoaId)
        {
            var existingPessoa = _pessoasRespository.Get(pessoaId);


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
