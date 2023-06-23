using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Slobodianiuk.University.Example.Models.Database;
using Slobodianuik.University.Example.Database.Interfaces;

namespace Slobodianiuk.University.Example.Web.Pages
{
    public class OrderModel : PageModel
    {
        public Flower Flower{ get; private set; }

        private readonly ILogger<OrderModel> _logger;


        private readonly IDbEntityService<Flower> _flowerService;
        private readonly IDbEntityService<Order> _OrderService;

        public OrderModel(IDbEntityService<Flower> flowerService, IDbEntityService<Order> orderService, ILogger<OrderModel> logger)
        {
            _flowerService = flowerService;
            _logger = logger;
            _OrderService = orderService;
        }
        public async Task OnGet(int id)
        {
            Flower = await _flowerService.GetById(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            _logger.LogDebug($"Started Action: Add order from ({User.Identity.Name})");

            DateTime today = DateTime.Today;
           


            _logger.LogInformation($"Creating Order by {User.Identity.Name}");
            await _OrderService.Create(new Order()
            {
                FlowerId = id,
                UserId = User.Identity.Name, // Name êîðèñòóâà÷à ç êîíòåêñòó àâòîðèçàö³¿
                date = today
            });
            _logger.LogInformation($"Ending Creating Order by {User.Identity.Name}");

            _logger.LogTrace($"Redirect User({User.Identity.Name}) from /Order to /Index");
            return new RedirectToPageResult("/Index");
        }
    }
}
