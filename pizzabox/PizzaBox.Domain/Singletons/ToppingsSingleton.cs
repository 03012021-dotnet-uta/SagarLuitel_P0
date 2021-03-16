using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Domain.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class ToppingSingleton
  {
    private static ToppingSingleton _toppingSingleton;
    public List<Topping> topping { get; set; } // print job
    private readonly string _path = @"topping.xml";
    public static ToppingSingleton Instance
    {
      get
      {
        if (_toppingSingleton == null)
        {
          _toppingSingleton = new ToppingSingleton(); // printer
        }

        return _toppingSingleton;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private ToppingSingleton()  //reading from xml
    {
    //   var fs = new FileStorage();

    //   if (topping == null)
    //   {
    //     topping = fs.ReadFromXml<Topping>(_path).ToList();
    //   }
    }

    public void Seeding()  //writing to xml
    {
      var toppings = new List<Topping>
            {
                new Topping{
                    Name = "Onion",
                    Price = 0.020
                },
                new Topping{
                    Name = "Green Peppers",
                    Price = 0.20
                },
                new Topping{
                    Name = "Mushrooms",
                    Price = 0.30
                },
                new Topping{
                    Name = "Extra Cheese",
                    Price = 0.50
                },
                new Topping{
                    Name = "Black Olives",
                    Price = 0.5
                },
                new Topping{
                    Name = "Pepperoni",
                    Price = 1.00
                },
                new Topping{
                    Name = "Sausage",
                    Price = 1.00
                },
                new Topping{
                    Name = "Bacon",
                    Price = 1.00
                }
            };

            var fs = new FileStorage();

            fs.WriteToXml<Topping>(toppings, _path);

            topping = fs.ReadFromXml<Topping>(_path).ToList();

    }

  }
}
