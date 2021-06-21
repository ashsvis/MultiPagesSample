using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MultiPagesSample
{
    public partial class Form1 : Form
    {
        private Dictionary<string, UserControl> pages = new Dictionary<string, UserControl>();

        public Form1()
        {
            InitializeComponent();
        }

        private void InsertPage(string pageName)
        {
            UserControl page;
            if (pages.ContainsKey(pageName))
                page = pages[pageName];
            else
            {
                page = new UserControl1() { Dock = DockStyle.Fill };
                pages.Add(pageName, page);
            }
            panelCenter.Controls.Clear();
            panelCenter.Controls.Add(page);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertPage("Panel1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertPage("Panel2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InsertPage("Panel3");
        }
    }
}
