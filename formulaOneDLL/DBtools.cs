﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;


namespace FormulaOneDLL
{
    public class DBtools
    {
        public DBtools() { }

        public const string QUERYPATH = @"C:\data\formulaone\";
        public const string DBPATH = @"C:\data\formulaone\";
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ DBPATH + "FormulaOne.mdf;Integrated Security=True";
        private DataTable dataTable = new DataTable();

        public List<string> GetCountries()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string IsoCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            Console.WriteLine("{0} {1} ", IsoCode, descr);
                            retVal.Add(IsoCode + " - " + descr);
                        }
                    }
                }
            }
            return retVal;
        }

        public object caricaTables(string tablename)
        {
            DataTable dt = new DataTable();
            using (SqlConnection dbConn = new SqlConnection())
            {
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = $"SELECT * FROM " + tablename;
                dbConn.ConnectionString = CONNECTION_STRING;
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public void ExecuteSqlScript(string sqlScriptName)
        {
            var fileContent = File.ReadAllText(QUERYPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open(); int i = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                catch (SqlException err)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            con.Close();
        }

        public List<string> getTableName()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = "SELECT TABLE_NAME  FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return retVal;
        }

        public void DropTable(string tableName)
        {
            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("Drop Table " + tableName + ";", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            catch (SqlException err)
            {
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            con.Close();
        }

        public void DBBackup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + DBPATH + "FormulaOne.mdf] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        File.Delete(DBPATH+ "FormulaOne_Backup.bak");
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + DBPATH + "FormulaOne.mdf] TO DISK='" + DBPATH + @"FormulaOne_Backup.bak'";
                        backupcomm.ExecuteNonQuery();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Backup database Success");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    backupConn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Backup database Failed");
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public DataTable getTable(string tableName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\nQuery data example: ");
                Console.WriteLine("\n=========================================\n");
                String sql = $"SELECT * FROM {tableName}";
                using (SqlCommand command = new SqlCommand(sql, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool callDropTable(string tableName)
        {
            try
            {
                DropTable(tableName);
                Console.WriteLine("\nDROP " + tableName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDROP " + tableName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }

        public void DBRestore()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sqlStmt2 = string.Format(@"ALTER DATABASE [" + DBPATH + "FormulaOne.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = @"USE MASTER RESTORE DATABASE [" + DBPATH + "FormulaOne.mdf] FROM DISK='" + DBPATH + @"FormulaOne_Backup.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format(@"ALTER DATABASE [" + DBPATH + "FormulaOne.mdf] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Restore database Success");
                    Console.ForegroundColor = ConsoleColor.White;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restore database Failed");
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool callExecuteSqlScript(string scriptName)
        {
            try
            {
                ExecuteSqlScript(scriptName + ".sql");
                Console.WriteLine("\nCreate " + scriptName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nCreate " + scriptName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }

        public void PullData()
        {
            string connString = @"your connection string here";
            string query = "select * from table";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();
        }
    }
}