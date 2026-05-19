/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 2:53 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
namespace ejemploBd
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
		
	{
		// Paso 1 --> crea una cadena de conexión
		private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
		private int id = -1;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			CargarUsuarios();
			
		}
		
		public void CargarUsuarios()
		{
			
			try {
				// Paso 2: Crear conexión (se libera automáticamente al salir del using)
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					// Paso 3: Consulta SQL
					string consulta = "SELECT  id, nombre, clave, rol from usuario";
					//paso 4 Abre la conexión
					conexion.Open();
					// Paso 4: Adaptador ejecuta consulta y llena DataTable
					MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
					DataTable tabla = new DataTable(); // Tabla en memoria
					adaptador.Fill(tabla);
					// Paso 5: Mostrar datos
					dgvUsuarios.DataSource = tabla;
					lblEstado.Text = string.Format("Cargados {0} usuarios.", tabla.Rows.Count);
					
				}
			} catch (Exception ex) {
				
				MessageBox.Show(string.Format("No se pudo realizar conexion por : {0}",ex.Message));
			}
		}
		
		void BtnAgregarUsuarioClick(object sender, EventArgs e)
		{
			UsuarioNuevo frmnuevo  = new UsuarioNuevo();
			
			if (frmnuevo.ShowDialog() == DialogResult.OK) // para mantener estructura
			{
				CargarUsuarios();
				
			}
		}
		
		// Evento que se ejecuta cuando el usuario hace clic en el botón "Eliminar"
		void BtnEliminarUsuarioClick(object sender, EventArgs e)
		{
			// Verificar si hay al menos una fila seleccionada en el DataGridView
			if (dgvUsuarios.SelectedRows.Count == 0)
			{
				MessageBox.Show("Seleccione un usuario para eliminar.");
				return; // Sale del método si no hay selección
			}

			// Obtener el ID del usuario de la primera fila seleccionada
			// Asume que la columna se llama "id" (debe coincidir con la consulta SQL)
			id = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["id"].Value);

			// Preguntar confirmación al usuario (Yes/No)
			if (MessageBox.Show(string.Format("¿Eliminar usuario con ID {0}?", id),
			                    "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				try
				{
					// Usamos using para que la conexión y el comando se liberen automáticamente al terminar
					using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
						using (MySqlCommand cmd = new MySqlCommand("DELETE FROM usuario WHERE id = @id", conexion))
					{
						// Parámetro para evitar inyección SQL
						cmd.Parameters.AddWithValue("@id", id);
						conexion.Open();      // Abrir conexión a MySQL
						cmd.ExecuteNonQuery(); // Ejecutar el DELETE
					}
					MessageBox.Show("Usuario eliminado correctamente.");
					id = -1;   // Limpiar el ID seleccionado
					CargarUsuarios();              // Refrescar el DataGridView
				}
				catch (Exception ex)
				{
					// Mostrar cualquier error (por ejemplo, problema de conexión o clave foránea)
					MessageBox.Show(string.Format("Error al eliminar: {0}", ex.Message));
				}
			}
		}
		
		
		
		
		void BtnAcualizarUsuarioClick(object sender, EventArgs e)
		{
			// Obtener datos de la fila seleccionada
			DataGridViewRow fila = dgvUsuarios.SelectedRows[0];
			int id = Convert.ToInt32(fila.Cells["id"].Value);
			string nombre = fila.Cells["nombre"].Value.ToString();
			string clave = fila.Cells["clave"].Value.ToString();
			int rol = Convert.ToInt32(fila.Cells["rol"].Value);

			using (UsuarioNuevo  frmEditar = new UsuarioNuevo(id, nombre, clave, rol))
			{
				
				if (frmEditar.ShowDialog() == DialogResult.OK)
				{
					CargarUsuarios();
				}
			}
		}
	}
}