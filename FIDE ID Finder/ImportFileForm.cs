using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIDE_ID_Finder.Services;

namespace FIDE_ID_Finder
{
    public partial class ImportFileForm : Form
    {
        private string? _fileContents = null;
        private readonly LogService _logger = LogService.Get();

        public IList<string[]> Data { get; set; } = new List<string[]>();

        public ImportFileForm()
        {
            InitializeComponent();
            skipFirstLineBox.Checked = true;
            skipFirstLineBox.CheckStateChanged += SkipFirstLineBoxOnCheckStateChanged;
        }

        private void SkipFirstLineBoxOnCheckStateChanged(object? sender, EventArgs e)
        {
            if (_fileContents != null)
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                ReadAndApplyLines();
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName != "")
            {
                var fs = openFileDialog.OpenFile();
                if (fs.CanRead)
                {
                    var reader = new StreamReader(fs);
                    _fileContents = reader.ReadToEnd();
                    _logger.Log("File read from " + openFileDialog.FileName);
                    filePathLabel.Text = openFileDialog.FileName;
                    reader.Close();
                    fs.Close();
                }
            }
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            ReadAndApplyLines();
        }

        private void ReadAndApplyLines()
        {
            var lines = _fileContents!.Split(new[] { "\n", "\r", "\r\n" }, StringSplitOptions.TrimEntries);
            bool columnsAdded = false;
            bool skippedFirstLine = false;
            foreach (var line in lines)
            {
                if (line.Length < 1)
                {
                    continue;
                }

                var columnsText = line.Split(",");
                if (!columnsAdded)
                {
                    for (var i = 0; i < columnsText.Length; i++)
                    {
                        dataGridView.Columns.Add(new DataGridViewTextBoxColumn()
                        {
                            Name = i.ToString()
                        });
                    }

                    dataGridView.Rows.Add(new DataGridViewRow());
                    for (var i = 0; i < columnsText.Length; i++)
                    {
                        string[] source = { "", "Soyad", "Ad", "Doğum Tarihi" };
                        var combo = new DataGridViewComboBoxCell();
                        combo.DataSource = source.ToList();
                        if (i < 3)
                        {
                            combo.Value = source[i + 1];
                        }

                        dataGridView.Rows[0].Cells[i] = combo;
                    }

                    columnsAdded = true;
                }

                if (!skippedFirstLine && skipFirstLineBox.Checked)
                {
                    skippedFirstLine = true;
                    continue;
                }

                dataGridView.Rows.Add(columnsText);
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            if (!IsContentValid())
            {
                return;
            }

            var nameColumn = -1;
            var surnameColumn = -1;
            var bdayColumn = -1;
            var comboRow = dataGridView.Rows[0];

            for (var i = 0; i < comboRow.Cells.Count; i++)
            {
                var comboCell = comboRow.Cells[i];
                if ("Soyad".Equals(comboCell.Value))
                {
                    surnameColumn = i;
                }

                if ("Ad".Equals(comboCell.Value))
                {
                    nameColumn = i;
                }

                if ("Doğum Tarihi".Equals(comboCell.Value))
                {
                    bdayColumn = i;
                }
            }

            Data = new List<string[]>();
            var expectedColumnCount = bdayColumn == -1 ? 2 : 3;

            for (var i = 1; i < dataGridView.Rows.Count; i++)
            {
                var row = dataGridView.Rows[i];
                var dataRow = new string[3];
                var appliedColumn = 0;

                for (var j = 0; j < row.Cells.Count && appliedColumn < expectedColumnCount; j++)
                {
                    if (row.Cells[j].Value != null)
                    {
                        if (j == surnameColumn)
                        {
                            dataRow[0] = (string)row.Cells[j].Value;
                            appliedColumn++;
                        }

                        if (j == nameColumn)
                        {
                            dataRow[1] = (string)row.Cells[j].Value;
                            appliedColumn++;
                        }

                        if (j == bdayColumn)
                        {
                            dataRow[2] = (string)row.Cells[j].Value;
                            appliedColumn++;
                        }
                    }
                }

                if (appliedColumn == expectedColumnCount)
                {
                    Data.Add(dataRow);
                }

            }

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsContentValid()
        {
            if (_fileContents == null || dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Dosya seçilmedi!", "Hata");
                return false;
            }

            var comboRow = dataGridView.Rows[0];
            var numOfSurnameSelected = 0;
            var numOfNameSelected = 0;
            var numOfBDaySelected = 0;

            foreach (DataGridViewComboBoxCell comboCell in comboRow.Cells)
            {
                if ("Soyad".Equals(comboCell.Value))
                {
                    numOfSurnameSelected++;
                }

                if ("Ad".Equals(comboCell.Value))
                {
                    numOfNameSelected++;
                }

                if ("Doğum Tarihi".Equals(comboCell.Value))
                {
                    numOfBDaySelected++;
                }
            }

            if (numOfNameSelected == 0 || numOfSurnameSelected == 0)
            {
                MessageBox.Show("Soyad veya Ad alanı seçilmedi", "Hata");
                return false;
            }

            if (numOfNameSelected > 1)
            {
                MessageBox.Show("Birden fazla Ad alanı seçildi", "Hata");
                return false;
            }

            if (numOfSurnameSelected > 1)
            {
                MessageBox.Show("Birden fazla Soyad alanı seçildi", "Hata");
                return false;
            }

            if (numOfBDaySelected > 1)
            {
                MessageBox.Show("Birden fazla Doğum Tarihi alanı seçildi", "Hata");
                return false;
            }

            return true;
        }
    }
}
