using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Movies_list_ajax_model.Models;

namespace Movies_list_ajax_model.moviesDb
{
    public class MoviesDb
    {
        string cs = ConfigurationManager.ConnectionStrings["SQLMVC"].ToString();

        public List<Moviesmodel> ListAll()
        {
            List<Moviesmodel> objmovies = new List<Moviesmodel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectMovie", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader mov = com.ExecuteReader();
                while (mov.Read())
                {
                    objmovies.Add(new Moviesmodel
                    {
                        id = Convert.ToInt32(mov["id"]),
                        MoviesName = Convert.ToString(mov["MoviesName"]),
                        Hero = Convert.ToString(mov["Hero"]),
                        Heroin = Convert.ToString(mov["Heroin"]),
                    });
         
                }
                return objmovies;
            }
        }

        public int Add(Moviesmodel mov)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insertupdatemovies", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", mov.id);
                com.Parameters.AddWithValue("@MoviesName", mov.MoviesName);
                com.Parameters.AddWithValue("@Hero", mov.Hero);
                com.Parameters.AddWithValue("@Heroin", mov.Hero);
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
            } 
            return i;
        }

        public int Update(Moviesmodel mov)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Insertupdatemovies", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", mov.id);
                com.Parameters.AddWithValue("@MoviesName", mov.MoviesName);
                com.Parameters.AddWithValue("@Hero", mov.Hero);
                com.Parameters.AddWithValue("@Heroin", mov.Hero);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;


        }

        public int Delete(int id)
        {
            int i;
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteMovie", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

    }


}