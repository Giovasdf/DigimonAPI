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


        public static List<Digimon> listDigimons;


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
    }
}
