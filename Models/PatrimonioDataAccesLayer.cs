using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApiPartner.Models    
{
    public class PatrimonioDataAccesLayer
    {
        string connectionString = "Data Source=./SQLEXPRESS;AttachDbFilename=C:/Program Files/Microsoft SQL Server/MSSQL14.MSSQLSERVER/MSSQL/DATA/TestePartner.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        //	GET patrimonios - Obter todos os patrimônios
        public IEnumerable<Patrimonio> GetAllPatrimonios()
        {
            List<Patrimonio> list = new List<Patrimonio>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPatrimonio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Patrimonio p = new Patrimonio
                    {
                        Id = Convert.ToInt32(rdr["PatrimonioId"]),
                        Nome = rdr["Nome"].ToString(),
                        Descricao = rdr["Descricao"].ToString(),
                        MarcaId = Convert.ToInt32(rdr["MarcaId"]),
                        NumTombo = Convert.ToInt32(rdr["NumTombo"])
                    };

                    list.Add(p);
                }
                con.Close();
            }
            return list;
        }

        //POST patrimonios - Inserir um novo patrimônio
        public void PostPatrimonio(Patrimonio p)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPatrimonio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", p.Nome);
                cmd.Parameters.AddWithValue("@Descricao", p.Descricao);                
                cmd.Parameters.AddWithValue("@MarcaId", p.MarcaId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //PUT patrimonios/{id} - Alterar os dados de um patrimônio
        public void PutPatrimonio(Patrimonio p)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePatrimonio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PartrimonioId", p.Id);
                cmd.Parameters.AddWithValue("@Nome", p.Nome);
                cmd.Parameters.AddWithValue("@Descricao", p.Descricao);                
                cmd.Parameters.AddWithValue("@MarcaId", p.MarcaId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //	GET patrimonios/{id} - Obter um patrimônio por ID 
        public Patrimonio GetPatrimonio(int? id)
        {
            Patrimonio p = new Patrimonio();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Patrimonio WHERE PatrimonioID= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    p.Id = Convert.ToInt32(rdr["PatrimonioId"]);
                    p.Nome = rdr["Nome"].ToString();
                    p.Descricao = rdr["Descricao"].ToString();
                    p.NumTombo = Convert.ToInt32(rdr["NumTombo"]);
                    p.MarcaId = Convert.ToInt32(rdr["MarcaId"]);
                }
            }
            return p;
        }

        //	DELETE patrimonios/{id} - Excluir um patrimônio
        public void DeletePatrimonio(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePatrimonio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatrimonioId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
