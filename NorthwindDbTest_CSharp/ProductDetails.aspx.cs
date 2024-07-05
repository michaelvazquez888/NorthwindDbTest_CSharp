using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace NorthwindDbTest_CSharp
{
    public partial class ProductDetails : Page
    {
        public string OrdersTitle = "Orders";
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<Order> Orders { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ProductId"]))
                {
                    ProductId = Convert.ToInt32(Request.QueryString["ProductId"]);
                }

                LoadProductDetails(ProductId);
            }
        }

        private void LoadProductDetails(int productId)
        {
            if (productId < 1)
            {
                return;
            }

            using (ProductsRepository productRepo = new ProductsRepository())
            using (SuppliersRepository suppliersRepo = new SuppliersRepository())
            using (CategoriesRepository categoriesRepo = new CategoriesRepository())
            {
                ProductViewModelService productViewModelService = new ProductViewModelService();
                var product = productRepo.GetById(productId);

                if (product != null)
                {
                    if (product.SupplierId > 0)
                    {
                        product.Supplier = suppliersRepo.GetById(product.SupplierId);
                    }

                    if (product.CategoryId > 0)
                    {
                        product.Category = categoriesRepo.GetById(product.CategoryId);
                    }

                    Product = product;
                }
            }

            using (OrdersRepository ordersRepo = new OrdersRepository())
            {
                Orders = ordersRepo.GetAll()
                .Where(o => o.Details.Any(od => od.ProductId == productId))
                .Select(o => new Order
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    Customer = o.Customer,
                    EmployeeId = o.EmployeeId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    ShipVia = o.ShipVia,
                    Freight = o.Freight,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    Details = o.Details
                        .Where(od => od.ProductId == productId)
                        .ToList()
                }).ToList();
            }
        }
    }
}