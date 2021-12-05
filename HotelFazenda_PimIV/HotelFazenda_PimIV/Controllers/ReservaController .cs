using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelFazenda_PimIV.Controllers
{
    public class ReservaController : Controller
    {
        public ActionResult Consulta()
        {
            ViewBag.Paginas = new Pagina().Lista();
            return View();
        }

        public ActionResult NovaReserva()
        {
            return View();
        }

        [HttpPost]
        public void CriarReserva()
        {
            DateTime dataNascimento;
            DateTime.TryParse(Request["datanascimento"], out dataNascimento);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.CPF = Request["cpf"];
            pagina.Sexo = Request["sexo"];
            pagina.DataNascimento = dataNascimento;
            pagina.PossuiPcD = Request["possuipcd"];
            pagina.CEP = Request["cep"];
            pagina.NumCasa = Request["numcasa"];
            pagina.NumCelular = Request["numcelular"];
            pagina.Email = Request["email"];
            pagina.Save();
            Response.Redirect("/Consulta");
        }

        public ActionResult EditarReserva(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }

        [HttpPost]
        public void AlterarReserva(int id)
        {
            try
            {
                var pagina = Pagina.BuscaPorId(id);

                DateTime dataNascimento;
                DateTime.TryParse(Request["datanascimento"], out dataNascimento);

                pagina.Nome = Request["nome"];
                pagina.CPF = Request["cpf"];
                pagina.Sexo = Request["sexo"];
                pagina.DataNascimento = dataNascimento;
                pagina.PossuiPcD = Request["possuipcd"];
                pagina.CEP = Request["cep"];
                pagina.NumCasa = Request["numcasa"];
                pagina.NumCelular = Request["numcelular"];
                pagina.Email = Request["email"];

                pagina.Save();
            }
            catch
            {
                TempData["Sucesso"] = "Página não pode ser alterada";
            }
            Response.Redirect("/Consulta");
        }


        public void ExcluirReserva(int id)
        {
            Pagina.Excluir(id);
            Response.Redirect("/Consulta");
        }

    }
}