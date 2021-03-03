using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FormulaOneDLL;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static DBtools DBTools;

        static void Main(string[] args)
        {
            DBTools = new DBtools();
            char scelta = ' ';
            do
            {
                Console.WriteLine("\n*** FORMULA ONE - CONSOLE ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Circuits");
                Console.WriteLine("5 - Create Races");
                Console.WriteLine("6 - Create RacesPoints");
                Console.WriteLine("7 - Create Scorse");
                Console.WriteLine("------------------");
                Console.WriteLine("B - Backup");
                Console.WriteLine("T - Restore");
                Console.WriteLine("R - Reset");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        DBTools.ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        DBTools.ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        DBTools.ExecuteSqlScript("Drivers.sql");
                        break;
                    case '4':
                        DBTools.ExecuteSqlScript("Circuits.sql");
                        break;
                    case '5':
                        DBTools.ExecuteSqlScript("Races.sql");
                        break;
                    case '6':
                        DBTools.ExecuteSqlScript("RacesPoints.sql");
                        break;
                    case '7':
                        DBTools.ExecuteSqlScript("Scores.sql");
                        break;
                    case 'B':
                        Thread.Sleep(1050);
                        DBTools.DBBackup();
                        break;
                    case 'T':
                        Thread.Sleep(1050);
                        DBTools.DBRestore();
                        break;
                    case 'R':
                        Thread.Sleep(1050);
                        DBTools.DBBackup();
                        bool OK;

                        OK = DBTools.callDropTable("Country");
                        if (OK) OK = DBTools.callDropTable("Team");
                        if (OK) OK = DBTools.callDropTable("Driver");

                        //script file
                        if (OK) OK = DBTools.callExecuteSqlScript("countries");
                        if (OK) OK = DBTools.callExecuteSqlScript("teams");
                        if (OK) OK = DBTools.callExecuteSqlScript("drivers");
                        if (OK)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("RESET DB OK");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                            DBTools.DBRestore();
                        
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }
    }
}
