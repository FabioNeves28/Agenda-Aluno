using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;




namespace Pesquisando_Dados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string MySqlClientString = "server= localhost;user id = root; " +
            "database = bdagenda";


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            conn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tbalunos", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                MessageBox.Show("Favor digitar o código para realizar a pesquisa", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(MySqlClientString);
                conn.Open();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tbalunos where codigo=" + txtcodigo.Text, conn);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                txtnome.Text = dt.Rows[0][1].ToString();
                txtendereco.Text = dt.Rows[0][2].ToString();
                txttelefone.Text = dt.Rows[0][3].ToString();
                txtemail.Text = dt.Rows[0][4].ToString();
                txtidade.Text = dt.Rows[0][5].ToString();
                txtdatanas.Text = dt.Rows[0][6].ToString();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tbalunos(codigo,nome,endereco,fone,email,idade," +
                "datanas) " +
                "VALUES("+txtcodigo.Text+",'"+txtnome.Text+"','"+txtendereco.Text+"'," +
                "'"+txttelefone.Text+"'," +
                "'"+txtemail.Text+"',"+txtidade.Text+",'"+txtdatanas.Text+"')";
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            txtcodigo.Clear();
            txtnome.Clear();
            txtendereco.Clear();
            txttelefone.Clear();
            txtemail.Clear();
            txtidade.Clear();
            txtdatanas.Clear();
            txtcodigo.Focus();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE tbalunos SET nome = '" + txtnome.Text +
"', endereco = '" + txtendereco.Text + "', fone = '" + txttelefone.Text + "'," +
"email = '" + txtemail.Text + "',idade = '" + txtidade.Text + "'," +
"datanas = '" + txtdatanas.Text + "' WHERE codigo = '" + txtcodigo.Text + "' ";
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM tbalunos WHERE codigo = " + txtcodigo.Text;
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            MySqlCommand cmd = new MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo_busca =
            dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtcodigo.Text = codigo_busca;
            MySqlConnection conn = new MySqlConnection(MySqlClientString);
            conn.Open();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tbalunos WHERE codigo = " + codigo_busca, conn);
            da.Fill(dt);
            txtnome.Text = dt.Rows[0][1].ToString();
            txtendereco.Text = dt.Rows[0][2].ToString();
            txttelefone.Text = dt.Rows[0][3].ToString();
            txtemail.Text = dt.Rows[0][4].ToString();
            txtidade.Text = dt.Rows[0][5].ToString();
            txtdatanas.Text = dt.Rows[0][6].ToString();


        }
    }
}