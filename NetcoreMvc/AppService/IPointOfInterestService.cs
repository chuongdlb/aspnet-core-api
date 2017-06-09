using System.Collections.Generic;
using NetcoreMvc.Dto;

namespace NetcoreMvc.AppService
{
    public interface IPointOfInterestService
    {
        IEnumerable<PointOfInterestDto> GetAllPointsOfInterest();
        
        PointOfInterestDto GetPoIById(int poiId);
        PointOfInterestDto FindPoIByName(string poiName);
    }
}