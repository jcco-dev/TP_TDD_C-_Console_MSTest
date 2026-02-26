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

   

}
