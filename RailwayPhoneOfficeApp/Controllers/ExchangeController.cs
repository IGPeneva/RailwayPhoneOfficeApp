using Microsoft.AspNetCore.Mvc;
using RailwayPhoneOfficeApp.Data;
using RailwayPhoneOfficeApp.Data.Models;
using RailwayPhoneOfficeApp.Models;
using SQLitePCL;

namespace RailwayPhoneOfficeApp.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly RailwayPhoneOfficeDbContext _context;

        public ExchangeController(RailwayPhoneOfficeDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var exchanges = _context.TelephoneExchanges
                .Select(c => new ExchangeIndexViewModel
                {
                    Name = c.Name,
                    Capacity = c.Capacity
                }).ToList();

            return View(exchanges);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ExchangeCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(ExchangeCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var exchange = new TelephoneExchange
                {
                    Name = viewModel.Name,
                    Capacity = viewModel.Capacity
                };

                _context.TelephoneExchanges.Add(exchange);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
