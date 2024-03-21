namespace week9exercise.models.responses
{
    public class BookResponse
    {
        public int id { get; set; }

        public string title { get; set; }

        public string synopsis { get; set; }

        public DateOnly publicationDate { get; set; }

        public string isbn { get; set; }

        public List<AuthorResponse> authors { get; set; }

        public List<GenreResponse> genres { get; set; }
    }
}