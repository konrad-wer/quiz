using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace Quiz
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            StyleApplier.ApplyColors(this);
            LoadValues();
        }

        public void LoadValues()
        {
            if (!File.Exists("config.xml"))
                return;
            XDocument configFile;
            try
            {
                configFile = XDocument.Load("config.xml");
            }
            catch { return; }

            XElement entry;

            try
            {
                entry = configFile.Descendants("buttonColor").First();
                buttonColorTextboxRed.Text = entry.Attribute("red").Value;
                buttonColorTextboxGreen.Text = entry.Attribute("green").Value;
                buttonColorTextboxBlue.Text = entry.Attribute("blue").Value;
            }
            catch { }

            try
            {
                entry = configFile.Descendants("backgroundColor").First();
                backgroundColorTextboxRed.Text = entry.Attribute("red").Value;
                backgroundColorTextboxGreen.Text = entry.Attribute("green").Value;
                backgroundColorTextboxBlue.Text = entry.Attribute("blue").Value;
            }
            catch { }

            try
            {
                entry = configFile.Descendants("fontColor").First();
                fontColorTextboxRed.Text = entry.Attribute("red").Value;
                fontColorTextboxGreen.Text = entry.Attribute("green").Value;
                fontColorTextboxBlue.Text = entry.Attribute("blue").Value;
            }
            catch { }

            try
            {
                entry = configFile.Descendants("programName").First();
                programNameTextbox.Text = entry.Value;
            }
            catch { }

            try
            {
                entry = configFile.Descendants("buttonStyle").First();
                buttonStyleButton.FlatStyle = entry.Value == "Popup" ? FlatStyle.Popup : FlatStyle.Standard;
            }
            catch { }
        }

        private void buttonStyleButtonClick(object sender, EventArgs e)
        {
            if ((sender as Button).FlatStyle == FlatStyle.Standard)
                (sender as Button).FlatStyle = FlatStyle.Popup;
            else
                (sender as Button).FlatStyle = FlatStyle.Standard;
        }

        private void buttonColorTextboxTextChanged(object sender, EventArgs e)
        {
            int red, green, blue;
            int.TryParse(buttonColorTextboxRed.Text, out red);
            int.TryParse(buttonColorTextboxGreen.Text, out green);
            int.TryParse(buttonColorTextboxBlue.Text, out blue);

            var c = Color.FromArgb(red % 256, green % 256, blue % 256);
            buttonColorSample.BackColor = c;
            buttonStyleButton.BackColor = c;
            
        }

        private void backgroundColorTextboxTextChanged(object sender, EventArgs e)
        {
            int red, green, blue;
            int.TryParse(backgroundColorTextboxRed.Text, out red);
            int.TryParse(backgroundColorTextboxGreen.Text, out green);
            int.TryParse(backgroundColorTextboxBlue.Text, out blue);

            backgroundColorSample.BackColor = Color.FromArgb(red % 256, green % 256, blue % 256);
        }

        private void fontColorTextboxTextChanged(object sender, EventArgs e)
        {
            int red, green, blue;
            int.TryParse(fontColorTextboxRed.Text, out red);
            int.TryParse(fontColorTextboxGreen.Text, out green);
            int.TryParse(fontColorTextboxBlue.Text, out blue);

            var c = Color.FromArgb(red % 256, green % 256, blue % 256);
            fontColorSample.BackColor = c;
            buttonStyleButton.ForeColor = c;
        }

        private void saveButtonClick(object sender, EventArgs e)
        {
            var elements = new List<XElement>();

            elements.Add(new XElement("programName", programNameTextbox.Text));

            var buttonColor = new XElement
            (
                "buttonColor",
                new XAttribute("red", buttonColorTextboxRed.Text),
                new XAttribute("green", buttonColorTextboxGreen.Text),
                new XAttribute("blue", buttonColorTextboxBlue.Text)
            );
            elements.Add(buttonColor);

            var backgroundColor = new XElement
            (
                "backgroundColor",
                new XAttribute("red", backgroundColorTextboxRed.Text),
                new XAttribute("green", backgroundColorTextboxGreen.Text),
                new XAttribute("blue", backgroundColorTextboxBlue.Text)
            );
            elements.Add(backgroundColor);

            var fontColor = new XElement
            (
                "fontColor",
                new XAttribute("red", fontColorTextboxRed.Text),
                new XAttribute("green", fontColorTextboxGreen.Text),
                new XAttribute("blue", fontColorTextboxBlue.Text)
            );
            elements.Add(fontColor);

            elements.Add(new XElement("buttonStyle", buttonStyleButton.FlatStyle == FlatStyle.Standard ? "Standard" : "Popup"));

            var document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("settings", elements));
            document.Save("config.xml");

            StyleApplier.Reload();
            StyleApplier.ApplyColors(this);
        }

        private void backToDefaultClick(object sender, EventArgs e)
        {
            if (File.Exists("config.xml"))
                File.Delete("config.xml");

            StyleApplier.Reload();
            StyleApplier.ApplyColors(this);
        }
    }
}
