﻿
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMomery
{



    public class InMemoryProductDal : IProductDal


    {
        List<Product> _products;
        public InMemoryProductDal()
        {   // veritabanlarından geliyor gibi
            _products = new List<Product> {
                
            new Product{ProductId=1, CategoryId = 1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
            new Product{ProductId=2, CategoryId = 1, ProductName="Kemara", UnitPrice=500, UnitsInStock=3},
            new Product{ProductId=3, CategoryId = 2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
            new Product{ProductId=4, CategoryId = 2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
            new Product{ProductId=5, CategoryId = 2, ProductName="Fare", UnitPrice=852, UnitsInStock=1}
       
        };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Lambda

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);



            _products.Remove(productToDelete);
        }

        public List<Product> GetALL()
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim Ürün id'sine sahip listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
