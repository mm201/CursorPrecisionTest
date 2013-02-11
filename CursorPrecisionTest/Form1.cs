using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CursorPrecisionTest.Properties;
using System.IO;
using System.Runtime.InteropServices;

namespace CursorPrecisionTest
{
    public partial class Form1 : Form
    {
        private Cursor m_cursor;
        private Point m_mouse_pos;

        public Form1()
        {
            InitializeComponent();
            m_cursor = new Cursor(LoadCursorFromFile("Resources\\cursor.cur"));
            panel1.Cursor = m_cursor;
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadCursorFromFile(string path);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = (int)g.DpiX / 12 - 1;

            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, panel1.Width, panel1.Height));
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(m_mouse_pos.X - width, m_mouse_pos.Y, width * 2 + 1, 1));
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(m_mouse_pos.X, m_mouse_pos.Y - width, 1, width * 2 + 1));
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            m_mouse_pos = e.Location;
            panel1.Invalidate();
        }

    }
}
