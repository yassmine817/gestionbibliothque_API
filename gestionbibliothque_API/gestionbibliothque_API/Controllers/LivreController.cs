using AutoMapper;
using gestionbibliothque_API.DomainModels;
using gestionbibliothque_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace gestionbibliothque_API.Controllers
{
    [ApiController]
    public class LivreController : Controller   
    {
        private  readonly ILivreRepository livreRepository;
        private readonly IMapper mapper;

        public LivreController(ILivreRepository livreRepository , IMapper mapper)
        {
            this.livreRepository = livreRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task <IActionResult> GetAllLivres()
        {
            var livre = await  livreRepository.GetLivresAsync();
            
            return Ok(mapper.Map<List<Livre>>(livre));
        }

        [HttpGet]
        [Route("[controller]/{livreId:guid}"), ActionName("GetLivresAsync")]
        public async Task<IActionResult> GetLivreAsync([FromRoute] Guid LivreId)
        {
            // Fetch Student Details
            var livre = await livreRepository.GetLivreAsync(LivreId);

            // Return Student
            if (livre == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Livre>(livre));
        }
        
    }
}
