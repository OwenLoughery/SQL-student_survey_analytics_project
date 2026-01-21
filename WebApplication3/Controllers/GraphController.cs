namespace WebApplication3.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using System.Threading.Tasks;

public class GraphController : Controller
{
    private readonly SqlProcedureService _service;

    public GraphController(SqlProcedureService service)
    {
        _service = service;
    }

    public IActionResult DailyStats()
    {
        var data = _service.GetDailyStats();
        return View(data);
    }


    public IActionResult LoveCareer()
    {
        var data = _service.GetLoveCareer();
        return View(data);
    }

}
