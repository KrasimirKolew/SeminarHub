namespace SeminarHub.Data
{
    public static class Constants
    {
        public const int SeninarTopicMaxLen = 100;
        public const int SeninarTopicMinLen = 3;

        public const int SeminarLectureMaxLen = 60;
        public const int SeminarLectureMinLen = 5;

        public const int SeminarDetailsMaxLen = 500;
        public const int SeminarDetailsMinLen = 10;

        public const int DurationMin = 30;
        public const int DurationMax = 180;

        public const string DateFormat = "dd/MM/yyyy HH:mm";

        public const int CategoryNameMaxLen = 50;
        public const int CategoryNameMinLen = 3;

        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
    }
}
