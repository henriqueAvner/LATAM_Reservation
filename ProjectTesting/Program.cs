
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

        //Console.WriteLine("Digite a data de Ida da viagem: ");
       // DateTime startDate = DateTime.Parse(Console.ReadLine());

       // Console.WriteLine("Digite a data de Chegada da viagem: ");
       // DateTime arriveDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine();
        var web = new AutomationWeb( originTrip, destinyTrip);
        web.LatamTest();
    }
}



//xpath do mês calendário:
//*[@id="calendarContainer"]/div/div/div/div/div[2]/div[2]/div/div[3]/div/table

//classe do dia do mes:
//CalendarDay