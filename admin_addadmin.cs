using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameShop
{


    public partial class admin_addadmin : Form
    {

        admin_alter f;
        string[] str = new string[4];
        public admin_addadmin(admin_alter admin1)
        {
            InitializeComponent();
            this.f = admin1;
        }

        public admin_addadmin(string[] str1,admin_alter admin1)
        {
            InitializeComponent();
            this.f = admin1;
            for(int i = 0; i < str1.Length; i++)
            {
                this.str[i] = str1[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
        }

        private void admin_addadmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into admin values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                MessageBox.Show(sql);
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                }
                f.Table();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "delete from admin where id='" + str[0] + "'and name='" + str[1] + "'";
                string sql2 = "insert into admin values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                Dao dao = new Dao();
                dao.Excute(sql);
                dao.Excute(sql2);
                f.Table();
            }
        }
    }
}
