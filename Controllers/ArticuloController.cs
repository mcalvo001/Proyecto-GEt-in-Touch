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
    public class ArticuloController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection forms)
        {
            Articulo articulo = new Articulo();

            articulo.Id_articulo1 = Convert.ToInt32(forms.Get("id_articulo"));

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));
            articulo.Autor1 = usuario;

            articulo.Nombre_articulo1 = forms.Get("nombre_articulo");
            articulo.Fecha_publicacion1 = Convert.ToDateTime(forms.Get("fecha_publicacion"));
            articulo.Text1 = forms.Get("texto");
            articulo.Foto1 = forms.Get("foto");

            string[] respuesta = new string[2];
            respuesta[0] = articulo.Update_Articulo_BD();
            respuesta[1] = forms.Get("id_articulo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection forms)
        {
            Articulo articulo = new Articulo();

            articulo.Id_articulo1 = Convert.ToInt32(forms.Get("id_articulo"));

            Usuario usuario = new Usuario();
            usuario.Id_usuario1 = Convert.ToInt32(forms.Get("id_usuario"));
            articulo.Autor1 = usuario;

            articulo.Nombre_articulo1 = forms.Get("nombre_articulo");
            articulo.Fecha_publicacion1 = Convert.ToDateTime(forms.Get("fecha_publicacion"));
            articulo.Text1 = forms.Get("texto");
            articulo.Foto1 = forms.Get("foto");


            string[] respuesta = new string[2];
            respuesta[0] = articulo.Insert_Articulo_BD();
            respuesta[1] = forms.Get("id_articulo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection forms)
        {
            Articulo articulo = new Articulo();

            articulo.Id_articulo1 = Convert.ToInt16(forms.Get("id_articulo"));

            string[] respuesta = new string[2];
            respuesta[0] = articulo.Delete_Articulo_BD();
            respuesta[1] = forms.Get("id_articulo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Articulo articulo = new Articulo();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Articulo>>(HttpStatusCode.Created, articulo.Select_All_Articulo_BD());
            return response;
        }
        public HttpResponseMessage Get([FromUri] int id, bool proceso) {
            if (proceso == true)
            {
                Articulo articulo = new Articulo();
                Usuario usuario = new Usuario();
                usuario.Id_usuario1 = id;
                articulo.Autor1 = usuario;

                HttpResponseMessage response = Request.CreateResponse<Models.Articulo>(HttpStatusCode.Created, articulo.Select_ArticuloxAutor());
                return response;
            }
            else
            {
                Articulo articulo = new Articulo();
                articulo.Id_articulo1 = id;

                HttpResponseMessage response = Request.CreateResponse<Models.Articulo>(HttpStatusCode.Created, articulo.Select_Articulo());
                return response;
            }


        }
    }
}
