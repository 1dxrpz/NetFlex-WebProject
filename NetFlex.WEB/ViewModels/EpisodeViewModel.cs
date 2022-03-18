namespace NetFlex.WEB.ViewModels
{
    public class EpisodeViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid SerialId { get; set; }
        public int Duration { get; set; }
        public int Number { get; set; }

        public string VideoLink { get; set; }
    }
}
