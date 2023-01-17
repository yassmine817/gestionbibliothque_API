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
        private readonly ILivreRepository livreRepository;
        private readonly IMapper mapper;

        public LivreController(ILivreRepository livreRepository, IMapper mapper)
        {
            this.livreRepository = livreRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllLivres()
        {
            var livre = await livreRepository.GetLivresAsync();

            return Ok(mapper.Map<List<Livre>>(livre));
        }

        [HttpGet]
        [Route("[controller]/{livreId:guid}"), ActionName("GetLivresAsync")]
        public async Task<IActionResult> GetLivreAsync([FromRoute] Guid LivreId)
        {
            // Fetch books Details
            var livre = await livreRepository.GetLivreAsync(LivreId);

            // Return book
            if (livre == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Livre>(livre));
        }


        [HttpPut]
        [Route("[controller]/{LivreId:guid}")]
        public async Task<IActionResult> UpdateLivreAsync([FromRoute] Guid LivreId, [FromBody] UpdateLivreRequest request)
        {
            if (await livreRepository.Exists(LivreId))
            {
                // Update Details
                var updatedLivre = await livreRepository.UpdateLivre(LivreId, mapper.Map<DataModels.Livre>(request));

                if (updatedLivre != null)
                {
                    return Ok(mapper.Map<Livre>(updatedLivre));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{livreId:guid}")]
        public async Task<IActionResult> DeleteLivreAsync([FromRoute] Guid LivreId)
        {
            if (await livreRepository.Exists(LivreId))
            {
                var livre = await livreRepository.DeleteLivre(LivreId);
                return Ok(mapper.Map<Livre>(livre));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/add/livre")]
        public async Task<IActionResult> AddLivreAsync([FromBody] AddLivreRequest request)
        {
            var livre = await livreRepository.AddLivre(mapper.Map<DataModels.Livre>(request));
            return CreatedAtAction(nameof(GetLivreAsync), new { livreId = livre.Id },
                mapper.Map<Livre>(livre));
        }


    }
}
