using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingoMeter
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            syncFromConfig();
        }

        private void syncToConfig()
        {
            Config.SetAll((int)delay.Value, (int)maxPing.Value,
                setBgColor.BackColor, setGoodColor.BackColor, setNormalColor.BackColor, setBadColor.BackColor,
                isStartUp.Checked);
        }

        private void syncFromConfig()
        {
            delay.Value = Config.Delay;
            maxPing.Value = Config.MaxPing;

            setBgColor.BackColor = Config.BgColor;
            setGoodColor.BackColor = Config.GoodColor;
            setNormalColor.BackColor = Config.NormalColor;
            setBadColor.BackColor = Config.BadColor;

            isStartUp.Checked = Config.RunOnStartup;
        }

        private void setBgColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setBgColor.BackColor = colorDialog1.Color;
            }
        }

        private void setGoodColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setGoodColor.BackColor = colorDialog1.Color;
            }
        }

        private void setNormalColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setNormalColor.BackColor = colorDialog1.Color;
            }
        }

        private void setBadColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                setBadColor.BackColor = colorDialog1.Color;
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            syncToConfig();
            Config.Save();
            NotificationIcon.SyncFromConfig();
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Reset all settings to default?",
                "Reset all?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Config.Reset();
                syncFromConfig();
                NotificationIcon.SyncFromConfig();
            }
        }
    }
}
