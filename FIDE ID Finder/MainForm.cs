using System.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using FIDE_ID_Finder.Helpers;
using FIDE_ID_Finder.Model;
using FIDE_ID_Finder.Services;
using FIDE_ID_Finder.Test;
using Console = System.Console;

namespace FIDE_ID_Finder
{
    public partial class main : Form
    {
        private readonly PlayerService _playerService = new PlayerService();

        private readonly TestData _testData = new TestData();

        private IList<Player> _foundPlayers = new List<Player>();

        public main()
        {
            InitializeComponent();
            _playerService.ProgressStatusChanged += PlayerServiceOnProgressStatusChanged;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            standardRadioButton.Checked = true;
        }

        private async void findButton_Click(object sender, EventArgs e)
        {
            DisableActions();
            playersDataViewOutput.Rows.Clear();
            var foundPlayers = await _playerService.FindPlayers(GetRatingType(), PopulateInput());
            _foundPlayers = foundPlayers;
            ApplyFoundPlayers(foundPlayers);

            tabControl.SelectedTab = outputTab;
            ratingTypeLabel.Text = GetRatingType().ToString();
            numOfPlayersLabel.Text = _foundPlayers.Count.ToString();
            findButton.Enabled = true;
            searchTextBox.Enabled = true;
            EnableActions();
        }

        private IList<Player> PopulateInput()
        {
            var players = new List<Player>();

            foreach (DataGridViewRow row in playersDataViewInput.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[0] != null
                        && row.Cells[1] != null
                        && row.Cells[0].Value != null
                        && row.Cells[1].Value != null
                        )
                    {
                        var p = new Player
                        {
                            Surname = PlayerNameFilter.FilterAndUpperFirst(row.Cells[0].Value.ToString()!),
                            Name = PlayerNameFilter.FilterAndUpperFirst(row.Cells[1].Value.ToString()!)
                        };

                        if (row.Cells[2] != null && row.Cells[2].Value != null)
                        {
                            p.Birthday = row.Cells[2].Value.ToString()!;
                        }

                        players.Add(p);
                    }
                }
            }

            return players;
        }

        private void ApplyFoundPlayers(IList<Player> foundPlayers)
        {
            foreach (var player in foundPlayers)
            {
                object[] row =
                {
                    player.Surname,
                    player.Name,
                    player.Birthday,
                    player.Fed,
                    player.Title,
                    player.Id,
                    "Kopyala",
                    player.Rating,
                    "Kopyala"
                };
                playersDataViewOutput.Rows.Add(row);
            }
        }

        private RatingType GetRatingType()
        {
            if (standardRadioButton.Checked)
            {
                return RatingType.Standard;
            }

            if (rapidRadioButton.Checked)
            {
                return RatingType.Rapid;
            }

            return RatingType.Blitz;
        }

        private void playersDataViewOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == playersDataViewOutput.Columns["copyFideId"]!.Index
                || e.ColumnIndex == playersDataViewOutput.Columns["copyRating"]!.Index)
            {
                var row = playersDataViewOutput.Rows[e.RowIndex];

                var cell = row.Cells[e.ColumnIndex - 1];
                if (cell != null)
                {
                    Clipboard.SetText(cell.Value.ToString()!);
                }

            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchInFoundPlayers();
        }

        private void SearchInFoundPlayers()
        {
            if (_foundPlayers.Count <= 0) return;
            var keyword = searchTextBox.Text.ToLower();

            if (keyword.Length == 0)
            {
                playersDataViewOutput.Rows.Clear();
                ApplyFoundPlayers(_foundPlayers);
                return;
            }

            var foundInFoundPlayers = _foundPlayers.Where(player => player.Fullname.ToLower().Contains(keyword)).ToList();

            playersDataViewOutput.Rows.Clear();
            ApplyFoundPlayers(foundInFoundPlayers);
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchInFoundPlayers();
            }
        }

        private void PlayerServiceOnProgressStatusChanged(object? sender, ProgressStatus e)
        {
            switch (e)
            {
                case ProgressStatus.Downloading:
                    statusLabel.Text = "Rating dosyası indiriliyor...";
                    break;
                case ProgressStatus.ConvertingFiles:
                    statusLabel.Text = "Oyuncular kaydediliyor...";
                    break;
                case ProgressStatus.Searching:
                    statusLabel.Text = "Oyuncular Aranıyor...";
                    break;
                case ProgressStatus.Finished:
                    statusLabel.Text = "Tamamlandı!";
                    break;
                case ProgressStatus.DeletingOldFiles:
                    statusLabel.Text = "Eski dosyalar siliniyor...";
                    break;
            }
        }

        private async void RedownloadRatingsButton_Click(object sender, EventArgs e)
        {
            DisableActions();
            await _playerService.ReDownloadRatingFile(GetRatingType());
            EnableActions();
        }

        private void EnableActions()
        {
            Enabled = true;
            redownloadRatingsButton.Enabled = true;
            searchButton.Enabled = true;
            exportButton.Enabled = true;
        }

        private void DisableActions()
        {
            Enabled = false;
            redownloadRatingsButton.Enabled = false;
            searchButton.Enabled = false;
            exportButton.Enabled = false;
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var logsForm = new LogViewer();
            logsForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "CSV file (*.csv)|*.csv";
            dialog.Title = "Dışarı Aktar";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                var fs = dialog.OpenFile();
                if (fs.CanWrite)
                {
                    var output = new StringBuilder();
                    string[] headings = { "ID", "Surname", "Name", "Fed", "Title", "Rating", "B-day" };
                    output.AppendLine(string.Join(",", headings));
                    foreach (var player in _foundPlayers)
                    {
                        string[] line =
                            { player.Id, player.Surname, player.Name, player.Fed, player.Title, player.Rating, player.Birthday };
                        output.AppendLine(string.Join(",", line));
                    }


                    fs.Write(Encoding.ASCII.GetBytes(output.ToString()));
                }

                fs.Close();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var importCvs = new ImportFileForm();
            importCvs.Closing += (o, args) =>
            {
                if (importCvs.DialogResult == DialogResult.OK)
                {
                    playersDataViewInput.Rows.Clear();
                    var allKeys = importCvs.Data;
                    foreach (var keys in allKeys)
                    {
                        playersDataViewInput.Rows.Add(keys);
                    }
                }
            };
            importCvs.ShowDialog();

        }
    }
}