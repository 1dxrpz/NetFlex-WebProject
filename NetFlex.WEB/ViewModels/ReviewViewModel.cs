namespace NetFlex.WEB.ViewModels
{
    public class ReviewViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Guid ContentId { get; set; }
        public string Text { get; set; }
        public float Rating { get; set; }

        public DateTime PublishTime { get; set; }
    }
}
