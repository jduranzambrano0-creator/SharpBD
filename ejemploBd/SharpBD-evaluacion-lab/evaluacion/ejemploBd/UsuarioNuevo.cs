/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 6:41 p. m.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class UsuarioNuevo : Form
	{
		// ESTA PARTE FUNCIONA: Úsala como guía para completar el resto del sistema
		private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
		private bool _esEdicion = false;
		private int _id = -1;
		
		public UsuarioNuevo()
		{
			InitializeComponent();
		}
		
		public UsuarioNuevo(int id,string nombre, string clave, int rol)
		{
			InitializeComponent();
			txtNombre.Text =  nombre;
			txtClave.Text = clave;
			cmbRol.SelectedIndex = rol;
			_id = id;
			_esEdicion = true;
			this.Text = "Editar Usuario";
			btnGuardar.Text = "Actualizar";
		}
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtClave.Text) || cmbRol.SelectedIndex == -1)
			{
				MessageBox.Show("Complete todos los campos.");
				return;
			}
			
			int idrol = (int)cmbRol.SelectedIndex;
			string consulta = _esEdicion ? 
				"UPDATE usuario SET nombre=@nombre, clave=@clave, rol=@rol WHERE id=@id" : 
				"INSERT INTO usuario (nombre, clave, rol) VALUES (@nombre, @clave, @rol)";		
			
			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
				{
					cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
					cmd.Parameters.AddWithValue("@clave", txtClave.Text);
					cmd.Parameters.AddWithValue("@rol", idrol);
					if (_esEdicion) cmd.Parameters.AddWithValue("@id", _id);
					
					conexion.Open();
					cmd.ExecuteNonQuery(); // ESTA LÍNEA ES CLAVE: Ejecuta la acción en la BD
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
