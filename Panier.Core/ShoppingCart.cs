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

            // (Les validations price/quantity viendront dans les étapes suivantes)
            var item = new CartItem(name, price, quantity);
            items.Add(item);
        }

        public decimal GetTotal() => throw new NotImplementedException();
        public void ApplyDiscount(decimal percentage) => throw new NotImplementedException();
    }
}
