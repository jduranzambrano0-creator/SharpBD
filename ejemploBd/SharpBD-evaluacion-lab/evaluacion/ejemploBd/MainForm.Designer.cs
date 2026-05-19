/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 2:53 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ejemploBd
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgvUsuarios = new System.Windows.Forms.DataGridView();
			this.dataView1 = new System.Data.DataView();
			this.btnAgregarUsuario = new System.Windows.Forms.Button();
			this.btnEliminarUsuario = new System.Windows.Forms.Button();
			this.btnActualizarUsuario = new System.Windows.Forms.Button();
			this.btnGestionModulos = new System.Windows.Forms.Button();
			this.lblEstado = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvUsuarios
			// 
			this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsuarios.Location = new System.Drawing.Point(100, 49);
			this.dgvUsuarios.Name = "dgvUsuarios";
			this.dgvUsuarios.ReadOnly = true;
			this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvUsuarios.Size = new System.Drawing.Size(501, 189);
			this.dgvUsuarios.TabIndex = 0;
			// 
			// btnAgregarUsuario
			// 
			this.btnAgregarUsuario.Location = new System.Drawing.Point(100, 285);
			this.btnAgregarUsuario.Name = "btnAgregarUsuario";
			this.btnAgregarUsuario.Size = new System.Drawing.Size(107, 43);
			this.btnAgregarUsuario.TabIndex = 1;
			this.btnAgregarUsuario.Text = "Agregar";
			this.btnAgregarUsuario.UseVisualStyleBackColor = true;
			this.btnAgregarUsuario.Click += new System.EventHandler(this.BtnAgregarUsuarioClick);
			// 
			// btnEliminarUsuario
			// 
			this.btnEliminarUsuario.Location = new System.Drawing.Point(256, 285);
			this.btnEliminarUsuario.Name = "btnEliminarUsuario";
			this.btnEliminarUsuario.Size = new System.Drawing.Size(107, 43);
			this.btnEliminarUsuario.TabIndex = 2;
			this.btnEliminarUsuario.Text = "Eliminar";
			this.btnEliminarUsuario.UseVisualStyleBackColor = true;
			this.btnEliminarUsuario.Click += new System.EventHandler(this.BtnEliminarUsuarioClick);
			// 
			// btnActualizarUsuario
			// 
			this.btnActualizarUsuario.Location = new System.Drawing.Point(414, 285);
			this.btnActualizarUsuario.Name = "btnActualizarUsuario";
			this.btnActualizarUsuario.Size = new System.Drawing.Size(107, 43);
			this.btnActualizarUsuario.TabIndex = 3;
			this.btnActualizarUsuario.Text = "Actualizar";
			this.btnActualizarUsuario.UseVisualStyleBackColor = true;
			this.btnActualizarUsuario.Click += new System.EventHandler(this.BtnAcualizarUsuarioClick);
			// 
			// lblEstado
			// 
			this.lblEstado.Location = new System.Drawing.Point(234, 339);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(100, 23);
			this.lblEstado.TabIndex = 4;
			this.lblEstado.Text = "Estado";
			// 
			// btnGestionModulos
			// 
			this.btnGestionModulos.Location = new System.Drawing.Point(544, 285);
			this.btnGestionModulos.Name = "btnGestionModulos";
			this.btnGestionModulos.Size = new System.Drawing.Size(120, 43);
			this.btnGestionModulos.TabIndex = 5;
			this.btnGestionModulos.Text = "Módulos (Proyecto)";
			this.btnGestionModulos.UseVisualStyleBackColor = true;
			this.btnGestionModulos.Click += new System.EventHandler(this.BtnGestionModulosClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(691, 371);
			this.Controls.Add(this.btnGestionModulos);
			this.Controls.Add(this.lblEstado);
			this.Controls.Add(this.btnActualizarUsuario);
			this.Controls.Add(this.btnEliminarUsuario);
			this.Controls.Add(this.btnAgregarUsuario);
			this.Controls.Add(this.dgvUsuarios);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ejemplo Conección Base de datos";
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblEstado;
		private System.Windows.Forms.Button btnActualizarUsuario;
		private System.Windows.Forms.Button btnEliminarUsuario;
		private System.Windows.Forms.Button btnAgregarUsuario;
		private System.Windows.Forms.Button btnGestionModulos;
		private System.Data.DataView dataView1;
		private System.Windows.Forms.DataGridView dgvUsuarios;
	}
}
