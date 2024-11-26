using System;
using System.Collections.Generic;
using prop = WFO.Propiedades.Procesos.Promotoria;

namespace WFO.Negocio.Procesos.Promotoria
{
    public class TramitesPromotoria
    {
        AccesoDatos.Procesos.Promotoria.TramitesPromotoria tramitesPromotoria = new AccesoDatos.Procesos.Promotoria.TramitesPromotoria();

        public List<prop.TramitesPromotoria> ConsultaTramitesPromotoria(int IdUsuario, int IdTramite)
        {
            return tramitesPromotoria.ConsultaTramitesPromotoria(IdUsuario, IdTramite);
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoria(int Id)
        {
            return tramitesPromotoria.ListaTramitesPromotoria(Id);
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaFechas(int Id, int IdStatusTramite, DateTime Fecha_Inicio, DateTime Fecha_Termino)
        {
            return tramitesPromotoria.ListaTramitesPromotoriaFechas(Id, IdStatusTramite, Fecha_Inicio, Fecha_Termino);
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaEstado(int Id, string Estado)
        {
            return tramitesPromotoria.ListaTramitesPromotoriaEstado(Id, Estado);
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaPendientes(int Id)
        {
            return tramitesPromotoria.ListaTramitesPromotoriaPendientes(Id);
        }
    }
}
