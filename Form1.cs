using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Zeshan-----event handler for Button 2 ie button2_Click method creates an instance of DBConnect class to use its insert method.
/// Zeshan-----Insert method takes the input from Form1's sign up section as parameters and use them to populate the users table.
/// Zeshan-----Insert method also creates a new table by the name of user's username to store their portfolio.
/// </summary>

namespace Financial_Portfolio_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string Fname=" ", Lname=" ", Uname=" ", Pword=" ";
        int Rprof=0;
        string Signin_UN=" ", Signin_PW=" ";
        public static List<string>[] Portfolio = new List<string>[5];

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnect dbEvent = new DBConnect();
            Boolean incorrect = dbEvent.SelectPW(Signin_PW, Signin_UN);
            DBConnect.str = Signin_UN;
            if (incorrect == false)
                MessageBox.Show("Incorrect username or password");
            else
            {
                Portfolio = dbEvent.Select(Signin_UN);
                var form = new Form2();
                form.Show();
            }
            this.textBox1.Clear();
            this.textBox2.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rprof = comboBox1.SelectedIndex;
            Rprof++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Lname = textBox6.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Uname = textBox4.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            Signin_PW = textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string price = Form3.getPrice(textBox7.Text);
            button3.Text = "$ "+price;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar='*';
            Pword = textBox5.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Fname == " " || Lname == " " || Uname == " " || Pword == " " || Rprof == 0)
                MessageBox.Show("Can not leave a field empty");
            else
            {
                MessageBox.Show("Your user account is created");

                DBConnect dbEvent = new DBConnect();
                dbEvent.Insert(Fname, Lname, Uname, Pword, Rprof);

                Form1 settings = new Form1();
                this.Close();
                settings.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Signin_UN = textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Fname = textBox3.Text;

        }
    }
}
