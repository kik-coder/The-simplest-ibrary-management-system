using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zuowanhuijia
{
    public partial class zuce3 : Form
    {
       string ID = "";
        public zuce3()
        {
            InitializeComponent();
        }
        public zuce3(string id)
        {
            InitializeComponent();
            ID = id;
        }
        private void admin23_Load(object sender, EventArgs e)
        {
            Table();
        }
        public void Table()
        {
            //从数据库读取数据
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select [no],[bid],[datetime] from lend where uid = '{ID}'";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(),dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.Daoclose();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
