using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// 
  /// </summary>
  public class CheesePizza : APizza
  {
    protected override void AddCrust()
    {
      Crust = new Crust();
    }

    protected override void AddSize()
    {
      Size = new Size();
    }

    protected override void AddToppings()
    {
      Toppings = new List<Topping>
      {
          
      };
    }

            public CheesePizza()
        {
            Name = "Cheese Pizza";
        }
  }
}
