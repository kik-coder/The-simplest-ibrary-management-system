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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();//各控件的显示
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 admin21 = new admin21();
            admin21.ShowDialog();
            Table();
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        public void Table() {
            //从数据库读取数据
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from book";
            IDataReader dc = dao.read(sql);

            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.Daoclose();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from book where id = '{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0) {
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
            catch {
                MessageBox.Show("请先在表格选中要删除的图书记录！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string auther = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string chuban = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string kucun = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                admin22 admin = new admin22(id, name, auther, chuban, kucun);
                admin.ShowDialog();
                Table();
            }
            catch {
                MessageBox.Show("error!");
            }
            //admin22 admin22 = new admin22();
            //admin22.ShowDialog();
        }
        public void Table_id()
            //号码查询
        {
            //从数据库读取数据
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select * from book where id = '{textBox1.Text}'";
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
            string sql = $"select * from book where name like '%{textBox2.Text}%'";//模糊查询
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.Daoclose();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Table_id();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Table_name();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.SelectedRows.Count;//获取当前选中的行数
            string sql = $"delete from book where id in(";//使用拼接来写多行的删除sql语句
            for (int i = 0; i < n; i++) {
                //MessageBox.Show(dataGridView1.SelectedRows[i].Cells[i].Value.ToString());
                sql += $"'{dataGridView1.SelectedRows[i].Cells[0].Value.ToString()}',";
                //这里拼接的sql多了一个，用remove去掉
            }
            sql = sql.Remove(sql.Length - 1);
            sql += ")";
            Dao dao = new Dao();
            if (dao.Execute(sql) > n - 1)//受影响的行数
            {
                MessageBox.Show($"成功删除{n}条信息");
                Table();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
