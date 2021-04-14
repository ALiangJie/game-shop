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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void admin_Load(object sender, EventArgs e)
        {

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

        private void 添加游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin_add f = new admin_add(this);
            f.ShowDialog();
        }

        private void 删除游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("确定删除该游戏马？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();

                string sql = "delete from game where id='" + id + "'and name='" + name + "'";
                //MessageBox.Show(sql);
                Dao dao = new Dao();
                dao.Excute(sql);
                string sql1 = "delete from gamerecord where gameid='" + id + "'";
                dao.Excute(sql1);
                Table();
            }
        }

        private void 修改游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString()};
            admin_add f = new admin_add(str,this);
            f.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 查看游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        public void Table1()
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



        private void button1_Click(object sender, EventArgs e)
        {
                Table1();
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
    }
}
