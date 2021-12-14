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
    public class Usuario_ArticulosController : ApiController
    {
        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Usuario_Articulos usuario_articulos = new Usuario_Articulos();

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));
            usuario_articulos.Id_usuario1 = usuario;

            Articulo articulo = new Articulo();
            articulo.Id_articulo1 = Convert.ToInt32(forms.Get("id_articulo"));
            usuario_articulos.Id_articulo1 = articulo;

            string[] respuesta = new string[3];
            respuesta[0] = usuario_articulos.Insert_Usuario_Articulos_BD();
            respuesta[1] = forms.Get("id_usuario");
            respuesta[2] = forms.Get("id_articulo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Usuario_Articulos usuario_articulos = new Usuario_Articulos();

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));
            usuario_articulos.Id_usuario1 = usuario;

            Articulo articulo = new Articulo();
            articulo.Id_articulo1 = Convert.ToInt32(forms.Get("id_articulo"));
            usuario_articulos.Id_articulo1 = articulo;

            string[] respuesta = new string[3];
            respuesta[0] = usuario_articulos.Delete_Usuario_Articulos_BD();
            respuesta[1] = forms.Get("id_usuario");
            respuesta[2] = forms.Get("id_articulo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] int id)
        {
            Usuario_Articulos usuario_articulos = new Usuario_Articulos();
                
            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = id;
            usuario_articulos.Id_usuario1 = usuario;

                HttpResponseMessage response = Request.CreateResponse<List<Models.Usuario_Articulos>>(HttpStatusCode.Created, usuario_articulos.Select_Articulos_x_Usuarios());
                return response;
        }

    }
}
