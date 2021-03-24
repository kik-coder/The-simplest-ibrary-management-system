using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace zuowanhuijia
{
    public partial class zuce : Form
    {
        public zuce()
        {
            InitializeComponent();
            Table();
        }
       

        public void Table()
        {
            //从数据库读取数据
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from user_b";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.Daoclose();

        }

        private void zuce_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取用户的用户号
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql1 = $"select no from lend where uid = '{id}'";
                    Dao dao1 = new Dao();
                    //IDataReader dc = dao1.read(sql1);
                    SqlDataReader sq =  dao1.read(sql1);
                    if (sq.HasRows)
                    {
                        MessageBox.Show("该用户存在未还书记录"+"，请联系后删除！");
                    }
                    else
                    {
                        string sql = $"delete from user_b where id = '{id}';delete from lend where uid = '{id}';";
                        Dao dao = new Dao();
                        if (dao.Execute(sql) > 0)
                        {
                            MessageBox.Show("删除成功");
                            Table();
                        }
                        else
                        {
                            MessageBox.Show("删除失败" + sql);
                        }
                        dao.Daoclose();
                    }
                }


            }
            catch
            {
                MessageBox.Show("请先在表格选中要删除的用户信息！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string sex = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string tele = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string psw = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                zuce1 zuce = new zuce1(id, name, sex, tele, psw);
                zuce.ShowDialog();
                Table();
            }
            catch
            {
                MessageBox.Show("error!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zuce2 zuce = new zuce2();
            zuce.ShowDialog();
            Table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            zuce3 admin = new zuce3(id);
            admin.ShowDialog();
            Table();
        }
        public void Table_id()
        //号码查询
        {
            //从数据库读取数据
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from user_b where id = '{textBox1.Text}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.Daoclose();

        }
        public void Table_name()
        //名字查询
        {
            //从数据库读取数据
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from user_b where name like '%{textBox2.Text}%'";//模糊查询
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.Daoclose();

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Table_id();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Table_name();
        }
    }
}
