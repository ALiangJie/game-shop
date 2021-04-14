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
    public partial class user_alter : Form
    {
        string userid1;
        public user_alter()
        {
            InitializeComponent();
        }


        public user_alter(string userid)
        {
            InitializeComponent();
            userid1 = userid;
            string sql = "select * from playergame where id='" + userid1 + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            dr.Read();
            textBox1.Text = dr["password"].ToString();
            dr.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update playergame set password='" + textBox2.Text + "'where id='" + userid1 + "'";
            Dao dao = new Dao();
            int i = dao.Excute(sql);
            if (i > 0)
            {
                MessageBox.Show("hxd,密码更新了");
            }

        }
    }
}
