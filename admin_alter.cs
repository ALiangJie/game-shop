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
    public partial class admin_alter : Form
    {
        public admin_alter()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }
        //让表格显示数据
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from admin";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);

            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["id"].ToString();
                b = dr["name"].ToString();
                c = dr["phone"].ToString();
                d = dr["password"].ToString();


                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);

            }
            dr.Close();//关闭连接
        }
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin_addadmin f = new admin_addadmin(this);
            f.ShowDialog();
        }

        private void admin_alter_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确认删除马？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string adminid = dataGridView1.SelectedCells[0].Value.ToString();
                string adminnaem = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from admin where id='" + adminid + "'and name='" + adminnaem + "'";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功！");
                }
            }
            Table();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a, b, c, d;
            a = dataGridView1.SelectedCells[0].Value.ToString();
            b = dataGridView1.SelectedCells[1].Value.ToString();
            c = dataGridView1.SelectedCells[2].Value.ToString();
            d = dataGridView1.SelectedCells[3].Value.ToString();

            string[] str = { a, b, c, d };
            admin_addadmin f = new admin_addadmin(str,this);
            f.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
