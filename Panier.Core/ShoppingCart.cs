using System;
using System.Collections.Generic;
using System.Text;

namespace Panier.Core
{
    public sealed class ShoppingCart
    {
        // Collection interne initialisée
        // Champs privés (en haut de la classe)
        private readonly List<CartItem> items = new();
        private bool _discountApplied = false;
        private decimal _discountPercentage = 0m;

        // Méthodes ensuite
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

            if (_discountApplied)
            {
                subtotal = subtotal * (1 - (_discountPercentage / 100m));
            }

            return subtotal;
        }

        public void ApplyDiscount(decimal percentage) //=> throw new NotImplementedException();
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Cannot apply discount to an empty cart.");

            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Discount must be between 0 and 100.");

            if (_discountApplied)
                throw new InvalidOperationException("Discount can only be applied once.");

            _discountApplied = true;
            _discountPercentage = percentage;
        }
    }
}
