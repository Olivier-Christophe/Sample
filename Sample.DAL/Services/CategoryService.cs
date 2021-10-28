using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.Services
{
    public class CategoryService
    {
        private SqlConnection oConn;
        public CategoryService(SqlConnection oConn)
        {
            this.oConn = oConn;
        }

        public List<Category> Get()
        {
            try
            {
                oConn.Open();
                string requete = "SELECT * FROM Category";
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = requete;
                SqlDataReader reader = cmd.ExecuteReader();
                List<Category> result = new List<Category>();

                while (reader.Read())
                {
                    result.Add(new Category


                    {
                        CategoryId = (int)reader["CategoryID"],
                        Name = reader["Name"].ToString(),
                    });

                    
                };
                return (result);



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



        public int Add(Category categories)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "INSERT INTO Category(Name) OUTPUT inserted.CategoryID VALUES (@P1)";
                cmd.Parameters.AddWithValue("p1", categories.Name);
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
