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
    public partial class shiyan : Form
    {
        public shiyan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao1 = new Dao();
            string sql1 = "select MAX(id) from user_b";
            int n1 = dao1.Execute(sql1);
            IDataReader dc = dao1.read(sql1);
            MessageBox.Show("dc");
        }
    }
}
