using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucHanhWebMVC.Models;

namespace ThucHanhWebMVC.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lstsanpham = db.TDanhMucSps.ToList();


            return View(lstsanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SanPhamTheoLoai(string maLoai)
        {
            List<TDanhMucSp> lstsanpham = db.TDanhMucSps.Where(x => x.MaLoai == maLoai).OrderBy(x => x.TenSp).ToList();
            return View(lstsanpham);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}