using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO; 

namespace Financial_Portfolio_Manager
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        string sTick, numSh, datePur, pr, val;

        public static string getPrice(string symbol)
        {
            var url = "https://query2.finance.yahoo.com/v10/finance/quoteSummary/" + symbol + "?modules=price";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";

            string s;
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                s = result;
            }

            string s1 = "\"regularMarketPrice\":{\"raw\":";
            int index = s.IndexOf(s1);
            int start = index + 28;
            string s2 = s.Substring(start, 4);
            return s2;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            numSh = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sTick = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime myDateTime = DateTime.Now;
            datePur = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            double d;
            pr = getPrice(sTick);
            d = Double.Parse(pr)* Double.Parse(numSh) ;
            val = d.ToString();
            DBConnect dbEvent = new DBConnect();
            dbEvent.Insert_Transaction(sTick, numSh, datePur, pr, val, DBConnect.str);
            Form3 settings = new Form3();
            this.Close();
            settings.Close();
            MessageBox.Show("Your transaction is saved: ");
        }
    }
}
