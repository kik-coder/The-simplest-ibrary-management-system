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
    public partial class admin22 : Form
        //修改窗口
    {
        string ID = "";
        public admin22()
        {
            InitializeComponent();
        }

        public admin22(string id, string name, string auther, string press, string number) {
            InitializeComponent();
            ID = textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = auther;
            textBox4.Text = press;
            textBox5.Text = number;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql = $"update book set id = '{textBox1.Text}',[name] = '{textBox2.Text}',auther = '{textBox3.Text}'," +
                    $"chuban = '{textBox4.Text}',kucun = {textBox5.Text} where id = '{ID }'";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
            }
            else {
                MessageBox.Show("id不可为空！");
            }
        }
    }
}
