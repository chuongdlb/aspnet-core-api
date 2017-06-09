using Microsoft.AspNetCore.Mvc;
using NetcoreMvc.AppService;
using NetcoreMvc.Dto;

namespace NetcoreMvc.Controllers
{
    [Route("api/poi")]
    public class PointsOfInterestController : Controller
    {
     
        private readonly IPointOfInterestService _pointOfInterestService;

        public PointsOfInterestController(IPointOfInterestService pointOfInterestService)
        {
            _pointOfInterestService = pointOfInterestService;
        }
        
        [HttpGet("")]
        public IActionResult GetAllPointsOfInterest()
        {
            return Ok(_pointOfInterestService.GetAllPointsOfInterest());
        }

        // GET api/poi/5
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            PointOfInterestDto retPoiDto = _pointOfInterestService.GetPoIById(id);
            if (retPoiDto == null)
            {
                return NotFound();
            }
            return Ok(retPoiDto);
        }
    
        [HttpGet("name/{poiName}")]
        public IActionResult GetCity(string poiName)
        {
            PointOfInterestDto retPoiDto = _pointOfInterestService.FindPoIByName(poiName);
            if (retPoiDto == null)
            {
                return NotFound();
            }
            return Ok(retPoiDto);
        }
        
    }
}