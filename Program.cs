using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDispenser
{
    public class Program
    {
        static List<double> cartPrices = new List<double>();
        static List<string> menu = new List<string>();
        static double cokePrice = 2.23;
        static double mtnPrice = 1.3;
        static int cokeResult = 0;
        static int mtnResult = 0;

        public static void Main(string[] args)
        {
            //Set title
            Console.Title = "CruXial's Food Dispenser";

        //Greet the user
        Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hey! And welcome to CruXial's 'Food Dispenser'");
            Console.WriteLine("Press <ENTER> to continue!\n\n");

            var checkKey = Console.ReadKey();

            if (checkKey.Key != ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"\nI told you to press <ENTER> not '{checkKey.Key}'");

                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;

            //Inform the user
            Console.WriteLine("Available commands:\n!balance\n!stop\n!addmoney\n!menu\n!cart\n!checkout\n!buy");

            var Balance = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\n");
                Console.WriteLine("Execute a command..");
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Yellow;

                var readLine = Console.ReadLine();

                if(readLine.ToLower() == "!stop")
                {
                    Console.WriteLine("See ya, Come again!");

                    break;
                }

                if (readLine.ToLower() == "!balance")
                {
                    Console.WriteLine($"You currently have ${Balance} on your account.");
                }

                if (readLine.ToLower() == "!addmoney")
                {
                    Console.WriteLine("How much money do you want to add?");
                    Console.WriteLine("10");
                    Console.WriteLine("50");
                    Console.WriteLine("100");

                    string input = Console.ReadLine();

                    string[] values = new[] { "10", "50", "100" };
                    if (!values.Any(x => input.Contains(x)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please specify a valid value!");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    if (input.ToLower() == "10")
                    {
                        Balance = Balance + 10;

                        Console.WriteLine($"$10 has been added to your account! You now have ${Balance}");
                    }

                    if (input.ToLower() == "50")
                    {
                        Balance = Balance + 50;

                        Console.WriteLine($"$50 has been added to your account! You now have ${Balance}");
                    }

                    if (input.ToLower() == "100")
                    {
                        Balance = Balance + 100;

                        Console.WriteLine($"$100 has been added to your account! You now have ${Balance}");
                    }
                }

                if (readLine.ToLower() == "!menu")
                {
                    menu = new List<string> { "Coke ($2,23)\n", "MtnDew ($1,3)\n" };

                    Console.WriteLine(String.Join("", menu));
                    Console.WriteLine("\n \n");

                    Task.Delay(1000);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Would you like to add something to your cart?\n");

                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        Console.WriteLine("\nType the name of the item you want to add to your cart\n");

                        switch (Console.ReadLine().ToLower())
                        {
                            case "coke":
                                Coke();
                                break;

                            case "mtndew":
                                MtnDew();
                                break;

                            default:
                                Console.WriteLine("Invalid item!");
                                break;
                        }

                    }
                }

                if(readLine.ToLower() == "!cart")
                {
                    if (cartPrices.Count == 0)
                    {
                        Console.WriteLine("\nYour cart is empty.");
                    }
                    else
                    {
                        Console.WriteLine($"\n Total Price: {cartPrices.Sum():c}");
                    }
                }

                if(readLine.ToLower() == "!checkout")
                {
                    Console.WriteLine($"Balance: ${Balance}");

                    if(cartPrices.Count == 0)
                    {
                        cartPrices.Add(0.0);
                    }

                    Console.WriteLine($"\n Total Price: {cartPrices.Sum():c}");

                    if(Balance < cartPrices.Sum())
                    {
                        Console.WriteLine($"You only have ${Balance}, however you need {cartPrices.Sum():c} to check out.");
                    }

                    if (Balance > cartPrices.Sum())
                    {
                        Console.WriteLine("Thanks for your purchase, Hope I'll see you again soon!");
                    }
                }

                if(readLine.ToLower() == "!buy")
                {
                    Console.WriteLine("\nMenu:\nCoke\nMtnDew\n\nType the name of the product you want to buy!");

                    if(readLine.ToLower() == "coke")
                    {
                        Coke();
                    }

                    if (readLine.ToLower() == "mtndew")
                    {
                        MtnDew();
                    }
                }
            } 
            //end of loop
        }

        public static void Coke()
        {
            Console.WriteLine("\nAlrighty! How many do you want to add?\n");

            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                cartPrices.Add(cokePrice * amount);

                Console.WriteLine($"\n{amount} coke(s) has been added to your cart!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please specify a valid number!");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }

        public static void MtnDew()
        {
            Console.WriteLine("\nAlrighty! How many do you want to add?\n");

            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                cartPrices.Add(mtnPrice * amount);

                Console.WriteLine($"\n{amount} MtnDew(s) has been added to your cart!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please specify a valid number!");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
    }
}