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
                string requete = "SELECT s.*, c.Name FROM sample s LEFT JOIN SampleCategory sc ON s.SampleId = sc.SampleId LEFT JOIN Category c ON sc.CategoryId = c.CategoryId";
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
                        CategoryName = (reader["Name"] is DBNull) ? null : (string)reader["Name"],
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
                cmd.CommandText = "INSERT INTO Sample(Auteur,Titre,URL) OUTPUT inserted.SampleID VALUES (@P1,@p2,@p3)";
                cmd.Parameters.AddWithValue("p1", samples.Auteur);
                cmd.Parameters.AddWithValue("p2", samples.Titre);
                cmd.Parameters.AddWithValue("p3", samples.URL);

                return (int)cmd.ExecuteScalar();

            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                oConn.Close();
            }

        }

        public void AddCategoryToSample(int idS, int idCat)
        {
            oConn.Open();
            SqlCommand cmd = oConn.CreateCommand();
            cmd.CommandText = "INSERT INTO [SampleCategory](SampleId,CategoryId) VALUES (@P1,@p2)";
            cmd.Parameters.AddWithValue("p1", idS);
            cmd.Parameters.AddWithValue("p2", idCat);

            cmd.ExecuteScalar();
            oConn.Close();
        }
        #region delete();//correct ?
        public bool Delete(int Sampleid)
        {
           try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "DELETE FROM Sample WHERE SampleId = @p1";
                cmd.Parameters.AddWithValue("p1", Sampleid);
                return cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                oConn.Close();
            }
        }

        public bool Update(Samples samples)
        {
            try
            {
                oConn.Open();
                SqlCommand cmd = oConn.CreateCommand();
                cmd.CommandText = "UPDATE Sample SET Auteur = @p2 , Titre = @p3,URL =@p4  WHERE SampleId = @p1";
                cmd.Parameters.AddWithValue("p1", samples.SampleId);
                cmd.Parameters.AddWithValue("p2", samples.Auteur);
                cmd.Parameters.AddWithValue("p3", samples.Titre);
                cmd.Parameters.AddWithValue("p4", samples.URL);
                return cmd.ExecuteNonQuery() != 0;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
        #endregion

    
}
