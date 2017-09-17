using AutoType.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AutoType
{
    public partial class frmMain : Form
    {
        private PrivateFontCollection PFC;

        public frmMain()
        {
            InitializeComponent();

            PFC = new PrivateFontCollection();
            var Data = Resources.font;
            var FontLocation = Marshal.AllocHGlobal(Data.Length);
            Marshal.Copy(Data, 0, FontLocation, Data.Length);
            PFC.AddMemoryFont(FontLocation, Data.Length);
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            btnType.Enabled = false;
            var T = new Thread(() =>
            {
                Thread.Sleep(5000);
                Invoke((MethodInvoker)delegate
                {
                    AutoType();
                });
            });
            T.IsBackground = true;
            T.Start();
        }

        private void tbKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                tbKeys.SelectAll();
            }
        }

        private void tbKeys_TextChanged(object sender, EventArgs e)
        {
            colorize();
        }

        private void lblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new AboutBox()).ShowDialog();
        }

        private void colorize()
        {
            SuspendUpdate.Suspend(tbKeys);
            int cPos = tbKeys.SelectionStart;
            int start = 0;
            tbKeys.SelectAll();
            tbKeys.SelectionColor = Color.White;
            tbKeys.SelectionBackColor = Color.Black;
            tbKeys.SelectionFont = new Font(PFC.Families[0], 12);
            foreach (Syntax.ColorInstruction i in (new Syntax()).Configuration.Colors)
            {
                foreach (Match m in i.Expression.Matches(tbKeys.Text, start))
                {
                    tbKeys.Select(m.Index, m.Length);
                    tbKeys.SelectionColor = i.ForeColor;
                    tbKeys.SelectionBackColor = Color.FromArgb(0x10, 0x10, 0x10);
                }
            }
            tbKeys.Select(cPos, 0);
            tbKeys.SelectionColor = Color.White;
            tbKeys.SelectionBackColor = Color.Black;
            SuspendUpdate.Resume(tbKeys);
        }

        private void AutoType()
        {
            var txt = tbKeys.Text.Replace("\r", "").Replace("\n", "{ENTER}");
            SendKeys.SendWait(txt);
            btnType.Enabled = true;
        }

        private void Insert(string Text)
        {
            tbKeys.Text = tbKeys.Text.Substring(0, tbKeys.SelectionStart) +
                Text +
                tbKeys.Text.Substring(tbKeys.SelectionStart + tbKeys.SelectionLength);
        }
    }
}
