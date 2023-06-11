using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using System.Security.Cryptography;
using TelPhoneApp;

namespace OrderProgram {
    public partial class MainForm : Form {
        string Conn = "Server=cs-dept.esm.kr;Port=23306;Database=syspDB;Uid=syspDB;Pwd=qotngns";
        public MainForm() {
            InitializeComponent();
        }
        private void printDelivery()
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                string sql = "SELECT * FROM Delivery";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds1, "Delivery");
            }

            Display.Rows.Clear();
            foreach (DataRow r in ds1.Tables[0].Rows)
            {
                Display.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (newAddress.Text != "" && newNum.Text != "") {
                Order newOrder = new Order(newAddress.Text, newNum.Text);

                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    string str = $"INSERT INTO Delivery VALUES ('{newOrder.getAdrress()}', '{newOrder.getNum()}', null, null, null)";
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    cmd.ExecuteNonQuery();
                }

                printDelivery();

                newAddress.Text = "";
                newNum.Text = "";
                newAddress.Focus();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            string phone = search.Text;
            if (phone == "")
                return;

            remove.Text = "";
            remove.Focus();

            DataSet ds = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                string sql = $"SELECT * FROM Delivery WHERE num = {phone}";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds, "Delivery");
            }

            Display.Rows.Clear();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                Display.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
            }
        }
        private void btnRemove_Click(object sender, EventArgs e) {
            string phone = remove.Text;
            if (phone == "")
                return;

            remove.Text = "";
            remove.Focus();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                string str = $"DELETE FROM Delivery where num={phone}";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.ExecuteNonQuery();
            }


            printDelivery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printDelivery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                string sql = "SELECT * FROM Baemin";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds, "Delivery");
            }

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                conn.Open();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    string str = $"INSERT INTO Delivery VALUES ('{r[0]}', '{r[1]}', null, null, null)";
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    cmd.ExecuteNonQuery();
                }
            }

            printDelivery();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            int selectRow = Display.GetCellCount(DataGridViewElementStates.Selected);
            if (selectRow < 1){
                return;
            }
            foreach (DataGridViewRow row in this.Display.SelectedRows)
            {
                DataGridViewRow selectedRow = row;
                string deleteAddress = selectedRow.Cells[0].Value.ToString();
                string deletePhone = selectedRow.Cells[1].Value.ToString();
                string deleteState = selectedRow.Cells[4].Value.ToString();

                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    string str = $"DELETE FROM Delivery where num={deletePhone}";
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    cmd.ExecuteNonQuery();
                }

                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    conn.Open();
                    Random r = new Random();
                    string company = (r.Next(0, 100)%2) == 0 ? "바로고" : "생각대로";
                    int time = r.Next(30, 60);
                    string str = $"INSERT INTO Delivery VALUES ('{deleteAddress}', '{deletePhone}', {time}, '{company}', '{deleteState}')";
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    cmd.ExecuteNonQuery();

                    if (company.Equals("바로고"))
                    {
                        companyPicture.Image = global::TelPhoneApp.Properties.Resources.바로고;
                    }
                    else
                    {
                        companyPicture.Image = global::TelPhoneApp.Properties.Resources.생각대로;
                    }
                }
            }
            printDelivery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                string sql = "SELECT * FROM Delivery";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds1, "Delivery");
            }

            int bCnt = 0;
            int sCnt = 0;
            foreach (DataRow r in ds1.Tables[0].Rows)
            {
                if (r[3].Equals("바로고"))
                {
                    bCnt++;
                }
                else
                {
                    sCnt++;
                }
            }
            textBox1.Text = bCnt.ToString();
            textBox2.Text = sCnt.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                string sql = $"SELECT * FROM Delivery where state=0";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds1, "Delivery");
            }

            Display.Rows.Clear();
            foreach (DataRow r in ds1.Tables[0].Rows)
            {
                Display.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                string sql = $"SELECT * FROM Delivery where state=1";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds1, "Delivery");
            }

            Display.Rows.Clear();
            foreach (DataRow r in ds1.Tables[0].Rows)
            {
                Display.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();

            using (MySqlConnection conn = new MySqlConnection(Conn))
            {
                string sql = $"SELECT * FROM Delivery where state=2";
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                adpt.Fill(ds1, "Delivery");
            }

            Display.Rows.Clear();
            foreach (DataRow r in ds1.Tables[0].Rows)
            {
                Display.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.mega-mgccoffee.com/");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            printDelivery();
            this.Close();
        }
    }
}
