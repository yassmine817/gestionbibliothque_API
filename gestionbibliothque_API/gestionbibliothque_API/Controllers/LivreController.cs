using AutoMapper;
using gestionbibliothque_API.DomainModels;
using gestionbibliothque_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    }
}
