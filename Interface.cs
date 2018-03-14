using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

namespace CLIENTHTTP2
{
    class Interface
    {
        public static string usertext,back, contenttext, both, columntype, title,port;
        public static int choice;
        public static int identification;
        

        static void Main(string[] args)
        {
            Random rnd = new Random();
            identification = rnd.Next(100);
            choice = 0;
            Console.WriteLine("Wpisz port na którym klient będzie komunikować się z serwerem");
            try
            {
                port = Console.ReadLine();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Nieprawidłowy format!");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                RysujOdPoczatku();
            }
             

           
            Console.WriteLine("Wybierz jedną z opcji");
            Console.WriteLine("1.Utwórz nowy typ zdarzenia");
            Console.WriteLine("2.Wyślij zdarzenie");
            Console.WriteLine("3.Wyjdź");

            ConsoleKeyInfo key = Console.ReadKey();
            if (char.IsDigit(key.KeyChar))
            {
                choice = Int32.Parse(key.KeyChar.ToString());
                if (choice != 1 && choice != 2 && choice != 3)
                    Rysuj();
            }
            if (char.IsLetter(key.KeyChar))
            {
                    Rysuj();
            }

            switch (choice)
            {

                case 1:
                    DodajTypZdarzenia();
                    break;

                case 2:
                    Przeslijzdarzenie();
                    break;

                case 3:
                    Console.WriteLine("Do zobaczenia");
                    System.Threading.Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;

            }

        }



        static void Rysuj()
        {
            Console.Clear();
            Console.WriteLine("Wybierz jedną z opcji");
            Console.WriteLine("1.Utwórz nowy typ zdarzenia");
            Console.WriteLine("2.Wyślij zdarzenie");
            Console.WriteLine("3.Wyjdź");
            int menu = 0;
            ConsoleKeyInfo key = Console.ReadKey();
            if (char.IsDigit(key.KeyChar))
            {
                menu = Int32.Parse(key.KeyChar.ToString());
                if (menu != 1 && menu != 2 && menu != 3)
                    Rysuj();
            }
            if (char.IsLetter(key.KeyChar))
            {
                    Rysuj();
            }
            switch (menu)
            {
                case 1:
                    DodajTypZdarzenia();
                    break;

                case 2:
                    Przeslijzdarzenie();
                    break;
                case 3:
                    Console.WriteLine("Do zobaczenia");
                    System.Threading.Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;

            }
        }
        static void RysujOdPoczatku()
        {
            Console.Clear();
            Console.WriteLine("Wpisz port na którym klient będzie komunikować się z serwerem");
            try
            {
                port = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Nieprawidłowy format!");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Rysuj();
            }
            Console.WriteLine("Wybierz jedną z opcji");
            Console.WriteLine("1.Utwórz nowy typ zdarzenia");
            Console.WriteLine("2.Wyślij zdarzenie");
            Console.WriteLine("3.Wyjdź");
            int choice = 0;
            ConsoleKeyInfo key = Console.ReadKey();
            if (char.IsDigit(key.KeyChar))
            {
                choice = Int32.Parse(key.KeyChar.ToString());
                if (choice != 1 && choice != 2 && choice != 3)
                    Rysuj();
            }
            if (char.IsLetter(key.KeyChar))
            {
                Rysuj();
            }
            switch (choice)
            {
                case 1:
                    DodajTypZdarzenia();
                    break;

                case 2:
                    Przeslijzdarzenie();
                    break;
                case 3:
                    Console.WriteLine(Environment.NewLine + "Do zobaczenia");
                    System.Threading.Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;

            }
        }


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Nie można uzyskać adresu IPv4");
            // źródłem funkcji strona: https://stackoverflow.com/questions/6803073/get-local-ip-address
        }

        static void DodajTypZdarzenia()
        {
            
           try
                    {
                        Console.Clear();
                        Console.WriteLine("Podaj nazwe tabeli");
                        title = Console.ReadLine();
                        Console.WriteLine("Wpisz dodatkową ilość kolumn oprócz podstawowych czterech");
                        int number = Int32.Parse(Console.ReadLine());

                        for (int i = 0; i < number; i++)
                        {
                            Console.WriteLine("Podaj nazwę kolumny");
                            usertext = Console.ReadLine();
                            Console.WriteLine("Podaj typ kolumny(varchar albo int) oraz w nawiasach maksymalną ilośc znaków");
                            columntype = Console.ReadLine();
                            both = usertext + " " + columntype + " ";
                            contenttext += both + ",";
                        }
                        contenttext = title + " ( " + "Id int not null , " + " Adres_IP " + "varchar(1000), " + "Czas_zdarzenia datetime," + "Typ_zdarzenia varchar(1000)," + contenttext;
                        StringContent content = new StringContent(contenttext);
                        Program pr = new Program(content, port);
                        contenttext = String.Empty;
                              System.Threading.Thread.Sleep(1500);
                              Console.WriteLine("Aby powrócić do menu głównego wpisz ESC");
                              string back = Console.ReadLine();
                              if (back == "esc" || back == "ESC" || back == "Esc")
                               {
                                Rysuj();
                               }
                else
                {
                    Console.WriteLine("Do zobaczenia");
                    System.Threading.Thread.Sleep(1500);
                    Environment.Exit(0);
                }
                


            }
            catch (Exception error)
                    {
                        Console.WriteLine("Nie udało się wygenerować zdarzenia + {0} " + Environment.NewLine,error);
                        Console.WriteLine("Za chwilę zostaniesz przeniesiony do menu głównego");
                        System.Threading.Thread.Sleep(2000);
                        Rysuj();
                    }
                  
            
        }

        static void Przeslijzdarzenie()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Podaj nazwe tabeli");
                title = Console.ReadLine();
                Console.WriteLine("Wpisz ilość dodatkowych kolumn tabeli oprócz podstawowych czterech");
                int number = Int32.Parse(Console.ReadLine());
                
                
                Console.WriteLine("Proszę o podanie typu zdarzenia: ");
                string typevent = "'" + Console.ReadLine() + "'";
                string eventtime = "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "' ";
                string ip = "'" + GetLocalIPAddress() + "'";
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("Podaj wartość");
                    usertext = Console.ReadLine();
                    contenttext += "'" + usertext + "'" + ",";
                }

                contenttext = "INSERT INTO " + title + " VALUES " + "( " + identification + ", " + ip + ", " + eventtime + ", " + typevent + ", " + contenttext;
                StringContent content = new StringContent(contenttext);
                Program pr = new Program(content, port);
                contenttext = String.Empty;
                System.Threading.Thread.Sleep(1500);
                    Console.WriteLine("Aby powrócić do menu głównego wpisz ESC");
                    string back = Console.ReadLine();
                    if (back == "esc" || back == "ESC" || back == "Esc")
                {
                    Rysuj();
                }
                else
                {
                    Console.WriteLine("Do zobaczenia");
                    System.Threading.Thread.Sleep(1500);
                    Environment.Exit(0);
                }
                
            }
            catch (Exception error)
            {
                Console.WriteLine("Nie udało się przesłać zdarzenia + {0} " + Environment.NewLine, error);
                Console.WriteLine("Za chwilę zostaniesz przeniesiony do menu głównego");
                System.Threading.Thread.Sleep(2000);
                Rysuj();
            }
        }

    }



    }

