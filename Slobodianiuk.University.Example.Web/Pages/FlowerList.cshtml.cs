using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Slobodianiuk.University.Example.Models.Database;
using Slobodianuik.University.Example.Database.Interfaces;

namespace Slobodianiuk.University.Example.Web.Pages
{
    public class FlowerListModel : PageModel
    {
        public IList<Flower> Flowers { get; private set; }


        private readonly IDbEntityService<Flower> _flowerService;
        private readonly ILogger<FlowerListModel> _logger;

        public FlowerListModel(IDbEntityService<Flower> flowerService, ILogger<FlowerListModel> logger)
        {
            _flowerService = flowerService;
            _logger = logger;
        }
        public async Task OnGet() {
            Flowers = await _flowerService.GetAll().ToListAsync();

            _logger.LogTrace("Display of all Cars on the screen");
        }
    }
}
