using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace TestApplication.Controllers
{
    public class EstabelecimentoController : Controller
    {
        // GET: Estabelecimento
        public ActionResult Index()
        {
            List<Estabelecimento> EstabelecimentoList = new List<Estabelecimento>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EstoqueContext"].ConnectionString))
            {

                EstabelecimentoList = db.Query<Estabelecimento>("Select * From tblEstabelecimento").ToList();
            }
            return View(EstabelecimentoList);
            //return View();
        }
        //Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\liban\\Projeto\\TestApplication\\TestApplication\\App_Data\\bancoDeDados.mdf;Integrated Security=True
        //Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\bancoDeDados.mdf;Integrated Security=True;
        // GET: Estabelecimento/Details/5
        public ActionResult Details(int id)
        {
            Estabelecimento _estab = new Estabelecimento();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EstoqueContext"].ConnectionString))
            {
                _estab = db.Query<Estabelecimento>("Select * From tblEstabelecimento " +
                                       "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return View(_estab);
            //return View();
        }

        // GET: Estabelecimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estabelecimento/Create
        [HttpPost]
        public ActionResult Create(Estabelecimento collection)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EstoqueContext"].ConnectionString))

            {
                string sqlQuery;
                if (collection.status)
                {
                    sqlQuery = "Insert Into tblEstabelecimento (razaoSocial,nomeFantasia,cnpj,email,cidade,estado,telefone,dataCadastro,categoria,status,agencia,conta) Values('" + collection.razaoSocial + "','" + collection.nomeFantasia + "'," + collection.cnpj + ",'" + collection.email + "','" + collection.cidade + "','" + collection.estado + "'," + collection.telefone + ",'" + collection.dataCadastro + "'," + collection.categoria + ",1" + "," + collection.agencia + "," + collection.conta + ")";
                }
                else
                {
                    sqlQuery = "Insert Into tblEstabelecimento (razaoSocial,nomeFantasia,cnpj,email,cidade,estado,telefone,dataCadastro,categoria,status,agencia,conta) Values('" + collection.razaoSocial + "','" + collection.nomeFantasia + "'," + collection.cnpj + ",'" + collection.email + "','" + collection.cidade + "','" + collection.estado + "'," + collection.telefone + ",'" + collection.dataCadastro + "'," + collection.categoria + ",0" + "," + collection.agencia + "," + collection.conta + ")";
                }
                //string sqlQuery = $@"Insert Into tblEstabelecimento (razaoSocial,nomeFantasia,cnpj,email,cidade,estado,telefone,dataCadastro,categoria,status,agencia,conta) Values({collection.razaoSocial},{collection.nomeFantasia}, {collection.cnpj}, {collection.email},{collection.cidade},{collection.estado},{collection.telefone},{collection.dataCadastro},{collection.categoria},{collection.status},{collection.agencia},{collection.conta})";
                //string sqlQuery = $@"Insert Into tblEstabelecimento (razaoSocial,nomeFantasia,cnpj,email,cidade,estado,telefone,dataCadastro,categoria,status,agencia,conta) Values(@$collection)";
                //int rowsAffected = db.Execute(sqlQuery, collection);
                int rowsAffected = db.Execute(sqlQuery);
            }

            return RedirectToAction("Index");
            //try
            //{
                // TODO: Add insert logic here

             //   return RedirectToAction("Index");
            //}
            //catch
            //{
              //  return View();
           // }
        }

        // GET: Estabelecimento/Edit/5
        public ActionResult Edit(int id)
        {
            Estabelecimento estab = new Estabelecimento();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EstoqueContext"].ConnectionString))
            {
                estab = db.Query<Estabelecimento>("Select * From tblEstabelecimento " +
                                       "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return View(estab);
            //return View();
        }

        // POST: Estabelecimento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Estabelecimento collection)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EstoqueContext"].ConnectionString))

            {

                string sqlQuery = "update tblEstabelecimento set razaoSocial='" + collection.razaoSocial + "',nomeFantasia='" + collection.nomeFantasia + "',cnpj='" + collection.cnpj + "' where Id=" + collection.id;

                int rowsAffected = db.Execute(sqlQuery);
            }

            return RedirectToAction("Index");
            //try
            //{
            // TODO: Add update logic here

            //  return RedirectToAction("Index");
            //}
            //catch
            //{
            // return View();
            //}
        }

        // GET: Estabelecimento/Delete/5
        public ActionResult Delete(int id)
        {
            Estabelecimento estab = new Estabelecimento();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EstoqueContext"].ConnectionString))
            {
                estab = db.Query<Estabelecimento>("Select * From tblEstabelecimento " +
                                       "WHERE Id =" + id, new { id }).SingleOrDefault();
            }
            return View(estab);
            //return View();
        }

        // POST: Estabelecimento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["EstoqueContext"].ConnectionString))
            {
                string sqlQuery = "Delete From tblEstabelecimento WHERE Id = " + id;

                int rowsAffected = db.Execute(sqlQuery);


            }
            return RedirectToAction("Index");
            //try
            //{
            // TODO: Add delete logic here

            //  return RedirectToAction("Index");
            //}
            //catch
            //{
            //  return View();
            //}
        }
    }
}
