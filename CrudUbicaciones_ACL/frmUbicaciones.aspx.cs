using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;

namespace CrudUbicaciones_ACL
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BLL oUbicacionesBLL;
        ubicacionesDALL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
        }

        public void ListarUbicaciones()
        {
            oUbicacionesDAL = new ubicacionesDALL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();
        }
        public ubicaciones_BLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicaciones_BLL();
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDALL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones();
        }
        protected void btnEliminarReg_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicacionesDALL();
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones();
        }
        

        protected void SeleccionarRegistros(object sender, GridViewCommandEventArgs e)
        {
            int FilaSeleccionada = int.Parse(e.CommandArgument.ToString());

            txtID.Value = gvUbicaciones.Rows[FilaSeleccionada].Cells[1].Text;
            txtUbicacion.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[2].Text;
            txtLat.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[3].Text;
            txtLong.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[4].Text;

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = false;
        }
    }
}