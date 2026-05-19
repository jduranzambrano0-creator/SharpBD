using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class GestionModulos : Form
	{
        // EXAMEN PASO 1: Esta cadena está vacía. Cópiala de MainForm.cs
        private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";

        public GestionModulos()
        {
            InitializeComponent();
            CargarModulos();
        }

        private void CargarModulos()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {

                    // LO QUE ESTABA MAL: Los guiones bajos de la plantilla.
                    // CORRECCIÓN: Usar los nombres reales de las columnas según el CREATE TABLE del README: 'nombre_es' y 'nombre_en'.
                    string consulta = "SELECT id, nombre_es, nombre_en FROM modulo";

                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();

                    // LO QUE ESTABA MAL: La línea estaba vacía con un comentario.
                    // CORRECCIÓN: Ejecutar .Fill() para poblar el DataTable con los registros de la base de datos.
                    adaptador.Fill(tabla);

                    dgvModulos.DataSource = tabla;

                    // MEJORA ESTÁTICA: Distribuye las columnas de manera uniforme en la pantalla para que no se agrupen a la izquierda.
                    dgvModulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        void BtnVerPreguntasClick(object sender, EventArgs e)
        {
            // CONTROL DE SEGURIDAD: Evita que el programa explote si el usuario hace clic sin seleccionar ninguna fila.
            if (dgvModulos.SelectedRows.Count == 0) return;

            // LO QUE ESTABA MAL: El mapeo del ID en la fila seleccionada.
            // CORRECCIÓN: Extrae el valor de la celda "id" del módulo seleccionado en la grilla y lo convierte a entero.
            int idModulo = Convert.ToInt32(dgvModulos.SelectedRows[0].Cells["id"].Value);

            // LO QUE ESTABA MAL: Pasar dos parámetros cuando el diseño del README.md exige explícitamente pasar únicamente el ID.
            // CORRECCIÓN: Se instancia el formulario de preguntas enviando exclusivamente la variable 'idModulo' en el constructor.
            GestionPreguntas frm = new GestionPreguntas(idModulo);
            frm.ShowDialog();
        }

        void BtnGuardarClick(object sender, EventArgs e)
		{
			
		}
	}
}
