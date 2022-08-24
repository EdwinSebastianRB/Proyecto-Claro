using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;

namespace CAPA_NEGOCIO
{
   public class Clientes_BL
    {
        public List<ClIENTES> ListarClientes()
        {
            return new Clientes_DAL().ListarClientes();
        }


        public List<TIPO_IDENTIFICACION> ConsultarTipoIdentificacion()
        {
            return new Clientes_DAL().ConsultarTipoIdentificacion();
        }

        public static ClIENTES RegistrarClientes(ClIENTES cli)
        {
            return Clientes_DAL.RegistrarClientes(cli);
        }

        public static bool ValidarDocument(ClIENTES cedula)
        {
            return Clientes_DAL.ValidarDocumen(cedula);
        }

        public static ClIENTES ModificarClientes(ClIENTES cli)
        {
            return Clientes_DAL.ModificarClientes(cli);
        }

        public static ClIENTES EliminarClientes(ClIENTES cli)
        {
            return Clientes_DAL.EliminarClientes(cli);
        }

        public ClIENTES ObtenerId(int id)
        {
            return new Clientes_DAL().ObtenerId(id);
        }

    }
}
