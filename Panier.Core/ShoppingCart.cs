using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        // Collection interne initialisée
        private readonly List<CartItem> items = new();

        public int GetItemCount() //=> throw new NotImplementedException();
        { 
            return items.Count; 
        }

        public void AddItem(string name, decimal price, int quantity) //=> throw new NotImplementedException();
        {
            // ✅ Validation AVANT ajout
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Item name is required.", nameof(name));
             
            if (price <= 0) throw new ArgumentOutOfRangeException(nameof(price));

            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            // (Les validations price/quantity viendront dans les étapes suivantes)
            var item = new CartItem(name, price, quantity);
            items.Add(item);
        }

        public decimal GetTotal() //=> throw new NotImplementedException();
        {
            decimal subtotal = 0m;

            foreach (var item in items)
            {
                subtotal += item.Price * item.Quantity;
            }

            return subtotal;
        }

        public void ApplyDiscount(decimal percentage) => throw new NotImplementedException();
    }
}
