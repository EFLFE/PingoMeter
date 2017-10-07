using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingoMeter
{
    // config data mem
    internal static class Config
    {
        private const string CONF_FILE_NAME = "config.txt";

        public static int Delay;

        public static int MaxPing;

        public static Color BgColor;
        public static Color GoodColor;
        public static Color NormalColor;
        public static Color BadColor;

        public static bool RunOnStartup;

        public static void SetAll(int delay, int maxPing, Color bgColor, Color goodColor,
                                  Color normalColor,  Color badColor, bool runOnStartup)
        {
            Delay = delay;
            MaxPing = maxPing;
            BgColor = bgColor;
            GoodColor = goodColor;
            NormalColor = normalColor;
            BadColor = badColor;
            RunOnStartup = runOnStartup;
        }

        public static void Reset()
        {
            Delay       = 3000;
            MaxPing     = 250;
            BgColor     = Color.FromArgb(70, 0, 0);
            GoodColor   = Color.FromArgb(120, 180, 0);
            NormalColor = Color.FromArgb(255, 180, 0);
            BadColor    = Color.FromArgb(255, 0, 0);
            RunOnStartup = true;
        }

        public static void Load()
        {
            if (File.Exists(CONF_FILE_NAME))
            {
                string[] conf = File.ReadAllLines(CONF_FILE_NAME);

                for (int i = 0; i < conf.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(conf[i]) || conf[i].Trim()[0] == '#')
                        continue;

                    string line = conf[i].Trim();
                    string[] split = line.Split(new char[] { ' ' }, 2);

                    if (split.Length == 2)
                    {
                        switch (split[0])
                        {
                        case nameof(Delay):
                            int.TryParse(split[1], out Delay);
                            break;

                        case nameof(MaxPing):
                            int.TryParse(split[1], out MaxPing);
                            break;

                        case nameof(BgColor):
                            setColorFromString(ref BgColor, split[1]);
                            break;

                        case nameof(GoodColor):
                            setColorFromString(ref GoodColor, split[1]);
                            break;

                        case nameof(NormalColor):
                            setColorFromString(ref NormalColor, split[1]);
                            break;

                        case nameof(BadColor):
                            setColorFromString(ref BadColor, split[1]);
                            break;

                        case nameof(RunOnStartup):
                            bool.TryParse(split[1], out RunOnStartup);
                            break;
                        }
                    }
                }
            }
            else
            {
                Reset();
                Save();
            }
        }

        private static void setColorFromString(ref Color color, string str)
        {
            if (str.IndexOf(':') != -1)
            {
                string[] rgb = str.Split(':');
                if (rgb.Length == 3)
                {
                    if (int.TryParse(rgb[0], out int r) && r > -1 && r < 256 &&
                        int.TryParse(rgb[1], out int g) && g > -1 && g < 256 &&
                        int.TryParse(rgb[2], out int b) && b > -1 && b < 256)
                        color = Color.FromArgb(r, g, b);
                }
            }
        }

        public static void Save()
        {
            var sb = new StringBuilder();
            sb.AppendLine("# PingoMeter config file");

            sb.AppendLine($"{nameof(Delay)} {Delay}");
            sb.AppendLine($"{nameof(MaxPing)} {MaxPing}");

            sb.AppendLine($"{nameof(BgColor)} {BgColor.R}:{BgColor.G}:{BgColor.B}");
            sb.AppendLine($"{nameof(GoodColor)} {GoodColor.R}:{GoodColor.G}:{GoodColor.B}");
            sb.AppendLine($"{nameof(NormalColor)} {NormalColor.R}:{NormalColor.G}:{NormalColor.B}");
            sb.AppendLine($"{nameof(BadColor)} {BadColor.R}:{BadColor.G}:{BadColor.B}");

            sb.AppendLine($"{nameof(RunOnStartup)} {RunOnStartup}");

            File.WriteAllText(CONF_FILE_NAME, sb.ToString());
        }

    }
}
