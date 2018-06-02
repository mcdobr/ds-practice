using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tree2Xml
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "XML files (*.xml)|*xml";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XDocument xdoc = XDocument.Load(ofd.OpenFile());
                    xml2tree(xdoc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = "c:\\";
            sfd.Filter = "XML files (*.xml)|*xml";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XDocument xdoc = tree2xml();
                xdoc.Save(sfd.OpenFile());
            }
        }

        private void xml2tree(XDocument xdoc)
        {
            treeView.Nodes.Clear();

            XElement xroot = xdoc.Elements().First();
            TreeNode troot = new TreeNode(stringifyElement(xroot));
            treeView.Nodes.Add(troot);

            xml2treeStep(xroot.Elements(), troot);
        }

        
        private void xml2treeStep(IEnumerable<XElement> elements, TreeNode tparent)
        {
            foreach (var elem in elements)
            {
                TreeNode tElem = new TreeNode(stringifyElement(elem));
                xml2treeStep(elem.Elements(), tElem);
                tparent.Nodes.Add(tElem);
            }
        }

        private string stringifyElement(XElement elem)
        {
            if (string.IsNullOrWhiteSpace(elem.Value) || elem.HasElements)
                return elem.Name.ToString();
            else
                return string.Format("{0}={1}", elem.Name.ToString(), elem.Value);
        }

        private XDocument tree2xml()
        {
            TreeNode troot = treeView.Nodes[0];
            XElement xroot = new XElement(troot.Text);

            tree2xmlStep(troot.Nodes, xroot);

            XDocument xdoc = new XDocument();
            xdoc.Add(xroot);
            return xdoc;
        }

        private void tree2xmlStep(TreeNodeCollection elements, XElement xparent)
        {
            foreach (TreeNode elem in elements)
            {
                XElement xelem = unstringifyElement(elem.Text);
                tree2xmlStep(elem.Nodes, xelem);
                xparent.Add(xelem);
            }
        }

        private XElement unstringifyElement(string str)
        {
            XElement elem = null;
            if (str.Contains('='))
            {
                string[] splitResult = str.Split('=');
                elem = new XElement(splitResult[0]);
                elem.Value = splitResult[1];
            }
            else
                elem = new XElement(str);
            return elem;
        }

        private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode telem = e.Node;


            treeView.AfterCheck -= treeView_AfterCheck;
            // Check ancestors
            TreeNode parent = telem.Parent;
            while (parent != null)
            {
                parent.Checked = parent.Nodes.Cast<TreeNode>().Any(node => node.Checked == true);
                //parent.Checked = telem.Checked;
                parent = parent.Parent;
            }

            // Check descendants
            checkAllChildren(telem, telem.Nodes);

            treeView.AfterCheck += treeView_AfterCheck;
        }

        private void checkAllChildren(TreeNode root, TreeNodeCollection descendants)
        {
            foreach (TreeNode node in descendants)
            {
                node.Checked = root.Checked;
                checkAllChildren(root, node.Nodes);
            }
        }
    }
}
