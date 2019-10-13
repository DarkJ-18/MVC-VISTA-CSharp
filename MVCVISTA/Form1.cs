using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;



namespace MVCVISTA
{
    public partial class Form1 : Form
    {
        ClsContacto objContacto = null;
        ClsContactoMgr objContactoMgr = null;
        DataTable Dtt;

        public Form1()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 1;
            objContactoMgr = new ClsContactoMgr(objContacto);

            Dtt = new DataTable();
            Dtt = objContactoMgr.Listar();
            if (Dtt.Rows.Count > 0)
            {
                dtregistros.DataSource = Dtt;
            }
        }

        private void Guardar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 2;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContacto.Nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Contacto Guardado Correctamente", "Mensaje");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();          
            btncambios.Enabled = false;
            btneliminar.Enabled = false;

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            Listar();
            LimpiarCampos();

        }

        private void LimpiarCampos()
        {
            txtcodigo.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            txtcodigo.Focus();
        }

        private void GuardarCambios()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 3;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContacto.Nombre = txtnombre.Text;
            objContacto.Telefono = txttelefono.Text;

            objContactoMgr = new ClsContactoMgr(objContacto);
            objContactoMgr.GuardarDatos();
            MessageBox.Show("Cambios Guardados Exitosamente", "Mensaje");
        }


        private void dtregistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[1].Value.ToString();
            txttelefono.Text = dtregistros.Rows[dtregistros.CurrentRow.Index].Cells[2].Value.ToString();

            btnguardar.Enabled = false;
            btncambios.Enabled = true;
            txtcodigo.Enabled = false;
            btneliminar.Enabled = true;
        }

        private void btncambios_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Listar();
            LimpiarCampos();


            btnguardar.Enabled = true;
            btncambios.Enabled = false;
            txtcodigo.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();

        }

        public void Eliminar()
        {
            objContacto = new ClsContacto();
            objContacto.opc = 4;
            objContacto.Id = Convert.ToInt32(txtcodigo.Text);
            objContactoMgr = new ClsContactoMgr(objContacto);

            objContactoMgr.ElinminarDatos();
            MessageBox.Show("Datos Eliminados Exitosamente", "Mensaje");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
           // Eliminar();
            Listar();          
            btnguardar.Enabled = true;
            btncambios.Enabled = false;
            txtcodigo.Enabled = true;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtcodigo.Enabled = true;
            Listar();
            btnguardar.Enabled = true;
            btncambios.Enabled = false;
            btneliminar.Enabled = false;
            LimpiarCampos();
        }
    }
}






