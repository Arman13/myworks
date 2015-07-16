using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {            
            var printer = new Printer();
            printer.PrintStarted += printer_PrintStarted;
            printer.Printing += printer_Printing;
            printer.PrintFinished += printer_PrintFinished;

            printer.Print(4);

        }
        static void printer_PrintFinished(object sender, EventArgs e)
        {
            Console.WriteLine("Print Finished");
        }
        static void printer_Printing(object sender, PrintingEventArgs e)
        {
            Console.WriteLine(e.CurrentPageNumber);
        }
        static void printer_PrintStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Print Started");
        }
    }
}
