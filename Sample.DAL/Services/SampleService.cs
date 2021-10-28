using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.Services
{
    public class SampleService
    {
        private SqlConnection oConn;
        public SampleService(SqlConnection oConn)
        {
            this.oConn = oConn;
        }
        public List<Samples> Get()
        {
            try
            {
                oConn.Open();
                string requete = "SELECT * FROM Sample";
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = requete;
                SqlDataReader reader = cmd.ExecuteReader();
                List<Samples> result = new List<Samples>();
                while (reader.Read())
                {
                    result.Add(new Samples
                    {
                        SampleId = (int)reader["SampleID"],
                        Titre = reader["Titre"].ToString(),
                        Auteur= (reader["Auteur"] is DBNull) ? null : reader["Auteur"].ToString(),
                        Description = (reader["Description"] is DBNull) ? null : reader["Description"].ToString(),
                        Format= (reader["Format"] is DBNull) ? null : reader["Format"].ToString(),
                        URL= (reader["URL"] is DBNull) ? null : reader["URL"].ToString(),
                        IsTelechargeable = (reader["IsTelechargeable"] is DBNull) ? null : (bool)reader["IsTelechargeable"],

                    });
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                oConn.Close();
            }
        }

        public int Add(Samples samples)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Sample(Auteur),Sample(Titre) OUTPUT inserted.SampleID VALUES (@P1,@p2})";
                cmd.Parameters.AddWithValue("p1", samples.Auteur);
                cmd.Parameters.AddWithValue("p2", samples.Titre);

                return (int)cmd.ExecuteScalar();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                oConn.Close();
            }

        }

    }
}
