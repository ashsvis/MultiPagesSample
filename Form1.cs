using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MultiPagesSample
{
    public partial class Form1 : Form
    {
        private ComplexData complexData;

        private Dictionary<string, UserControl> pages = new Dictionary<string, UserControl>();

        public Form1()
        {
            InitializeComponent();

            complexData = new ComplexData();
        }

        private void InsertPage(string pageName, Type pageType)
        {
            UserControl page;
            if (pages.ContainsKey(pageName))
                page = pages[pageName];
            else
            {
                page = (UserControl) Activator.CreateInstance(pageType);
                page.Dock = DockStyle.Fill;
                pages.Add(pageName, page);
            }
            panelCenter.Controls.Clear();
            panelCenter.Controls.Add(page);
        }

        private void OnPropertyPanelApplied(object sender, EventArgs e)
        {
            if (sender is TextBoxesPanel textsPanel)
                complexData.Texts = textsPanel.Data;
            if (sender is CheckBoxesPanel flagsPanel)
                complexData.Flags = flagsPanel.Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelCenter.Controls.Clear();
            new TextBoxesPanel { Parent = panelCenter, Dock = DockStyle.Fill, Applied = OnPropertyPanelApplied }.Build(complexData.Texts);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelCenter.Controls.Clear();
            new CheckBoxesPanel { Parent = panelCenter, Dock = DockStyle.Fill, Applied = OnPropertyPanelApplied }.Build(complexData.Flags);
        }
    }

    public class ComplexData
    {
        public TextData Texts { get; set; } = new TextData();
        public FlagData Flags { get; set; } = new FlagData();
    }

    public class TextData
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
    }

    public class FlagData
    {
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }
        public bool Flag3 { get; set; }
    }
}
