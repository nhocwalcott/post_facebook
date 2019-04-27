using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace Mmosoft.Facebook.Sdk.Examples
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
         void ThreadMethod()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tb1.Text = dlg.FileName;
                pb1.Image = new Bitmap(dlg.FileName);
            }
        }
        private void upload_Click(object sender, EventArgs e)
        {
            Thread newThread = new Thread(new ThreadStart(ThreadMethod));
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Copy(tb1.Text, Path.Combine(@"G:\meo_meo", Path.GetFileName(tb1.Text)), true);
            MessageBox.Show("Đã lưu!");
            this.Hide();
            Form1 dlg2 = new Form1();
            dlg2.ShowDialog();
            this.Close();
        }
    }
}
