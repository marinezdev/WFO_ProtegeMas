using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using promotoria = WFO.Propiedades.Procesos.Promotoria;
using DevExpress.Web.ASPxTreeList;
using System.IO;
using DevExpress.Web;

using prop = WFO.Propiedades.Procesos.Operacion;

namespace WFO.Procesos.Operador
{
    public partial class Pendientes: Utilerias.Comun
    {
        WFO.Negocio.Procesos.Operacion.Cat_Pendientes pendientes = new Negocio.Procesos.Operacion.Cat_Pendientes();
        WFO.Negocio.Procesos.Operacion.Pendientes PendientesListado = new Negocio.Procesos.Operacion.Pendientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                manejo_sesion = (WFO.IU.ManejadorSesion)Session["Sesion"];
                PintaPendientes(manejo_sesion.Usuarios.IdUsuario);
            }
        }

        protected void PintaPendientes(int Id)
        {
            List<prop.Cat_Pendientes> PendientesUsuario = pendientes.SelecionarPendientes(Id);

            string MesaUsuario = "";
            int num = 0;
            string atributo = "";

            for (int i = 0; i < PendientesUsuario.Count; i++)
            {
                if (num == 0)
                {
                    atributo = "Card_1";
                    num = 1;
                }
                else
                {
                    atributo = "Card_2";
                    num = 0;
                }

                MesaUsuario += "<div class='control-label col-md-4 col-sm-4 col-xs-6' onClick='Cantidades(" + PendientesUsuario[i].Id_Pendiente + ")'>" +
                                    "<div class='x_panel text-center " + atributo + "'>" +
                                        "<a  style='color:#ffffff'>" +
                                            "<i class='fa " + PendientesUsuario[i].Icono + " fa-5x'></i>" +
                                            "<div class='form-group text-center'>" +
                                                "<hr />" +
                                                "<h2><small style='color:#ffffff'>" + PendientesUsuario[i].Nombre + " - " + PendientesUsuario[i].Total + "</small></h2>" +
                                            "</div>" +
                                        "</a>" +
                                    "</div>" +
                                "</div>";
            }

            MesasLiteral.Text = MesaUsuario;
        }

        public void btnConsultar_Click(object sender, EventArgs e)
        {
            manejo_sesion = (WFO.IU.ManejadorSesion)Session["Sesion"];
            int IdPendiente  = Convert.ToInt32(hfIdPendiente.Value);

            List<prop.Pendientes> Tramites = PendientesListado.SelecionarPendientes(IdPendiente,manejo_sesion.Usuarios.IdUsuario);

            rptTramite.DataSource = Tramites;
            rptTramite.DataBind();

            string script = "";
            script = "$('#myModal').modal({backdrop: 'static', keyboard: false});";
            script += "$('#datatable').DataTable({}); ";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            
            TituloModal.Text = "Consulta trámites";
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                // LECTURA DE VARIABLES 
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                int IdTramite = Convert.ToInt32(arg[0]);
                int IdMesa = Convert.ToInt32(arg[1]);

                if (String.IsNullOrEmpty(IdMesa.ToString()) || IdMesa == 0)
                {
                    Response.Redirect("ConsultaTramite.aspx?Procesable=" + IdTramite);
                }
                else
                {
                    Response.Redirect("TramiteProcesar.aspx?Procesable=" + IdTramite + "&IdMesa=" + IdMesa);
                } 
            }
        }
    }
}