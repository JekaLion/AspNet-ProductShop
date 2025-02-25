﻿using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class OrderBasketRepository : IBasketRepository<OrderBasket>
    {
        private readonly ProductContext db = new ProductContext();

        public bool AddToBasket(int basketId, int productId)
        {
            if (db.OrderBaskets.FirstOrDefault(b => b.Id == basketId) != null && db.Products.FirstOrDefault(p => p.Id == productId) != null)
            {
                db.OrderBasketItems.Add(new OrderBasketItem { OrderBasketId = basketId, ProductId = productId });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveFromBasket(int basketId, int productId)
        {
            if (db.OrderBaskets.FirstOrDefault(b => b.Id == basketId) != null && db.Products.FirstOrDefault(p => p.Id == productId) != null)
            {
                OrderBasketItem basketItem = db.OrderBasketItems.FirstOrDefault(bi => bi.OrderBasketId == basketId && bi.ProductId == productId);
                if (basketItem != null)
                {
                    db.OrderBasketItems.Remove(basketItem);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Dictionary<int, int> GetAllItems(int basketId)
        {
            throw new NotImplementedException();
        }
    }
}