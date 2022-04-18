using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.WEB.ViewModels;

namespace NetFlex.WEB.Controllers
{
	public class SeriesController : Controller
	{
        private IVideoService _videoService;

        public SeriesController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<IActionResult> Index()
        {
            var getSerials = await _videoService.GetSerials();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
            var mapper = new Mapper(config);
            var serials = mapper.Map<IEnumerable<SerialDTO>, IEnumerable<SerialViewModel>>(getSerials);

            return View(serials);
        }
    }
}
