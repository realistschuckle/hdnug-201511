using Dapper;
using Npgsql;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using Componentpalooza.Models;

namespace Componentpalooza.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<AppOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        
        public IActionResult Index()
        {
            ViewData["Title"] = "Calendar!";
            using(var conn = new NpgsqlConnection(_connectionString))
            {
                var appointments = conn.Query<Appointment>("SELECT * FROM appointments");
                return View("Index", appointments);
            }
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
        
        private readonly string _connectionString;
    }
}
