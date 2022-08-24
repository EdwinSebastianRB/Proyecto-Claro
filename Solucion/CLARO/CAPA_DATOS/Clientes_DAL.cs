using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_DATOS
{
    public class Clientes_DAL
    {


        
        public List<ClIENTES> ListarClientes()
        {
            try
            {
                using (CLAROEntities1 bd = new CLAROEntities1())
                {
                    var query = bd.ClIENTES.ToList();
                    bd.SaveChanges();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   


       



        public List<TIPO_IDENTIFICACION> ConsultarTipoIdentificacion()
        {
            try
            {
                using (CLAROEntities1 bd = new CLAROEntities1())
                {
                    var query = bd.TIPO_IDENTIFICACION.ToList();
                    bd.SaveChanges();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ClIENTES RegistrarClientes(ClIENTES cli)
        {
            try
            {
                using (CLAROEntities1 bd = new CLAROEntities1())
                {
                    bd.ClIENTES.Add(cli);
                    bd.SaveChanges();
                    return cli;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool ValidarDocumen(ClIENTES cedulaa)
        {
            try
            {
                using (CLAROEntities1 bd = new CLAROEntities1())
                {
                    var validacion = (from p in bd.ClIENTES
                                      where p.Numero_Identificacion == cedulaa.Numero_Identificacion
                                      select p).Count();

                    if (validacion == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static ClIENTES ModificarClientes(ClIENTES cli)
        {
            try
            {
                using (CLAROEntities1 bd = new CLAROEntities1())
                {

                    bd.UpdateClienteEstado(cli.Id_Cliente, cli.Nombre, cli.Numero_Identificacion, cli.Correo, cli.Telefono, cli.Direccion, cli.Direccion_Instalacion, cli.Id_Tipo_Identificacion, cli.estado);
                    bd.SaveChanges();
                    return cli;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static ClIENTES EliminarClientes(ClIENTES cli)
        {
            try
            {
                using (CLAROEntities1 bd = new CLAROEntities1())
                {
                    var query = (from p in bd.ClIENTES
                                 where p.Id_Cliente == cli.Id_Cliente
                                 select p).FirstOrDefault();
                    query.Id_Cliente = cli.Id_Cliente;
                    bd.ClIENTES.Remove(query);
                    bd.SaveChanges();
                    return cli;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ClIENTES ObtenerId(int id)
        {
            try
            {
                using (CLAROEntities1 bd = new CLAROEntities1())
                {
                    var query = (from ClIENTES in bd.ClIENTES
                                 where ClIENTES.Id_Cliente == id
                                 select ClIENTES).FirstOrDefault();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
