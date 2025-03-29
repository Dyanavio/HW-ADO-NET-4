using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_ADO_NET_4
{
    class UserInterface
    {
        private DatabaseManager manager;
        public UserInterface(DatabaseManager manager)
        {
            this.manager = manager;
        }
        public void GetAllRecords()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("----- List of All Records -----");
            Console.ResetColor();

            DataView view = manager.GetAllRecords();
            if (view.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database is empty");
                Console.ResetColor();
            }
            else OutputAllRecords(view);
        }
        public void GetAllTypes()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("----- List of All Types -----");
            Console.ResetColor();

            DataView view = manager.GetAllTypes();
            if (view.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database is empty");
                Console.ResetColor();
            }
            else OutputAllTypes(view);
        }
        public void OutputMinPriceItems()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----- List of Items with Min Price -----");
            Console.ResetColor();

            List<Item> items = manager.GetMinPriceRecord();
            Console.WriteLine("{0, -5} {1, -15} {2, -10} {3, -10} {4, -50} {5, -8} {6, -8}", "Id", "Sort", "Country", "Type", "Description", "Grams", "Price");
            Console.WriteLine(new string('-', 120));
            foreach (var item in items)
            {
                Console.WriteLine("{0, -5} {1, -15} {2, -10} {3, -10} {4, -50} {5, -8} {6, -8}", item.Id, item.Sort, item.Country, item.Type, item.Description, item.Grams, item.Price);
            }

        }
        private void OutputAllTypes(DataView view)
        {
            Console.WriteLine("{0, -5} {1, -15}", "Id", "Type");
            Console.WriteLine(new string('-', 15));
            foreach (DataRowView rowView in view)
            {
                DataRow row = rowView.Row;
                string id = row["Id"].ToString();
                string type = row["Type"].ToString();
                Console.WriteLine("{0, -5} {1, -15}", id, type);
            }
        }
        private void OutputAllRecords(DataView view)
        {
            Console.WriteLine("{0, -5} {1, -15} {2, -10} {3, -10} {4, -50} {5, -8} {6, -8}", "Id", "Sort", "Country", "Type", "Description", "Grams", "Price");
            Console.WriteLine(new string('-', 120));
            foreach (DataRowView rowView in view)
            {
                DataRow row = rowView.Row;
                string id = row["Id"].ToString();
                string sort = row["Sort"].ToString();
                string country = row["Country"].ToString();
                string type = row["TypeName"].ToString();
                string description = row["Description"].ToString();
                string grams = row["Grams"].ToString();
                string price = row["Price"].ToString();
                Console.WriteLine("{0, -5} {1, -15} {2, -10} {3, -10} {4, -50} {5, -8} {6, -8}", id, sort, country, type, description, grams, price);
            }
        }

        public void RunMainMenu()
        {
            try
            {
                int input;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------- Coffee Database -------");
                    Console.ResetColor();
                    Console.WriteLine("Options:\n\t1 - Output all\n\t2 - Output types\n\t3 - Output item by min price\n\t0 - Exit");
                    Console.Write("Input: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    switch (input)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Exiting . . .");
                            Console.ResetColor();
                            break;
                        case 1:
                            GetAllRecords();
                            break;
                        case 2:
                            GetAllTypes();
                            break;
                        case 3:
                            OutputMinPriceItems();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No such option present");
                            Console.ResetColor();
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                while (input != 0);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e.Message + ". Exiting program");
            }
        }
    }
}
