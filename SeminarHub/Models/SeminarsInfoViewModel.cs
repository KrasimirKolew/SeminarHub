using SeminarHub.Data;

namespace SeminarHub.Models
{
    public class SeminarsInfoViewModel
    {
        public SeminarsInfoViewModel(int id, string topic, string lecture , string category, DateTime dateAndTime, string organizer)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecture;
            Category = category;
            DateAndTime = dateAndTime.ToString(Constants.DateFormat);
            Organizer = organizer;
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string Category { get; set; }

        public string DateAndTime { get; set; }

        public string Organizer { get; set; }

    }
}
