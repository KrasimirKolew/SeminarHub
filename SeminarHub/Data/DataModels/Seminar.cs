using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.DataModels
{
    [Comment("Seminars")]
    public class Seminar
    {

        [Key]
        [Comment("Seminar Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(Constants.SeninarTopicMaxLen)]
        [Comment("Seminar Topic")]
        public string Topic { get; set; } = string.Empty;


        [Required]
        [MaxLength(Constants.SeminarLectureMaxLen)]
        [Comment("Seminar Lecturer")]
        public string Lecturer {  get; set; } = string.Empty;

        [Required]
        [MaxLength(Constants.SeminarDetailsMaxLen)]
        [Comment("Seminar Details")] 
        
        public string Details { get; set;} = string.Empty;

        [Required]
        [Comment("Seminar ForeignKey to Organizer")]
        public string OrganizerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OrganizerId))]
        [Comment("Seminar Organizer")]
        public IdentityUser Organizer { get; set; } = null!;

        [Required]
        [Comment("Seminar DateAndTime")]
        public DateTime DateAndTime { get; set; }

        [Comment("Seminar Duration")]
        public int Duration {  get; set; }

        [Required]
        [Comment("Seminar ForeignKey to Category")]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Seminar Category")]
        public Category Category { get; set; } = null!;


        public IList<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
    }
}

