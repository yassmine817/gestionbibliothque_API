using AutoMapper;
using gestionbibliothque_API.DomainModels;

using gestionbibliothque_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestionbibliothque_API.Controllers
{

    [ApiController]
    public class AuteursController : Controller
    {
        private readonly ILivreRepository livreRepository;
        private readonly IMapper mapper;
        public AuteursController(ILivreRepository livreRepository, IMapper mapper)
        {
            this.livreRepository = livreRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllAuteurs()
        {
            var AuteursList = await livreRepository.GetAuteursAsync();

            if (AuteursList == null || !AuteursList.Any())
            {
                return NotFound();
            }
            
            return Ok(mapper.Map<List<Auteurs>>(AuteursList));
        }


     

        [HttpGet]
        [Route("[controller]/{AuteurId:guid}"), ActionName("GetAuteursAsync")]
        public async Task<IActionResult> GetAuteursAsync([FromRoute] Guid AuteurId)
        {
            // Fetch book Details
            var auteur= await livreRepository.GetOneAuteurAsync(AuteurId);

            // Return 
            if (auteur == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Auteurs>(auteur));
        }


        [HttpPost]
        [Route("[controller]/add/auteur")]
        public async Task<IActionResult> AddAuteursAsync([FromBody] AddAuteurRequest request)
        {
            var auteur = await livreRepository.AddAuteur(mapper.Map<DataModels.Auteurs>(request));
            return CreatedAtAction(nameof(GetAuteursAsync), new {},
                mapper.Map<Auteurs>(auteur)) ;
        }


    }
}

  

