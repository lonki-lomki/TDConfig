using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TDConfig
{
    public partial class Form1 : Form
    {

        // TODO: редактирование параметров монстров
        // TODO: всплывающее меню по правой кнопке

        private int selectedColumn;

        ContextMenuStrip popupMenu;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode treeNode;

            // Открыть диалог выбора файла
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            DialogResult result = openFileDialog1.ShowDialog();
            // Проверить результат выполнения диалога
            if (result == DialogResult.OK)
            {
                // загрузка информации из файловой системы - построить дерево
                //string topDir = "TDGame";
                string topDir = Path.GetDirectoryName(openFileDialog1.FileName);
                // Получение списка файлов в указанном каталоге
                // возвращает данные в таком виде: "TDGame\\monsters.txt"
                string[] files = Directory.GetFiles(topDir);

                // Цикл по файлам основного каталога
                foreach (string s in files)
                {
                    // Выделить из пути имя файла
                    string filename = Path.GetFileName(s);

                    if (filename.StartsWith("monsters"))
                    {
                        // Загрузка списка монстров
                        // Загрузить весь файл в одну строковую переменную
                        string content = File.ReadAllText(s);

                        // Разбор содержимого файла
                        List<MobStruct> monsters = UtilsParse.ParseList<MobStruct>(MobStruct.Parse, content);

                        // список монстров получен, сформировать иерархию для отображения в дереве
                        TreeNode[] array = new TreeNode[monsters.Count];

                        for (int i = 0; i < monsters.Count; i++)
                        {
                            TreeNode node = new TreeNode(monsters[i].name);
                            array[i] = node;
                        }

                        // Добавить ветку монстров в общее дерево
                        TreeNode monsters_node = new TreeNode("Монстры", array);
                        treeView1.Nodes.Add(monsters_node);
                    }
                    if (filename.StartsWith("towers"))
                    {
                        // Загрузка списка башен
                        // Загрузить весь файл в одну строковую переменную
                        string content = File.ReadAllText(s);

                        // Разбор содержимого файла
                        List<TowerStruct> towers = UtilsParse.ParseList<TowerStruct>(TowerStruct.Parse, content);

                        // список монстров получен, сформировать иерархию для отображения в дереве
                        TreeNode[] array = new TreeNode[towers.Count];

                        for (int i = 0; i < towers.Count; i++)
                        {
                            TreeNode node = new TreeNode(towers[i].name);
                            array[i] = node;
                        }

                        // Добавить ветку монстров в общее дерево
                        TreeNode towers_node = new TreeNode("Башни", array);
                        treeView1.Nodes.Add(towers_node);
                    }
                }

                // Получение списка вложенных каталогов
                string[] dirs = Directory.GetDirectories(topDir);

                // Цикл по списку найденных каталогов
                foreach (string s in dirs)
                {
                    // Выделить из пути имя файла
                    string filename = Path.GetFileName(s);

                    if (filename.StartsWith("Levels"))
                    {
                        // чтение файлов в данном каталоге (в каждом отдельном файле - описание одного уровня)
                        string[] files2 = Directory.GetFiles(s);

                        // Массив для создания иерархии в дереве
                        TreeNode[] array = new TreeNode[files2.Length];
                        int i = 0;
                        // Цикл по файлам, найденным в каталоге
                        foreach (string s2 in files2)
                        {
                            string filename2 = Path.GetFileNameWithoutExtension(s2);
                            treeNode = new TreeNode(filename2);
                            array[i++] = treeNode;
                        }
                        // Поместить сформированный список в иерархию
                        treeNode = new TreeNode("Уровни", array);
                        treeView1.Nodes.Add(treeNode);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создать контекстное меню
            popupMenu = new ContextMenuStrip();
            popupMenu.Text = "Контекстное меню";

            ToolStripMenuItem item = new ToolStripMenuItem("Add");
            item.Text = "Add";

            popupMenu.Items.Add(item);

            treeView1.ContextMenuStrip = popupMenu;
            popupMenu.Show();

            /*
            // Настройка ListView
            listView1.Clear();
            listView1.Columns.Add("Параметр");
            listView1.Columns.Add("Значение");

            // TODO: тестовое наполнение
            listView1.Items.Add("Параметр 1");
            listView1.Items.Add("Параметр 2");
            listView1.Items.Add("Параметр 3");

            // Добавить значения параметров
            for(int i=0; i<listView1.Items.Count; i++)
            {
                ListViewItem.ListViewSubItem lvsi = listView1.Items[i].SubItems.Add("" + i);
                lvsi.Tag = (object)("" + i);
            }

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            */
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            /*
            listView1.Items.Clear();

            ListViewItem lvi;

            if (e.Node.Text == "Уровень 1")
            {
                lvi = listView1.Items.Add("Наименование");
                //listView1.Items.Add("Обучающий уровень");
                ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add("Обучающий уровень");
                lvsi.Tag = lvsi.Text;
            }
            if (e.Node.Text == "Уровень 2")
            {
                lvi = listView1.Items.Add("Наименование");
                //listView1.Items.Add("Уровень с боссом");
                ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add("Уровень с боссом");
                lvsi.Tag = lvsi.Text;
            }
            */
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ListViewHitTestInfo hit = listView1.HitTest(e.X, e.Y);
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Selected == true)
                {
                    for (int i=0; i<item.SubItems.Count; i++)
                    {
                        if (hit.SubItem.Tag == item.SubItems[i].Tag)
                        {
                            selectedColumn = i;
                            // Первую колонку не редактируем!
                            if (selectedColumn == 0)
                            {
                                return;
                            }
                            // Установить параметры поля редактирования текста
                            textBox1.Left = listView1.Left + hit.SubItem.Bounds.Left + 3;
                            textBox1.Top = listView1.Top + hit.SubItem.Bounds.Top;
                            textBox1.Width = hit.SubItem.Bounds.Width;
                            textBox1.Text = hit.SubItem.Text;
                            textBox1.Visible = true;
                            textBox1.Focus();
                            textBox1.SelectAll();
                        }
                    }
                }
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Убрать фокус ввода когда нажата клавиша Enter
            if (e.KeyChar == (char)Keys.Return)
            {
                textBox1_LostFocus(sender, null);
            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                textBox1.Text = listView1.Items[listView1.SelectedItems[0].Index].SubItems[selectedColumn].Text;
                textBox1_LostFocus(sender, null);
            }
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            string selectDetail;

            // Убрать TextBox
            textBox1.Visible = false;
            // Сохранить старое значение (то, что было до редактирования)
            selectDetail = listView1.SelectedItems[0].SubItems[selectedColumn].Text;
            // Сравнить старое и новое значения
            if (selectDetail.Equals(textBox1.Text) == false)
            {
                // Значения различаются, можно заменить
                listView1.Items[listView1.SelectedItems[0].Index].SubItems[selectedColumn].Text = textBox1.Text;
                // TODO: Установить флаг необходимости сохранения значений
                // needSave = true;
            }
        }

    }
}
