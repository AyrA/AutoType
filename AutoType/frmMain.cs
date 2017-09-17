using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void AutoType()
        {
            var txt = tbKeys.Text.Replace("\r", "").Replace("\n", "{ENTER}");
            SendKeys.SendWait(txt);

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
    }
}
