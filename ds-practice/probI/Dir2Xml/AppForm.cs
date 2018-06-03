using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dir2Xml
{
    public partial class AppForm : Form
    {
        private string folderPath;
        public AppForm()
        {
            InitializeComponent();
        }

        private void saveToXmlButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fwd = new FolderBrowserDialog();
            if (fwd.ShowDialog() == DialogResult.OK)
            {
                folderPath = fwd.SelectedPath;
                DirectoryInfo dirInfo = new DirectoryInfo(folderPath);

                XDocument xdoc = new XDocument();
                xdoc.Add(processEntity(dirInfo));

                xdoc.Save("output.xml");
            }
        }

        private XElement processEntity(DirectoryInfo dirInfo)
        {
            XElement element = new XElement("dir", new XAttribute("name", dirInfo.Name));

            foreach (var file in dirInfo.GetFiles())
                element.Add(new XElement("file", file.Name));

            foreach (var dir in dirInfo.GetDirectories())
                element.Add(new XElement(processEntity(dir)));

            return element;
        }

    }
}
