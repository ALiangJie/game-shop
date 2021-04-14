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
    public partial class user_delete : Form
    {
        string userid1;
        public user_delete(string userid)
        {
            
            userid1 = userid;
            InitializeComponent();
            Table();
        }

        //让表格显示数据
        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from gamerecord where id='" + userid1 + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string gameid1 = dr["gameid"].ToString();
                string sql2 = "select * from game where id='" +gameid1+ "'";
                IDataReader dr2 = dao.read(sql2);
                dr2.Read();
                string a, b, c, d;
                a = dr2["id"].ToString();
                b = dr2["name"].ToString();
                c = dr2["type"].ToString();
                d = dr2["company"].ToString();


                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();//关闭连接
        }

        private void user_delete_Load(object sender, EventArgs e)
        {

        }

        private void 删除选中的游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gameid = dataGridView1.SelectedCells[0].Value.ToString();
            string sql = " delete gamerecord where id='" + userid1 + "' and gameid='" + gameid + "'";
            Dao dao = new Dao();
            dao.Excute(sql);
            Table();
        }
    }
}
