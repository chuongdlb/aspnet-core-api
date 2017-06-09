using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetcoreMvc.AppService;
using NetcoreMvc.Dto;

namespace NetcoreMvc.Controllers
{
    [Route("api/cities")]
    public class CitesController : Controller
    {
        private readonly ICityInfoService _cityInfoService;

        public CitesController(ICityInfoService cityInfoService)
        {
            _cityInfoService = cityInfoService;
        }
        [HttpGet("")]
        public IActionResult GetCities()
        {
//            return Ok(CitiesDataStore.Current.Cities);
            return Ok(_cityInfoService.GetAllCities());
        }

        // GET api/cities/5
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            CityDto retCityDto = _cityInfoService.GetCityById(id);
            if (retCityDto == null)
            {
                return NotFound();
            }
            return Ok(retCityDto);
        }
    
        [HttpGet("name/{cityName}")]
        public IActionResult GetCity(string cityName)
        {
            CityDto retCityDto = _cityInfoService.FindCityByName(cityName);
            if (retCityDto == null)
            {
                return NotFound();
            }
            return Ok(retCityDto);
        }
        
        // POST api/cities
        [HttpPost]
        public IActionResult AddCity([FromBody] CityDto inputCityDto)
        {
            if (inputCityDto == null)
            {
                return BadRequest();
            }
            var maxNumberOfCities = CitiesDataStore.Current.Cities.Count;
            CitiesDataStore.Current.Cities.Add(new CityDto(++maxNumberOfCities, inputCityDto.Name, inputCityDto.Description));
            return CreatedAtRoute("GetCity", new {id = inputCityDto.Id}, inputCityDto);
        }

        // PUT api/cities/2
        [HttpPut("{id}")]
        public IActionResult EditCity(int id, [FromBody] CityDto inputCityDto)
        {
            CityDto requireCityDto = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (requireCityDto == null)
            {
                return NotFound();
            }
            requireCityDto.Name = inputCityDto.Name;
            requireCityDto.Description = inputCityDto.Description;
            return new JsonResult(requireCityDto);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            CityDto requireCityDto = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (requireCityDto == null)
            {
                return NotFound();
            }
            return Ok(CitiesDataStore.Current.Cities.Remove(requireCityDto));
        }
    }
}