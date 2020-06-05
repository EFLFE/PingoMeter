using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace PingoMeter
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            SyncFromConfig();
        }

        private void SyncToConfig(IPAddress address)
        {
            Config.SetAll(
                delay: (int)delay.Value,
                maxPing: (int)maxPing.Value,
                bgColor: setBgColor.BackColor,
                goodColor: setGoodColor.BackColor,
                normalColor: setNormalColor.BackColor,
                badColor: setBadColor.BackColor,
                runOnStartup: false,
                address: address,
                alarmConnectionLost: alarmConnectionLost.Checked,
                alarmTimeOut: alarmTimeOut.Checked,
                alarmResumed: alarmResumed.Checked);
        }

        private void SyncFromConfig()
        {
            delay.Value   = Config.Delay;
            maxPing.Value = Config.MaxPing;

            setBgColor.BackColor     = Config.BgColor.Color;
            setGoodColor.BackColor   = Config.GoodColor.Color;
            setNormalColor.BackColor = Config.NormalColor.Color;
            setBadColor.BackColor    = Config.BadColor.Color;

            alarmTimeOut.Checked        = Config.AlarmTimeOut;
            alarmConnectionLost.Checked = Config.AlarmConnectionLost;
            alarmResumed.Checked        = Config.AlarmResumed;

            //isStartUp.Checked = Config.s_runOnStartup;

            if (Config.TheIPAddress != null)
                ipAddress.Text = Config.TheIPAddress.ToString();
        }

        private void SetBgColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setBgColor.BackColor = colorDialog1.Color;
            }
        }

        private void SetGoodColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setGoodColor.BackColor = colorDialog1.Color;
            }
        }

        private void SetNormalColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setNormalColor.BackColor = colorDialog1.Color;
            }
        }

        private void SetBadColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setBadColor.BackColor = colorDialog1.Color;
            }
        }

        private void IsStartUp_CheckedChanged(object sender, EventArgs e)
        {
            //if (lockEvents)
            // TODO IsStartUp
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            // check ip address
            if (!IPAddress.TryParse(ipAddress.Text, out IPAddress address))
            {
                MessageBox.Show("IP Address is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SyncToConfig(address);
            Config.Save();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Reset all settings to default?",
                "Reset all?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Config.Reset();
                SyncFromConfig();
            }
        }

        private void AlarmTimeOut_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/EFLFE/PingoMeter");
        }
    }
}
