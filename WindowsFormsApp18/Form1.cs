using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem != null && toolStripComboBox2.SelectedItem != null)
            {
                string selectedFont = toolStripComboBox1.SelectedItem.ToString();
                float fontSize = float.Parse(toolStripComboBox2.SelectedItem.ToString());

                // Cập nhật phông chữ và kích thước cho richTextBox1
                richTextBox1.SelectionFont = new Font(selectedFont, fontSize);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void địnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
                toolStripComboBox1.Text = fontDlg.Font.Name;
                toolStripComboBox2.Text = fontDlg.Font.Size.ToString();
            }
        }
        private void UpdateComboBoxSelection()
        {
            // Cập nhật phông chữ trong ComboBox
            toolStripComboBox1.Text = richTextBox1.SelectionFont.Name;

            // Cập nhật kích thước phông chữ trong ComboBox
            toolStripComboBox2.Text = richTextBox1.SelectionFont.Size.ToString();
        }


        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"; // Thiết lập bộ lọc định dạng file

            // Kiểm tra nếu người dùng chọn một đường dẫn và nhấn "Save"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu nội dung của richTextBox1 vào file đã chọn
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("File saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void tsbtnB_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;
            richTextBox1.SelectionFont = new Font(currentFont, newStyle);
        }

        private void tsbtnI_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ FontStyle.Italic;
            richTextBox1.SelectionFont = new Font(currentFont, newStyle);

        }

        private void tsbtnU_Click(object sender, EventArgs e)
        {
            Font currentFont = richTextBox1.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;
            richTextBox1.SelectionFont = new Font(currentFont, newStyle);
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem != null && toolStripComboBox2.SelectedItem != null)
            {
                string selectedFont = toolStripComboBox1.SelectedItem.ToString();
                float selectedSize = float.Parse(toolStripComboBox2.SelectedItem.ToString());

                // Cập nhật phông chữ và kích thước cho richTextBox1
                richTextBox1.SelectionFont = new Font(selectedFont, selectedSize);
            }
        }
    }
}
