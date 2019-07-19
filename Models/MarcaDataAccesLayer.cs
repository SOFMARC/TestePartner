using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApiPartner.Models
{
    public class MarcaDataAccesLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=localhost;Data Source=DESKTOP-R4JUREC";

        //	GET Marcas - Obter todas as marcas
        public IEnumerable<Marca> GetAllMarcas()
        {
            List<Marca> list = new List<Marca>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllMarcas", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Marca p = new Marca
                    {
                        MarcaId = Convert.ToInt32(rdr["MarcaID"]),
                        Nome = rdr["Nome"].ToString()                     
                    };

                    list.Add(p);
                }
                con.Close();
            }
            return list;
        }

        //POST Marcas - Inserir uma nova Marca
        public void PostMarca(Marca p)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddMarca", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", p.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //PUT Marcas/{id} - Alterar os dados de uma marca
        public void PutMarca(Marca p)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateMarca", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MarcaId ", p.MarcaId);
                cmd.Parameters.AddWithValue("@Nome", p.Nome);             
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //	GET Marcas/{id} - Obter uma marca por ID 
        public Marca GetMarca(int? id)
        {
            Marca p = new Marca();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Marca WHERE MarcaId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    p.MarcaId = Convert.ToInt32(rdr["MarcaId"]);
                    p.Nome = rdr["Nome"].ToString();  
                }
            }
            return p;
        }

        //	DELETE Marcas/{id} - Excluir uma marca
        public void DeleteMarca(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteMarca", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MarcaId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

