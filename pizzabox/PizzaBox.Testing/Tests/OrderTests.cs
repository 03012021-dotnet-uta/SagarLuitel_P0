using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;

using Xunit;
using System.Collections.Generic;

namespace PizzaBox.Testing.Tests
{
  public class OrderTests
  {

    [Fact]
    public void Test_pizzaOrder_Fact()
    {
        
      List<APizza> Pizza = new List<APizza>{
          new CustomPizza() 
      };

      var myOrder = new Order(Pizza);
      // arrange
      
      var expected = 1;

      // act
      var actual = myOrder.Pizzas.Count;

      // assert
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_OrderEmail_Fact()
    {
        
      List<APizza> Pizza = new List<APizza>{
          new CustomPizza() 
      };

      var myOrder = new Order(Pizza);
      // arrange
      var customer = new Customer();
      customer.Email = "example@gmial.com";

      myOrder.customerEmail = customer.Email;

      var expected =  "example@gmial.com";

      // act
      var actual = myOrder.customerEmail;

      // assert
      Assert.Equal(expected, actual);
    }
  }
}