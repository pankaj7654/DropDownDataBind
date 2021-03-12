using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace dropdown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-BA8E536\SQLEXPRESS;Initial Catalog=database3;Integrated Security=True");
      
        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand("insert into Table_1 values(@id,@name,@course)", cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@course",comboBox1.Text.ToString());
           
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cc();
        }
        public void cc()
        {
            cnn.Open();

            SqlCommand cmd = new SqlCommand("select course from Table_1", cnn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["course"].ToString());
            }

            cnn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
