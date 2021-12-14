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
    public class ExpedienteController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection forms)
        {
            Expediente expediente = new Expediente();

            expediente.Id_expediente1 = Convert.ToInt16(forms.Get("id_expediente"));

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt16(forms.Get("id_usuario"));
            expediente.Id_usuario1 = usuario;
;
            expediente.Fecha_realizacion1 = Convert.ToDateTime(forms.Get("fecha_realizacion"));


            string[] respuesta = new string[2];
            respuesta[0] = expediente.Update_Expediente_BD();
            respuesta[1] = forms.Get("id_expediente");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Expediente expediente = new Expediente();

            expediente.Id_expediente1 = Convert.ToInt32(forms.Get("id_expediente"));

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));
            expediente.Id_usuario1 = usuario;
            ;
            expediente.Fecha_realizacion1 = Convert.ToDateTime(forms.Get("fecha_realizacion"));

            string[] respuesta = new string[2];
            respuesta[0] = expediente.Insert_Expediente_BD();
            respuesta[1] = forms.Get("id_expediente");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Expediente expediente = new Expediente();

            expediente.Id_expediente1 = Convert.ToInt16(forms.Get("id_expediente"));

            string[] respuesta = new string[2];
            respuesta[0] = expediente.Delete_Expediente_BD();
            respuesta[1] = forms.Get("id_expediente");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Expediente expediente = new Expediente();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Expediente>>(HttpStatusCode.Created, expediente.Select_All_Expediente_BD());
            return response;
        }
        public HttpResponseMessage Get([FromUri] int id)
        {
            Expediente expediente = new Expediente();
            expediente.Id_expediente1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.Expediente>(HttpStatusCode.Created, expediente.Select_Expediente());
            return response;
        }
    }
}
