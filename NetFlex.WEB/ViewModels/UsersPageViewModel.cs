namespace NetFlex.WEB.ViewModels
{
	public class UsersPageViewModel
	{
		public int UsersCount { get; set; }
		public IEnumerable<NetFlex.WEB.ViewModels.AdminUserVievModel> Users { get; set; }
	}
}
