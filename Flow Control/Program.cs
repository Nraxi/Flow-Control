using System.Diagnostics;
using System.IO;

namespace Flow_Control
{
    internal class Program
    {
        private static List<Model> party = new List<Model>();
        static void Main(string[] args)
        {
            Console.WriteLine("Kalles Bio - Huvud Meny");

            do
            {
                Console.WriteLine("1. Köp Biljett" +
                     "\n2. Lägg till sällskap" +
                     "\n0. Stäng ner programet"); 
                string input = Console.ReadLine()!;
                if (input != null)
                {
                    input = input.ToUpper();
                }

                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Checker();
                        break;
                    case "2":
                        Sallskap();
                        break;

                    default:
                        Console.WriteLine
                            ("Felaktigt knappval");
                        break;
                }
            } while (true);

            static void Checker()
            {
                bool fortsattkop = true;

                do
                {
                    Console.WriteLine("Ange din ålder");
                    string ageInput = Console.ReadLine()!;
                    if (ageInput != null)
                    {
                        int age;

                        if (int.TryParse(ageInput, out age))
                        {
                            Model logic = new Model(age, 0,0);
                            TicketPrice(logic);
                            Messages(logic); 
                        }
                        else
                        {
                            Console.WriteLine("fel värde");
                        }
                    }
                    else
                    {
                        Console.WriteLine("inget värde angett");
                    }
                    Console.WriteLine("Vill du lägga till en ytterligare person? (Ja/Nej)");
                    string addAnotherInput = Console.ReadLine()!.Trim().ToUpper();

                    if (addAnotherInput != "JA")
                    {
                        fortsattkop = false;
                    }
                } while (fortsattkop);
            }

                
           
            static void TicketPrice(Model logic)
            {
                int age = logic.Age;
                int price;

                if (age <= 20)
                {
                   
                    if (age == 20)
                    {
                        price = 80;
                    }
                    else if (age >= 13)
                    {
                        price = 50;
                    }
                    else
                    {
                        price = 0;
                    }
                }
                else if (age >= 65)
                {
                    price = 90;
                }
                else
                {
                    price = 120;
                }
                logic.Price = price;
            }

            static void Messages(Model logic)
            {
                int age = logic.Age;
                int price = logic.Price;
                if (age <= 20)
                {
                    Console.WriteLine($"din ålder är {age} år &");
                    if (age == 20)
                    {
                        Console.WriteLine($"ditt pris är ungdomspris {price} kr ");
                    }
                    else if (age >= 5)
                    {
                        Console.WriteLine($"ditt pris är {price} kr");
                    }
                    else
                    {
                        Console.WriteLine($"ditt pris är {price} kr och du får kolla på filmen gratis");
                    }
                }
                else if (age >= 65)
                {
                    Console.WriteLine($"Grattis du är pensionär och får betala {price} kr");
                }
                else
                {
                    Console.WriteLine($"Sorry ditt pris är standard pris på {price} kr pga att du är {age}år");
                }
            }

            static void Sallskap()
            {
                Console.WriteLine("Ange antalet personer i sällskapet:");
                string partySizeInput = Console.ReadLine()!;
                int partySize;
                if (int.TryParse(partySizeInput, out partySize))
                {
                    for (int i = 0; i < partySize; i++)
                    {
                        Console.WriteLine($"Ange ålder för person {i + 1}:");
                        string ageInput = Console.ReadLine()!;
                        if (int.TryParse(ageInput, out int age))
                        {
                            Model person = new Model(age, 0, 0);
                            party.Add(person);
                        }
                        else
                        {
                            Console.WriteLine("Felaktig ålder. Ange en siffra.");
                            i--; 
                        }
                    }

                    int totalSum = 0;
                    foreach (var person in party)
                    {
                        TicketPrice(person);
                        totalSum += person.Price;
                    }

                    Console.WriteLine($"Den totala summan för hela sällskapet på {partySize} personer är: {totalSum} kr");
                }
                else
                {
                    Console.WriteLine("Felaktigt antal. Ange en siffra.");
                }
            }

        }
    }
}
