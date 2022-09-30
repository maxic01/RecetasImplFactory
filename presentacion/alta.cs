using recetasmasmasrapido.dominio;
using recetasmasmasrapido.servicios;
using recetasmasmasrapido.servicios.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recetasmasmasrapido
{
    public partial class alta : Form
    {
        private IServicio servicio;
        private Receta nueva;
        
        public alta()
        {
            InitializeComponent();
            servicio = new ImplFactoryServicio().crearServicio();
            nueva = new Receta();
        }

        private void alta_Load(object sender, EventArgs e)
        {
            cargarCombo();
            ultimaReceta();
        }

        private void ultimaReceta()
        {
            lblNro.Text = "Receta #:" + servicio.proximaReceta();
        }

        private void cargarCombo()
        {
            DataTable tabla = servicio.listarIngredientes();
            cboProducto.DataSource = tabla;
            cboProducto.DisplayMember = "n_ingrediente";
            cboProducto.ValueMember = "n_ingrediente";
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar un ingrediente");
                cboProducto.Focus();
                return;
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["Ingrediente"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("ese ingrediente ya fue ingresado");
                    return;
                }
            }
            DataRowView item = (DataRowView)cboProducto.SelectedItem;
            int ingr = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            Ingrediente i = new Ingrediente(ingr, nom);
            int cant = Convert.ToInt32(nudCantidad.Value);
            DetalleReceta detalle = new DetalleReceta(i, cant);
            nueva.agregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] {ingr, nom, cant});
            totalCantidad();
        }

        private void totalCantidad()
        {
            lblTotalIngredientes.Text = "Total Ingredientes:" + dgvDetalles.Rows.Count;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("debe seleccionar un tipo de receta");
                cboTipo.Focus();
                return;
            }
            if(txtCheff.Text == string.Empty)
            {
                MessageBox.Show("debe ingresar un cheff");
                txtCheff.Focus();
                return;
            }
            if(txtNombre.Text == string.Empty)
            {
                MessageBox.Show("debe ingresar un nombre de receta");
                txtNombre.Focus();
                return;
            }
            if(dgvDetalles.Rows.Count < 3)
            {
                MessageBox.Show("debe ingresar al menos 3 ingredientes");
                return;
            }
            nueva.Nombre = txtNombre.Text;
            nueva.Cheff = txtCheff.Text;
            nueva.TipoReceta = Convert.ToInt32(cboTipo.SelectedValue);
            if (servicio.ejecutarReceta(nueva))
            {
                MessageBox.Show("receta guardada");
                limpiar();
            }
            else
            {
                MessageBox.Show("no se pudo guardar");
            }
        }

        private void limpiar()
        {
            txtCheff.Text = string.Empty;
            txtNombre.Text = string.Empty;
            dgvDetalles.Rows.Clear();
            cboProducto.SelectedIndex = -1;
            cboTipo.SelectedIndex = -1;
            lblTotalIngredientes.Text = "Total Ingredientes:";
            ultimaReceta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("desea eliminar este ingrediente?", "ELIMINAR", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                nueva.quitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                totalCantidad();
            }
        }
    }
}
