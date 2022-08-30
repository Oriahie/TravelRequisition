using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelRequisition.Core.Entities;
using TravelRequisition.Core.Interface.Repositories;
using TravelRequisition.Core.Interface.Services;
using TravelRequisition.Infrastructure;
using TravelRequisition.Infrastructure.Models;

namespace TravelRequisition.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TravelRequestController : ControllerBase
    {
        private readonly ITravelRequestRepository _travelRepo;
        private readonly ICountryService _countryService;
        private readonly IWeatherService _weatherService;
        public TravelRequestController(ITravelRequestRepository travelRepo,
                                       ICountryService countryService,
                                       IWeatherService weatherService)
        {
            _travelRepo = travelRepo;
            _weatherService = weatherService;
            _countryService = countryService;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAllTravelRequests()
        {
            var res = await _travelRepo.GetAll();

            return Ok(new Response<List<TravelRequest>>()
            {
                Message = "Retrieved Successfully",
                Succeeded = true,
                Data = res
            });
        }

        [HttpGet("searchlocation/{location}")]
        public async Task<IActionResult> SearchLocation([Required] string location)
        {
            var country = await _countryService.GetByName(location);
            var weather = await _weatherService.GetWeather(country.latlng[0], country.latlng[1]);

            return Ok(new Response<SearchCountryResponseModel>()
            {
                Message = "Retrieved Successfully",
                Succeeded = true,
                Data = weather.Map(country)
            });
        }


        [HttpGet("getByReqNumber/{reqNum}")]
        public async Task<IActionResult> GetTravelRequest([Required] long reqNum)
        {
            var res = await _travelRepo.GetByRequisitionNumber(reqNum);

            return Ok(new Response<TravelRequest>()
            {
                Message = "Retrieved Successfully",
                Succeeded = true,
                Data = res
            });
        }

        [HttpDelete("delete/{reqNum}")]
        public async Task<IActionResult> DeleteTravelRequest([Required] long reqNum)
        {
            var res = await _travelRepo.Delete(reqNum);

            return Ok(new Response<bool>()
            {
                Message = "Deleted Successfully",
                Succeeded = true,
                Data = res
            });
        }


        [HttpPost("create")]
        public async Task<IActionResult> CreateTravelRequest([FromBody]TravelRequestModel model)
        {
            var res = await _travelRepo.Create(model.Map());

            return Ok(new Response<TravelRequest>()
            {
                Message = "Created Successfully",
                Succeeded = true,
                Data = res
            });
        }

    }
}
