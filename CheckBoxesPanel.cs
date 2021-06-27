using System;
using System.Windows.Forms;

namespace MultiPagesSample
{
    public partial class CheckBoxesPanel : UserControl
    {
        public FlagData Data { get; private set; }

        public EventHandler Applied = delegate { };

        public CheckBoxesPanel()
        {
            InitializeComponent();
        }

        public void Build(FlagData flags)
        {
            Data = flags;

            checkBox1.Checked = Data.Flag1;
            checkBox2.Checked = Data.Flag2;
            checkBox3.Checked = Data.Flag3;
        }

        public void Apply()
        {
            Data.Flag1 = checkBox1.Checked;
            Data.Flag2 = checkBox2.Checked;
            Data.Flag3 = checkBox3.Checked;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btApply.Enabled = true;
        }
    }
}
