using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>

        List<APizza> pizzas = PizzaSingleton.Instance.Pizzas;

        List<APizza> myOrder = new List<APizza>();
        static void Main(string[] args)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("******************************************************************************");
            System.Console.WriteLine("     - - - - - - - - - - - -  WELCOME TO PizzaBox  - - - - - - - - - - - ");
            System.Console.WriteLine("******************************************************************************");
            Console.WriteLine();


            Console.WriteLine("IF YOUR ARE OUR CUSTOMER PLEASE ENTER 1");
            Console.WriteLine("IF YOUR ARE ONE OF OUR STORE MANAGERS ENTER 2");
            Console.WriteLine("TO EXIT THE APPLICATION ENTER 0");

            var userIn = Console.ReadLine();

            if (userIn == "1")
            {
                AsACustomer();
            }
            if (userIn == "2")
            {
                //store manage
            }

        }

        /// <summary>
        /// 
        /// </summary>

        public static void AsACustomer()
        {
            Program p = new Program();

            // var ss = StoreSingleton.Instance;

            // ss.Seeding();

            // // print all the stores available, must be from file or db
            // foreach (var item in ss.Stores)
            // {
            //   System.Console.WriteLine(item);
            // }
            System.Console.WriteLine();
            System.Console.WriteLine("Select your Store ");

            int n = 0;

            foreach (var store in StoreSingleton.Instance.Stores)
            {
                Console.WriteLine(++n + ": " + store);
            }

            // select a store
            int input = Convert.ToInt32(Console.ReadLine());

            int input2 = 3;
            do
            {
                // print the customer menu
                System.Console.WriteLine();
                System.Console.WriteLine("1. Place Order");
                System.Console.WriteLine("2. View Your Cart");
                System.Console.WriteLine("3. Chechout");
                System.Console.WriteLine("4. View Your History");
                System.Console.WriteLine("5. Exit");

                // select a menu option
                input2 = Convert.ToInt32(Console.ReadLine());

                switch (input2)
                {
                    case 1:
                        p.placeOrder();
                        break;
                    case 2:
                        p.orderlist();
                        break;
                    case 3:
                        p.checkOut(StoreSingleton.Instance.Stores[input].Name); //to chechout 
                        break;
                    case 4:
                        p.orderHistory();
                        break;
                }

            } while (input2 == 5);
        }

        public void placeOrder()
        {
            //  var pizzaS = PizzaSingleton.Instance;
            //  pizzaS.Seeding();
            int i = 0;
            foreach (var pizza in pizzas)
            {
                Console.WriteLine(++i + ": " + pizza);
            }

            // select a type of pizza
            var input3 = Console.ReadLine();
            switch (input3)
            {
                case "1":
                    customPizza();
                    break;
                case "2":
                    preSetPizza(pizzas[Convert.ToInt32(input3) - 1]);
                    break;
                case "3":
                    preSetPizza(pizzas[Convert.ToInt32(input3) - 1]);
                    break;
                case "4":
                    preSetPizza(pizzas[Convert.ToInt32(input3) - 1]);
                    break;
            }

        }
        void customPizza()
        {
            var cPizza = new CustomPizza();

            Options(cPizza);

            //string[] toppings = new string[] {"Onion", "Green Peppers", "Mushrooms" };
            var toppings = new Dictionary<string, double>{ {"Onion", 0.20}, {"Green Peppers", 0.20}, {"Mushrooms", 0.20}, {"Extra Cheese", 0.50},
                                                       {"Black olives", 0.50}, {"Pepperoni", 1.00}, {"Sausage", 1.00}, {"Bacon", 1.00}};
            int t;
            int i = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose a Topping: ");
                Console.WriteLine();
                Console.WriteLine("1: Onion --------------- $ 0.20 ");
                Console.WriteLine("2: Green peppers ------- $ 0.20 ");
                Console.WriteLine("3: Mushrooms ----------- $ 0.20 ");
                Console.WriteLine("4: Extra Cheese -------- $ 0.50 ");
                Console.WriteLine("5: Black olives -------- $ 0.50 ");
                Console.WriteLine("6: Pepperoni ----------- $ 1.00 ");
                Console.WriteLine("7: Sausage ------------- $ 1.00 ");
                Console.WriteLine("8: Bacon --------------- $ 1.00 ");
                Console.WriteLine();
                Console.WriteLine("0: Done Adding Toppings");

                t = Convert.ToInt32(Console.ReadLine());

                if (t != 0)
                {
                    cPizza.Toppings[i].Name = toppings.ElementAt(t - 1).Key;
                    cPizza.Toppings[i].Price = toppings.ElementAt(t - 1).Value;
                }
                i++;
            } while (t != 0);

            myOrder.Add(cPizza);
        }

        // Pre set pizzas if customer wanna order already made pizzas 
        void preSetPizza(APizza pizza)
        {
            Console.WriteLine(pizza.Name);
            Options(pizza);
            myOrder.Add(pizza);
        }

        void checkOut(string StoreName)
        {
            Customer customer = new Customer();
            Order order = new Order(myOrder);
            var total = order.calcTotal();

            Console.WriteLine();
            Console.WriteLine("List of Pizza that you ordered: ");
            foreach (var p in myOrder)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Your Total:  $" + total);

            Console.WriteLine();
            Console.WriteLine("Please Enter your Name: ");
            customer.Name = Console.ReadLine();

            Console.WriteLine("Please Enter your Email: ");
            customer.Email = Console.ReadLine();

            order.StoreName = StoreName;
            order.customerEmail = customer.Email;

            var os = OrderSingleton.Instance;

            os.Seeding(order);

            //Console.WriteLine("Please Enter your Card Number: ");
        }


        void Options(APizza cPizza)
        {
            System.Console.WriteLine();
            Console.WriteLine("Choose a Crust: ");
            Console.WriteLine("1: Thick ------- $ 0.5 ");
            Console.WriteLine("2: Thin  ------- $ 0.3 ");
            int c = Convert.ToInt32(Console.ReadLine());
            switch (c)
            {
                case 1:
                    cPizza.Crust.Name = "Thick";
                    cPizza.Crust.Price = 0.5;
                    break;
                case 2:
                    cPizza.Crust.Name = "Thin";
                    cPizza.Crust.Price = 0.3;
                    break;

                default:
                    cPizza.Crust.Name = "Thick";
                    cPizza.Crust.Price = 0.5;
                    break;
            }

            System.Console.WriteLine();
            Console.WriteLine("Choose a Size: ");
            Console.WriteLine("1: Small -------- $ 7.00 ");
            Console.WriteLine("2: Medium ------- $ 9.99 ");
            Console.WriteLine("3: Large -------- $ 12.95 ");

            int s = Convert.ToInt32(Console.ReadLine());
            switch (s)
            {
                case 1:
                    cPizza.Size.Name = "Small";
                    cPizza.Size.Price = 7.00;
                    break;
                case 2:
                    cPizza.Size.Name = "Medium";
                    cPizza.Size.Price = 9.99;
                    break;

                case 3:
                    cPizza.Size.Name = "Large";
                    cPizza.Size.Price = 12.95;
                    break;

                default:
                    cPizza.Size.Name = "Medium";
                    cPizza.Size.Price = 9.99;
                    break;
            }
        }

        void orderlist(){
            Order order = new Order(myOrder);
            var total = order.calcTotal();
            Console.WriteLine();
            Console.WriteLine("List of Pizza that you ordered: ");
            foreach (var p in myOrder)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Your Total:  $" + total);
        }
        void orderHistory(){
            Console.WriteLine("Plese Enter your Email ");
            var email = Console.ReadLine();

            var sinOrd = OrderSingleton.Instance;

            var order = sinOrd.readOrderList();

            if(email.Equals(order.customerEmail)){
                Console.WriteLine("Store: " + order.StoreName);
                foreach(var p in order.Pizzas){
                    Console.WriteLine(p.Size.Name+ " " + p.Name + " " + p.Crust.Name + " Crust with");
                    foreach(var t in p.Toppings){
                        Console.Write(t.Name + " ");
                    }
              }
                var mytotal = order.calcTotal();
                Console.WriteLine("Total: $ " + mytotal);
            }
            
        }

    }
}
