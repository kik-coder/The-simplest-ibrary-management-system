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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int a = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else {
                MessageBox.Show("输入有空项,请重新输入");
            }
        }
        //登陆方法判断
        public void Login()
        {
            //用户
            if (radioButtonuser.Checked == true)
            {
                Dao dao = new Dao();
                string sql = "select * from user_b where id='" + textBox1.Text + "'and psw = '" + textBox2.Text + "'";//这是sql语句与查询的结合
                //注意数据库的命名问题，不可用user当表名
                //MessageBox.Show(sql);
                IDataReader dc = dao.read(sql);
                //dc.Read();
                //MessageBox.Show(dc[0].ToString(),dc["name"].ToString());
                //dc.Read();//这里会从第一行读取,read会返回一个bool型
                if (dc.Read())
                {
                    Date.UID = dc["id"].ToString();
                    Date.Uname = dc["name"].ToString();
                    //这里将账号和用户名传过去，方便后面使用
                    MessageBox.Show("登陆成功");
                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();//对话框形式打开，对原窗口不可修改
                    this.Show();
                }
                //MessageBox.Show(dc[0].ToString());//会读到第一个内容
                else { 
                    MessageBox.Show("登陆失败");                   
                }
                dao.Daoclose();
            }
            //管理员
            else {
                Dao dao = new Dao();
                string sql = "select * from admin where name ='" + textBox1.Text + "'and psw = '" + textBox2.Text + "'";//这是sql语句与查询的结合
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登陆成功");
                    admin1 admin = new admin1();
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();
                }
                //MessageBox.Show(dc[0].ToString());//会读到第一个内容
                else
                {
                    MessageBox.Show("登陆失败");
                    
                }
                dao.Daoclose();
            }
            //MessageBox.Show("单选框未选择");

        }

        private void button2_Click(object sender, EventArgs e)//注册
        {
            zuce z = new zuce();
            z.ShowDialog();
        }
    }
}
