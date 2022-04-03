namespace NetFlex.WEB.ViewModels
{
    public class AllContentViewModel
    {
        public List<FilmViewModel> Films { get; set; }
        public List<SerialViewModel> Serials { get; set; }

        public List<GenreViewModel> Genres { get; set; }

        public AllContentViewModel()
        {
            Films = new List<FilmViewModel>();
            Serials = new List<SerialViewModel>();
            Genres = new List<GenreViewModel>();
        }
    }
}
