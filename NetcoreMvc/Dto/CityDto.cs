using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetcoreMvc.Dto
{
    public class CityDto
    {
        public CityDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage = "City name must not be empty!")]
        [MaxLength(50, ErrorMessage = "Length of city name must not exceed 50 characters")]
        public string Name { get; set; }
        public string Description { get; set; }


        public int NumberOfPointsOfInterest => PointsOfInterest.Count;

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();

    }
}