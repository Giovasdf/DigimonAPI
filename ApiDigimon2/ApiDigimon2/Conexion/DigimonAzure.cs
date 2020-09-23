using ApiDigimon2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDigimon2.Conexion
{
    public class DigimonAzure
    {
        static string connectionString = @"Server=DESKTOP-S6JN4IA\SQLEXPRESS;Database=Digimon;Trusted_Connection=True;";


        public static List<Digimon> listDigimons ;

        //Get All Digimons
        public static List<Digimon> getAllDigimons()
        {
            var dt = new DataTable();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "select * from Digimon";

                //abrir la conexion
                connection.Open();
                var DataAdapter = new SqlDataAdapter(command);
                DataAdapter.Fill(dt);

                
                listDigimons = new List<Digimon>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Digimon digimon = new Digimon();

                    digimon.name = dt.Rows[i]["name"].ToString();
                    digimon.size = int.Parse(dt.Rows[i]["size"].ToString());
                    digimon.attribute = dt.Rows[i]["attribute"].ToString();
                    //digimon.created_at = dt.Rows[0]["name"].ToString();
                    digimon.level = dt.Rows[i]["level"].ToString();
                    digimon.type = dt.Rows[i]["type"].ToString();
                    digimon.idDigimon = int.Parse(dt.Rows[i]["idDigimon"].ToString());

                    listDigimons.Add(digimon);
                }



                return listDigimons;
            }
        }

        //Get Digimon by ID
        public static List<Digimon> getDigimon(int id)
        {
            var dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = $"select * from Digimon where idDigimon = {id}";

                //abrir la conexion
                connection.Open();
                var DataAdapter = new SqlDataAdapter(command);
                DataAdapter.Fill(dt);

                listDigimons = new List<Digimon>();


                if(dt != null && dt.Rows.Count > 0)
                {
                    Digimon digimon = new Digimon();
                    digimon.name = dt.Rows[0]["name"].ToString();
                    digimon.size = int.Parse(dt.Rows[0]["size"].ToString());
                    digimon.attribute = dt.Rows[0]["attribute"].ToString();
                    //digimon.created_at = dt.Rows[0]["name"].ToString();
                    digimon.level = dt.Rows[0]["level"].ToString();
                    digimon.type = dt.Rows[0]["type"].ToString();
                    digimon.idDigimon = int.Parse(dt.Rows[0]["idDigimon"].ToString());

                    listDigimons.Add(digimon);
                }
                

                return listDigimons;
            }
        }

        //Get Digimon by Name
        public static List<Digimon> getDigimon(string name)
        {
            var dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = $"select * from Digimon where name = '{name}'";

                //abrir la conexion
                connection.Open();
                var DataAdapter = new SqlDataAdapter(command);
                DataAdapter.Fill(dt);

                listDigimons = new List<Digimon>();


                if (dt != null && dt.Rows.Count > 0)
                {
                    Digimon digimon = new Digimon();
                    digimon.name = dt.Rows[0]["name"].ToString();
                    digimon.size = int.Parse(dt.Rows[0]["size"].ToString());
                    digimon.attribute = dt.Rows[0]["attribute"].ToString();
                    //digimon.created_at = dt.Rows[0]["name"].ToString();
                    digimon.level = dt.Rows[0]["level"].ToString();
                    digimon.type = dt.Rows[0]["type"].ToString();
                    digimon.idDigimon = int.Parse(dt.Rows[0]["idDigimon"].ToString());

                    listDigimons.Add(digimon);
                }


                return listDigimons;
            }
        }

        //Get Random Digimon 
        public static List<Digimon> getDigimonRandom()
        {
            var dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "select * from Digimon";

                //abrir la conexion
                connection.Open();
                var DataAdapter = new SqlDataAdapter(command);
                DataAdapter.Fill(dt);

                listDigimons = new List<Digimon>();


                if (dt != null && dt.Rows.Count > 0)
                {
                    var rand = new Random();
                    int numRand = rand.Next(0, dt.Rows.Count);


                    Digimon digimon = new Digimon();
                    digimon.name = dt.Rows[numRand]["name"].ToString();
                    digimon.size = int.Parse(dt.Rows[numRand]["size"].ToString());
                    digimon.attribute = dt.Rows[numRand]["attribute"].ToString();
                    digimon.level = dt.Rows[numRand]["level"].ToString();
                    digimon.type = dt.Rows[numRand]["type"].ToString();
                    digimon.idDigimon = int.Parse(dt.Rows[numRand]["idDigimon"].ToString());

                    listDigimons.Add(digimon);
                }


                return listDigimons;
            }
        }

        public static void InsertDigimon(Digimon digimon)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(null, connection);
                //Query
                command.CommandText = "INSERT INTO Digimon (name,level,type,attribute,size) VALUES (@name,@level,@type,@attribute,@size)";
                command.Parameters.AddWithValue("@name", digimon.name);
                command.Parameters.AddWithValue("@level", digimon.level);
                command.Parameters.AddWithValue("@type", digimon.type);
                command.Parameters.AddWithValue("@attribute", digimon.attribute);
                command.Parameters.AddWithValue("@size", digimon.size);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }

    }
}
