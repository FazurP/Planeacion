using AppPlaneacionDocente.Data;
using AppPlaneacionDocente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPlaneacionDocente.Controllers
{
    public class IndexController : Controller
    {

        private PlaneacionEntities context = new PlaneacionEntities();

        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.idCatGrado = new SelectList(GetAllGrados(),"id","strValor");
            ViewBag.idCatMateria = new SelectList(GetAllMaterias(),"id","strValor");
            ViewBag.idCatCicloEscolar = new SelectList(GetAllCicloEscolar(),"id","strValor");
            ViewBag.idCatPeriodo = new SelectList(GetAllPeriodos(),"id","strValor");
            ViewBag.idCatGrupos = new SelectList("");
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarPlaneacion(Planeacion planeacion)
        {
            if (planeacion != null)
            {
                TblPlaneacion tblPlaneacion = new TblPlaneacion();

                tblPlaneacion.idCatCicloEscolar = planeacion.idCatCicloEscolar;
                tblPlaneacion.idCatGrado = planeacion.idCatGrado;
                tblPlaneacion.idCatGrupos = planeacion.idCatGrupos;
                tblPlaneacion.idCatMaterias = planeacion.idCatMateria;
                tblPlaneacion.idCatPeriodo = planeacion.idCatPeriodo;
                tblPlaneacion.TblObjetosAprendizaje = new TblObjetosAprendizaje { strAprendizajeEsperado = planeacion.objetosAprendizaje.strAprendizajeEsperado };
                tblPlaneacion.strBloques = planeacion.strBloques;
                tblPlaneacion.strCompetenciaDesarrollar = planeacion.strCompetenciaDesarrollar;
                tblPlaneacion.strContextoEscuela = planeacion.strContextoEscuela;
                tblPlaneacion.strCriteriosDesempeño = planeacion.strCriteriosDesempeño;
                tblPlaneacion.strCriteriosEvaluacion = planeacion.strCriteriosEvaluacion;
                tblPlaneacion.strDesempeñoEstudianteConcluirBloque = planeacion.strDesempeñoEstudianteConcluirBloque;
                tblPlaneacion.strDiagnosticoSocioEducativo = planeacion.strDiagnosticoSocioEducativo;
                tblPlaneacion.strInstitucion = planeacion.strInstitucion;
                tblPlaneacion.strTotalHoras = planeacion.strTotalHoras;
                tblPlaneacion.strTotalSesiones = planeacion.strTotalSesiones;

                context.TblPlaneacion.Add(tblPlaneacion);
                context.SaveChanges();
            }
            return RedirectToAction("Index","Index");
        }

        [HttpGet]
        public ActionResult GenerarPlanClase()
        {
            List<TblPlaneacion> planeaciones = new List<TblPlaneacion>();
            List<Planeacion> planeacions = new List<Planeacion>();

            planeaciones = context.TblPlaneacion.ToList();

            foreach (TblPlaneacion item in planeaciones)
            {
                Planeacion planeacion = new Planeacion();
                planeacion.id = item.id;
                planeacion.cicloEscolar = new CicloEscolar { strValor = item.CatCicloEscolar.strValor };
                planeacion.grupo = new Grupo { strValor = item.CatGrupos.strValor };
                planeacion.grupo.grado = new Grado { strValor = item.CatGrupos.CatGrado.strValor };
                planeacion.materia = new Materia { strValor = item.CatMateria.strValor };
                planeacion.periodo = new Periodo { strValor = item.CatPeriodo.strValor};

                planeacions.Add(planeacion);
            }

            return View(planeacions);
        }

        public List<Grado> GetAllGrados()
        {
            List<Grado> grados = new List<Grado>();

            //Select * from CatGrado;
            List<CatGrado> catGrados = context.CatGrado.ToList();

            foreach (CatGrado item in catGrados)
            {
                Grado grado = new Grado();

                grado.id = item.id;
                grado.strValor = item.strValor;

                grados.Add(grado);
            }
            Grado grado1 = new Grado();

            grado1.id = 0;
            grado1.strValor = "Seleccionar";
            grados.Insert(0,grado1);
            return grados;
        }

        public List<Materia> GetAllMaterias()
        {
            List<CatMateria> catMaterias = context.CatMateria.ToList();
            List<Materia> materias = new List<Materia>();

            foreach (CatMateria item in catMaterias)
            {
                Materia materia = new Materia();

                materia.id = item.id;
                materia.strValor = item.strValor;

                materias.Add(materia);
            }

            Materia materia1 = new Materia();

            materia1.id = 0;
            materia1.strValor = "Seleccionar";

            materias.Insert(0,materia1);

            return materias;
        }

        public List<CicloEscolar> GetAllCicloEscolar()
        {
            List<CicloEscolar> cicloEscolars = new List<CicloEscolar>();
            List<CatCicloEscolar> catCicloEscolars = context.CatCicloEscolar.ToList();

            foreach (CatCicloEscolar item in catCicloEscolars)
            {
                CicloEscolar cicloEscolar = new CicloEscolar();

                cicloEscolar.id = item.id;
                cicloEscolar.strValor = item.strValor;

                cicloEscolars.Add(cicloEscolar);
            }

            CicloEscolar cicloEscolar1 = new CicloEscolar();

            cicloEscolar1.id = 1;
            cicloEscolar1.strValor = "Seleccionar";

            cicloEscolars.Insert(0,cicloEscolar1);

            return cicloEscolars;
        }

        public List<Periodo> GetAllPeriodos()
        {
            List<Periodo> periodos = new List<Periodo>();
            List<CatPeriodo> catPeriodos = context.CatPeriodo.ToList();

            foreach (CatPeriodo item in catPeriodos)
            {
                Periodo periodo = new Periodo();

                periodo.id = item.id;
                periodo.strValor = item.strValor;

                periodos.Add(periodo);
            }

            Periodo periodo1 = new Periodo();

            periodo1.id = 0;
            periodo1.strValor = "Seleccionar";

            periodos.Insert(0,periodo1);

            return periodos;
        }

        public ActionResult GetAllGruposByGrado(int _idGrado)
        {
            List<Grupo> grupos = new List<Grupo>();
            List<CatGrupos> catGrupos = context.CatGrupos.Where(p => p.idCatGrado == _idGrado).ToList();

            foreach (CatGrupos item in catGrupos)
            {
                Grupo grupo = new Grupo();

                grupo.id = item.id;
                grupo.strValor = item.strValor;

                grupos.Add(grupo);
            }

            Grupo grupo1 = new Grupo();

            grupo1.id = 0;
            grupo1.strValor = "Seleccionar";

            grupos.Insert(0,grupo1);

            ViewBag.idCatGrupos = new SelectList(grupos,"id","strValor");
            return PartialView("_Grupos");
        }
        public ActionResult ShowPlanClase(int _idPlaneacion)
        {
            return PartialView("_ShowPlanClase");
        }

        public ActionResult SavePlanClase()
        {
            return RedirectToAction("GenerarPlanClase","Index");
        }
    }
}