using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO.Propiedades.Procesos.Promotoria
{
    public class expediente
    {
        public int Id { get; set; }
        public int Id_Tramite { get; set; }
        public int Id_Archivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public int Activo { get; set; }
        public int Fusion { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string FusionTexto { get; set; }
        public int Tam { get; set; }
    }
}
