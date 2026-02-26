using Panier.Core;

namespace Panier.Tests;

[TestClass]
public class ShoppingCartTests
{
    [TestMethod]
    public void NewCart_ItemCount_IsZero()
    {
        // Arrange
        var cart = new ShoppingCart();

        // Act
        var count = cart.GetItemCount();

        // Assert
        Assert.AreEqual(0, count);
    }

    [TestMethod]
    public void NewCart_Total_IsZero()
    {
        var cart = new ShoppingCart();

        var total = cart.GetTotal();

        Assert.AreEqual(0m, total);
    }

    [TestMethod]
    public void ApplyDiscount_OnEmptyCart_Throws()
    {
        var cart = new ShoppingCart();

        Assert.ThrowsExactly<InvalidOperationException>(() => cart.ApplyDiscount(10m));
    }

    [TestMethod]
    public void AddItem_Valid_IncreasesItemCount()
    {
        var cart = new ShoppingCart();

        cart.AddItem("Pomme", 1.5m, 2);

        Assert.AreEqual(1, cart.GetItemCount());
    }

    [TestMethod]
    public void AddItem_InvalidName_Throws()
    {
        var cart = new ShoppingCart();

        Assert.ThrowsExactly<ArgumentException>(() => cart.AddItem("   ", 1m, 1));
    }

    [TestMethod]
    public void AddItem_PriceLessOrEqualZero_Throws()
    {
        var cart = new ShoppingCart();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => cart.AddItem("Pomme", 0m, 1));
    }

    [TestMethod]
    public void AddItem_QuantityLessOrEqualZero_Throws()
    {
        var cart = new ShoppingCart();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => cart.AddItem("Pomme", 1m, 0));
    }

    [TestMethod]
    public void GetTotal_OneItem_IsPriceTimesQuantity()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Pomme", 2m, 3);

        Assert.AreEqual(6m, cart.GetTotal());
    }

    [TestMethod]
    public void GetTotal_MultipleItems_IsSumCorrect()
    {
        var cart = new ShoppingCart();
        cart.AddItem("Pomme", 2m, 3);   // 6
        cart.AddItem("Lait", 1.5m, 2);  // 3

        Assert.AreEqual(9m, cart.GetTotal());
    }

    [TestMethod]
    public void ApplyDiscount_10Percent_ReducesTotal()
    {
        var cart = new ShoppingCart();
        cart.AddItem("A", 10m, 1);

        cart.ApplyDiscount(10m);

        Assert.AreEqual(9m, cart.GetTotal());
    }

    [TestMethod]
    public void ApplyDiscount_0Percent_NoChange()
    {
        var cart = new ShoppingCart();
        cart.AddItem("A", 10m, 1);

        cart.ApplyDiscount(0m);

        Assert.AreEqual(10m, cart.GetTotal());
    }

    [TestMethod]
    public void ApplyDiscount_100Percent_TotalZero()
    {
        var cart = new ShoppingCart();
        cart.AddItem("A", 10m, 1);

        cart.ApplyDiscount(100m);

        Assert.AreEqual(0m, cart.GetTotal());
    }
}
