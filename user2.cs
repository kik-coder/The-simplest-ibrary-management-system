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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
        }

        private void 查看图书和借阅_Load(object sender, EventArgs e)
        {
            Table();
        }
        public void Table()
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//库存
            if (number < 1)
            {
                MessageBox.Show("库存不足，请联系管理员购入");
            }
            else {
                string sql = $"insert into lend([uid],[bid],[datetime]) values('{Date.UID}','{id}',GETDATE());" +
                    $"update book set kucun = kucun-1 where id = '{id}'";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 1) {//因为执行了两条指令
                    MessageBox.Show($"用户：{Date.Uname}借出了图书{id}");
                    Table();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
