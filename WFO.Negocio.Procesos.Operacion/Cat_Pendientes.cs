using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO.Propiedades.Procesos.Operacion;

namespace WFO.Negocio.Procesos.Operacion
{
    public class Cat_Pendientes
    {
        AccesoDatos.Procesos.Operacion.Cat_Pendientes pendientes = new AccesoDatos.Procesos.Operacion.Cat_Pendientes();

        public List<prop.Cat_Pendientes> SelecionarPendientes(int Id_Usuario)
        {
            return pendientes.SelecionarPendientes(Id_Usuario);
        }
    }
}
