using AutoType.Properties;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace AutoType
{
    public partial class frmMain : Form
    {
        private PrivateFontCollection PFC;

        /// <summary>
        /// Initializes Form and optionally loads a File
        /// </summary>
        /// <param name="FileName">File name to Load (if not null or empty)</param>
        public frmMain(string FileName = null)
        {
            InitializeComponent();

            PFC = new PrivateFontCollection();
            var Data = Resources.font;
            var FontLocation = Marshal.AllocHGlobal(Data.Length);
            Marshal.Copy(Data, 0, FontLocation, Data.Length);
            PFC.AddMemoryFont(FontLocation, Data.Length);

            foreach (string MainLabel in KeyCodes.Groups)
            {
                var MainItem = (ToolStripMenuItem)cms.Items.Add(MainLabel);
                foreach (var Entry in KeyCodes.GetKeys(MainLabel))
                {
                    var SubItem = MainItem.DropDownItems.Add(Entry.Key);
                    SubItem.Tag = Entry.Value;
                    SubItem.Click += InsertSpecial;
                }
            }

            if (!string.IsNullOrEmpty(FileName) && File.Exists(FileName))
            {
                tbKeys.Text = File.ReadAllText(FileName);
            }
        }

        private void InsertSpecial(object sender, EventArgs e)
        {
            Insert(((ToolStripItem)sender).Tag.ToString());
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbKeys.Text))
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
            else
            {
                MessageBox.Show("The text is empty", "Empty text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tbKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                tbKeys.SelectAll();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                cms.Show(tbKeys, new Point(tbKeys.Width - 5, tbKeys.Height - 5));
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

        /// <summary>
        /// Colorizes Syntax
        /// </summary>
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

        /// <summary>
        /// Performs Autotype
        /// </summary>
        private void AutoType()
        {
            var txt = tbKeys.Text.Replace("\r", "").Replace("\n", "{ENTER}");
            SendKeys.SendWait(txt);
            btnType.Enabled = true;
        }

        /// <summary>
        /// Inserts Text at the current Location
        /// </summary>
        /// <param name="Text">Text</param>
        private void Insert(string Text)
        {
            var Pos = tbKeys.SelectionStart;
            tbKeys.Text = tbKeys.Text.Substring(0, tbKeys.SelectionStart) +
                Text +
                tbKeys.Text.Substring(tbKeys.SelectionStart + tbKeys.SelectionLength);
            tbKeys.SelectionStart = Pos + Text.Length;
        }
    }
}
