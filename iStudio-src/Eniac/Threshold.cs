using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eniac
{    
    public partial class Threshold : Form
    {

        private System.Drawing.Bitmap pbkup = null;
        public System.Drawing.Bitmap p2 = null;
        public Form1 frmain;
        private byte threshold = 127;
        public Threshold(Bitmap pimg)
        {
            InitializeComponent();
            pbkup = pimg;
            p2 = pbkup;
            
          thresholdBox.Text = threshold.ToString();
          slider.Value = threshold;
         
        }

        #region thresher>>stuff
        public void thresholder(int k , Bitmap pimg )
        {
            preview.Image = pbkup;
            Bitmap grays4 = (Bitmap)preview.Image;
            int width = 150;
            int height = 100;
            
            for (int l = 0; l < height; l++)
            {
                for (int m = 0; m < width; m++)
                {   Color col4;
                    col4 = grays4.GetPixel(m , l);
                    if (col4.R > k)
                    {
                        grays4.SetPixel(m, l , Color.FromArgb(255 , 255 , 255 , 255 ));
                    }
                    else
                    {
                        grays4.SetPixel(m, l , Color.FromArgb(255 , 0 , 0 , 0 ));
                    }
                }
            }
            preview.Image = grays4;
        }
        #endregion 
       
        // Slider position changed

        private void slider_ValuesChanged(object sender, System.EventArgs e)
        {
            threshold = (byte)slider.Value;
            thresholdBox.Text = threshold.ToString();
        }

        private void thresholdBox_ValuesChanged(object sender, System.EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Threshold_Load(object sender, EventArgs e)
        {
            preview.Image = pbkup;
              threshold = (byte)slider.Value;
           thresholdBox.Text = threshold.ToString();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            preview.Image = pbkup;
            threshold = (byte)slider.Value;
        
           // string ttmp = (string)threshold.ToString();

           thresholdBox.Text = (string)slider.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void preview_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pbkup = p2;
            thresholder(slider.Value , pbkup);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Theshold code will be added soon");
            // thresholdBox.Text;
        }

     }
}
