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
                     "\n3. Repitera" +
                     "\n4. Splitta 3 ord" +
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
                    case "3":
                        Repeat();
                        break;
                    case "4":
                        Split();
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
                            Model logic = new Model(age, 0, 0);
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
                var age = logic.Age;
                var price = logic.Price;


                if (age <= 20)
                {

                    if (age <= 5)
                    {
                        price = 0;
                    }
                    if (age >= 6 && age <= 13)
                    {
                        price = 50;
                    }
                    if (age > 13 && age <= 20)
                    {
                        price = 80;
                    }
                }
                else if (age >= 65 && age < 100)
                {
                    price = 90;
                }
                else if (age >= 100)
                {
                    price = 0;
                }

                else
                {
                    price = 120;
                }
                logic.Price = price;
            }

            static void Messages(Model logic)
            {
                var age = logic.Age;
                var price = logic.Price;
                if (age <= 20)
                {
                    Console.WriteLine($"din ålder är {age} år &");
                    if (age == 20)
                    {
                        Console.WriteLine($"ditt pris är ungdomspris {price} kr ");
                    }
                    else if (age < 5)
                    {
                        Console.WriteLine($"ditt pris är barnpris och det kostar {price} kr");
                    }
                    else
                    {
                        Console.WriteLine($"ditt pris är {price} kr");
                    }
                }
                else if (age >= 65 && age < 100)
                {
                    Console.WriteLine($"Grattis du är pensionär och får betala {price} kr");
                }
                else if (age >= 100)
                {
                    Console.WriteLine($"Wow du är {age} år klart du får gå in för {price} kr");
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

                // Försöker konvertera inmatningen till en integer
                if (int.TryParse(partySizeInput, out partySize))
                {
                    // Loopa över varje person i sällskapet
                    for (int i = 0; i < partySize; i++)
                    {   
                        // frågar användare efter ålder för varje person
                        Console.WriteLine($"Ange ålder för person {i + 1}:");
                        string ageInput = Console.ReadLine()!;


                        // Försöker konvertera inmatad ålder till en integer.
                        if (int.TryParse(ageInput, out int age))
                        {

                            // Skapar ett personobjekt med angiven ålder och lägger till det i listan för sällskapet.
                            Model person = new Model(age, 0, 0);
                            party.Add(person);
                        }
                        else
                        {
                            // Om inmatningen inte är en giltig ålder, meddela användaren och återgå till föregående steg i loopen.
                            Console.WriteLine("Felaktig ålder. Ange en siffra.");
                            i--;
                        }
                    }
                    // Beräkna den totala summan för biljettkostnaderna för hela sällskapet.
                    int totalSum = 0;
                    foreach (var person in party)
                    {
                        TicketPrice(person); // Beräkna biljettpriset för varje person.
                        totalSum += person.Price; // Lägg till personens biljettpris till den totala summan.
                    }
                    // Skriv ut den totala summan för biljettpriserna för hela sällskapet.
                    Console.WriteLine($"Den totala summan för hela sällskapet på {partySize} personer är: {totalSum} kr");
                }
                else
                {
                    Console.WriteLine("Felaktigt antal. Ange en siffra.");
                }
            }
            static void Repeat()
            {
                Console.WriteLine("Skriv in det du vill repitera x 10:");
                string Input = Console.ReadLine()!;
                Console.WriteLine("\nAnswer:");
                if (!string.IsNullOrWhiteSpace(Input))
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        Console.Write($"{i}.{Input} ");
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    Console.WriteLine();
                }
            }




            static void Split()
            {


                Console.WriteLine("skriv in en mening med 3ord antingen med mellanslag eller med , tecken");
                string input = Console.ReadLine()!;  // Läser inmatningen från användaren.
                string[] seperators = { " ", "," };  // Definierar en array av tecken som används som separatorer för att dela upp inmatningen.
                string[] words = input.Split(seperators, StringSplitOptions.RemoveEmptyEntries); // Delar upp inmatningen baserat på de definierade separatorerna och tar bort eventuella tomma delsträngar.

                for (int i = 0; i < words.Length; i++)  // Loopar igenom varje ord i den delade inmatningen.
                {
                    // Kontrollerar om det är det tredje ordet (baserat på att indexet börjar från 0).
                    if ((i + 1) % 3 == 0) // Om resten vid division med 3 är 0 (vilket innebär var tredje ord)
                    {
                        Console.WriteLine($"<{words[i]}>");  // Skriver ut det tredje ordet med < och > runt det för att markera det.
                    }
                }
            }
        }
    }
}

