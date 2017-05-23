using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetcoreMvc.Dto;
using NetcoreMvc.EntityFrameworkCore;
using NetcoreMvc.EntityFrameworkCore.Entities;
using NetcoreMvc.EntityFrameworkCore.Repositories;

namespace NetcoreMvc.AppService
{
    public class CityInfoService : ICityInfoService
    {
        protected readonly IGenericRepository<City> _cityRepository;

        public CityInfoService(IGenericRepository<City> cityRepository)
        {
            _cityRepository =  cityRepository;
        }
        public void AddNewCity(CityDto cityDto)
        {
            var newCity = new City()
            {
                Name = cityDto.Name,
                Description = cityDto.Description,

            };
            foreach (var pointOfInterestDto in cityDto.PointsOfInterest)
            {
                newCity.PointsOfInterest.Add(new PointOfInterest()
                {
                    Name = pointOfInterestDto.Name,
                    Description = pointOfInterestDto.Description
                });
            }
            _cityRepository.Insert(newCity);
            
        }

        public IEnumerable<CityDto> GetAllCitiesWithPOI()
        {
            var cities = _cityRepository.GetAll().Include(city => city.PointsOfInterest);
            var cityDtos = Mapper.Map<IEnumerable<CityDto>>(cities);
            return cityDtos;
        }

        public IEnumerable<CityWithoutPointsOfInterestDto> GetAllCities()
        {
            var cities = _cityRepository.GetAll().ToList();

            var cityDtos = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cities);
            
            return cityDtos;
        }

       
        public CityDto GetCityById(int cityId)
        {
            var returnCity = _cityRepository.GetAll().Include(city => city.PointsOfInterest)
                .FirstOrDefault(city => city.Id == cityId);
            return Mapper.Map<CityDto>(returnCity);
        }
    }
}