using AutoMapper;
using JwtAuthWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            // Fetch data from the database
            // domain walks
            var walks = await walkRepository.GetAllAsync();

            //convert domain walks to DTO walks
            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walks);

            //return response
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            //Get walk domain object from the database
            var walkDomain = await walkRepository.GetAsync(id);

            //Convert domain object to DTO
            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);

            //return response
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        {
            //convert DTO to Domain object
            var walkDomain = new Models.Domain.Walk
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId,
            };
        //Pass domain object to repository
        walkDomain=await walkRepository.AddAsync(walkDomain);
        //convert the Domain object back to DTO
        var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);
            //Send DTO response back to Client
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);

        }

    }
}
