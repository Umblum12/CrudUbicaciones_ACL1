using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;

namespace DAL
{
    public class ubicacionesDALL
    {
        SQLDBHelper cConexion;
        public ubicacionesDALL() {
        cConexion = new SQLDBHelper();
        }
        public bool Agregar(ubicaciones_BLL OubicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "INSERT INTO Direcciones (Ubicacion, Latitud, Longitud) Values(@Ubicacion, @Latitud, @Longitud)";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return cConexion.EjecutarComandoSQL(cmdComando);
        }
        public void Eliminar(ubicaciones_BLL ubicaciones_BLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "DELETE FROM Direcciones WHERE ID=@ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = ubicaciones_BLL.ID;
            cConexion.EjecutarComandoSQL(cmdComando);
        }
        public void Modificar() { }
        public DataTable Listar() {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "SELECT * FROM Direcciones";
            cmdComando.CommandType = CommandType.Text;
            DataTable TablaResultante = cConexion.EjecutarSentenciaSQL(cmdComando);
            return TablaResultante;
        }
    }
}
