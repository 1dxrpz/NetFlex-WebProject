namespace NetFlex.WEB.ViewModels
{
    public class FullVideoInfoViewModel
    {
        public List<FilmViewModel> Films { get; set; }
        public List<SerialViewModel> Serials { get; set; }

        public List<GenreViewModel> Genres { get; set; }

        public FullVideoInfoViewModel()
        {
            Films = new List<FilmViewModel>();
            Serials = new List<SerialViewModel>();
            Genres = new List<GenreViewModel>();
        }
    }
}
