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
    public partial class Form1 : Form
    {
        public System.Drawing.Bitmap image = null;
        public System.Drawing.Bitmap image2 = null;
        public System.Drawing.Bitmap image3 = null;
        public System.Drawing.Bitmap bkup = null;
        public int red,blue,green;
     
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void histpgramEqualizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invert();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
        //The about fx used to get about windows

        /*About was written  
         * Rohit Yadav
         */

        #region   About
        private void About()
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }
        #endregion

        #region OpenFile image 1
        public void openfile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            string path = open.FileName;
            
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                image = (Bitmap)Bitmap.FromFile(open.FileName);
                bkup = (Bitmap)Bitmap.FromFile(open.FileName);
            }
        }
        #endregion

        #region OpenFile image 2
        public void openfile2()
        {
            OpenFileDialog open2 = new OpenFileDialog();
            open2.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            string path2 = open2.FileName;

            if (open2.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(open2.FileName);
                image2 = (Bitmap)Bitmap.FromFile(open2.FileName);
            }
        }
        #endregion

        #region OpenFile image 3
        public void openfile3()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            string path = open.FileName;

            if (open.ShowDialog() == DialogResult.OK)
            {
                image3 = (Bitmap)Bitmap.FromFile(open.FileName);
                pictureBox3.Image = image3;
            }
        }
        #endregion

        #region savefile
        private void savefile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                pictureBox1.Image.Save(saveFileDialog.FileName);
            }
        }
        
        
        #endregion

        #region Grayscale
        private void grayscale()
        {
            Bitmap grays = (Bitmap)pictureBox1.Image;
            int width = grays.Size.Width;
            int height = grays.Size.Height;
            float fake;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {

                    Color col;
                    col = grays.GetPixel(i, j);
                    grays.SetPixel(i, j, Color.FromArgb((col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3));
                    fake = (float)j * 100 / height;
                    toolStripProgressBar1.Value = ((int)fake);
                    
                }
                image = grays;
            }
            pictureBox1.Image = image;
            toolStripProgressBar1.Value = 0;
        }
        #endregion

        #region Threshold
        private void Thold()
        {
            Bitmap thr = (Bitmap)ResizeBitmap(image, 150, 100);
            int width = thr.Size.Width;
            int height = thr.Size.Height;
            float fake;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {

                    Color col;
                    col = thr.GetPixel(i, j);
                    thr.SetPixel(i, j, Color.FromArgb((col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3, (col.R + col.G + col.B) / 3));
                    fake = (float)j * 100 / height;
                    toolStripProgressBar1.Value = ((int)fake);
                }
            }
            toolStripProgressBar1.Value = 0;
            Threshold img = new Threshold(thr);
            img.ShowDialog();
        }
        #endregion

        #region invert
        private void invert()
        {
            Bitmap invert = (Bitmap)pictureBox1.Image;
            int width = invert.Size.Width;
            int height = invert.Size.Height;
            float fake2=0;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Color col3;
                    col3 = invert.GetPixel(i, j);
                    invert.SetPixel(i, j, Color.FromArgb((255 - col3.R), (255 - col3.G), (255 - col3.B)));
                    fake2= (float)j * 100 / height;
                    toolStripProgressBar1.Value = ((int) fake2);
                }
                image = invert;
            }
            pictureBox1.Image = image;
            toolStripProgressBar1.Value = 0;
        }
        #endregion

        #region convertsepia

        private void sepia()
        {
            Bitmap sepia = (Bitmap)pictureBox1.Image;
            int width = sepia.Size.Width;
            int height = sepia.Size.Height;
            float fake;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {

                    Color col;
                    col = sepia.GetPixel(i, j);
                    int R = (int)(col.R * .393 + col.G * .769 + col.B * .189) ;
                    int G = (int)(col.R * .349 + col.G * .686 + col.B * .168) ;
                    int B = (int)(col.R * .272 + col.G * .534 + col.B * .131) ;

                    if (R > 255) 
                    {
                        R = 255; 
                    }
                    if (G > 255)
                    {
                        G = 255;
                    }
                    if (B > 255)
                    {
                        B = 255;
                    }
                    /*outputRed = (inputRed * .393) + (inputGreen *.769) + (inputBlue * .189)

outputGreen = (inputRed * .349) + (inputGreen *.686) + (inputBlue * .168)

outputBlue = (inputRed * .272) + (inputGreen *.534) + (inputBlue * .131)
                     */ 
                    
                    sepia.SetPixel(i, j, Color.FromArgb( R , G , B ));
                    fake = (float)j * 100 / height;
                    toolStripProgressBar1.Value = ((int)fake);
                    image = sepia;
                }

            }
            pictureBox1.Image = image;
            toolStripProgressBar1.Value = 0;
        
        }
        
        #endregion

        #region resize

        public Bitmap ResizeBitmap(Bitmap b, int wid, int hei)
        {
            Bitmap thimg = new Bitmap(wid, hei);
            using (Graphics g = Graphics.FromImage((Image)thimg))
                g.DrawImage(b, 0, 0, wid, hei);
            return thimg;
        }
        
        #endregion

        #region absolute fx
        private int abs(int z)
        {
            if (z < 0)
                return -z;
            else
                return z;
        }
        #endregion


        #region thresher>>stuff
        public void thresholder(int k, Bitmap pimg)
        {
            grayscale();
            Bitmap grays4 = (Bitmap)pictureBox1.Image;
            int width = grays4.Size.Width;
            int height = grays4.Size.Height;

            for (int l = 0; l < height; l++)
            {
                for (int m = 0; m < width; m++)
                {
                    Color col4;
                    col4 = grays4.GetPixel(m, l);
                    if (col4.R > k)
                    {
                        grays4.SetPixel(m, l, Color.FromArgb(255, 255, 255, 255));
                    }
                    else
                    {
                        grays4.SetPixel(m, l, Color.FromArgb(255, 0, 0, 0));
                    }
                }
            }
            pictureBox1.Image = grays4;
        }
        #endregion 


        #region 2 Filters difference
        private void twoimgdiff()
        {
            Bitmap grays = image;
            Bitmap img2 = image2;
            if (!((grays.Size.Width == img2.Size.Width) && (grays.Size.Height == img2.Size.Height)))
            {
                textBox1.Text = "Error: Dimension Mismatch";
                
            }
            else
            {
                int width = grays.Size.Width;
                int height = grays.Size.Height;
                float fake;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        Color col, col2;
                        col = grays.GetPixel(i, j);
                        col2 = img2.GetPixel(i, j);

                        int r = col.R - col2.R;
                        r = abs(r); //needless to use :-)
                        int g = col.G - col2.G;
                        g = abs(g);
                        int b = col.B - col2.B;
                        b = abs(b);
                        
                        if ((r<=red) && (g<=green) && (b<=blue))
                        {
                            grays.SetPixel(i, j, Color.FromArgb(123 , 123, 123 ));
                        }
                        
                        else
                            grays.SetPixel(i, j, Color.FromArgb( col.R , col.G , col.B));
                        
                        fake = (float)j * 100 / height;
                        toolStripProgressBar1.Value = ((int)fake);

                    }
                    image = grays;
                }
                pictureBox1.Image = image;
                toolStripProgressBar1.Value = 0;
            }
        }
        #endregion

        #region Wall Changer
        private void walchanger()
        {
            Bitmap img2 = (Bitmap)pictureBox3.Image;
            Bitmap grays = (Bitmap)pictureBox1.Image;
            if (!((grays.Size.Width <= img2.Size.Width) && (grays.Size.Height <= img2.Size.Height)))
            {
                textBox1.Text = "Error: Dimension Mismatch";

            }
            else
            {
                int width = grays.Size.Width;
                int height = grays.Size.Height;
                float fake;
                int tr, tg, tb;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {

                        Color col, wall;
                        col = grays.GetPixel(i, j);
                        wall = img2.GetPixel(i, j);
                       if ((col.R == 123) && (col.G == 123) && (col.B == 123))
                        {
                            //tr = col.R + wall.R;
                          //  tg = col.G + wall.G;
                          //  tb = col.B + wall.B;
                            
                              //  if (tr > 255)
                               //     tr = 255;
                             //   if (tg > 255)
                              //      tg = 255;
                              //  if (tb > 255)
                               //     tb = 255;
                            
                            grays.SetPixel(i, j, Color.FromArgb( wall.R , wall.G , wall.B) );
                        
                        }
                        fake = (float)j * 100 / height;
                        toolStripProgressBar1.Value = ((int)fake);

                    }
                    image = grays;
                }
                pictureBox1.Image = image;
                toolStripProgressBar1.Value = 0;
            }
        }
        #endregion 

        #region 2 Filters add
        private void twoimgadd()
        {
            Bitmap grays = image;
            Bitmap img2 = image2;
            if (!((grays.Size.Width == img2.Size.Width) && (grays.Size.Height == img2.Size.Height)))
            {
                textBox1.Text = "Error: Dimension Mismatch";

            }
            else
            {
                int width = grays.Size.Width;
                int height = grays.Size.Height;
                float fake;
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        Color col, col2;
                        col = grays.GetPixel(i, j);
                        col2 = img2.GetPixel(i, j);

                        int r = col.R + col2.R;
                        
                        int g = col.G + col2.G;
                        
                        int b = col.B + col2.B;
                        grays.SetPixel(i, j, Color.FromArgb( r / 2 , g / 2 , b / 2 ));

                        fake = (float)j * 100 / height;
                        toolStripProgressBar1.Value = ((int)fake);

                    }
                    image = grays;
                }
                pictureBox1.Image = image;
                toolStripProgressBar1.Value = 0;
            }
        }
        #endregion


        #region Remove yellow
        private void rmyellow()
        {
            Bitmap grays = (Bitmap)pictureBox1.Image;
            int width = grays.Size.Width;
            int height = grays.Size.Height;
            int r, b, g;
            float fake;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {

                    Color col;
                    col = grays.GetPixel(i, j);
                    g = (col.R + col.B) / 4;
                    r = col.R;
                    r = abs(r);
                    b = col.B;
                    b = b - g;
                    b = abs(b);
                    r = r - g;
                    r = abs(r);
                    
                    grays.SetPixel(i, j, Color.FromArgb( r , col.G , b));
                    fake = (float)j * 100 / height;
                    toolStripProgressBar1.Value = ((int)fake);

                }
                image = grays;
            }
            pictureBox1.Image = image;
            toolStripProgressBar1.Value = 0;
        }
        #endregion

        #region Remove Red
        private void rmred()
        {
            Bitmap grays = (Bitmap)pictureBox1.Image;
            int width = grays.Size.Width;
            int height = grays.Size.Height;
            int r, b, g;
            float fake;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {

                    Color col;
                    col = grays.GetPixel(i, j);
                    g = (col.G+ col.B) / 4;
                    r = col.G;
                    r = abs(r);
                    b = col.B;
                    b = b - g;
                    b = abs(b);
                    r = r - g;
                    r = abs(r);

                    grays.SetPixel(i, j, Color.FromArgb(col.R, r, b ));
                    fake = (float)j * 100 / height;
                    toolStripProgressBar1.Value = ((int)fake);

                }
                image = grays;
            }
            pictureBox1.Image = image;
            toolStripProgressBar1.Value = 0;
        }
        #endregion
        #region Remove Blue(tinge it)
        private void rmblue()
        {
            Bitmap grays = (Bitmap)pictureBox1.Image;
            int width = grays.Size.Width;
            int height = grays.Size.Height;
            int r, b, g;
            float fake;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {

                    Color col;
                    col = grays.GetPixel(i, j);
                    g = (col.R + col.G) / 4;
                    r = col.R;
                    r = abs(r);
                    b = col.G;
                    b = b - g;
                    b = abs(b);
                    r = r - g;
                    r = abs(r);

                    grays.SetPixel(i, j, Color.FromArgb(r, b, col.B));
                    fake = (float)j * 100 / height;
                    toolStripProgressBar1.Value = ((int)fake);

                }
                image = grays;
            }
            pictureBox1.Image = image;
            toolStripProgressBar1.Value = 0;
        }
        #endregion





        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About();    //used about sated above to open 
        }
                              
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            About();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            grayscale();
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayscale();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bkup;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Thold();
        }

        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thresholder(65, image);
            //Thold();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            invert();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        
        
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            savefile();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = 50;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void flipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = image;
            
        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = image;
            
        }

        private void verticallyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.Image = image;
            
        }

        private void horizontallyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = image;
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void rotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = image;
        }

        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sepia();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = bkup;
        }

        private void yCbCrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            pictureBox1.Image = ResizeBitmap(image, 500, 370);
        }

        private void image1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openfile();
        }

        private void image2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openfile2();
        }

        private void image1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }

        private void image2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = image2;

        }

        private void addImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoimgadd();
        }

        private void subtractImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_ButtonClick(object sender, EventArgs e)
        {
            
        }

        private void image1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openfile();
        }

        private void rotate90DegreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = image;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            sepia();
        }

        private void mergeImages12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoimgadd();
        }

        private void differenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void image2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openfile2();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // w = (string)toolStripTextBox1.Text;
           // h = (string)toolStripTextBox2.Text;
           // pictureBox1.Image = ResizeBitmap(image, (int)w.ToString(), (int)h.ToCharArray());
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = ResizeBitmap(image, image.Size.Width / 2, image.Size.Height / 2); 
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = ResizeBitmap(image, image.Size.Width / 4, image.Size.Height / 4); 
      
        }

        private void halfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ResizeBitmap(image, image.Size.Width / 2, image.Size.Height / 2); 
      
        }

        private void quarterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ResizeBitmap(image, image.Size.Width / 4, image.Size.Height / 4); 
      

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ResizeBitmap(image, image.Size.Width / 8, image.Size.Height / 8); 
      
        }

        private void thresholderBasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thresholder(65, image);
        }

        private void cleanerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rmyellow();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rmred();
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rmblue();
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void wallpaperChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walchanger();
        }

        private void image3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfile3();
        }

        private void wallpaperXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            walchanger();
        }

        private void image3forWallpaperXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openfile3();
        }

        private void threshold10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            red = 10;
            green = 10;
            blue = 15;

            twoimgdiff();
        }

        private void threshold20ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            red = 20;
            green = 20;
            blue = 25;

            twoimgdiff();
        
        }

        private void threshold30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            red = 30;
            green = 30;
            blue = 35;

            twoimgdiff();
        
        }

        private void threshold40ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            red = 40;
            green = 40;
            blue = 45;

            twoimgdiff();
        
        }

        private void threshold0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            red = 0;
            green = 0;
            blue = 0;

            twoimgdiff();
        
        }

        private void threshold0ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            red = 0;
            green = 0;
            blue = 0;

            twoimgdiff();

        }

        private void threshold10ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            red = 10;
            green = 10;
            blue = 15;

            twoimgdiff();
        }

        private void threshold20ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            red = 20;
            green = 20;
            blue = 25;

            twoimgdiff();
        }

        private void threshold30ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            red = 30;
            green = 30;
            blue = 35;

            twoimgdiff();
        }

        private void threshold40ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            red = 40;
            green = 40;
            blue = 45;

            twoimgdiff();
        }

        private void threshold50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            red = 50;
            green = 50;
            blue = 55;

            twoimgdiff();
        }

        private void threshold50ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            red = 50;
            green = 50;
            blue = 55;

            twoimgdiff();
        }

        

        

    }
}
