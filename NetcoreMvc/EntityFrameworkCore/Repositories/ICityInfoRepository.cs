using System.Linq;
using NetcoreMvc.EntityFrameworkCore.Entities;

namespace NetcoreMvc.EntityFrameworkCore.Repositories
{
    public interface ICityInfoRepository : IGenericRepository<City>
    {
        IQueryable<City> GetAllCitiesWithPOI();
        City GetCityByName(string cityName);
        City GetCity(int cityId, bool includedPointsOfInterest = true);
    }
}