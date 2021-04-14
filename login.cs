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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 700)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                if (comboBox1.Text == "玩家")
                {
                    string sql = "select *from playergame where id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
                    Dao dao = new Dao();
                    IDataReader dr = dao.read(sql);
                    dr.Read();
                    string userid = dr["id"].ToString();
                    user user1 = new user(userid);

                    user1.Show();
                    this.Hide();
                    //this.Close();
                }
                else
                {
                    if (comboBox1.Text == "管理员")
                    {          
                        admin admin1 = new admin();
                        admin1.Show();
                        this.Hide();
                        //this.Close();
                    }
                    else if (comboBox1.Text == "超级管理员")
                    {
                        admin_alter admin_alter1 = new admin_alter();
                        admin_alter1.Show();
                        this.Hide();
                    }
                }
                
                timer1.Stop();
            }
        }
        
        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (login1())
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                
            }
        }

        private bool login1()
        {
            if(textBox1.Text==""|| textBox2.Text == "" || comboBox1.Text== "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.Text == "玩家")
            {
                string sql = "select *from playergame where id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("用户不存在或密码错误！hxd密码不要忘记");
                    return false;
                }

            }
            if (comboBox1.Text == "管理员")
            {
                string sql = "select *from admin where id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("用户不存在或密码错误！hxd密码不要忘记");
                    return false;
                }
            }
            if (comboBox1.Text == "超级管理员")
            {
                string sql = "select *from superadmin where id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("hxd别试了！这能告诉你！");
                    return false;
                }
            }

            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
