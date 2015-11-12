using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.OptionsModel;
using Componentpalooza.Models;
using Componentpalooza.ViewModels.Home;

namespace Componentpalooza.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IOptions<AppOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Calendar!";
            using(var conn = new NpgsqlConnection(_connectionString))
            {
                var appointments = await conn.QueryAsync<Appointment>("SELECT * FROM appointments ORDER BY StartsAt");
                return View("Index", new IndexViewModel(appointments));
            }
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
        
        private readonly string _connectionString;
    }
}
