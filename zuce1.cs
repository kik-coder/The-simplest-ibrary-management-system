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
    public partial class zuce1 : Form
    {
        string ID = "";
        public zuce1()
        {
            InitializeComponent();
        }
        public zuce1(string id, string name, string sex, string tele, string psw)
        {
            InitializeComponent();
            ID = textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = sex;
            textBox4.Text = tele;
            textBox5.Text = psw;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sql = $"update user_b set id = '{textBox1.Text}',[name] = '{textBox2.Text}',sex = '{textBox3.Text}'," +
                    $"tele = '{textBox4.Text}',psw = {textBox5.Text} where id = '{ID}'";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("id不可为空！");
            }
        }

        private void zuce1_Load(object sender, EventArgs e)
        {

        }
    }
}
