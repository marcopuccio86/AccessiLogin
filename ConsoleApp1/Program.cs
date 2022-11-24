using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScriviMenu();
        }
        public static class User
        {
            public static string username;
            public static string password;
            public static bool IsLogged;
            public static DateTime DataOraLog;
            public static List<DateTime> ListaAccessi = new List<DateTime>();
            public static void Login()
            {
                Console.WriteLine("Inserisci username:");
                User.username = Console.ReadLine();

                Console.WriteLine("Inserisci password:");
                User.password = Console.ReadLine();

                Console.WriteLine("Conferma password:");
                string conferma = Console.ReadLine();

                if ((User.password == conferma) && (User.username != ""))
                {
                    IsLogged = true;
                    DataOraLog = DateTime.Now;
                    User.ListaAccessi.Add(DataOraLog);
                    Console.WriteLine($"Utente correttamente loggato alle ore {DataOraLog}");
                }
                else
                {
                    Console.WriteLine("Non è possibile effettuare il login");
                }
            }

            public static void Logout()
            {
                username = "";
                password = "";
                IsLogged = false;
                Console.WriteLine("Nessun utente loggato al sistema");
            }

            public static void StampaDataEOraLogin()
            {
                if (User.IsLogged == true)
                {
                    Console.WriteLine($"L'utente {User.username} ha effettuato l'accesso il {User.DataOraLog}");
                }
                else
                {
                    Console.WriteLine("Non risultano utenti loggati a sistema");
                }
            }

            public static void VerificaListaAccessi()
            {
                Console.WriteLine("===LISTA DEGLI ACCESSI EFFETTUATI INIZIO===");
                foreach (DateTime item in ListaAccessi)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("===LISTA DEGLI ACCESSI EFFETTUATI FINE===");
            }
        }

        public static void ScriviMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("==============OPERAZIONI===============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Verifica lista Accessi");

            var scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    User.Login();
                    break;
                case "2":
                    User.Logout();
                    break;
                case "3":
                    User.StampaDataEOraLogin();
                    break;
                case "4":
                    User.VerificaListaAccessi();
                    break;
            }
            ScriviMenu();
        }
    }
}
