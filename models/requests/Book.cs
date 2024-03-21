namespace week9exercise.models.requests
{
    public class Book
    {

        public string title { get; set; }

        public string synopsis { get; set; }

        public DateOnly publicationDate { get; set; }

        public string isbn { get; set; }

        public List<int> authorIds { get; set; }

        public List<int> genreIds { get; set; }
    }
}