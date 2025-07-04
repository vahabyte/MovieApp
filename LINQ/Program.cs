using LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
namespace LINQ
{
    public class Program
    {

        class CustomerModel
        {

            public CustomerModel()
            {
                this.Orders = new List<OrderModel>();
            }
            public string CustomerId { get; set; }
            public string CustomerName { get; set; } 
            public int OrderCount { get; set; }

            public List<OrderModel> Orders { get; set; }
        }

        class OrderModel
        {

            public int OrderId { get; set; }
            public decimal Total { get; set; }
            public List<ProductModel> Products { get; set; }
        }

      public class ProductModel
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public decimal? Price { get; set; }
            //public int Quantity { get; set; }
        }


        static void Main(string[] args)
        {

            using (var db = new CustomNorthwindContext())
            {

                //Klasik sql sorguları ile işlem yapma

                //var sonuc = db.Database.ExecuteSqlRaw("delete from Products where ProductID=78");

                //var sonuc = db.Database.ExecuteSqlRaw("update Products set ProductName='Yeniii ürün' where ProductID = 81 ");

                //var query = "4";
                //var products = db.Products.FromSqlRaw($"select * from Products where CategoryID = {query}").ToList();

                //foreach (var product in products)
                //{
                //    Console.WriteLine(product.ProductName);
                //}               


                var products = db.ProductModels
                    .FromSqlRaw("select ProductID , ProductName as Name , UnitPrice as Price from Products where CategoryID = 4").ToList();

                foreach (var product in products)
                {

                    Console.WriteLine(product.Name);
                
                }

            }

        }

        //private static void CokluTabloCalismasi2(NorthwindContext db)
        //{
        //    var customers = db.Customers.Where(cus => cus.CustomerId == "BSBEV")
        //        .Select(cus => new CustomerModel()
        //        {

        //            CustomerId = cus.CustomerId,
        //            CustomerName = cus.ContactName,
        //            OrderCount = cus.Orders.Count,
        //            Orders = cus.Orders.Select(order => new OrderModel
        //            {
        //                OrderId = order.OrderId,
        //                Total = order.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
        //                Products = order.OrderDetails.Select(od => new ProductModel
        //                {
        //                    ProductId = od.ProductId,
        //                    Name = od.Product.ProductName,
        //                    Price = od.UnitPrice,
        //                    Quantity = od.Quantity
        //                }).ToList()

        //            }).ToList()

        //        })
        //        .ToList();


        //    foreach (var customer in customers)
        //    {

        //        Console.WriteLine(customer.CustomerId + " => " + customer.CustomerName + " => " + customer.OrderCount);
        //        Console.WriteLine("Siparişler");
        //        foreach (var order in customer.Orders)
        //        {
        //            Console.WriteLine("******************************************************");
        //            Console.WriteLine(order.OrderId + " => " + order.Total);

        //            foreach (var product in order.Products)
        //            {
        //                Console.WriteLine(product.ProductId + " => " + product.Name + " => " + product.Quantity + " => " + product.Price);
        //            }
        //        }

        //    }
        //}

        //private static void CokluTabloCalisma(NorthwindContext db)
        //{
        //    //Çoklu tablo ilişkilendirerek selectleme


        //    var products = db.Products.Include(c => c.Category).Where(p => p.Category.CategoryName == "Condiments").ToList();

        //    foreach (var p in products)
        //    {

        //        Console.WriteLine(p.ProductName + " " + p.ProductId + " " + p.Category.CategoryName);

        //    }


        //    ilgili kategorilerin hangisinde ürün bilgisi yok ilişkilendirilmemiştir!

        //        1.yol
        //                var categories = db.Categories.Where(c => !c.Products.Any()).ToList();
        //    2.yol
        //                var categories = db.Categories.Where(c => c.Products.Count == 0).ToList();


        //    query expressions
        //                extension method


        //        var products = (from p in db.Products where p.UnitPrice > 10 select p).ToList();

        //    var products2 = db.Products.Where(p => p.UnitPrice > 10).ToList();


        //    Sadece tedarikçileri olan supliers bilgileri getirmek(INNER JOIN)
        //                var products = (from p in db.Products
        //                                join s in db.Suppliers
        //                                on p.SupplierId equals s.SupplierId
        //                                select new
        //                                {

        //                                    p.ProductName,
        //                                    contactName = s.ContactName,
        //                                    CompanyName = s.CompanyName,


        //                                }).ToList();


        //    foreach (var product in products)
        //    {

        //        Console.WriteLine(product.ProductName);

        //    }
        //}

        //private static void SilmeIslemi(NorthwindContext db)
        //{
        //    SİLME İŞLEMİ

        //        var p = db.Products.Find(83);

        //    if (p != null)
        //    {

        //        db.Products.Remove(p);
        //        db.SaveChanges();
        //        Console.WriteLine(p.ProductName + " Verisi silindi");
        //    }


        //    SİLME İŞLEMİ(SELECT OLMADAN)

        //        var p = new Product() { ProductId = 80 };
        //    db.Remove(p);
        //    db.SaveChanges();
        //}

        //private static void Sorular(NorthwindContext db)
        //{
        //    ------------------------------------------SORULAR------------------------------------------


        //        SORU(ÜRÜNLER TABLOSUNDAKİ İLK 5 KAYDI GETİR product id ye göre)


        //        var products = db.Products.OrderBy(p => p.ProductId).Select(p => p.ProductName).Take(5).ToList();

        //    SORU ÜRÜNKLER TABLOSUNDAKİ İKİNCİ 5 KAYDI ALINIZ.

        //        var products = db.Products.OrderBy(p => p.ProductId).Select(p => p.ProductName).Skip(5).Take(5).ToList();

        //    SORU TÜM MÜŞTERİ KAYITLARINI GETİR

        //    var customers = db.Customers.Select(c => c.ContactName).ToList();

        //    SORU TÜM MÜŞTERİLERİN SADECE CustomerId ve ContactName kolonlarını getir

        //    var customers = db.Customers.Select(c => new { c.CustomerId, c.ContactName }).ToList();


        //    foreach (var c in customers)
        //    {
        //        Console.WriteLine("Id= " + c.CustomerId + " Name= " + c.ContactName);
        //    }


        //    SORU ALMANYADA YAŞAYAN MÜŞTERİLERİN ADLARINI GETİRİNİZ!

        //    var customers = db.Customers.Where(c => c.Country == "Germany").Select(c => c.ContactName).ToList();


        //    foreach (var c in customers)
        //    {
        //        Console.WriteLine(c);
        //    }


        //    SORU "Diego Roel" isimli müşteri nerede yaşamaktadır ? GETİR

        //    var customers = db.Customers.Where(c => c.ContactName == "Diego Roel")
        //        .Select(c => new { c.Country, c.City }).FirstOrDefault();

        //    Console.WriteLine("Diego Roel " + customers.Country + " ülkesinin, " + customers.City + " Şehrinde yaşamaktadır.");


        //    SORU STOKTA OLMAYAN ÜRÜNLER HANGİLERİDİR?


        //    var products = db.Products.Where(p => p.UnitsInStock == 0).Select(c => c.ProductName).ToList();

        //    foreach (var p in products)
        //    {
        //        Console.WriteLine("Stokta olmayan ürünler : " + p);
        //    }

        //    SORU TÜM ÇALIŞANLARIN ADINI VE SOYADINI TEK KOLON HALİNDE GETİR


        //        var employees = db.Employees.Select(e => new { e.FirstName, e.LastName }).ToList();

        //    foreach (var e in employees)
        //    {
        //        Console.WriteLine("Name = " + e.FirstName + " Last Name = " + e.LastName);
        //    }
        //}

        //private static void IlkBas(NorthwindContext db)
        //{
        //    var products = db.Products.Select(p => new ProductModel
        //    {
        //        Id = p.ProductId,
        //        Name = p.ProductName,
        //        Price = p.UnitPrice

        //    }).Where(p => p.Price > 18);

        //    var products = db.Products.Where(p => p.CategoryId >= 1 && p.CategoryId <= 5).Select(p => p.ProductName
        //    );

        //    var products = db.Products.Where(p => p.ProductName == "Chai").Select(p => p.ProductName).ToList();
        //    var products = db.Products.Where(p => p.ProductName.Contains("Ch")).Select(p => p.ProductName).ToList();
        //}

        //private static void HesaplamaSorgulari(NorthwindContext db)
        //{
        //    // HESAPLAMA SORGULARI

        //    var results = db.Products.Count(p => p.UnitPrice > 10 && p.UnitPrice < 30); //count içi where olur

        //    var results = db.Products.Count(p => !p.Discontinued); //false olanları (yani satışta olanları getirir)

        //    var results = db.Products.Min(p => p.UnitPrice);

        //    Console.WriteLine(results);

        //    var results = db.Products.Where(p => !p.Discontinued).Average(p => p.UnitPrice);
        //    Console.WriteLine(results);

        //    var results = db.Products.Where(p => !p.Discontinued).Sum(p => p.UnitPrice);
        //    Console.WriteLine(results);
        //}

        //private static void VeriGuncelleme(NorthwindContext db)
        //{
        //    //VERİ GÜNCELLEME

        //    var products = db.Products.FirstOrDefault(p => p.ProductId == 1);

        //    if (products != null)
        //    {

        //        products.UnitsInStock += 10;
        //        db.SaveChanges();
        //        Console.WriteLine("Veri Güncellendi!");

        //    }
        //}

        //private static void VeriEkleme(NorthwindContext db)
        //{
        //    //VERİ EKLEME

        //    var p1 = new Product() { ProductName = "Yeni ürün 5", CategoryId = 2 };
        //    var p2 = new Product() { ProductName = "Yeni ürün 6", CategoryId = 2 };

        //    var products = new List<Product>() { p1, p2 };
        //    db.Products.AddRange(products);

        //    db.SaveChanges();
        //    Console.WriteLine("Yeni ürünler eklendi! ");
        //    Console.WriteLine(p1.ProductId + " " + p2.ProductId);




        //    //VERİ EKLEME (SELECT OLMADAN)


        //    var p = new Product() { ProductId = 1 };

        //    db.Products.Attach(p);

        //    p.UnitsInStock = 50;

        //    db.SaveChanges();

        //    Console.WriteLine("Veri Güncellendi!");


        //    //FIND İLE 

        //    //var products = db.Products.Find(1);

        //    //if (products != null)
        //    //{
        //    //    products.UnitPrice = 48;
        //    //    db.Update(products);
        //    //    db.SaveChanges();
        //    //    Console.WriteLine(" Veri fiyatı " + +products.UnitPrice + " ile güncellendi!");
        //    //}
        //}
    }
}
