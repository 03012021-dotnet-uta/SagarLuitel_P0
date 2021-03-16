using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PepperoniPizza : APizza
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
            Toppings = new List<Topping>();
            var top = new Topping{
                Name = "Pepperoni",
                Price = 1.00
            };
            Toppings.Add(top);
        }

        public PepperoniPizza()
        {
            Name = "Pepperoni Pizza";
        }
    }
}
