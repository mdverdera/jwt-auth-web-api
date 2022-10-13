﻿using AutoMapper;
using JwtAuthWebAPI.Models.Domain;
using JwtAuthWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            //var regions = new List<Region>()
            //{
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Wellington",
            //        Code = "WLG",
            //        Area=227755,
            //        Lat=-1.8822,
            //        Long=299.88,
            //        Population=5000000
            //    },
            //    new Region
            //    {
            //        Id = Guid.NewGuid(),
            //        Name = "Auckland",
            //        Code = "AUCK",
            //        Area=123568,
            //        Lat=-2.6522,
            //        Long=56.88,
            //        Population=800000
            //    }
            //};

            var regions = await regionRepository.GetAllAsync();

            // return DTO regions
            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region => {
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,     
            //        Area = region.Area,
            //        Code = region.Code,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population  
            //    };

            //    regionsDTO.Add(regionDTO);
            //});

            var regionsDTO  = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

    }
}
