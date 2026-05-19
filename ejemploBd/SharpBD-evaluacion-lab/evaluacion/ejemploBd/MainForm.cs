/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 2:53 p. m.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class MainForm : Form
	{
        // ESTA PARTE FUNCIONA: Úsala como guía para completar el resto del sistema
        //private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
        
		
		// LO QUE ESTABA MAL: Dejar la cadena vacía ("").
        // CORRECCIÓN: Se extrae la credencial idéntica de MainForm.cs para conectar localmente con XAMPP.
        private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";



        private int id = -1;
		
		public MainForm()
		{
			InitializeComponent();
			CargarUsuarios();
		}
		
		public void CargarUsuarios()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					string consulta = "SELECT id, nombre, clave, rol from usuario";
					conexion.Open();
					MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
					DataTable tabla = new DataTable();
					adaptador.Fill(tabla);
					dgvUsuarios.DataSource = tabla;
					lblEstado.Text = string.Format("Cargados {0} usuarios.", tabla.Rows.Count);
				}
			} catch (Exception ex) {
				MessageBox.Show(string.Format("Error de conexión: {0}", ex.Message));
			}
		}
		
		void BtnAgregarUsuarioClick(object sender, EventArgs e)
		{
			UsuarioNuevo frmnuevo  = new UsuarioNuevo();
			if (frmnuevo.ShowDialog() == DialogResult.OK)
			{
				CargarUsuarios();
			}
		}
		
		void BtnEliminarUsuarioClick(object sender, EventArgs e)
		{
			if (dgvUsuarios.SelectedRows.Count == 0) return;
			id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id"].Value);

			if (MessageBox.Show("¿Eliminar?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand("DELETE FROM usuario WHERE id = @id", conexion))
				{
					cmd.Parameters.AddWithValue("@id", id);
					conexion.Open();      
					cmd.ExecuteNonQuery(); 
				}
				CargarUsuarios();
			}
		}

        void BtnAcualizarUsuarioClick(object sender, EventArgs e)
        {
            // CONTROL DE SEGURIDAD: Si el usuario presiona el botón sin elegir a nadie, salimos para evitar caídas
            if (dgvUsuarios.SelectedRows.Count == 0) return;

            DataGridViewRow fila = dgvUsuarios.SelectedRows[0];

            try
            {
                // SOLUCIÓN AL NULL REFERENCE: Cambiamos las cadenas por el orden físico de las columnas en tu SQL.
                // fila.Cells[0] -> id
                // fila.Cells[1] -> nombre
                // fila.Cells[2] -> clave
                // fila.Cells[3] -> rol
                int id = Convert.ToInt32(fila.Cells[0].Value);

                // El operador '??' asegura que si la celda está vacía, asigne un texto en blanco "" en vez de explotar con null
                string nombre = (fila.Cells[1].Value ?? "").ToString();
                string clave = (fila.Cells[2].Value ?? "").ToString();
                int rol = Convert.ToInt32(fila.Cells[3].Value);

                using (UsuarioNuevo frmEditar = new UsuarioNuevo(id, nombre, clave, rol))
                {
                    if (frmEditar.ShowDialog() == DialogResult.OK)
                    {
                        CargarUsuarios();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar los datos de la fila: " + ex.Message);
            }
        }

        void BtnGestionModulosClick(object sender, EventArgs e)
		{
			// EXAMEN: Abrir el formulario de Gestión de Módulos
			GestionModulos frm = new GestionModulos();
			frm.ShowDialog();
		}
	}
}
