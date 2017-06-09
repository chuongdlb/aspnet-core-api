using System.Linq;
using NetcoreMvc.EntityFrameworkCore.Entities;

namespace NetcoreMvc.EntityFrameworkCore.Repositories
{
    public static class CityInfoRepositoryExtension
    {
        public static City GetCityByName(this IGenericRepository<City> cityRepository, string cityName)
        {
            return cityRepository.GetAll().FirstOrDefault(c => c.Name.Contains(cityName) || cityName.Contains(c.Name));
        }
    }
}