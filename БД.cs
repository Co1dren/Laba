using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace Yahta
{
    public partial class БД : Form
    {
        public БД()
        {
            InitializeComponent();
        }

        private void БД_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "яхта1DataSet.Стоимость_аренды". При необходимости она может быть перемещена или удалена.
            this.стоимость_арендыTableAdapter.Fill(this.яхта1DataSet.Стоимость_аренды);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "яхта1DataSet.Порт". При необходимости она может быть перемещена или удалена.
            this.портTableAdapter.Fill(this.яхта1DataSet.Порт);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "яхта1DataSet.Водоизмещение". При необходимости она может быть перемещена или удалена.
            this.водоизмещениеTableAdapter.Fill(this.яхта1DataSet.Водоизмещение);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            водоизмещениеBindingSource.EndEdit();
            водоизмещениеTableAdapter.Update(яхта1DataSet);

            стоимостьАрендыBindingSource.EndEdit();
            стоимость_арендыTableAdapter.Update(яхта1DataSet);

            портBindingSource.EndEdit();
            портTableAdapter.Update(яхта1DataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // обработчик события печати
            printDocument1.PrintPage += PrintPageHandler;
            printPreviewDialog1.Document = printDocument1;
            // если в диалоге было нажато ОК
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printPreviewDialog1.Document.Print(); // печатаем

        }
        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Bitmap bm1 = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            this.dataGridView1.DrawToBitmap(bm1, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm1, 0, 0);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // обработчик события печати
            printDocument1.PrintPage += PrintPageHandler1;
            printPreviewDialog1.Document = printDocument1;
            // если в диалоге было нажато ОК
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printPreviewDialog1.Document.Print(); // печатаем
        }
        private void PrintPageHandler1(object sender, PrintPageEventArgs e)
        {
            Bitmap bm2 = new Bitmap(this.dataGridView2.Width, this.dataGridView2.Height);
            this.dataGridView2.DrawToBitmap(bm2, new Rectangle(0, 0, this.dataGridView2.Width, this.dataGridView2.Height));
            e.Graphics.DrawImage(bm2, 0, 0);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // обработчик события печати
            printDocument1.PrintPage += PrintPageHandler2;
            printPreviewDialog1.Document = printDocument1;
            // если в диалоге было нажато ОК
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printPreviewDialog1.Document.Print(); // печатаем
        }
        private void PrintPageHandler2(object sender, PrintPageEventArgs e)
        {
            Bitmap bm3 = new Bitmap(this.dataGridView3.Width, this.dataGridView3.Height);
            this.dataGridView3.DrawToBitmap(bm3, new Rectangle(0, 0, this.dataGridView3.Width, this.dataGridView3.Height));
            e.Graphics.DrawImage(bm3, 0, 0);
        }
        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Файлы Word (*.doc; *.docx)|*.doc?";

            if (sd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Экспорт в Word
                    string fn = System.IO.Directory.GetCurrentDirectory() + "\\Yahta_20.docx";
                    int r = dataGridView1.CurrentCell.RowIndex;

                    var ID_Port = dataGridView1.Rows[r].Cells[1].FormattedValue.ToString();
                    var ID_Water = dataGridView1.Rows[r].Cells[2].FormattedValue.ToString();
                    var Arenda = dataGridView1.Rows[r].Cells[3].FormattedValue.ToString();
                    var Sluz = dataGridView1.Rows[r].Cells[4].FormattedValue.ToString();
                    

                    Word.Application wordApp = new Word.Application();
                    wordApp.Visible = false;
                    Word.Document wordDocument = wordApp.Documents.Open(fn);

                    ReplaceWordStub("ID_Port}", ID_Port, wordDocument);
                    ReplaceWordStub("{ID_Water}", ID_Water, wordDocument);
                    ReplaceWordStub("{Arenda}", Arenda, wordDocument);
                    ReplaceWordStub("{Sluz}", Sluz, wordDocument);
                    wordDocument.SaveAs2(sd.FileName);
                    wordApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка: Приложение Word не удалось сохраннить данный файл, так как он используется другим процессом", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Файлы Word (*.xls; *.xlsx)|*.xls?";
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    excelApp.Visible = false;

                    worksheet.Cells[1, "A"] = "Айди порта";
                    worksheet.Cells[1, "B"] = "Айди водоизмещения";
                    worksheet.Cells[1, "C"] = "Аренда";
                    worksheet.Cells[1, "D"] = "Шлюз";
                    worksheet.Columns.AutoFit();
                    for (int i = 2; i < dataGridView1.RowCount + 1; i++)
                        for (int j = 1; j < dataGridView1.ColumnCount + 1; j++)
                            worksheet.Rows[i].Columns[j] = dataGridView1.Rows[i - 1].Cells[j - 1].FormattedValue;
                    excelApp.AlertBeforeOverwriting = false;
                    excelApp.DisplayAlerts = false;
                    workbook.SaveAs(sd.FileName);
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка: Приложение Excel не удалось сохраннить данный файл, так как он используется другим процессом", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
