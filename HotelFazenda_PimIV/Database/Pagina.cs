using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagina
    {
        private string sqlConn()
        {
            return ConfigurationManager.AppSettings["sqlConn"];
        }

        public DataTable Lista()
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Hospede";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Salvar(int id, string nome, string cpf, string sexo, DateTime datanascimento, string possuipcd, string cep, string numcasa, string numcelular, string email)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = $"insert into Hospede (Nome, CPF, Sexo, DataNascimento, PossuiPcD, CEP, NumCasa, NumCelular, Email) " +
                    $"values('{nome}', '{cpf}', '{sexo}', '{datanascimento.ToString("yyyy-MM-dd")}', '{possuipcd}', '{cep}', '{numcasa}', '{numcelular}', '{email}')";
                if(id != 0)
                {
                    queryString = "update Hospede set Nome='" + nome+"', CPF='"+cpf+"', Sexo='"+sexo+"', DataNascimento='"+ datanascimento.ToString("yyyy-MM-dd") +
                        "', PossuiPcD='"+possuipcd+"', CEP='"+cep+"', NumCasa='"+numcasa+"', NumCelular='"+numcelular+"', Email='"+email+"' where id="+id;
                }
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable BuscaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = "select * from Hospede where id=" + id;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void Excluir(int id)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn()))
            {
                string queryString = $"delete from Hospede where id=" + id;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
