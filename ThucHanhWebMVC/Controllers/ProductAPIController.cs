using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Models;
using ThucHanhWebMVC.Models.ProductModels;

namespace ThucHanhWebMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var sanPham = (from p in db.TDanhMucSps
                           select new Product
                           {
                               maSp = p.MaSp,
                               tenSp = p.TenSp,
                               maLoai = p.MaLoai,
                               anhDaiDien = p.AnhDaiDien,
                               giaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }
        
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GetProductsByCategory(string maloai)
        {
            var sanPham = (from p in db.TDanhMucSps
                           where p.MaLoai == maloai
                           select new Product
                           {
                               maSp = p.MaSp,
                               tenSp = p.TenSp,
                               maLoai = p.MaLoai,
                               anhDaiDien = p.AnhDaiDien,
                               giaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanPham;
        }
    }
}
