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
    public partial class user : Form
    {

        string userid1;//记录登录玩家的id
        public user(string userid)
        {
            userid1 = userid;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            toolStripStatusLabel1.Text = "白嫖党永远的家！欢迎id为" + userid1 + "的玩家登录，玩的开心！";
            timer1.Start();
            Table();
        }


        //让表格显示数据
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from game";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);

            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["id"].ToString();
                b = dr["name"].ToString();
                c = dr["type"].ToString();
                d = dr["company"].ToString();


                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);

            }
            dr.Close();//关闭连接
        }

        private void 游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查找游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void user_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 我的库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            string gameid = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的游戏编号
            string sql1 = " select * from gamerecord where id='" + userid1 + "'and gameid='" + gameid + "'";
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql1);
            if (!dc.Read())
            {
                string sql = "insert into gamerecord values('" + userid1 + "','" + gameid + "')";
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("添加游戏成功！");
                }
            }
            else
            {
                MessageBox.Show("游戏已在库存中！");
            }


        }

        private void 我的游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_delete f = new user_delete(userid1);
            f.Show();
        }

        private void 修改登录密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_alter f = new user_alter(userid1);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from game where name='" + textBox1.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);

            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["id"].ToString();
                b = dr["name"].ToString();
                c = dr["type"].ToString();
                d = dr["company"].ToString();


                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);

            }
            dr.Close();//关闭连接
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from game where type='" + textBox2.Text + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);

            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["id"].ToString();
                b = dr["name"].ToString();
                c = dr["type"].ToString();
                d = dr["company"].ToString();


                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);

            }
            dr.Close();//关闭连接
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
