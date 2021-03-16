using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class VeggiePizza : APizza
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
            Toppings = new List<Topping>{
              new Topping{
                  Name = "Onion",
                  Price = 0.20
              },
              new Topping{
                  Name = "Green peppers",
                  Price = 0.20
              },
              new Topping{
                  Name = "Black Olives",
                  Price = 0.20
              },
              new Topping{
                  Name = "Mushrooms",
                  Price = 0.20
              }
           };
        }

        public VeggiePizza()
        {
            Name = "Veggie Pizza";
        }
    }
}
