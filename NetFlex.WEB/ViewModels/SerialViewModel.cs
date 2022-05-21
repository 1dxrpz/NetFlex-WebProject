namespace NetFlex.WEB.ViewModels
{
    public class SerialViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public int NumEpisodes { get; set; }
        public int AgeRating { get; set; }
        public float UserRating { get; set; }
        public string Description { get; set; }

        public List<GenreViewModel> Genres { get; set; }
        public List<EpisodeViewModel> Episodes { get; set; }

        public SerialViewModel()
        {
            Genres = new List<GenreViewModel>();
            Episodes = new List<EpisodeViewModel>();
        }
    }
}
