using System.Linq;
using NetcoreMvc.EntityFrameworkCore.Entities;

namespace NetcoreMvc.EntityFrameworkCore.Repositories
{
    public static class PointOfInterestRepositoryExtension
    {
        public static PointOfInterest GetPoIByName(this IGenericRepository<PointOfInterest> poiRepository, string poiName)
        {
            return poiRepository.GetAll().FirstOrDefault(poi => poi.Name.Contains(poiName) || poiName.Contains(poi.Name));

        }
    }
}