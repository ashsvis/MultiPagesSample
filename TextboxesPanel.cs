using System;
using System.Windows.Forms;

namespace MultiPagesSample
{
    public partial class TextBoxesPanel : UserControl
    {
        public TextData Data { get; private set; }

        public EventHandler Applied = delegate { };

        public TextBoxesPanel()
        {
            InitializeComponent();
        }

        public void Build(TextData texts)
        {
            Data = texts;

            textBox1.Text = Data.Text1;
            textBox2.Text = Data.Text2;
            textBox3.Text = Data.Text3;
        }

        public void Apply()
        {
            Data.Text1 = textBox1.Text;
            Data.Text2 = textBox2.Text;
            Data.Text3 = textBox3.Text;

            btApply.Enabled = false;
        }

        protected void OnApplied()
        {
            Applied(this, EventArgs.Empty);
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            try
            {
                Apply();
                OnApplied();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btApply.Enabled = true;
        }
    }
}
