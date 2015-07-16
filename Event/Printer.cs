using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Event
{
    public class Printer
    {
        public event EventHandler PrintStarted;
        public event EventHandler PrintFinished;
        public event EventHandler<PrintingEventArgs> Printing;
        public void Print(int pageCount)
        {
            OnPrintStarted();
            for (int i = 1; i <= pageCount; i++)
            {
                OnPrinting(i);
                Thread.Sleep(1000);
            }
            OnPrintFinishd();
        }
        private void OnPrinting(int i)
        {

            if (PrintFinished != null)
            {
                EventHandler<PrintingEventArgs> del = (EventHandler<PrintingEventArgs>)Printing;
                PrintingEventArgs args = new PrintingEventArgs();
                args.CurrentPageNumber = i;
                del(this, args);
            }
        }
        private void OnPrintFinishd()
        {
            if (PrintStarted != null)
            {
                EventHandler del = (EventHandler)PrintFinished;
                del(this, EventArgs.Empty);
            }
        }
        private void OnPrintStarted()
        {
            if (PrintStarted != null)
            {
                EventHandler del = (EventHandler)PrintStarted;
                del(this, EventArgs.Empty);
            }
        }
    }
}
