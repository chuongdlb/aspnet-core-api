using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetcoreMvc.EntityFrameworkCore.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}