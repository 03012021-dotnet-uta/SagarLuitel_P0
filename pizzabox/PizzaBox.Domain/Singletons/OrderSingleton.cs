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

    public List<Order> myOrders {get; set;}
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
      var fs = new FileStorage();
      
      if(myOrders == null){
        myOrders = fs.ReadFromXml<Order>(_path).ToList();
      }
        
    }

    // public Order readOrderList(){
    //     System.Xml.Serialization.XmlSerializer reader =
    //     new System.Xml.Serialization.XmlSerializer(typeof(Order));  
    //     System.IO.StreamReader file = new System.IO.StreamReader( _path);  
    //     Order overview =  (Order)reader.Deserialize(file);  
    //     file.Close();

    //     return overview; 
    // }
    public void Seeding(Order order)  //writing to xml
    {
        var orders = new List<Order>();
        foreach(var ord in myOrders){
          orders.Add(ord);
        }
        orders.Add(order);

        var fs = new FileStorage();
        fs.WriteToXml<Order>(orders, _path);
        myOrders = fs.ReadFromXml<Order>(_path).ToList();
    }

  }
}
