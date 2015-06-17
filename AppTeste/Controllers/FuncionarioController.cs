using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppTeste.Models;

namespace AppTeste.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {

            var funcionario = new Funcionario()
            {
                Nome = "Fábio Jansen",
                FuncionarioId = 1,
                Matricula = "000123",
                
                
            };

            funcionario.Contracheque = funcionario.Matricula;

            TempData["FuncionarioContracheque"] = funcionario.Contracheque;
            
            return View(funcionario);
        }

        public ActionResult VerContracheque(string filename)
        {

            var fileStream = new FileStream("d:/contracheque/" + TempData["FuncionarioContracheque"] + ".pdf",
                                 FileMode.Open,
                                 FileAccess.Read
                               );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            TempData.Keep();
            return fsResult;
         }
    }
}