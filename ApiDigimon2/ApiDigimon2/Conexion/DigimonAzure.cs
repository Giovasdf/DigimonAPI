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
                Digimon digimon = new Digimon();
                listDigimons = new List<Digimon>();
                digimon.name = dt.Rows[0]["name"].ToString();
                digimon.size = int.Parse(dt.Rows[0]["size"].ToString());
                digimon.attribute = dt.Rows[0]["attribute"].ToString();
                //digimon.created_at = dt.Rows[0]["name"].ToString();
                digimon.level = dt.Rows[0]["level"].ToString();
                digimon.type = dt.Rows[0]["type"].ToString();
                digimon.idDigimon = int.Parse(dt.Rows[0]["idDigimon"].ToString());
                listDigimons.Add(digimon);
                return listDigimons;
            }
        }
    
    }
}
