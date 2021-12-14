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
    public class MensajeController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection forms)
        {
            Mensaje mensaje = new Mensaje();

            mensaje.Id_mensaje1 = Convert.ToInt16(forms.Get("id_mensaje"));

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt16(forms.Get("id_usuario"));
            mensaje.Id_usuario1 = usuario;

            Chat chat = new Chat();
            chat.Id_chat1 = Convert.ToInt16(forms.Get("id_chat"));
            mensaje.Id_chat1 = chat;

            mensaje.Texto1 = forms.Get("texto");
            mensaje.Fecha_hora1 = Convert.ToDateTime(forms.Get("fecha_hora"));

            string[] respuesta = new string[2];
            respuesta[0] = mensaje.Update_Mensaje_BD();
            respuesta[1] = forms.Get("id_mensaje");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Mensaje mensaje = new Mensaje();

            mensaje.Id_mensaje1 = Convert.ToInt32(forms.Get("id_mensaje"));

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));
            mensaje.Id_usuario1 = usuario;

            Chat chat = new Chat();
            chat.Id_chat1 = Convert.ToInt32(forms.Get("id_chat"));
            mensaje.Id_chat1 = chat;

            mensaje.Texto1 = forms.Get("texto");
            mensaje.Fecha_hora1 = Convert.ToDateTime(forms.Get("fecha_hora"));

            string[] respuesta = new string[2];
            respuesta[0] = mensaje.Insert_Mensaje_BD();
            respuesta[1] = forms.Get("id_mensaje");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Mensaje mensaje = new Mensaje();

            Chat chat = new Chat();
            chat.Id_chat1 = Convert.ToInt32(forms.Get("id_chat"));
            mensaje.Id_chat1 = chat;

            string[] respuesta = new string[2];
            respuesta[0] = mensaje.Delete_Mensaje_BD();
            respuesta[1] = forms.Get("id_chat");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Mensaje mensaje = new Mensaje();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Mensaje>>(HttpStatusCode.Created, mensaje.Select_All_Mensaje_BD());
            return response;
        }
        public HttpResponseMessage Get([FromUri] int id, bool proceso)
        {
            if (proceso == true)
            {
                Mensaje mensaje = new Mensaje();
                Chat chat = new Chat();
                chat.Id_chat1 = id;
                mensaje.Id_chat1 = chat;

                HttpResponseMessage response = Request.CreateResponse<List<Models.Mensaje>>(HttpStatusCode.Created, mensaje.Select_MensajexChat());
                return response;
            }
            else {
            Mensaje mensaje = new Mensaje();
            mensaje.Id_mensaje1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.Mensaje>(HttpStatusCode.Created, mensaje.Select_Mensaje());
            return response;
            }
                
            
        }


    }
}
