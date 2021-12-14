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
    public class UsuarioController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection forms)
        {
            Usuario usuario = new Usuario();

            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));

            Institucion institucion = new Institucion();
            institucion.Id_institucion1 = Convert.ToInt32(forms.Get("id_institucion"));
            usuario.Id_institucion1 = institucion;

            usuario.Correo1 = forms.Get("correo");
            usuario.Nombre_usuario1 = forms.Get("nombre_usuario");
            usuario.Constraseña1 = forms.Get("contraseña");
            usuario.Foto1 = forms.Get("foto");
            usuario.Rol1 = forms.Get("rol");

            string[] respuesta = new string[2];
            respuesta[0] = usuario.Update_Usuario_BD();
            respuesta[1] = forms.Get("id_usuario");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Usuario usuario = new Usuario();

            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));

            Institucion institucion = new Institucion();
            institucion.Id_institucion1 = Convert.ToInt32(forms.Get("id_institucion"));
            usuario.Id_institucion1 = institucion;

            usuario.Correo1 = forms.Get("correo");
            usuario.Nombre_usuario1 = forms.Get("nombre_usuario");
            usuario.Constraseña1 = forms.Get("contraseña");
            usuario.Foto1 = forms.Get("foto");
            usuario.Rol1 = forms.Get("rol");

            string[] respuesta = new string[2];
            respuesta[0] = usuario.Insert_Usuario_BD();
            respuesta[1] = forms.Get("id_usuario");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Usuario usuario = new Usuario();

            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));

            string[] respuesta = new string[2];
            respuesta[0] = usuario.Delete_Usuario_BD();
            respuesta[1] = forms.Get("id_usuario");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Usuario usuario = new Usuario();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Usuario>>(HttpStatusCode.Created, usuario.Select_All_Usuario_BD());
            return response;
        }
        public HttpResponseMessage Get([FromUri] int id, bool proceso)
        {
            if(proceso==true){
                Usuario usuario = new Usuario();
                Institucion institucion = new Institucion();
                institucion.Id_institucion1 = id;
                usuario.Id_institucion1 = institucion;

                HttpResponseMessage response = Request.CreateResponse<List<Models.Usuario>>(HttpStatusCode.Created, usuario.Select_UsuarioxInstitucion());
                return response;
            }
            else
            {
                Usuario usuario = new Usuario();
                usuario.Id_usuario1 = id;

                HttpResponseMessage response = Request.CreateResponse<Models.Usuario>(HttpStatusCode.Created, usuario.Select_Usuario());
                return response;
            }

        }
        
    }
}
