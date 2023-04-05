using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }
        private void Form1_MouseMove(object obj, MouseEventArgs mea)
        {
            this.Text = string.Format($"x:{mea.X} y: {mea.Y}");
        }
        private Rectangle rect = new Rectangle(50, 50, 90, 50);

        private void Form1_MouseClick(object obj, MouseEventArgs mea)
{
    if (mea.Button == MouseButtons.Left)
    {
        string message = "";
        if (rect.Contains(mea.Location))
        {
            message = "Курсор внутри прямоугольника";
        }
        else if (rect.IntersectsWith(new Rectangle(mea.Location, new Size(1, 1))))
        {
            message = "Курсор на границе прямоугольника";
        }
        else
        {
            message = "Курсор снаружи прямоугольника";
        }
        
        if (Control.ModifierKeys == Keys.Control)
        {
            this.Close();
        }
        
        MessageBox.Show(message);
    }
}
        private void Form1_MouseDown(object obj, MouseEventArgs mea)
        {
            if (mea.Button == MouseButtons.Right)
            {
                this.Text = ($"Размер окна: {this.ClientSize.Width} x {this.ClientSize.Height}");
            }
        }
    }
    
}
