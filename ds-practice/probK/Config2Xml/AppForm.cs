using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Config2Xml
{
    public partial class AppForm : Form
    {
        private long sum = 0;

        public AppForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Citeste din fisierul App.config (care in folderul bin/%Configuratie rulare% o sa fie Config2Xml.exe.Config elem appSettings
            var listOfNumbers = ConfigurationManager.AppSettings["listOfNumbers"].Split(',').Select(x => int.Parse(x)).ToList();
            sum = listOfNumbers.Sum();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            XDocument xdoc = new XDocument(new XElement("SumOfList", sum));
            xdoc.Save("output.xml");
        }
    }
}
