Using EmployeeDataAccess;
Using System;
Using System.Collections.Generic;
Using System.Linq;
Using System.Net;
Using System.Web.Http;

Namespace ProductsApp.Controllers
{
    Public Class EmployeeController :  ApiController
    {
        Product[] products = New Product[] 
        { 
            New Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            New Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            New Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        Public IEnumerable<Product> GetAllProducts()
        {
            Return products;
        }

        Public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) >= p.Id == id);
            If (product == null)
            {
                Return NotFound();
            }
            Return Ok(product);
        }
    }
}