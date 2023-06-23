using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Slobodianiuk.University.Example.Models.Database;
using Slobodianuik.University.Example.Database.Interfaces;

namespace Slobodianiuk.University.Example.Web.Pages
{
    public class OrdersModel : PageModel
    {
        public IList<Order> Orders { get; set; }

        private readonly ILogger<OrdersModel> _logger;
        private readonly IDbEntityService<Order> _orderService;
        public OrdersModel(IDbEntityService<Order> orderService, ILogger<OrdersModel> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        public async Task OnGet()
        {
            Orders = await _orderService.GetAll().ToListAsync();
        }
    }
}
