using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
    public partial class GestionPreguntas : Form
    {
        // LO QUE ESTABA MAL: La cadena venía vacía y la variable privada sugerida tenía un guión bajo que rompía la coherencia con el README.
        // CORRECCIÓN: Colocar la ruta de conexión a la base de datos 'peducativa' y nombrar la variable 'idModulo' tal como dicta el examen.
        private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
        private int idModulo;

        // LO QUE ESTABA MAL: Los guiones en los parámetros del constructor original.
        // CORRECCIÓN: Definir el constructor para que acepte un único entero llamado 'idRecibido', siguiendo la estructura oficial de la evaluación.
        public GestionPreguntas(int idRecibido)
        {
            InitializeComponent();

            // LO QUE ESTABA MAL: El espacio estaba vacío sin lógica de asignación.
            // CORRECCIÓN: Asignar el parámetro de entrada a nuestra variable de clase para conservar el ID del módulo a lo largo de la sesión.
            this.idModulo = idRecibido;

            // LO QUE ESTABA MAL: Faltaba invocar al método; la grilla de preguntas se quedaba suspendida en blanco.
            // CORRECCIÓN: Llamar explícitamente a la función para que ejecute el filtro SQL inmediatamente al abrir el formulario.
            CargarPreguntas();
        }

        private void CargarPreguntas()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {

                    // LO QUE ESTABA MAL: La consulta apuntaba a una variable inexistente o mal nombrada.
                    // CORRECCIÓN: Concatenar la variable interna 'idModulo' para filtrar las preguntas específicas de la fila seleccionada.
                    string sql = "SELECT * FROM pregunta WHERE id_modulo = " + idModulo;

                    conexion.Open();
                    MySqlDataAdapter adp = new MySqlDataAdapter(sql, conexion);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    dgvPreguntas.DataSource = dt;

                    // MEJORA ESTÁTICA Y ESTRUCTURAL: Ajusta el ancho de las celdas automáticamente para leer las preguntas completas en el diseño.
                    dgvPreguntas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
