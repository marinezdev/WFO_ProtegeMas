using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO.Propiedades.Procesos.Promotoria;

namespace WFO.AccesoDatos.Procesos.Promotoria
{
    public class TramitesPromotoria
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.TramitesPromotoria> ConsultaTramitesPromotoria(int IdUsuario,int IdTramite)
        {
            b.ExecuteCommandSP("Tramite_Promotoria_PorUsuario");
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    Estatus = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    kwik = reader["kwik"].ToString(),
                    IdTipoTramite = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["IdTipoTramite"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        
        public List<prop.TramitesPromotoria> ListaTramitesPromotoria(int Id)
        {
            b.ExecuteCommandSP("Tramites_Promotoria_Seleccionar_Por_IdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Titular = reader["Titular"].ToString(),
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    Estatus = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    kwik = reader["kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaFechas(int Id, int IdStatusTramite, DateTime Fecha_Termino, DateTime Fecha_Inicio)
        {
            b.ExecuteCommandSP("Tramites_Promotoria_Seleccionar_Fechas_Por_IdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@IdStatusTramite", IdStatusTramite, SqlDbType.Int);
            b.AddParameter("@Fecha_Inicio", Fecha_Inicio, SqlDbType.DateTime);
            b.AddParameter("@Fecha_Termino", Fecha_Termino, SqlDbType.DateTime);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Titular = reader["Titular"].ToString(),
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    Estatus = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    kwik = reader["kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaEstado(int Id, string Estado)
        {
            b.ExecuteCommandSP("Indicador_General_Promotoria_PorUsuarioEstado");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@Estado", Estado, SqlDbType.NVarChar);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Titular = reader["Titular"].ToString(),
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    Estatus = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    kwik = reader["kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaPendientes(int Id)
        {
            b.ExecuteCommandSP("Indicador_General_Promotoria_PorUsuarioPendientes");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Numeros.ConvertirTextoANumeroEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Titular = reader["Titular"].ToString(),
                    FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    Estatus = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    kwik = reader["kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
