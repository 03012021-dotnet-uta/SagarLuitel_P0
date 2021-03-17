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

        List<Crust> crusts = CrustSingleton.Instance.Crusts;

        List<Size> sizes = SizeSingleton.Instance.mySize;
        List<Topping> toppings = ToppingSingleton.Instance.topping;

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
                AsStore();
            }

            //For seeding.
            // var size = SizeSingleton.Instance;
            // size.Seeding();

            // var crust = CrustSingleton.Instance;
            // crust.Seeding();

            // var topping = ToppingSingleton.Instance;
            // topping.Seeding();

            //  var pizzaS = PizzaSingleton.Instance;
            //  pizzaS.Seeding();

            // var ss = StoreSingleton.Instance;
            // ss.Seeding();


        }

        /// <summary>
        /// 
        /// </summary>

        public static void AsACustomer()
        {
            Program p = new Program();


            // // print all the stores available, must be from file or db
            // foreach (var item in ss.Stores)
            // {
            //   System.Console.WriteLine(item);
            // }
            int input;
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Select your Store ");

                int n = 0;

                foreach (var store in StoreSingleton.Instance.Stores)
                {
                    Console.WriteLine(++n + ": " + store);
                }

                // select a store
                input = Convert.ToInt32(Console.ReadLine());
                if (input != 1 && input != 2)
                {
                    Console.WriteLine("Please Enter A Valid Option 1");
                }
            } while (input != 1 && input != 2);

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
                        p.checkOut(StoreSingleton.Instance.Stores[input - 1].Name); //to chechout 
                        break;
                    case 4:
                        p.orderHistory();
                        break;
                    case 5:
                        Console.WriteLine("Good Bye! ");
                        break;

                }
               
            } while (input2 != 5);
        }

        public void placeOrder()
        {
            Console.WriteLine();
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
                default:
                    Console.WriteLine("Please Select A Valid Option 3");
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


            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Choose Up To 4 Toppings ");
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
                if (t == 0)
                {
                    break;
                }
                else if (t > 0 && t < 9)
                {
                    cPizza.Toppings[i].Name = toppings.ElementAt(t - 1).Key;
                    cPizza.Toppings[i].Price = toppings.ElementAt(t - 1).Value;
                }
                else
                {
                    Console.WriteLine("Please select a valid option  4");
                    --i;
                }
            }

            myOrder.Add(cPizza);
        }

        // Pre set pizzas if customer wanna order already made pizzas 
        void preSetPizza(APizza pizza)
        {
            Options(pizza);
            myOrder.Add(pizza);
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
                    cPizza.Crust.Name = crusts[0].Name;
                    cPizza.Crust.Price = crusts[0].Price;
                    break;
                case 2:
                    cPizza.Crust.Name = crusts[1].Name;
                    cPizza.Crust.Price = crusts[1].Price;
                    break;

                default:
                    Console.WriteLine("Please Enter A valid Option");
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
                    cPizza.Size.Name = sizes[0].Name;
                    cPizza.Size.Price = sizes[0].Price;
                    break;
                case 2:
                    cPizza.Size.Name = sizes[1].Name;
                    cPizza.Size.Price = sizes[1].Price;
                    break;

                case 3:
                    cPizza.Size.Name = sizes[2].Name;
                    cPizza.Size.Price = sizes[2].Price;
                    break;

                default:
                    Console.WriteLine("Please Enter A valid Option");
                    break;
            }
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

            Console.WriteLine("Your Total:  $" + Math.Round((Double)total, 2));

            Console.WriteLine();
            Console.WriteLine("Please Enter your Name: ");
            customer.Name = Console.ReadLine();

            Console.WriteLine("Please Enter your Email: ");
            customer.Email = Console.ReadLine();

            order.StoreName = StoreName;
            order.customerEmail = customer.Email;

            var os = OrderSingleton.Instance;

            os.Seeding(order);

        }

        void orderlist()
        {
            Order order = new Order(myOrder);
            var total = order.calcTotal();
            Console.WriteLine();
            Console.WriteLine("List of Pizza that you ordered: ");
            foreach (var p in myOrder)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("Your Total:  $" + Math.Round((Double)total, 2));
        }
        void orderHistory()
        {
            Console.WriteLine();
            Console.WriteLine("Plese Enter your Email ");
            var email = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            List<Order> ordersList = OrderSingleton.Instance.myOrders;

            foreach (var order in ordersList)
            {
                if (email.Equals(order.customerEmail))
                {
                    Console.WriteLine("Store: " + order.StoreName);
                    
                    foreach (var p in order.Pizzas)
                    {
                        Console.WriteLine(p.Size.Name + " " + p.Name + " " + p.Crust.Name + " Crust with");
                        foreach (var t in p.Toppings)
                        {
                            Console.Write(t.Name + " ");
                        }
                    }
                    Console.WriteLine();
                    var mytotal = order.calcTotal();
                    Console.WriteLine("Total: $ " + Math.Round((Double)mytotal, 2));
                }

            }
            Console.WriteLine();
        }


        public static void AsStore()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Select your Store ");

            int n = 0;
            foreach (var store in StoreSingleton.Instance.Stores)
            {
                Console.WriteLine(++n + ": " + store);
            }
            int x = Convert.ToInt32(Console.ReadLine());
             System.Console.WriteLine();

            List<Order> ordersList = OrderSingleton.Instance.myOrders;
            Console.WriteLine("Here is the list of Customer with their orders for your store.");
            foreach(var order in ordersList){
                if(order.StoreName == StoreSingleton.Instance.Stores[x-1].Name){
                    Console.WriteLine("Customer Email: " + order.customerEmail);
                    foreach(var p in order.Pizzas){
                        Console.WriteLine("Pizza: " + p.Name);
                    }
                }
            }
            System.Console.WriteLine();
            
        }

    }
}
