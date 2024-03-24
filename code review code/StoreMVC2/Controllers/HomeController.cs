using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using StoreMVC2.Models;

namespace StoreMVC2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }



    //! creating a list of products 
    public List <Product> AllProducts = new List<Product>(){
        new Product {
                    Id=1,
                    Name= "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                    Price= 22,
                    Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                    Image= "https://fakestoreapi.com/img/81fPKd-2AYL._AC_SL1500_.jpg",},

     new Product {
                    Id=2,
                    Name= "Mens Cotton Jacket",
                    Price= 55,
                    Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                    Image= "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg",},
    new Product {
                    Id=3,
                    Name= "Mens Casual Premium Slim Fit T-Shirts ",
                    Price= 35,
                    Description =  "great outerwear jackets for Spring/Autumn/Winter, suitable for many occasions, such as working, hiking, camping, mountain/rock climbing, cycling, traveling or other outdoors. Good gift choice for you or your family member. A warm hearted love to Father, husband or son in this thanksgiving or Christmas Day.",                    
                    Image= "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg",
                    }
    };



    public IActionResult Index()
    {   Console.WriteLine(HttpContext.Session.GetInt32("productId"));
        Console.WriteLine(HttpContext.Session.GetInt32("qty"));
        return View("Dashboard",AllProducts);
    }

    public IActionResult OneProduct(int productId)
    {
        Product oneProduct = AllProducts.FirstOrDefault(el => el.Id == productId);
        return View (oneProduct);
    }
    [HttpGet("products/{ProductId}")]

    [HttpPost ("buy")]
    public IActionResult BuyProduct (int qty , int productId)
    {
        HttpContext.Session.SetInt32("productId",productId);
        HttpContext.Session.SetInt32("quantity" ,qty);
        
        return RedirectToAction("BoughtProduct");
    }
    

    public IActionResult BoughtProduct()
    {
        int productId = (int) HttpContext.Session.GetInt32("productId");
        int quantity =  (int) HttpContext.Session.GetInt32("quantity");
        BoughtProduct bProduct = new BoughtProduct() {bProduct=product ,BQuantity=quantity}
        
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
