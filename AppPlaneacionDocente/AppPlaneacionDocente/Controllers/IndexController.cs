using AppPlaneacionDocente.Data;
using AppPlaneacionDocente.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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
            TblPlanDeClase tblPlanDeClase = new TblPlanDeClase();
            tblPlanDeClase.idPlaneacion = _idPlaneacion;
            return PartialView("_ShowPlanClase", tblPlanDeClase);
        }

        public ActionResult SavePlanClase(TblPlanDeClase tblPlanDeClase)
        {
            if (tblPlanDeClase != null)
            {
                TblPlanDeClase obj = new TblPlanDeClase();
                obj = context.TblPlanDeClase.Where(p => p.idPlaneacion == tblPlanDeClase.idPlaneacion).FirstOrDefault();
                if (obj == null)
                {
                    tblPlanDeClase.strBibliografia = tblPlanDeClase.strBibliografia;
                    tblPlanDeClase.strObservaciones = tblPlanDeClase.strObservaciones;
                    tblPlanDeClase.idPlaneacion = tblPlanDeClase.idPlaneacion;
                    context.TblPlanDeClase.Add(tblPlanDeClase);
                    context.SaveChanges();
                }   

            }



            return RedirectToAction("GenerarPlanClase","Index");
        }

        public void DeletePlaneacion(int _idPlaneacion)
        {
            if (_idPlaneacion > 0)
            {
                TblPlaneacion planeacion = new TblPlaneacion();

                planeacion = context.TblPlaneacion.FirstOrDefault(p => p.id == _idPlaneacion);
                context.TblPlaneacion.Remove(planeacion);
                context.SaveChanges();
            }
        }

        public FileResult Planeacion(int _idPlaneacion)
        {
            byte[] abytes = GeneratePlaneacion(_idPlaneacion);

            return File(abytes, "application/pdf", "PlaneacionEMS" + DateTime.Now + ".pdf");
            //return File(abytes, "application/pdf");
        }

        int totalColumn = 8;
        Document document;
        Font font;
        PdfPTable pdfPTable = new PdfPTable(8);
        PdfPTable stable = new PdfPTable(7);
        PdfPCell pdfPCell;
        MemoryStream memoryStream = new MemoryStream();

        private byte[] GeneratePlaneacion(int _idPlaneacion)
        {

            TblPlanDeClase tblPlanDeClase = new TblPlanDeClase();

            tblPlanDeClase = context.TblPlanDeClase.FirstOrDefault(p => p.idPlaneacion == _idPlaneacion);

            if (tblPlanDeClase != null)
            {
                document = new Document(PageSize.A4.Rotate(), 0, 0, 0, 0);
                document.SetPageSize(PageSize.A4.Rotate());
                document.SetMargins(20f, 20f, 20f, 20f);

                pdfPTable.WidthPercentage = 100;
                pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;

                stable.WidthPercentage = 100;
                stable.HorizontalAlignment = Element.ALIGN_LEFT;
                font = FontFactory.GetFont("Tahoma", 8f, 1);
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                pdfPTable.SetWidths(new float[] { 12.5f, 12.5f, 12.5f, 12.5f, 12.5f, 12.5f, 12.5f, 12.5f, });
                stable.SetWidths(new float[] { 14.28f, 7.28f, 25.28f, 13.28f, 13.28f, 13.28f, 13.28f });

                this.ReportHeader();
                this.ReportBody(tblPlanDeClase);
                pdfPTable.HeaderRows = 1;
                document.Add(pdfPTable);
                document.NewPage();
                document.Add(stable);
                document.Close();

                return memoryStream.ToArray();
            }
            else
            {
                Document errorDocumento = new Document(PageSize.A4.Rotate(),0,0,0,0);
                PdfPTable errortable = new PdfPTable(1);
                PdfPCell cellError;
                MemoryStream memoryStreamError = new MemoryStream();
                Font font;
                errortable.WidthPercentage = 100;
                font = FontFactory.GetFont("Tahoma", 24, 1, BaseColor.RED);
                PdfWriter.GetInstance(errorDocumento,memoryStreamError);
                errorDocumento.Open();
                cellError = new PdfPCell(new Phrase("ERROR, GENERA EL PLAN DE CLASE PARA PODER GENERAR LA PLANEACIÓN.",font));
                cellError.Border = 0;
                errortable.AddCell(cellError);
                errorDocumento.Add(errortable);
                errorDocumento.Close();

                return memoryStreamError.ToArray();
            }
         

           
        }

        private void ReportHeader()
        {
            font = FontFactory.GetFont("Tahoma",14f,1);
            pdfPCell = new PdfPCell(new Phrase("Formato de Planeación para la Educación Media Superior",font));
            pdfPCell.Colspan = totalColumn;
            pdfPCell.PaddingBottom = 30;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();
        }

        private void ReportBody(TblPlanDeClase tblPlanDeClase)
        {
            font = FontFactory.GetFont("Tahoma", 10f,1, BaseColor.WHITE);

            #region Primera Pagina: Planeacion
            //Primer Fila

            pdfPCell = new PdfPCell(new Phrase("Institución:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.strInstitucion));
            pdfPCell.Colspan = 7;
            pdfPCell.Padding = 10f;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Segundo Fila

            pdfPCell = new PdfPCell(new Phrase("Semestre:",font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.CatGrupos.CatGrado.strValor));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Asignatura:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.CatMateria.strValor));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Ciclo Escolar:",font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.CatCicloEscolar.strValor));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Periodo de Aplicación:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.CatPeriodo.strValor));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Tercera Fila

            pdfPCell = new PdfPCell(new Phrase("Profesor:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Fazur Alejandro Estrada Ponce"));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Grupo:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.CatGrupos.strValor));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Total de Sesiones:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.strTotalSesiones));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase("Total de Horas Programadas:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.strTotalHoras));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Cuarta Fila

            pdfPCell = new PdfPCell(new Phrase("Contexto de la Escuela:", font));
            pdfPCell.Colspan = 1;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.strContextoEscuela));
            pdfPCell.Colspan = 7;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Quinta Fila

            pdfPCell = new PdfPCell(new Phrase("Diagnostico Socioeducativo:", font));
            pdfPCell.Colspan = 8;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Sexta Fila

            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.strDiagnosticoSocioEducativo));
            pdfPCell.Colspan = 8;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Septima Fila

            pdfPCell = new PdfPCell(new Phrase("Competencias a Desarrollar:", font));
            pdfPCell.Colspan = 8;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Octava Fila

            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.strCompetenciaDesarrollar));
            pdfPCell.Colspan = 8;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Novena Fila

            pdfPCell = new PdfPCell(new Phrase("Desempeños del Estudiante al Concluir el Bloque:", font));
            pdfPCell.Colspan = 4;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Objetos de Aprendizaje:", font));
            pdfPCell.Colspan = 4;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            //Decima Fila

            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.strDesempeñoEstudianteConcluirBloque));
            pdfPCell.Colspan = 4;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(tblPlanDeClase.TblPlaneacion.TblObjetosAprendizaje.strAprendizajeEsperado));
            pdfPCell.Colspan = 4;
            pdfPCell.Padding = 10f;
            pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            #endregion

            #region Segundo Pagina: Plan de Clase

            if (tblPlanDeClase.id > 0 && tblPlanDeClase.idActividadesEnseñanzaAprendizaje > 0 && tblPlanDeClase.idAtributos > 0 && tblPlanDeClase.idEstrategiasIntervencion > 0
                && tblPlanDeClase.idEvidenciaAprendizaje > 0 && tblPlanDeClase.idInstrumentosEvaluacion > 0 && tblPlanDeClase.idMateriasRecursosDidacticos > 0
                && tblPlanDeClase.idPlaneacion > 0 && tblPlanDeClase.idTiempo > 0 && tblPlanDeClase.strBibliografia != String.Empty && tblPlanDeClase.strObservaciones != String.Empty)
            {
                font = FontFactory.GetFont("Tahoma", 12f, 1, BaseColor.WHITE);

                pdfPCell = new PdfPCell(new Phrase("PLAN DE CLASE", font));
                pdfPCell.Colspan = 7;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                stable.CompleteRow();

                font = FontFactory.GetFont("Tahoma",10f,1,BaseColor.WHITE);

                //Segunda Fila

                pdfPCell = new PdfPCell(new Phrase("Actividades de Enseñanza-Aprendizaje",font));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Tiempo", font));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Atributos de las competencias genericas, competencias disciplinares y/o profesionales" +
                    " que se favorecenen su desarrollo con las actividades.", font));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Evidencias de Aprendizaje", font));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Instrumentos de Evaluación", font));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Estrategias de Intervención", font));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase("Material y Recursos Didacticos", font));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = new BaseColor(102, 102, 255);
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                stable.CompleteRow();

                //Tercera Fila

                pdfPCell = new PdfPCell(new Phrase("Apertura: "
                    +Environment.NewLine
                    +Environment.NewLine 
                    + tblPlanDeClase.TblActividadesEnseñanzaAprendizaje.strApertura));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine 
                    + Environment.NewLine 
                    + tblPlanDeClase.TblTiempo.strApertura));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblAtributos.strApertura));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblEvidenciaAprendizaje.strApertura));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblInstrumentosEvaluacion.strApertura));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblEstrategiasIntervencion.strApertura));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblMaterialRecursosDidacticos.strApertura));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                stable.CompleteRow();

                //Cuarta Fila

                pdfPCell = new PdfPCell(new Phrase("Desarrollo: "
                      + Environment.NewLine
                      + Environment.NewLine
                      + tblPlanDeClase.TblActividadesEnseñanzaAprendizaje.strDesarrollo));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                    + Environment.NewLine
                    + tblPlanDeClase.TblTiempo.strDesarrollo));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblAtributos.strDesarrollo));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblEvidenciaAprendizaje.strDesarrollo));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblInstrumentosEvaluacion.strDesarrollo));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblEstrategiasIntervencion.strDesarrollo));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblMaterialRecursosDidacticos.strDesarrollo));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                stable.CompleteRow();


                //Quinta Fila

                pdfPCell = new PdfPCell(new Phrase("Desarrollo: "
                       + Environment.NewLine
                       + Environment.NewLine
                       + tblPlanDeClase.TblActividadesEnseñanzaAprendizaje.strCierre));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                    + Environment.NewLine
                    + tblPlanDeClase.TblTiempo.strCierre));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblAtributos.strCierre));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblEvidenciaAprendizaje.strCierre));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblInstrumentosEvaluacion.strCierre));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblEstrategiasIntervencion.strCierre));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                pdfPCell = new PdfPCell(new Phrase(Environment.NewLine
                  + Environment.NewLine
                  + tblPlanDeClase.TblMaterialRecursosDidacticos.strCierre));
                pdfPCell.Colspan = 1;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                stable.CompleteRow();

                //Sexta Fila

                pdfPCell = new PdfPCell(new Phrase("Bibliografia: "
                         + Environment.NewLine
                         + Environment.NewLine
                         + tblPlanDeClase.strBibliografia));
                pdfPCell.Colspan = 7;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                stable.CompleteRow();

                //Septima Fila

                pdfPCell = new PdfPCell(new Phrase("Observaciones: "
                           + Environment.NewLine
                           + Environment.NewLine
                           + tblPlanDeClase.strObservaciones));
                pdfPCell.Colspan = 7;
                pdfPCell.Padding = 10f;
                pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfPCell.VerticalAlignment = Element.ALIGN_CENTER;
                pdfPCell.ExtraParagraphSpace = 0;
                stable.AddCell(pdfPCell);
                stable.CompleteRow();
            }

            #endregion
        }

    }
}