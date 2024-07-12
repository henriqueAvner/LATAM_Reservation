
using OpenQA.Selenium.Chrome;
using ProjectTesting.access;
namespace ProjectTesting;
public class Program
{
    public static void Main(string[] args)
    {


        Console.WriteLine("Digite a origem de sua viagem: ");
        string originTrip = Console.ReadLine();

        Console.WriteLine("Digite o destino de sua viagem: ");
        string destinyTrip = Console.ReadLine();

        Console.WriteLine();
        var web = new AutomationWeb( originTrip, destinyTrip);
        web.LatamTest();
    }
}