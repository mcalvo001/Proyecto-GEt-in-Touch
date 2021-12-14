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
    public class InstitucionController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection forms)
        {
            Institucion institucion = new Institucion();

            institucion.Id_institucion1 = Convert.ToInt16(forms.Get("id_institucion"));
            institucion.Nombre_institucion1 = forms.Get("nombre_institucion");
            institucion.Email1 = forms.Get("email");
            institucion.Telefonol1 = forms.Get("telefono");
            institucion.Tipo1 =forms.Get("tipo");
            institucion.Foto1 = forms.Get("foto");

            string[] respuesta = new string[2];
            respuesta[0] = institucion.Update_Institucion_BD();
            respuesta[1] = forms.Get("id_institucion");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Institucion institucion = new Institucion();

            institucion.Id_institucion1 = Convert.ToInt16(forms.Get("id_institucion"));
            institucion.Nombre_institucion1 = forms.Get("nombre_institucion");
            institucion.Email1 = forms.Get("email");
            institucion.Telefonol1 = forms.Get("telefono");
            institucion.Tipo1 = forms.Get("tipo");
            institucion.Foto1 = forms.Get("foto");

            string[] respuesta = new string[2];
            respuesta[0] = institucion.Insert_Institucion_BD();
            respuesta[1] = forms.Get("id_asignacion");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Institucion institucion = new Institucion();

            institucion.Id_institucion1 = Convert.ToInt16(forms.Get("id_institucion"));

            string[] respuesta = new string[2];
            respuesta[0] = institucion.Delete_Institucion_BD();
            respuesta[1] = forms.Get("id_asignacion");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Institucion institucion = new Institucion();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Institucion>>(HttpStatusCode.Created, institucion.Select_All_Institucion_BD());
            return response;
        }
        public HttpResponseMessage Get([FromUri] int id)
        {
            Institucion institucion = new Institucion();
            institucion.Id_institucion1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.Institucion>(HttpStatusCode.Created, institucion.Select_Institucion());
            return response;
        }
    }
}
