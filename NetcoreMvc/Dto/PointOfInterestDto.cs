using System.ComponentModel.DataAnnotations;

namespace NetcoreMvc.Dto
{
    public class PointOfInterestDto
    {
        public PointOfInterestDto(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Point of interest must not be empty!")]
        [MaxLength(50, ErrorMessage = "Length of Point-of-interest name must not exceed 50 characters")]
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}