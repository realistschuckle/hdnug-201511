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

        [HttpPost]
        public async Task<ActionResult> New(Appointment appointment)
        {
            using(var conn = new NpgsqlConnection(_connectionString))
            {
                string template = @"
                    INSERT INTO appointments(StartsAt, Title, FifteenMinuteMultiplier)
                    VALUES (@StartsAt, @Title, @FifteenMinuteMultiplier)
                ";
                await conn.ExecuteAsync(template, new {appointment.StartsAt, appointment.Title, appointment.FifteenMinuteMultiplier});
                return RedirectToAction("Index");
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            using(var conn = new NpgsqlConnection(_connectionString))
            {
                string template = @"
                    DELETE FROM appointments
                    WHERE id = @id
                ";
                await conn.ExecuteAsync(template, new {id});
                return RedirectToAction("Index");
            }
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
        
        private readonly string _connectionString;
    }
}
