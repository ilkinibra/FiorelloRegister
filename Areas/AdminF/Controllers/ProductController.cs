using fiorello.DAL;
using fiorello.Models;
using fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fiorello.Areas.AdminF.Controllers
{
    [Area("AdminF")]
    public class ProductController : Controller
    {
        private AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int take=5, int pageSize=1)
        {
            List<Product> products = _context.products.Include(p => p.Category).Skip((pageSize - 1) * take).Take(take).ToList();
            var productsVM = MapProductToProductVM(products);
            int pageCount = ReturnPageCount(take);
            Pagination<ProductVM> model = new Pagination<ProductVM>(pageCount, pageSize, productsVM);
             // return Json(model);
            // return View(model);
           Pagination<ProductVM> pagination = new Pagination<ProductVM>(ReturnPageCount(take), pageSize, MapProductToProductVM(products));
           return View(pagination);
        }
        private List<ProductVM> MapProductToProductVM(List<Product>products)
        {
            //List<ProductVM> productsVM = new List<ProductVM>();
            //foreach(var item in products)
            //{
            //    ProductVM product = new ProductVM
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        ImageUrl = item.ImageUrl,
            //        Count = item.Count,
            //        Price = item.Price,
            //        CategoryName=item.Category.Name
            //    };
            //    productsVM.Add(product);
            //}
            //return productsVM;

            List<ProductVM>productVMs=products.Select(p=> new ProductVM
            {
                Id =p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Count = p.Count,
                Price = p.Price,
                CategoryName=p.Category.Name
            }).ToList();
            return productVMs;

        }

        private int ReturnPageCount(int take)
        {
            int productCount = _context.products.Count();
            return (int)Math.Ceiling(((decimal)productCount / take));

        }
    }
}
