var urlaconectarse = "https://localhost:44327/api/";

function Creador_Cargando(titulo, texto, id) {
    return "<div class='card' style='width: 18rem;'id='" + id + "''><img width='200' height='150' src='Img/cargando.gif' class='card-img-top' alt='Cargando'><div class='card-body'><h5 class='card-title'>" + titulo + "</h5><p class='card-text'>" + texto + "</p></div></div>";
}

function Habilitar_Botones() {
    document.getElementById("btn_guardar").disabled = true;
    document.getElementById("btn_eliminar").disabled = false;
    document.getElementById("btn_actualizar").disabled = false;
}

function Deshabilitar_Botones() {
    document.getElementById("btn_guardar").disabled = false;
    document.getElementById("btn_eliminar").disabled = true;
    document.getElementById("btn_actualizar").disabled = true;
}

var articulo = new Object;
    articulo.id_articulo = "";
    articulo.id_usuario = "";
    articulo.nombre_articulo = "";
    articulo.fecha_publicacion = "";
    articulo.texto = "";
    articulo.foto = "";

var chat = new Object;
    chat.id_chat = "";
    chat.id_usuarioI = "";
    chat.id_usuarioII = "";

var evaluacion = new Object;
    evaluacion.id_evaluacion = "";
    evaluacion.id_expediente = "";
    evaluacion.resultado = "";

var expediente = new Object;
    expediente.id_expediente = "";
    expediente.id_usuario = "";
    expediente.fecha_realizacion = "";

var institucion = new Object;
    institucion.id_institucion = "";
    institucion.nombre_institucion = "";
    institucion.email = "";
    institucion.telefono = "";
    institucion.tipo = "";
    institucion.foto = "";

var mensaje = new Object;
    mensaje.id_mensaje = "";
    mensaje.id_usuario = "";
    mensaje.id_chat = "";
    mensaje.texto = "";
    mensaje.fecha_hora = "";

var usuario = new Object;
    usuario.id_usuario = "";
    usuario.id_institucion = "";
    usuario.correo = "";
    usuario.nombre_usuario = "";
    usuario.contraseña = "";
    usuario.foto = "";
    usuario.rol = "";

var articulo_fav = new Object;
    articulo_fav.id_usuario = "";
    articulo_fav.id_articulo = "";


function Ajax(formdata, url, verbo, espacio, id) {

    var accion = "";
    switch (verbo) {
        case "POST": {
            accion = "actualizando";
            break;
        }
        case "DELETE": {
            accion = "borrando";
            break;
        }
        default: {
            accion = "insertando";
            break;
        }
    }
    espacio.innerHTML += Creador_Cargando("Ejecutando acción tipo: " + verbo, "Se esta " + accion + " en " + url + " con Id: " + id, "info_id" + id);
    $.ajax({
        url: urlaconectarse + url,
        type: verbo,
        dataType: "json",
        data: formdata,
        success: function (data, textstatus, xhr) {
            alert(data[0]);
            $('#info_id' + data[1]).remove();
        },
        error: function (xhr, textstatus, errorthrown) {
            $('#info_id' + xhr[1]).remove();
            alert(xhr);
        }
    })
}

function Verifica_Institucion(id) {
    $.ajax({
        url: urlaconectarse + 'Institucion?id='+id,
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {
            console.log(data)
            llenarinstitucion(data);
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            $("#instituciones").remove();
            alert(xhr);
        }

    });
}

function Verifica_Usuario(formdata, proceso) {
    $.ajax({
        url: urlaconectarse + 'Usuario?id=' + usuario.id_usuario + "&" + proceso,
        type: 'GET',
        dataType: 'json',
        data: formdata,
        success: function (data, textStatus, xhr) {
            console.log(data);
            switch (data.Nombre_usuario1) {

                case "NO EXISTE":
                    {
                        alert("No existe");
                        break;
                    }
                case "Error":
                    {
                        alert("Hay una interrupción con la conexión a la base de datos, por favor intente mas tarde");
                        break;
                    }
                default:
                    {
                        Cargar_Formulario(data);
                        Habilitar_Formulario();
                        break;
                    }
            }
        }, error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
        }
    });

}

function Tabla_Artitulos(espacio) {
    $.ajax({
        url: urlaconectarse + 'Articulo',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {
            if (data.length > 0) {
                for (var indice in data) {
                    var maxrow = maxrow + 1;
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {
                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");
                    }

                    document.getElementById("articulo").innerHTML += "<div class='u-blog-post u-container-style u-repeater-item u-custom-color-7 u-repeater-item-4' style='margin: 10px;'><div class='u-container-layout u-similar-container u-container-layout-6' style='margin: 10px;'><a class='u-post-header-link' onclick = '(Hacerfavorito(" + data[indice].Id_articulo1 +"))'><img  class='u-blog-control u-expanded-width u-image u-image-default u-image-5' src='" + data[indice].Foto1 + "'></a><input hidden value='" + data[indice].Id_articulo1 + "' class='btnarticulo' /><h4 class='u-blog-control u-text u-text-12'><a class='u-post-header-link' href='blog/enviar.html'><hr/>" + data[indice].Nombre_articulo1 + "<hr/>" + data[indice].Autor1.Id_usuario1 + "<hr/>" + data[indice].Fecha_publicacion1 + "<a></h4><div class='u-blog-control u-post-content u-text u-text-13'>" + data[indice].Text1 + "</div></div></div>"

                }
                console.log(data)
            }
            $("#articulos").remove();
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            $("#articulos").remove();
            alert(xhr);
        }

    });
}

function Tabla_Chats(idusuario,proceso) {
    $.ajax({
        url: urlaconectarse + 'Chat?id=' + idusuario + "&" + proceso,
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {
            document.getElementById("chat").innerHTML = " ";
            document.getElementById("chat").innerHTML = "<div class='u-align-center u-container-style u-custom-color-1 u-list-item u-repeater-item u-list-item-1' style='margin: 10px;'><div class='u-container-layout u-similar-container u-valign-top-xs u-container-layout-2'><a style='width: 100%;' href='#nuevochat' class='u-border-none u-btn u-button-style u-custom-color-1 u-btn-1'>Nuevo chat</a><div class='u-image u-image-circle u-image-1' alt='' data-image-width='900' data-image-height='888'></div></div></div>";
            if (data.length > 0) {
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {
                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");
                    }
                    
                    if (idusuario == data[indice].Id_usuarioI1.Id_usuario1) {
                        document.getElementById("chat").innerHTML += "<div class='u-align-center u-container-style u-custom-color-1 u-list-item u-repeater-item u-list-item-1' style = 'margin: 10px; height:100%; width:100%;'><div class='u-container-layout u-similar-container u-valign-top-xs u-container-layout-2'><a onclick='Cargarchat(" + data[indice].Id_chat1 + ")' id=" + data[indice].Id_usuarioII1.Id_usuario1 + " class='u-border-none u-btn u-button-style u-custom-color-1 u-btn-1' style='width: 100%;'>" + data[indice].Id_chat1+":"+data[indice].Id_usuarioII1.Id_usuario1 + "</a><img id='" + data[indice].Id_usuarioII1.Id_usuario1+"' class='u-image u-image-circle u-image-1' alt='' data-image-width='900' data-image-height='888' /></div></div>";
                    } else {
                        document.getElementById("chat").innerHTML += "<div class='u-align-center u-container-style u-custom-color-1 u-list-item u-repeater-item u-list-item-1' style = 'margin: 10px; height:100%; width:100%'><div class='u-container-layout u-similar-container u-valign-top-xs u-container-layout-2'><a onclick='Cargarchat(" + data[indice].Id_chat1 + ")'id=" + data[indice].Id_usuarioI1.Id_usuario1 + " class='u-border-none u-btn u-button-style u-custom-color-1 u-btn-1' style='width: 100%;'>" + data[indice].Id_chat1 + ":"+ data[indice].Id_usuarioI1.Id_usuario1 + "</a><img id='" + data[indice].Id_usuarioI1.Id_usuario1 + "' class='u-image u-image-circle u-image-1' alt='' data-image-width='900' data-image-height='888' /></div></div>";
                    }

                    

                }
                console.log(data)
            }
            $("#chats").remove();
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            $("#chats").remove();
            alert(xhr);
        }

    });
}

function Tabla_Mensajes(idusuario,idchat, proceso) {
    $.ajax({
        url: urlaconectarse + 'Mensaje?id=' + idchat + "&" + proceso,
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {
            document.getElementById("mensaje").innerHTML = " ";
            if (data.length > 0) {
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {
                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");
                    }
                    if (data[indice].Id_usuario1.Id_usuario1 == idusuario) {
                        document.getElementById("mensaje").innerHTML += "<div class='u-align-center u-container-style u-custom-color-7 u-group u-shape-rectangle u-group-2'><div class='u-container-layout u-valign-middle u-container-layout-9'><p class='u-text u-text-2'>" + data[indice].Id_mensaje1 + "-" + data[indice].Texto1 + "</p><p class='u-text u-text-2'>" + data[indice].Id_usuario1.Id_usuario1 + "-" + data[indice].Fecha_hora1 + "</p></div></div><hr/>" ;

                    } else {
                        document.getElementById("mensaje").innerHTML += "<div class='u-align-center u-container-style u-custom-color-7 u-group u-shape-rectangle u-group-1'><div class='u-container-layout u-valign-middle u-container-layout-8'><p class='u-text u-text-1'>" + data[indice].Id_mensaje1 + "-" + data[indice].Texto1 + "</p><p class='u-text u-text-1'>" + data[indice].Id_usuario1.Id_usuario1 + "-" + data[indice].Fecha_hora1 + "</p></div></div><hr/>" ;
                    }



                }
                console.log(data)
            }
            $("#mensajes").remove();
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            $("#mensajes").remove();
            alert(xhr);
        }

    });
}

function Verifica_Articulo(formdata, proceso) {
    $.ajax({
        url: urlaconectarse + 'Articulo?id=' + articulo_fav.id_articulo + "&" + proceso,
        type: 'GET',
        dataType: 'json',
        data: formdata,
        success: function (data, textStatus, xhr) {
        console.log(data)
                    var objetoserializado = JSON.stringify(data);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {
                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");
                    }
                    document.getElementById("articulosfav").innerHTML += "<div class='u-blog-post u-container-style u-repeater-item u-custom-color-7 u-repeater-item-4' style='margin: 10px;'><div class='u-container-layout u-similar-container u-container-layout-6' style='margin: 10px;'><a class='u-post-header-link' onclick = '(Deshacerfavorito(" + data.Id_articulo1 + "))'><img  class='u-blog-control u-expanded-width u-image u-image-default u-image-5' src='" + data.Foto1 + "'></a><input hidden value='" + data.Id_articulo1 + "' class='btnarticulo' /><h4 class='u-blog-control u-text u-text-12'><a class='u-post-header-link' href='blog/enviar.html'><hr/>" + data.Nombre_articulo1 + "<hr/>" + data.Autor1.Id_usuario1 + "<hr/>" + data.Fecha_publicacion1 + "<a></h4><div class='u-blog-control u-post-content u-text u-text-13'>" + data.Text1 + "</div></div></div>"
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
        }

    });
}

function Tabla_ArtitulosFav(idusuario) {
    $.ajax({
        url: urlaconectarse + 'Usuario_Articulos?id=' + idusuario,
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {
            console.log(data);
         
            if (data.length > 0) {
               for (var indice in data) {
                   document.getElementById("articulosfav").innerHTML = " ";

                   var idarticulo = data[indice].Id_articulo1.Id_articulo1;
                       articulo_fav.id_articulo = idarticulo;
                   Verifica_Articulo(articulo_fav, "proceso=false")
               }
            }
            $("#articulosfavs").remove();
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            $("#articulosfavs").remove();
            alert(xhr);
        }

    });
}

function Tabla_UsuariosxInstitucion(idinstitucion,proceso) {
    $.ajax({
        url: urlaconectarse + 'Usuario?id=' + idinstitucion + "&" + proceso,
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {
            if (data.length > 0) {
                document.getElementById("tablebody").innerHTML = " ";
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";

                    for (var caracter in objetoserializado) {
                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");
                    }
                    document.getElementById("tablebody").innerHTML += '<tr><td><img style="width:100px; height:100px;" class="" src="' + data[indice].Foto1 + '"></td><td>' + data[indice].Id_usuario1 + '</td><td>' + data[indice].Correo1 + '</td><td>' + data[indice].Nombre_usuario1 + '</td><td>' + data[indice].Rol1 + '</td></tr>';

                }
            }
            $('#usuario').DataTable();
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
        }

    });
}

function Verifica_evaluacion(idevaluacion) {
    $.ajax({
        url: urlaconectarse + 'Evaluacion?id=' + idevaluacion,
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {
            console.log(data)
            var objetoserializado = JSON.stringify(data);
            var objetoserializadocomillas = "";
            for (var caracter in objetoserializado) {
                objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");
            }
            document.getElementById("result").value = data.Resultado1;
        }
        ,
        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
        }

    });
}