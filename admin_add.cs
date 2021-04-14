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
    public partial class admin_add : Form
    {
        admin admin1;
        string[] str = new string[4];
        public admin_add(admin f)
        {
            InitializeComponent();
            button3.Visible = false;//添加时隐藏修改按钮
            admin1 = f;
        }

        //用于修改，添加参位数组
        public admin_add(string[] a,admin f)
        {
            InitializeComponent();
            for(int i = 0; i < 4; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            button1.Visible = false;//修改时隐藏插入保存按钮
            admin1 = f;
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        //添加一款游戏
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "insert into game values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                //MessageBox.Show(sql);
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功");
                }
                admin1.Table();
            }
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
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
                MessageBox.Show("修改后有空项，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != str[0])
                {
                    string sql = "update game set id='" + textBox1.Text + "'where id='" + str[0] + "' and name='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[0] = textBox1.Text;
                }

                if (textBox2.Text != str[1])
                {
                    string sql = "update game set name='" + textBox2.Text + "'where id='" + str[0] + "' and name='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[1] = textBox2.Text;
                }

                if (textBox3.Text != str[2])
                {
                    string sql = "update game set type='" + textBox3.Text + "'where id='" + str[0] + "' and name='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[2] = textBox3.Text;
                }

                if (textBox4.Text != str[3])
                {
                    string sql = "update game set company='" + textBox4.Text + "'where id='" + str[0] + "' and name='" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[3] = textBox4.Text;
                }
                admin1.Table();
            }
        }
    }
}
