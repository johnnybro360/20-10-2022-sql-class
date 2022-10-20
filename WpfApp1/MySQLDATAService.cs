using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class MySQLDATAService
    {     // Define Connection Details
        private string dbName { get; set; } = "JP_traffic_cop";
        private string dbUser { get; set; } = "JP_traffic_cop";
        private string dbPassword { get; set; } = "Password1";
        private int dbPort { get; set; } = 3306;
        private string dbServer { get; set; } = "localhost";

        // Connection String and MySQL Connection
        private string dbConnectionString { get; set; } = "";
        public MySqlConnection conn { get; set; }
        
        public MySQLDATAService()
        {
            dbConnectionString = $"server={dbServer}; user={dbUser}; database={dbName}; port={dbPort}; password={dbPassword};";
            conn = new MySqlConnection(dbConnectionString);
        }

        public List<Traffic> GetTraffic()
        {
            string sqlQuery = "SELECT * FROM traffic;";
            List<Traffic> trafficlist = new List<Traffic>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //vehicleListbox.Items.Add($"{rdr[1]} : {rdr[2], 10}kph");
                    //traffic.Add(new Traffic(int.Parse(rdr[0].ToString()), rdr[1].ToString(), int.Parse(rdr[2].ToString()), int.Parse(rdr[3].ToString())));
                    int id = Convert.ToInt32(rdr["id"]);
                    string plate = rdr["number_plate"].ToString();
                    int speed = Convert.ToInt32(rdr["speed"]);
                    int limit = Convert.ToInt32(rdr["speed_limit"]);
                    Traffic traffic = new Traffic(id, plate, speed, limit);
                    trafficlist.Add(traffic);
                }
            }
            catch (InvalidCastException castEx)
            {
                Console.WriteLine(castEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return trafficlist;
        }

        public Traffic GetTraffic(int trafficid)
        {
            Traffic traffic = null;

            string sqlQuery = "SELECT * FROM traffic where id=@id;";
            List<Traffic> trafficlist = new List<Traffic>();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlParameter parameter = cmd.CreateParameter();
                parameter.ParameterName = "id";
                parameter.Value = trafficid;
                cmd.Parameters.Add(parameter);
                cmd.Prepare();

                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //vehicleListbox.Items.Add($"{rdr[1]} : {rdr[2], 10}kph");
                    //traffic.Add(new Traffic(int.Parse(rdr[0].ToString()), rdr[1].ToString(), int.Parse(rdr[2].ToString()), int.Parse(rdr[3].ToString())));
                    int id = Convert.ToInt32(rdr["id"]);
                    string plate = rdr["number_plate"].ToString();
                    int speed = Convert.ToInt32(rdr["speed"]);
                    int limit = Convert.ToInt32(rdr["speed_limit"]);
                    traffic = new Traffic(id, plate, speed, limit);
                    //trafficlist.Add(traffic);

                }
            }
            catch (InvalidCastException castEx)
            {
                Console.WriteLine(castEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();

         
            }
            return traffic;

        }

        public List<Person> GetPeople()
        {
            List<Person> personList = new List<Person>();
            string sqlQuery = "select * from people;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = int.Parse(rdr["id"].ToString());
                    string firstName = rdr["first_name"].ToString();
                    string lastName = rdr["last_name"].ToString();
                    DateTime dob = Convert.ToDateTime(rdr["dob"]);

                    Person person = new Person(id, firstName, lastName, dob);
                    personList.Add(person);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine();
            }
            finally
            {
                conn.Close();
            }
            return personList;
        }


        public void UpdatePeople(string name,int id) 
        {
            List<Person> personList = new List<Person>();
            string sqlQuery = "update people set first_name=@name where id=@id;";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader rdr = cmd.ExecuteReader();

                //MySqlDataReader rdr = cmd.ExecuteReader();


            }
            catch (Exception ex) 
            {
                Console.WriteLine();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
