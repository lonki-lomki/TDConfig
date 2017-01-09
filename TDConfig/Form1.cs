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
            TreeNode treeNode = new TreeNode("Башни");
            treeView1.Nodes.Add(treeNode);

            treeNode = new TreeNode("Монстры");
            treeView1.Nodes.Add(treeNode);

            TreeNode node2 = new TreeNode("Уровень 1");
            TreeNode node3 = new TreeNode("Уровень 2");
            TreeNode[] array = new TreeNode[] { node2, node3 };

            treeNode = new TreeNode("Уровни", array);
            treeView1.Nodes.Add(treeNode);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox(e.Node.Name);
            //textBox1.Text = e.Node.Text;

            // Очистить старое содержимое таблицы
            tableLayoutPanel1.Controls.Clear();

            // Установить количество строк и столбцов
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 2;

            // Размеры строк и столбцов
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.0f));
            //tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.0f));
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Добавить элементы в ячейки таблицы
            tableLayoutPanel1.Controls.Add(new Label() { Text = "Элемент" }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label() { Text = e.Node.Text }, 1, 0);

            if (e.Node.Text == "Уровень 1")
            {
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Наименование" }, 0, 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Обучающий уровень" }, 1, 1);
            }

            if (e.Node.Text == "Уровень 2")
            {
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Наименование" }, 0, 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Уровень с боссом" }, 1, 1);
            }

        }
    }
}
