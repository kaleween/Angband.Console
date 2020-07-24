using System.Linq;
using Angband.Core;

namespace Angband.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            switch (args.FirstOrDefault() ?? string.Empty)
            {
                case "SUM":
                    var somme = new Somme(args.Skip(1).Select(int.Parse));
                    System.Console.WriteLine(somme.Resultat);
                    break;
                case "ADD":
                    var addition = new Addition(int.Parse(args[1]), int.Parse(args[2]));
                    System.Console.WriteLine(addition.Resultat);
                    break;
                default:
                    System.Console.WriteLine("Commande invalide");
                    break;
            }
        }
    }
}
