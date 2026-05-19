namespace ejemploBd
{
	partial class GestionPreguntas
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView dgvPreguntas;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.dgvPreguntas = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvPreguntas
			// 
			this.dgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPreguntas.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPreguntas.Location = new System.Drawing.Point(0, 0);
			this.dgvPreguntas.Name = "dgvPreguntas";
			this.dgvPreguntas.Size = new System.Drawing.Size(484, 261);
			this.dgvPreguntas.TabIndex = 0;
			// 
			// GestionPreguntas
			// 
			this.ClientSize = new System.Drawing.Size(484, 261);
			this.Controls.Add(this.dgvPreguntas);
			this.Name = "GestionPreguntas";
			this.Text = "Preguntas";
			((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
			this.ResumeLayout(false);
		}
	}
}
