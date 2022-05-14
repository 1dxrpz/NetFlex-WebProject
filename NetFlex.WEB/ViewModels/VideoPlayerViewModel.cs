namespace NetFlex.WEB.ViewModels
{
	public class VideoPlayerViewModel
	{
		public string? VideoTitle { get; set; }
		public string? EpisodeName { get; set; }
		public string? VideoLink { get; set; }
		public bool EnableSeries { get; set; }

		public List<EpisodeViewModel> Episodes { get; set; }
	}
}
