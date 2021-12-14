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
    public class ChatController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection forms)
        {
            Chat chat = new Chat();

            chat.Id_chat1 = Convert.ToInt32(forms.Get("id_chat"));

            Usuario usuario1 = new Usuario();
            usuario1.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuarioI"));
            chat.Id_usuarioI1 = usuario1;

            Usuario usuario2 = new Usuario();
            usuario2.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuarioII"));
            chat.Id_usuarioII1 = usuario2;


            string[] respuesta = new string[2];
            respuesta[0] = chat.Update_Chat_BD();
            respuesta[1] = forms.Get("id_chat");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Chat chat = new Chat();

            chat.Id_chat1 = Convert.ToInt32(forms.Get("id_chat"));

            Usuario usuario1 = new Usuario();
            usuario1.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuarioI"));
            chat.Id_usuarioI1 = usuario1;

            Usuario usuario2 = new Usuario();
            usuario2.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuarioII"));
            chat.Id_usuarioII1 = usuario2;

            string[] respuesta = new string[2];
            respuesta[0] = chat.Insert_Chat_BD();
            respuesta[1] = forms.Get("id_chat");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Chat chat = new Chat();

            chat.Id_chat1 = Convert.ToInt32(forms.Get("id_chat"));

            string[] respuesta = new string[2];
            respuesta[0] = chat.Delete_Chat_BD();
            respuesta[1] = forms.Get("id_chat");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Chat chat = new Chat();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Chat>>(HttpStatusCode.Created, chat.Select_All_Chat_BD());
            return response;
        }
        public HttpResponseMessage Get([FromUri] int id, bool proceso)
        {
            if(proceso == true)
            {
                Chat chat = new Chat();
                Usuario usuario = new Usuario();
                usuario.Id_usuario1 = id;
                chat.Id_usuarioI1 = usuario;
                chat.Id_usuarioII1 = usuario;

                HttpResponseMessage response = Request.CreateResponse<List<Models.Chat>>(HttpStatusCode.Created, chat.Select_ChatxUsuario());
                return response;
            }
            else
            {
            Chat chat = new Chat();
            chat.Id_chat1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.Chat>(HttpStatusCode.Created, chat.Select_Chat());
            return response;
            }
            
        }

    }
}
