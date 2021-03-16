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
  public class PizzaSingleton
  {
    private static PizzaSingleton _pizzaSingleton;
    public List<APizza> Pizzas { get; set; } // print job
    private readonly string _path = @"pizza.xml";
    public static PizzaSingleton Instance
    {
      get
      {
        if (_pizzaSingleton == null)
        {
          _pizzaSingleton = new PizzaSingleton(); // printer
        }

        return _pizzaSingleton;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton()  //reading from xml
    {
      var fs = new FileStorage();

      if (Pizzas == null)
      {
        Pizzas = fs.ReadFromXml<APizza>(_path).ToList();
      }
    }

    public void Seeding()  //writing to xml
    {
      var pizzas = new List<APizza>
            {
                new CustomPizza(),
                new PepperoniPizza(),
                new CheesePizza(),
                new VeggiePizza()
            };

            var fs = new FileStorage();

            fs.WriteToXml<APizza>(pizzas, _path);

            Pizzas = fs.ReadFromXml<APizza>(_path).ToList();


    }

  }
}
