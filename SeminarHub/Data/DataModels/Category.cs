using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Data.DataModels
{
    [Comment("Seminar Categories")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.CategoryNameMaxLen)]
        [Comment("Catogory name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
