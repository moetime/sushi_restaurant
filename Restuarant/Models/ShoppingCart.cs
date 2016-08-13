﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Models;
using System.Web.Mvc;

namespace Restaurant.Models
{
    public class ShoppingCart
    {

        ShoppingCartContext storeDB = new ShoppingCartContext();

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context) {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller) {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(FoodItem foodItem) {
            // Get the matching cart and album instances
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.SessionID == ShoppingCartId
                && c.FoodItemID == foodItem.ID);

            if (cartItem == null) {
                // Create a new cart item if no cart item exists
                cartItem = new Cart {
                    FoodItemID = foodItem.ID,
                    SessionID = ShoppingCartId,
                    NumItems = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.NumItems++;
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id) {
            // Get the cart
            
            var cartItem = storeDB.Carts.Single(
                cart => cart.SessionID == ShoppingCartId
                && cart.FoodItemID == id);

            int itemCount = 0;

            if (cartItem != null) {
                if (cartItem.NumItems > 1) {
                    cartItem.NumItems--;
                    itemCount = cartItem.NumItems;
                }
                else {
                    storeDB.Carts.Remove(cartItem);
                }
                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart() {
            var cartItems = storeDB.Carts.Where(
                cart => cart.SessionID == ShoppingCartId);

            foreach (var cartItem in cartItems) {
                storeDB.Carts.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public List<Cart> GetCartItems() {
            return storeDB.Carts.Where(
                cart => cart.SessionID == ShoppingCartId).ToList();
        }
        public int GetCount() {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in storeDB.Carts
                          where cartItems.SessionID == ShoppingCartId
                          select (int?)cartItems.NumItems).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal() {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in storeDB.Carts
                              where cartItems.SessionID == ShoppingCartId
                              select (int?)cartItems.NumItems *
                              cartItems.FoodItem.Price).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(Order order) {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems) {
                var orderDetail = new OrderDetail {
                    FoodItemID = item.FoodItemID,
                    OrderID = order.OrderID,
                    UnitPrice = item.FoodItem.Price,
                    Quantity = item.NumItems
                };
                // Set the order total of the shopping cart
                orderTotal += (item.NumItems * item.FoodItem.Price);

                storeDB.OrderDetails.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderID;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context) {
            if (context.Session[CartSessionKey] == null) {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name)) {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName) {
            var shoppingCart = storeDB.Carts.Where(
                c => c.SessionID == ShoppingCartId);

            foreach (Cart item in shoppingCart) {
                item.SessionID = userName;
            }
            storeDB.SaveChanges();
        }
    }
}