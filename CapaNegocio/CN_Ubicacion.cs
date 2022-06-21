using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Ubicacion
    {
        private CD_Ubicacion objCapaDato = new CD_Ubicacion();

        public List<Departamento> ObtenerDepartamento()
        {
            return objCapaDato.ObtenerDepartamento();
        }

        public List<Provincia> ObtenerProvincia(string idDepartamento)
        {
            return objCapaDato.ObtenerProvincia(idDepartamento);
        }

        public List<Distrito> ObtenerDistrito(string idDepartamento, string idProvincia)
        {
            return objCapaDato.ObtenerDistrito(idDepartamento, idProvincia);
        }
    }
}
