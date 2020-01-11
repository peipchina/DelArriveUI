using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAUI
{
    public partial class CarNoPictureForm : Form
    {
        public CarNoPictureForm()
        {
            InitializeComponent();
        }
        private void PictureShow()
        {
            if (this.Tag == null) return;            
            this.pictureBox1.Image = Bitmap.FromFile(this.Tag.ToString());
        }

        private void CarNoPictureForm_Load(object sender, EventArgs e)
        {
            PictureShow();
            PictureMove(pictureBox1);
        }
        private void PictureMove(PictureBox pb)
        {
            pb.Click += Pb_Click;
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
