using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ServicioVenta.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString ActionLinkAllow(this HtmlHelper helper)
        {

            StringBuilder sb = new StringBuilder();

            if (HttpContext.Current.Session["Usuario"] != null)
            {

                Usuario oUsuario = (Usuario)HttpContext.Current.Session["Usuario"];

                Usuario rptUsuario = CD_Usuario.Instancia.ObtenerDetalleUsuario(oUsuario.IdUsuario);


                foreach (Menu item in rptUsuario.oListaMenu)
                {

                    sb.AppendLine("<li class='sidebar-dropdown'>");
                    sb.AppendLine("<a href = 'javascript:;' >");
                    sb.AppendLine("<i class='" + item.Icono + "'></i>");
                    sb.AppendLine("<span>" + item.Nombre + "</span>");
                    sb.AppendLine("</a>");
                    sb.AppendLine("<div class='sidebar-submenu'>");
                    sb.AppendLine("<ul>");
                    foreach (SubMenu subitem in item.oSubMenu)
                    {
                        sb.AppendLine("<li>");
                        if (subitem.Activo == true)
                        {
                            sb.AppendLine("<a href='/" + subitem.Controlador + "/" + subitem.Vista + "'>" + subitem.Nombre + "</a>");

                        }
                        sb.AppendLine("</li>");
                    }
                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine("</li>");
                }


            }


            return new MvcHtmlString(sb.ToString());
        }

    }
}
