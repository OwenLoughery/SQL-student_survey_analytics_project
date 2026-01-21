using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqlProcedureService _sqlProcedure;

        public HomeController(ILogger<HomeController> logger, SqlProcedureService sqlProcedure)
        {
            _logger = logger;
            _sqlProcedure = sqlProcedure;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Range()
        {
            return View();
        }

        public IActionResult Average()
        {
            return View();
        }

        [HttpPost]
        [HttpGet]

        public IActionResult GetChartData()
        {
            try
            {
                var variations = _sqlProcedure.GetVariations();
                var chartData = variations.Select(v => new
                {
                    v.QuestionName,
                    v.RangeValue,
                    v.Variance
                }).ToList();

                return Json(new { success = true, data = chartData });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching chart data.");
                return Json(new { success = false, message = "An error occurred while fetching chart data." });
            }
        }


        [HttpPost]
        [HttpGet]

        public IActionResult GetAverageData()
        {
            try
            {
                var variations = _sqlProcedure.GetAverages();

                var chartData = new ResponseAverage
                {
                    avgFeel = variations.avgFeel,
                    avgWorkload = variations.avgWorkload,
                    avgStress = variations.avgStress,
                    avgExpect = variations.avgExpect,
                    avgCurrent = variations.avgCurrent,
                    avgCareer = variations.avgCareer,
                    avgLove = variations.avgLove
                };


                return Json(new { success = true, data = chartData });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching GetAverage data.");
                return Json(new { success = false, message = "An error occurred while fetching chart data." });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
