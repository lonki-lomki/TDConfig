using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TDConfig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode treeNode = new TreeNode("Windows");
            treeView1.Nodes.Add(treeNode);

            treeNode = new TreeNode("Linux");
            treeView1.Nodes.Add(treeNode);

            TreeNode node2 = new TreeNode("C#");
            TreeNode node3 = new TreeNode("VB.NET");
            TreeNode[] array = new TreeNode[] { node2, node3 };

            treeNode = new TreeNode("Dot Net Perls", array);
            treeView1.Nodes.Add(treeNode);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox(e.Node.Name);
            textBox1.Text = e.Node.Text;
        }
    }
}
