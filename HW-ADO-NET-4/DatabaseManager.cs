using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.CodeDom.Compiler;

namespace HW_ADO_NET_4
{
    class DatabaseManager
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private DataSet dataset = new DataSet();
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public DatabaseManager()
        {
            InitialiseConnection();
        }
        public void InitialiseConnection()
        {
            try
            {
                string query = @"Select i.Id,  i.Sort, i.Country, i.Description, i.Grams, i.Price, t.Type AS TypeName from Items i join Types t ON i.TypeId = t.Id;";
                adapter = new SqlDataAdapter(query, connectionString);
                adapter.Fill(dataset, "Items");
                query = "Select * from Types";
                adapter = new SqlDataAdapter(query, connectionString);
                adapter.Fill(dataset, "Types");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Retrieved data successfully");
                Console.ResetColor();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
        public DataView GetAllTypes()
        {
            return dataset.Tables["Types"].DefaultView;
        }
        public DataView GetAllRecords()
        {
            return dataset.Tables["Items"].DefaultView;
        }
        public List<Item> GetMinPriceRecord()
        {
            List<Item> items = new List<Item>();
            DataTable table = dataset.Tables["Items"];

            var list = table.AsEnumerable().ToList();
            double minValue = (double)(list.Min(v => v["Price"]));
            DataRow[] rows = table.Select($"Price = {minValue}");
            foreach(DataRow row in rows)
            {
                if((double)row["Price"] == minValue)
                {
                    Item item = new Item();
                    item.Id = (int)row["Id"];
                    item.Sort = (string)row["Sort"];
                    item.Country = (string)row["Country"];
                    item.Type = (string)row["TypeName"];
                    item.Description = (string)row["Description"];
                    item.Grams = (double)row["Grams"];
                    item.Price = (double)row["Price"];
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
