using System.Collections.Generic;
using NetcoreMvc.Dto;
using NetcoreMvc.EntityFrameworkCore.Entities;

namespace NetcoreMvc.AppService
{
    public interface ICityInfoService
    {
        void AddNewCity(CityDto newCity);

        IEnumerable<CityDto> GetAllCitiesWithPOI();

        IEnumerable<CityWithoutPointsOfInterestDto> GetAllCities();
        
        CityDto GetCityById(int cityId);
    }
}