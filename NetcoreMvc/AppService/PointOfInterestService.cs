using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NetcoreMvc.Dto;
using NetcoreMvc.EntityFrameworkCore.Entities;
using NetcoreMvc.EntityFrameworkCore.Repositories;

namespace NetcoreMvc.AppService
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private IGenericRepository<PointOfInterest> _poiRepository;
        public PointOfInterestService(IGenericRepository<PointOfInterest> poiRepository)
        {
            _poiRepository = poiRepository;
        }

        public IEnumerable<PointOfInterestDto> GetAllPointsOfInterest()
        {
            var pointsOfInterest = _poiRepository.GetAll();
            var poiDtos = Mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterest);
            return poiDtos;
        }

        public PointOfInterestDto GetPoIById(int poiId)
        {
            var returnPoi = _poiRepository.GetAll().FirstOrDefault(poi => poi.Id == poiId);
            return Mapper.Map<PointOfInterestDto>(returnPoi);        
        }

        public PointOfInterestDto FindPoIByName(string poiName)
        {
            var returnPoi = _poiRepository.GetPoIByName(poiName);
            return Mapper.Map<PointOfInterestDto>(returnPoi);        
        }
    }
}