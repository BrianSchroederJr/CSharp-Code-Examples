using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_Async_Call
{
    public partial class frmLogger : Form
    {
        public frmLogger()
        {
            InitializeComponent();
        }

        private void btnLogInfo_Click(object sender, EventArgs e)
        {
            this.Text = Logger.LogWrite(txtLogPath.Text, txtLogInfo.Text);
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void btnSyncRead_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Logger.LogRead(txtLogPath.Text));
        }

        private async void btnAsyncRead_Click(object sender, EventArgs e)
        {
            btnAsyncRead.Enabled = false;
            string s = await Logger.LogReadAsync(txtLogPath.Text);
            MessageBox.Show(s);
            btnAsyncRead.Enabled = true;
        }
    }
}
