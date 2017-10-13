using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Drawing;

namespace Quiz
{
    static class StyleApplier
    {
        static XDocument configFile;

        static StyleApplier()
        {
            LoadStyle();
        }

        static void LoadStyle()
        {
            if (!File.Exists("config.xml"))
            {
                File.WriteAllText("config.xml",
                    "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\n" +
                    "<settings>\n" +
                    "  <programName> Quiz </programName>\n" +
                    "  <buttonColor red = \"50\" green = \"50\" blue = \"50\" />\n" +
                    "  <backgroundColor red = \"28\" green = \"28\" blue = \"28\" />\n" +
                    "  <fontColor red = \"200\" green = \"200\" blue = \"200\" />\n" +
                    "  <buttonStyle>Popup</buttonStyle>\n" +
                    "</settings >"
                );
            }

            try
            {
                configFile = XDocument.Load("config.xml");
            }
            catch
            {
                if (File.Exists("config.xml"))
                    File.Delete("config.xml");
                LoadStyle();
            }
        }

        public static void Reload()
        {
            LoadStyle();
        }

        public static void ApplyName(Form window)
        {
            var entry = configFile.Descendants("programName").First();

            if (entry != null)
                window.Text = entry.Value;
        }
        public static void ApplyColors(Control window)
        {
            XElement entry;
            int red, green, blue;
            try
            {
                entry = configFile.Descendants("backgroundColor").First();

                int.TryParse(entry.Attribute("red").Value, out red);
                int.TryParse(entry.Attribute("green").Value, out green);
                int.TryParse(entry.Attribute("blue").Value, out blue);

                window.BackColor = Color.FromArgb(red, green, blue);
            }
            catch { }

            try
            {
                entry = configFile.Descendants("fontColor").First();
                int.TryParse(entry.Attribute("red").Value, out red);
                int.TryParse(entry.Attribute("green").Value, out green);
                int.TryParse(entry.Attribute("blue").Value, out blue);

                window.ForeColor = Color.FromArgb(red % 256, green % 256, blue % 256);

                foreach (Control c in window.Controls)
                    if(!(c is TextBox))
                    c.ForeColor = Color.FromArgb(red % 256, green % 256, blue % 256);
            }
            catch { }

            try
            {
                entry = configFile.Descendants("buttonColor").First();
                int.TryParse(entry.Attribute("red").Value, out red);
                int.TryParse(entry.Attribute("green").Value, out green);
                int.TryParse(entry.Attribute("blue").Value, out blue);

                foreach (Control c in window.Controls)
                    if (c is Button)
                        c.BackColor = Color.FromArgb(red % 256, green % 256, blue % 256);
            }
            catch { }

            try
            {
                entry = configFile.Descendants("buttonStyle").First();
                foreach (Control c in window.Controls)
                    if (c is Button)
                        (c as Button).FlatStyle = entry.Value == "Popup" ? FlatStyle.Popup : FlatStyle.Standard;
            }
            catch { }
        }
    }
}
