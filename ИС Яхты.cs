using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahta
{
    public partial class Form1 : Form
    {
        Дополнительно _дополнительно = new Дополнительно();
        AboutBox1 _aboutBox1 = new AboutBox1();


        ToolTip _toolTip = new ToolTip();
        public Form1()
        {
            InitializeComponent();

            _toolTip.SetToolTip(button1, "Дополнительно");
            _toolTip.SetToolTip(button2, "О программе");
            _toolTip.SetToolTip(button3, "Выход");

            _toolTip.SetToolTip(textBox1, "Введите ФИО владельца");
            _toolTip.SetToolTip(textBox3, "Введите наименованние яхты");

            _toolTip.SetToolTip(maskedTextBox1, "Введите айди яхты");

            _toolTip.SetToolTip(radioButton1, "Выбирете тип паруса");
            _toolTip.SetToolTip(radioButton2, "Выбирете тип паруса");
            _toolTip.SetToolTip(radioButton3, "Выбирете тип паруса");
            _toolTip.SetToolTip(radioButton4, "Выбирете тип паруса");
            _toolTip.SetToolTip(radioButton5, "Выбирете тип паруса");
            _toolTip.SetToolTip(radioButton6, "Выбирете тип паруса");
            _toolTip.SetToolTip(radioButton7, "Выбирете тип паруса");

            _toolTip.SetToolTip(listBox1, "Указывается весь путь яхты");

            _toolTip.SetToolTip(numericUpDown2, "укажите количество дней прибывание в порту");

            _toolTip.SetToolTip(checkBox2, "Выбирите если яхта было арестованно");
            _toolTip.SetToolTip(checkBox3, "Выбирите если яхта попала под сканкции");

            _toolTip.SetToolTip(comboBox1, "Выбирите порт конечного назначения");


            дополнительноToolStripMenuItem.ToolTipText = "Дополнительно";
            вызовСправкиToolStripMenuItem.ToolTipText = "Вызов справки";
            оПрограммеToolStripMenuItem.ToolTipText = "О программе";
            выходToolStripMenuItem.ToolTipText = "Выход";


            toolStripButton1.ToolTipText = "Дополнительно";
            toolStripButton2.ToolTipText = "Временно не реализованно";
            toolStripButton3.ToolTipText = "Информация о программе";
            toolStripButton4.ToolTipText = "Выход";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _дополнительно.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _aboutBox1.Show();   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Выйти из программы ?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void дополнительноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            БД _бД = new БД();
            _бД.ShowDialog();
        }
    }
}
