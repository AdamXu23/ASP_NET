using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCore_CodeFirstExistingDB.Models;
using EFCore_CodeFirstExistingDB.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_CodeFirstExistingDB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context, ILogger<ProductsController> logger)
        {
            _context = context;

            //讀取DbContext使用的資料庫連線
            string conn = _context.Database.GetDbConnection().ConnectionString;

            _logger = logger;
        }


        //查詢所有資料
        public async Task<IActionResult> QueryAllData()
        {
            //非同步
            List<Products> products = await _context.Products.ToListAsync();
            var employees = await _context.Employees.ToListAsync();

            //同步
            List<Orders> orders = _context.Orders.ToList();
            var orderDetails = _context.OrderDetails.ToList();

            return Ok("Finished.");
        }


        //查詢單一筆Entity資料
        public async Task<IActionResult> QuerySingleData(int Id = 1)
        {
            //非同步
            var p1 = await _context.Products.FindAsync(Id);
            var p2 = await _context.Products.FirstAsync();
            var p3 = await _context.Products.FirstOrDefaultAsync();
            var p4 = await _context.Products.SingleAsync(p => p.ProductId == 1);
            var p5 = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == 1);

            //同步
            var p6 = _context.Products.Find(Id);
            var p7 = _context.Products.First();
            var p8 = _context.Products.FirstOrDefault();
            var p9 = _context.Products.Single(p => p.ProductId == 1);
            var p10 = _context.Products.SingleOrDefault(p => p.ProductId == 1);

            return Ok("Finished.");
        }

        //First(), FirstOrDefault(), Single(), SingleOrDefault()方法
        //在面對各種不同Source, Sequence和查詢結果時之差異
        public IActionResult FirstSingle()
        {
            string[] source1 = null; //source is null
            var s1 = source1.First(null); //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s2 = source1.FirstOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s3 = source1.Single(null);  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s4 = source1.SingleOrDefault(null); //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s5 = source1.First();   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s6 = source1.FirstOrDefault();  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s7 = source1.Single();  //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s8 = source1.SingleOrDefault(); //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s9 = source1.First(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s10 = source1.FirstOrDefault(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s11 = source1.Single(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')
            var s12 = source1.SingleOrDefault(s => s.Contains("t"));   //ArgumentNullException: Value cannot be null. (Parameter 'source')

            string[] source2 = { }; //source is {string[0]}
            var s21 = source2.First(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s22 = source2.FirstOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s23 = source2.Single(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s24 = source2.SingleOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s25 = source2.First();   //InvalidOperationException: Sequence contains no elements
            var s26 = source2.FirstOrDefault();  //null
            var s27 = source2.Single(); //InvalidOperationException: Sequence contains no elements
            var s28 = source2.SingleOrDefault();  //null
            var s29 = source2.First(s => s.Contains("t"));  //InvalidOperationException: Sequence contains no matching element
            var s30 = source2.FirstOrDefault(s => s.Contains("t"));  //null
            var s31 = source2.Single(s => s.Contains("t"));  //InvalidOperationException: Sequence contains no matching element
            var s32 = source2.SingleOrDefault(s => s.Contains("t"));  //null

            string[] source3 = { "Apple", "Orange", "Banana" }; //source is {string[3]}
            var s41 = source3.First(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s42 = source3.FirstOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s43 = source3.Single(null); //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s44 = source3.SingleOrDefault(null);  //ArgumentNullException: Value cannot be null. (Parameter 'predicate')
            var s45 = source3.First();   //Apple
            var s46 = source3.FirstOrDefault();  //Apple
            var s47 = source3.Single();   //InvalidOperationException: Sequence contains more than one element
            var s48 = source3.SingleOrDefault();  //InvalidOperationException: Sequence contains more than one element
            var s49 = source3.First(s => s.Contains("t"));  //InvalidOperationException: Sequence ,ontains no matching element
            var s50 = source3.FirstOrDefault(s => s.Contains("t"));  //null
            var s51 = source3.Single(s => s.Contains("t"));  //InvalidOperationException: Sequence contains no matching element
            var s52 = source3.SingleOrDefault(s => s.Contains("t"));  //null
            var s53 = source3.Single(s => s.Contains("a"));  //InvalidOperationException: Sequence contains more than one matching element
            var s54 = source3.SingleOrDefault(s => s.Contains("a"));  //InvalidOperationException: Sequence contains more than one matching element
            var s55 = source3.First(s => s.Contains("Ora"));  //Orange
            var s56 = source3.FirstOrDefault(s => s.Contains("Ora"));  //Orange
            var s57 = source3.Single(s => s.Contains("Ora"));  //Orange
            var s58 = source3.SingleOrDefault(s => s.Contains("Ora"));  //Orange

            return Ok("Finished.");
        }

        //以條件式過濾資料
        public async Task<IActionResult> FilteringData()
        {
            //非同步
            //Query Syntax查詢語法
            var p1 = await (from p in _context.Products
                            where p.UnitPrice >= 10 && p.UnitPrice <= 15
                            orderby p.ProductName, p.UnitPrice
                            select p)
                            .ToListAsync();

            //Method Syntax方法語法
            var p2 = await _context.Products
                            .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 15)
                            .OrderBy(p => p.ProductName).ThenBy(p => p.UnitPrice)
                            .ToListAsync();

            //同步
            var p3 = (from p in _context.Products
                      where p.UnitPrice >= 10 && p.UnitPrice <= 15
                      orderby p.ProductName descending, p.UnitPrice ascending
                      select p)
                      .ToList();

            var p4 = (_context.Products
                      .AsEnumerable()
                      .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 15))
                      .OrderByDescending(p => p.ProductName).ThenByDescending(p => p.UnitPrice)
                      .ToList();

            var p5 = (_context.Products
                      .AsQueryable()
                      .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 15))
                      .OrderByDescending(p => p.ProductName).ThenByDescending(p => p.UnitPrice)
                      .ToList();

            return Ok("Finished.");
        }

        //多個資料來源的Inner Join查詢
        public async Task<IActionResult> TablesJoin()
        {
            //兩個資料來源
            var innerJoin1 = from cate in _context.Categories
                             join prod in _context.Products on cate.CategoryId equals prod.CategoryId
                             select new { Name = prod.ProductName, Category = cate.CategoryName };

            //兩個資料來源
            var innerJoin2 = from cate in _context.Set<Categories>()
                             join prod in _context.Set<Products>() on cate.CategoryId equals prod.CategoryId
                             select new { Name = prod.ProductName, Category = cate.CategoryId };

            //四個資料來源
            var innerJoin3 = from customer in _context.Customers.TagWith("Multi Tables inner join")
                             join order in _context.Orders on customer.CustomerId equals order.CustomerId
                             join details in _context.OrderDetails on order.OrderId equals details.OrderId
                             join prod in _context.Products on details.ProductId equals prod.ProductId
                             select new { order.OrderId, customer.CompanyName, customer.ContactName, details.ProductId, prod.ProductName, details.UnitPrice, details.Quantity };

            var result = await innerJoin3.ToListAsync();

            return Ok("Finished.");
        }

        public async Task<IActionResult> SkipTake()
        {
            var products = from p in _context.Products
                           where p.UnitPrice >= 10 && p.UnitPrice <= 15
                           orderby p.ProductName descending, p.UnitPrice ascending
                           select p;

            //Skip(5)跳過前5筆, 然後Take(10)取10筆
            var query = await products.Skip(5).Take(10).ToListAsync();

            return Ok("Finished.");
        }

        //IQuerable<T> vs. IEnumerable<T> vs. ToList()
        public IActionResult QueryType()
        {
            DbSet<Products> pd1 = _context.Products;
            var pd2 = _context.Set<Products>();

            //1.Lazy Loading延後執行,盡可能將Expression轉換成完整伺服端SQL語法, 僅回傳必要結果到記憶體
            IQueryable<Products> products = _context.Products.TagWith("IQueryable")
                .Where(p => p.UnitPrice > 10);

            foreach (var item in products)
            {
                var i = item;
            }

            //2.Lazy Loading延後執行, 將資料全部載入記憶體後,再執行後續的操作
            IEnumerable<Products> prods = _context.Products.TagWith("IEnumerable")
                .AsEnumerable()
                .Where(p => p.UnitPrice > 10);


            foreach (var item in prods)
            {
                var i = item;
            }

            //3.立即執行，在記憶體中建立List<T>集合物件
            List<Products> prodList = _context.Products.TagWith("ToList()")
                .Where(p => p.UnitPrice > 10)
                .ToList();

            return Ok("Finished.");
        }

        //使用原生SQL查詢
        public async Task<IActionResult> RawSqlQuery()
        {
            //1.使用FromSqlRaw()送出原生SQL查詣字串
            var productsSql = await _context.Products
                            .FromSqlRaw("Select * from dbo.Products")
                            .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, UnitsOnOrder = p.UnitsOnOrder })
                            .AsNoTracking()
                            .ToListAsync();

            //2.呼叫GetTopSales預存程序
            var productsSP = _context.Products
                                .FromSqlRaw("EXECUTE dbo.GetTopSales")
                                .ToList();

            //3.呼叫GetTopSalesForCategory預存程序, 並傳入參數
            int categoryId = 1;
            var prodsPamam1 = _context.Products
                                .FromSqlRaw("EXECUTE dbo.GetTopSalesForCategory {0}", categoryId)
                                .ToList();

            //4.FromSqlInterpolated插入字串
            var prodsPamam2 = _context.Products
                                .FromSqlInterpolated($"EXECUTE dbo.GetTopSalesForCategory {categoryId}")
                                .ToList();

            return Ok("Finished.");
        }

        public async Task<IActionResult> Index()
        {
            //LINQ to Entity
            var products = await (from p in _context.Products
                                  select new ProductViewModel
                                  {
                                      Id = p.ProductId,
                                      Name = p.ProductName,
                                      UnitPrice = p.UnitPrice,
                                      UnitsInStock = p.UnitsInStock,
                                      UnitsOnOrder = p.UnitsOnOrder
                                  }).AsNoTracking()
                                  .ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //查詢包含所有欄位
            var product = await _context.Products
                                .FirstOrDefaultAsync(p => p.ProductId == id);

            //查詢只包含指定欄位
            ProductViewModel prod = await _context.Products
                    .Where(p => p.ProductId == id)
                    .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, UnitsOnOrder = p.UnitsOnOrder })
                    .SingleOrDefaultAsync();


            //送出原生SQL查詢,只包含指定欄位
            ProductViewModel pd = await _context.Products
                    .FromSqlInterpolated($"Select ProductID, ProductName,UnitPrice,UnitsInStock,UnitsOnOrder from dbo.Products where ProductID={id}")
                    .Select(p => new ProductViewModel { Id = p.ProductId, Name = p.ProductName, UnitPrice = p.UnitPrice, UnitsInStock = p.UnitsInStock, UnitsOnOrder = p.UnitsOnOrder })
                    .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return View(prod);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");

            return View();
        }


        //
        public async Task<IActionResult> DatabaseTransaction()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Products.Add(new Products { ProductName = "Cola", UnitPrice = 1, UnitsInStock = 15, UnitsOnOrder = 200 });
                    await _context.SaveChangesAsync();

                    Products wine = new Products { ProductName = "Wine", UnitPrice = 20, UnitsInStock = 10, UnitsOnOrder = 50 };
                    _context.Products.Add(wine);
                    await _context.SaveChangesAsync();

                    Products sugar = new Products { ProductName = "Sugar", UnitPrice = 2, UnitsInStock = 50, UnitsOnOrder = 250 };
                    _context.Products.Add(sugar);
                    await _context.SaveChangesAsync();

                    _context.Remove(wine);
                    await _context.SaveChangesAsync();

                    var identityCurrent = await _context.Products.FromSqlRaw("select *  from dbo.Products  where ProductId = IDENT_CURRENT('Products')").FirstOrDefaultAsync();

                    transaction.Commit();
                    _logger.LogWarning("Transaction交易成功!");

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogWarning(ex.ToString());
                }
            }


            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products product)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Products.Add(product);
                        await _context.SaveChangesAsync();

                        //_context.Products.Add(new Products { ProductName = "Wine", UnitPrice = 20, UnitsInStock = 10, UnitsOnOrder = 50 });
                        //await _context.SaveChangesAsync();

                        //可利用SingleOrDefault方法刻意製造Exception
                        //await _context.Products.SingleOrDefaultAsync();

                        transaction.Commit();

                        _logger.LogWarning("Transaction交易成功!");

                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogWarning(ex.ToString());

                        ModelState.AddModelError("TractionError", ex.ToString());
                    }
                }
            }

            return View(product);
        }

        // GET: ProductsCRUD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

        // POST: ProductsCRUD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products)
        {
            if (id != products.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Update(products);
                        await _context.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        transaction.Rollback();

                        if (!ProductsExists(products.ProductId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
 
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", products.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", products.SupplierId);
            return View(products);
        }

        // GET: ProductsCRUD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: ProductsCRUD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Products.Remove(products);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }

    }
}