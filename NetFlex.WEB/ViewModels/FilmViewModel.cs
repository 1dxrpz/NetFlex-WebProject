namespace NetFlex.WEB.ViewModels
{
    public class FilmViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public float UserRating { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string PreviewVideo { get; set; }
    }
}
