using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.API.DTO;
using Sample.DAL.Entities;
using Sample.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SampleService _sService;
        public SampleController(SampleService sService)
        {
            _sService = sService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Samples> liste = _sService.Get();
                List<SampleDTO> result = liste.Select(s => new SampleDTO
                {
                    SampleId = s.SampleId,
                    Auteur = s.Auteur,
                    Titre = s.Titre
                }).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(SampleAddDTO dto)
        {
            Samples s = new Samples
            {
                Auteur = dto.Auteur,
                Titre = dto.Titre

            };
            _sService.Add(s);
            return NoContent();
        }
    }
}
