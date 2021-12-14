using GETinTouch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
namespace GETinTouch.Controllers
{
    public class EvaluacionController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection forms)
        {
            Evaluacion evaluacion = new Evaluacion();

            evaluacion.Id_evaluacion1 = Convert.ToInt32(forms.Get("id_evaluacion"));

            Expediente expediente = new Expediente();
            expediente.Id_expediente1 = Convert.ToInt32(forms.Get("id_expediente"));
            evaluacion.Id_expediente1 = expediente;

            evaluacion.Resultado1 = forms.Get("id_resultado");

            string[] respuesta = new string[2];
            respuesta[0] = evaluacion.Update_Evaluacion_BD();
            respuesta[1] = forms.Get("id_evaluacion");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Evaluacion evaluacion = new Evaluacion();

            evaluacion.Id_evaluacion1 = Convert.ToInt32(forms.Get("id_evaluacion"));

            Expediente expediente = new Expediente();
            expediente.Id_expediente1 = Convert.ToInt32(forms.Get("id_expediente"));
            evaluacion.Id_expediente1 = expediente;

            evaluacion.Resultado1 = Convert.ToString(forms.Get("resultado"));

            string[] respuesta = new string[2];
            respuesta[0] = evaluacion.Insert_Evaluacion_BD();
            respuesta[1] = forms.Get("id_evaluacion");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Evaluacion evaluacion = new Evaluacion();

            evaluacion.Id_evaluacion1 = Convert.ToInt32(forms.Get("id_evaluacion"));

            string[] respuesta = new string[2];
            respuesta[0] = evaluacion.Delete_Evaluacion_BD();
            respuesta[1] = forms.Get("id_evaluacion");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Evaluacion evaluacion = new Evaluacion();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Evaluacion>>(HttpStatusCode.Created, evaluacion.Select_All_Evaluacion_BD());
            return response;
        }
        public HttpResponseMessage Get([FromUri] int id)
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.Id_evaluacion1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.Evaluacion>(HttpStatusCode.Created, evaluacion.Select_Evaluacion());
            return response;
        }

    }
}
