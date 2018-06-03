using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Languinator
{
    public partial class LanguinatorForm : Form
    {
        private readonly string[] languages = { "ro-RO", "en-US", "de-DE" };
        private System.Windows.Forms.Timer timer;
        private int languageIndex = 0;
        private ResourceManager rm;

        public LanguinatorForm()
        {
            InitializeComponent();
        }

        private void LanguinatorForm_Load(object sender, EventArgs e)
        {
            
            rm = new ResourceManager("Languinator.Strings", Assembly.GetExecutingAssembly());
            helloLabel.Text = rm.GetString("greeting", CultureInfo.CreateSpecificCulture("ro-RO"));

            timer = new System.Windows.Forms.Timer();
            timer.Tick += changeLanguage;
            timer.Interval = 2000;
            timer.Start();
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            languageIndex = (languageIndex + 1) % languages.Length;
            
            CultureInfo culture = CultureInfo.CreateSpecificCulture(languages[languageIndex]);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            helloLabel.Text = rm.GetString("greeting", culture);
        }
    }
}
