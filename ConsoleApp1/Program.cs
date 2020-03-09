using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var users = GetHellos();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("1 - Login  2 - Sosdat");
            var a = Console.ReadLine();

            switch (a)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Sosdat();
                    break;
            }

          
            //Console.WriteLine("Приветик!");
            //var test = Console.ReadLine();
            //var test2 = $"Ну доров {test}";
            //Console.WriteLine(test2);

        }

        static List<Hello> GetHellos()
        {
            var lines = File.ReadAllLines("Users.txt");
            var myUsers = new List<Hello>();

            foreach (var line in lines)
            {
                var a = new JavaScriptSerializer().Deserialize<Hello>(line);
                myUsers.Add(a);

            }
            return myUsers;
        } 
        static void Sosdat()
        {
            var prog = new Hello();

            prog.Login = Console.ReadLine();
            prog.Password = Console.ReadLine();

            var json = new JavaScriptSerializer().Serialize(prog);

            using (var file = File.Open("Users.txt", FileMode.Append))
            {
                using (var sw = new StreamWriter(file))
                {
                    sw.WriteLine(json);
                }
            }
        }
        static void Login()
        {
            Console.WriteLine("Log?");
            var login = Console.ReadLine();
            Console.WriteLine("Pass?");
            var password = GetPassword();
            var users = GetHellos();
            var p = users.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (p == null)
            {
                Console.WriteLine(" No! No! No!");
            }
            else
            {
                Console.WriteLine("Yes! Welcome");
            }
        }
        static string GetPassword() {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass; 
        }
    }
}
