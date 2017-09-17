using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoType
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
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

        private void colorize()
        {
            SuspendUpdate.Suspend(tbKeys);
            int cPos = tbKeys.SelectionStart;
            int start = 0;
            tbKeys.SelectAll();
            tbKeys.SelectionColor = Color.White;
            tbKeys.SelectionBackColor = Color.Black;
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

        private void tbKeys_TextChanged(object sender, EventArgs e)
        {
            colorize();
        }
    }
}
