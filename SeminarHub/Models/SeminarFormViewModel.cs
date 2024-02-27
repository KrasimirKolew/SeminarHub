using System.ComponentModel.DataAnnotations;
using System.Configuration;
using static SeminarHub.Data.Constants;
namespace SeminarHub.Models
{
    public class SeminarFormViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeninarTopicMaxLen,
            MinimumLength = SeninarTopicMinLen,
            ErrorMessage = StringLengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarLectureMaxLen,
            MinimumLength = SeminarLectureMinLen,
            ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(SeminarDetailsMaxLen,
            MinimumLength = SeminarDetailsMinLen,
            ErrorMessage = StringLengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string DateAndTime { get; set; } = string.Empty;

        [Range(DurationMin, DurationMax)]
        public int Duration { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories {  get; set; } = new List<CategoryViewModel>();

    }
}
