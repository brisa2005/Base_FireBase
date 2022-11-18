using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Base_de_datos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "eOz04RahwHDFF7P6VffhVVCdksTrXlfSsPGSIcs9",
            BasePath = "https://basedatos-39072-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {
                MessageBox.Show("Existe un problema en la conección de Internet");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 std = new Class1
            {
                Nombre = txtNombre.Text,
                Cuenta = txtCuenta.Text,
                Semestre = txtSemestre.Text,
                Grupo = txtGrupo.Text
            };
            var setter = client.Set("Lista/Estudiantes/"+txtCuenta.Text,std);
            MessageBox.Show("Datos insertados correctamente");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class1 std = new Class1
            {
                Nombre = txtNombre.Text,
                Cuenta = txtCuenta.Text,
                Semestre = txtSemestre.Text,
                Grupo = txtGrupo.Text

            };
            var setter = client.Update("ListaEstudiante/" + txtCuenta.Text, std);
            MessageBox.Show("Datos actualizados correctamente");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var resultado = client.Delete("Lista/Estudiantes/" + txtCuenta.Text);
            MessageBox.Show("Datos eliminados correctamente");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resultado = client.Delete("Lista/Estudiantes/" + txtCuenta.Text);
            Class1 std = resultado.ResultAs<Class1>();
            txtNombre.Text = std.Nombre;    
            txtSemestre.Text = std.Semestre;
            txtGrupo.Text = std.Grupo;

            MessageBox.Show("Datos encontrados en la base de datos");

        }
    }
}
