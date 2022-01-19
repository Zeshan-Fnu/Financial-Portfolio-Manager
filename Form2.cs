using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial_Portfolio_Manager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string>[] PF = Form1.Portfolio;
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
            this.dataGridView3.DataSource = null;
            this.dataGridView4.DataSource = null;
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();
            this.dataGridView3.Rows.Clear();
            this.dataGridView4.Rows.Clear();

            if (dataGridView1.ColumnCount == 0)
                dataGridView1.Columns.Add("StockTicker", "Stock Ticker");
            foreach (string x in PF[0])
            {
                dataGridView1.Rows.Add(x);

            }

            if (dataGridView2.ColumnCount == 0)
                dataGridView2.Columns.Add("DateOfPurchase", "Date of purchase");
            foreach (string x in PF[2])
            {
                dataGridView2.Rows.Add(x);

            }

            double net_val = 0;

            if (dataGridView3.ColumnCount == 0)
                dataGridView3.Columns.Add("PurchaseValue", "Purchase Value");
            foreach (string x in PF[4])
            {
                dataGridView3.Rows.Add(x);
                net_val += Double.Parse(x);
            }

            int ind = 0;
            if (dataGridView4.ColumnCount == 0)
                dataGridView4.Columns.Add("CurrentValue", "Current Value");
            foreach (string x in PF[0])
            {
                double q = Double.Parse(PF[1].ElementAt(ind));
                string y = Form3.getPrice(x);
                double p = Double.Parse(y);
                y = (p * q).ToString();
                dataGridView4.Rows.Add(y);
                ind++;
                net_val -= Double.Parse(y);
            }
            

            label1.Text = "$ " + net_val.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
