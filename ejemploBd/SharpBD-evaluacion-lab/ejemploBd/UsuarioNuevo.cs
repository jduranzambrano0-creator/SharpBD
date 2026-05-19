/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 6:41 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	/// <summary>
	/// Description of UsuarioNuevo.
	/// </summary>
	public partial class UsuarioNuevo : Form
	{
		//paso 1.- crea una cadena de conexión
		private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
		private bool _esEdicion = false;
		private int _id = -1;
		
		public UsuarioNuevo()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		public UsuarioNuevo(int id,string nombre, string clave, int rol)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			txtNombre.Text =  nombre;
			txtClave.Text = clave;
			cmbRol.SelectedIndex = rol;
			_id = id;
			_esEdicion = true;
			this.Text = "Editar Usuario";
			btnGuardar.Text = "actualizar";
			
			
		}
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			// Validaciones de campos vacíos
			if (string.IsNullOrWhiteSpace(txtNombre.Text))
			{
				MessageBox.Show("Escriba nombre para el usuario.");
				return;
			}
			if (string.IsNullOrWhiteSpace(txtClave.Text))
			{
				MessageBox.Show("Escriba clave para el usuario.");
				return;
			}
			// Validar que haya un rol seleccionado
			if (cmbRol.SelectedIndex == -1)
			{
				MessageBox.Show("Seleccione un rol.");
				return;
			}
			
			// Paso 1: Obtener el ID del rol usando SelectedValue (entero)
			int idrol = (int)cmbRol.SelectedIndex;
			
			// Definir la consulta según sea edición o nuevo
			string consulta;
			
			// Paso 2: Consulta SQL con parámetros
			if (_esEdicion){
				consulta = "UPDATE usuario SET nombre=@nombre, clave=@clave, rol=@rol WHERE id=@id";
				btnGuardar.Text = "actualizar";
			}
			else
				consulta = "INSERT INTO usuario (nombre, clave, rol) VALUES (@nombre, @clave, @rol)";		
			
			try
			{
				// Paso 3: Crear conexión y comando
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
				{
					// Paso 4: Asignar parámetros
					cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
					cmd.Parameters.AddWithValue("@clave", txtClave.Text);
					cmd.Parameters.AddWithValue("@rol", idrol);
					
					if (_esEdicion)
                    	cmd.Parameters.AddWithValue("@id", _id);
					// Paso 5: Abrir y ejecutar
					conexion.Open();
					cmd.ExecuteNonQuery();
				}
				MessageBox.Show(_esEdicion ? "Usuario actualizado correctamente." : "Usuario agregado correctamente.");
				
				this.DialogResult = DialogResult.OK;   // Para que el padre sepa que se agregó
				this.Close();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error al agregar: {0}", ex.Message));
			}
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
