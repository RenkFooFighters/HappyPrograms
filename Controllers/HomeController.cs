using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendaTelefonica.Models;
using AgendaTelefonica.Models.Entidades;

namespace AgendaTelefonica.Controllers
{
    public class HomeController : Controller
    {
        #region INSTÂNCIA DE CLASSES
        private ConexaoBanco conexao = new ConexaoBanco();
        private ActionClientes clActionClientes = new ActionClientes();
        private static Clientes clie;
        #endregion

        //Página principal
        public ActionResult Index()
        {
            return View(clActionClientes.GetAll());
        }

        //Criar clientes
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clientes clientes)
        {
            clActionClientes.Cadastrar(clientes);

            return View(clientes);
        }
        //

        //Alteração de informações do cliente
        [HttpGet]
        public ActionResult Update(int id)
        {
            clie = clActionClientes.GetById(id);

            return View(clie);
        }

        [HttpPost]
        public ActionResult Update(Clientes clientes)
        {

            clActionClientes.Update(clientes);

            return RedirectToAction("Index");

            
        }
        //

        //Deleta um cliente específico
        [HttpGet]
        public ActionResult Deletar(int id)
        {
            clActionClientes.DeletarById(id);

            return RedirectToAction("Index");
        }
        //

        //Abre a agenda de telefones
        public ActionResult Agenda()
        {
            return View(clActionClientes.GetAll());
        }
        //

        //Realiza update na agenda telefônica
        [HttpGet]
        public ActionResult UpdateTelefone(int id)
        {
           clie = clActionClientes.GetById(id);
           return View(clie);
         
        }

        [HttpPost]
        public ActionResult UpdateTelefone(Clientes clientes)
        {
            clActionClientes.Update(clientes);

            return RedirectToAction("Agenda");

        }
        //


    }
}