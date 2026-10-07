using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Menu : Form
    {
        DbProviderFactory factory;
        DbConnection connection;
        public Menu(DbProviderFactory factory, DbConnection connection)
        {
            InitializeComponent();
            this.factory = factory;
            this.connection = connection;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCommand command = factory.CreateCommand()!;
            command.Connection = connection;
            command.CommandText = "UPDATE crew " +
                "SET health = GREATEST(health - @damage, 0) " +
                "WHERE id = " + Convert.ToInt32(textBoxId.Text) + "; ";

            var par = command.CreateParameter();
            par.ParameterName = "@damage";
            par.Value = Convert.ToInt32(textBox1.Text);
            command.Parameters.Add(par);

            command.ExecuteNonQuery();
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbCommand command = factory.CreateCommand()!;
            command.Connection = connection;
            command.CommandText = "UPDATE crew " +
                "SET health = LEAST(health + @heal, 100) " +
                "WHERE id = " + Convert.ToInt32(textBoxId.Text) + "; ";

            var par = command.CreateParameter();
            par.ParameterName = "@heal";
            par.Value = Convert.ToInt32(textBox2.Text);
            command.Parameters.Add(par);

            command.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbCommand command = factory.CreateCommand()!;
            command.Connection = connection;
            command.CommandText = "UPDATE crew " +
                "SET status = @status " +
                "WHERE id = " + Convert.ToInt32(textBoxId.Text) + "; ";

            var par = command.CreateParameter();
            par.ParameterName = "@status";
            par.Value = textBox3.Text;
            command.Parameters.Add(par);

            command.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
