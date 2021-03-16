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
  public class OrderSingleton
  {
    private static OrderSingleton _orderSingleton;
        private readonly string _path = @"order.xml";
    public static OrderSingleton Instance
    {
      get
      {
        if (_orderSingleton == null)
        {
          _orderSingleton = new OrderSingleton(); // printer
        }

        return _orderSingleton;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private OrderSingleton()  //reading from xml
    {
        
    }

    public Order readOrderList(){
        System.Xml.Serialization.XmlSerializer reader =
        new System.Xml.Serialization.XmlSerializer(typeof(Order));  
        System.IO.StreamReader file = new System.IO.StreamReader( _path);  
        Order overview =  (Order)reader.Deserialize(file);  
        file.Close();

        return overview; 
    }
    public void Seeding(Order order)  //writing to xml
    {

        System.Xml.Serialization.XmlSerializer writer =
            new System.Xml.Serialization.XmlSerializer(typeof(Order));  
  
         
        System.IO.FileStream file = System.IO.File.Create(_path);  

        System.Console.WriteLine(_orderSingleton);
  
        writer.Serialize(file, order);  
        file.Close(); 
    }

  }
}
