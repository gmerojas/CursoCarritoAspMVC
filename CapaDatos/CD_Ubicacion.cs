using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Ubicacion
    {
        public List<Departamento> ObtenerDepartamento()
        {
            List<Departamento> Lista = new List<Departamento>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    String query = "select * from Departamento";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(
                                new Departamento()
                                {
                                    IdDepartamento = dr["IdDepartamento"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Lista = new List<Departamento>();
            }

            return Lista;
        }

        public List<Provincia> ObtenerProvincia(string idDepartamento)
        {
            List<Provincia> Lista = new List<Provincia>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    String query = "select * from Provincia where IdDepartamento = @IdDepartamento";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(
                                new Provincia()
                                {
                                    IdProvincia = dr["IdProvincia"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Lista = new List<Provincia>();
            }

            return Lista;
        }

        public List<Distrito> ObtenerDistrito(string idDepartamento, string idProvincia)
        {
            List<Distrito> Lista = new List<Distrito>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    String query = "select * from Distrito where IdProvincia = @IdProvincia and IdDepartamento = @IdDepartamento";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);
                    cmd.Parameters.AddWithValue("@IdDepartamento", idDepartamento);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(
                                new Distrito()
                                {
                                    IdDistrito = dr["IdDistrito"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Lista = new List<Distrito>();
            }

            return Lista;
        }
    }
}
