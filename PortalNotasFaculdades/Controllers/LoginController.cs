using PortalNotasFaculdades.Models;
using System.Linq;
using System.Web.Mvc;

namespace PortalNotasFaculdades.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //GET: Login Coordenador
        public ActionResult Coordenador()
        {
            return View();
        }

        //GET: Login Professor
        public ActionResult Professor()
        {
            return View();
        }

        //GET: Login Aluno
        public ActionResult Aluno()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AuthorizeC(UsuariosFaculdades userModel)
        {
            using (PortalContext db = new PortalContext())
            {
                var userDetails = db.UsuariosFaculdades.Where(x => x.EmailUsuario == userModel.EmailUsuario && x.SenhaUsuario == userModel.SenhaUsuario).FirstOrDefault();
                try
                {
                    Session["UsuarioId"] = userDetails.UsuarioId;
                    Session["NomeUsuario"] = userDetails.NomeUsuario;
                    Session["Tipo"] = userDetails.Tipo;
                    Session["FaculdadeId"] = userDetails.FaculdadeId;
                    Session["EmailFaculdade"] = userDetails.EmailFaculdade;
                    //Session["NomeInstituicao"] = ;
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    Response.Write("<script>alert('Usuário ou Senha não encontrados!')</script>");
                    return View("Index");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AuthorizeP(Professores userModel)
        {
            using (PortalContext db = new PortalContext())
            {
                var userDetails = db.Professores.Where(x => x.EmailUsuario == userModel.EmailUsuario && x.CpfUsuario == userModel.CpfUsuario).FirstOrDefault();
                try
                {
                    Session["UsuarioId"] = userDetails.UsuarioId;
                    Session["NomeUsuario"] = userDetails.NomeCompleto;
                    Session["EmailUsuario"] = userDetails.EmailUsuario;
                    Session["Tipo"] = userDetails.Tipo;
                    Session["FaculdadeId"] = userDetails.FaculdadeId;
                    Session["EmailFaculdade"] = userDetails.EmailFaculdade;
                    Session["CursoIdUm"] = userDetails.CursoIdUm;
                    Session["CursoIdDois"] = userDetails.CursoIdDois;
                    ViewData["CursoIdUm"] = userDetails.CursoIdUm;
                    return RedirectToAction("Index", "Home");
                }
                catch
                {
                    Response.Write("<script>alert('Usuário ou Senha não encontrados!')</script>");
                    return View("Index");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AuthorizeA(Alunos userModel)
        {
            using (PortalContext db = new PortalContext())
            {
                var userDetails = db.Alunos.Where(x => x.EmailUsuario == userModel.EmailUsuario && x.CpfUsuario == userModel.CpfUsuario).FirstOrDefault();
                try
                {
                    Session["UsuarioId"] = userDetails.UsuarioId;
                    Session["NomeUsuario"] = userDetails.NomeCompleto;
                    Session["EmailUsuario"] = userDetails.EmailUsuario;
                    Session["Tipo"] = userDetails.Tipo;
                    //Session["NomeInstituicao"] = ;
                    return RedirectToAction("Index", "Home", userModel.UsuarioId);
                }
                catch
                {
                    Response.Write("<script>alert('Usuário ou Senha não encontrados!')</script>");
                    return View("Index");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["UsuarioId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}