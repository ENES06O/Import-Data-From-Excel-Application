using ImportDataFromExcelApplication2.Models;
using ImportDataFromExcelApplication2.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace ImportDataFromExcelApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IPatient _patient;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IPatient patient)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _patient = patient;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile formFile)
        {
            string path = _patient.DocumentUpload(formFile);
            DataTable dt = _patient.PatientDataTable(path);
            _patient.ImportPatient(dt);

            return View();

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
