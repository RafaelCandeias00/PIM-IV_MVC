using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Pagina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string PossuiPcD { get; set; }
        public string CEP { get; set; }
        public string NumCasa { get; set; }
        public string NumCelular { get; set; }
        public string Email { get; set; }

        public List<Pagina> Lista()
        {
            var lista = new List<Pagina>();
            var paginaDb = new Database.Pagina();
            foreach (DataRow row in paginaDb.Lista().Rows)
            {
                var pagina = new Pagina();
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.CPF = row["cpf"].ToString();
                pagina.Sexo = row["sexo"].ToString();
                pagina.DataNascimento = Convert.ToDateTime(row["datanascimento"]);
                pagina.PossuiPcD = row["possuipcd"].ToString();
                pagina.CEP = row["cep"].ToString();
                pagina.NumCasa = row["numcasa"].ToString();
                pagina.NumCelular = row["numcelular"].ToString();
                pagina.Email = row["email"].ToString();

                lista.Add(pagina);
            }

            return lista;
        }

        public static Pagina BuscaPorId(int id)
        {
            var pagina = new Pagina();
            var paginaDb = new Database.Pagina();
            foreach (DataRow row in paginaDb.BuscaPorId(id).Rows)
            {
                pagina.Id = Convert.ToInt32(row["id"]);
                pagina.Nome = row["nome"].ToString();
                pagina.CPF = row["cpf"].ToString();
                pagina.Sexo = row["sexo"].ToString();
                pagina.DataNascimento = Convert.ToDateTime(row["datanascimento"]);
                pagina.PossuiPcD = row["possuipcd"].ToString();
                pagina.CEP = row["cep"].ToString();
                pagina.NumCasa = row["numcasa"].ToString();
                pagina.NumCelular = row["numcelular"].ToString();
                pagina.Email = row["email"].ToString();
            }

            return pagina;
        }

        public void Save()
        {
            new Database.Pagina().Salvar(
                this.Id, 
                this.Nome, 
                this.CPF, 
                this.Sexo, 
                this.DataNascimento, 
                this.PossuiPcD, 
                this.CEP, 
                this.NumCasa, 
                this.NumCelular, 
                this.Email
                );
        }

        public static void Excluir(int id)
        {
            new Database.Pagina().Excluir(id);
        }
    }
}
