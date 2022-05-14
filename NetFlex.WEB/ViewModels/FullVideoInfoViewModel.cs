namespace NetFlex.WEB.ViewModels
{
    public class FullVideoInfoViewModel
    {
        public FilmViewModel Film { get; set; }
        public SerialViewModel Serial { get; set; }
        public List<ReviewViewModel> Reviews { get; set; }

        public List<GenreVideosViewModel> Genres { get; set; }

        public FullVideoInfoViewModel()
        {
            Genres = new List<GenreVideosViewModel>();
        }
    }
}
