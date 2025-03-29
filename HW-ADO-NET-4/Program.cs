using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HW_ADO_NET_4
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager manager = new DatabaseManager();
            UserInterface ui = new UserInterface(manager);
            ui.RunMainMenu();
        }
    }
}
