namespace FIDE_ID_Finder
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            standardRadioButton = new RadioButton();
            rapidRadioButton = new RadioButton();
            blitzRadioButton = new RadioButton();
            findButton = new Button();
            playersDataViewInput = new DataGridView();
            surname = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            birthday = new DataGridViewTextBoxColumn();
            tabControl = new TabControl();
            inputTab = new TabPage();
            importButton = new Button();
            outputTab = new TabPage();
            exportButton = new Button();
            searchButton = new Button();
            searchTextBox = new TextBox();
            numOfPlayersLabel = new Label();
            label2 = new Label();
            ratingTypeLabel = new Label();
            label1 = new Label();
            playersDataViewOutput = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            fed = new DataGridViewTextBoxColumn();
            title = new DataGridViewTextBoxColumn();
            fideId = new DataGridViewTextBoxColumn();
            copyFideId = new DataGridViewButtonColumn();
            rating = new DataGridViewTextBoxColumn();
            copyRating = new DataGridViewButtonColumn();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            uygulamaToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            hakkındaToolStripMenuItem = new ToolStripMenuItem();
            kapatToolStripMenuItem = new ToolStripMenuItem();
            redownloadRatingsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)playersDataViewInput).BeginInit();
            tabControl.SuspendLayout();
            inputTab.SuspendLayout();
            outputTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playersDataViewOutput).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // standardRadioButton
            // 
            standardRadioButton.AutoSize = true;
            standardRadioButton.Location = new Point(22, 42);
            standardRadioButton.Name = "standardRadioButton";
            standardRadioButton.Size = new Size(72, 19);
            standardRadioButton.TabIndex = 1;
            standardRadioButton.TabStop = true;
            standardRadioButton.Text = "Standard";
            standardRadioButton.UseVisualStyleBackColor = true;
            // 
            // rapidRadioButton
            // 
            rapidRadioButton.AutoSize = true;
            rapidRadioButton.Location = new Point(124, 42);
            rapidRadioButton.Name = "rapidRadioButton";
            rapidRadioButton.Size = new Size(55, 19);
            rapidRadioButton.TabIndex = 2;
            rapidRadioButton.TabStop = true;
            rapidRadioButton.Text = "Rapid";
            rapidRadioButton.UseVisualStyleBackColor = true;
            // 
            // blitzRadioButton
            // 
            blitzRadioButton.AutoSize = true;
            blitzRadioButton.Location = new Point(214, 42);
            blitzRadioButton.Name = "blitzRadioButton";
            blitzRadioButton.Size = new Size(47, 19);
            blitzRadioButton.TabIndex = 3;
            blitzRadioButton.TabStop = true;
            blitzRadioButton.Text = "Blitz";
            blitzRadioButton.UseVisualStyleBackColor = true;
            // 
            // findButton
            // 
            findButton.Location = new Point(812, 31);
            findButton.Name = "findButton";
            findButton.Size = new Size(115, 41);
            findButton.TabIndex = 4;
            findButton.Text = "Oyuncuları Bul";
            findButton.UseVisualStyleBackColor = true;
            findButton.Click += findButton_Click;
            // 
            // playersDataViewInput
            // 
            playersDataViewInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            playersDataViewInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            playersDataViewInput.Columns.AddRange(new DataGridViewColumn[] { surname, name, birthday });
            playersDataViewInput.Location = new Point(0, 46);
            playersDataViewInput.Name = "playersDataViewInput";
            playersDataViewInput.RowTemplate.Height = 25;
            playersDataViewInput.Size = new Size(940, 440);
            playersDataViewInput.TabIndex = 5;
            // 
            // surname
            // 
            surname.HeaderText = "Soyad";
            surname.Name = "surname";
            // 
            // name
            // 
            name.HeaderText = "Ad";
            name.Name = "name";
            // 
            // birthday
            // 
            birthday.HeaderText = "Doğum Tarihi (Yıl)";
            birthday.MaxInputLength = 4;
            birthday.Name = "birthday";
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(inputTab);
            tabControl.Controls.Add(outputTab);
            tabControl.Location = new Point(22, 84);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(944, 526);
            tabControl.TabIndex = 6;
            // 
            // inputTab
            // 
            inputTab.Controls.Add(importButton);
            inputTab.Controls.Add(playersDataViewInput);
            inputTab.Location = new Point(4, 24);
            inputTab.Name = "inputTab";
            inputTab.Padding = new Padding(3);
            inputTab.Size = new Size(936, 498);
            inputTab.TabIndex = 0;
            inputTab.Text = "Aranan Oyuncular (Giriş)";
            inputTab.UseVisualStyleBackColor = true;
            // 
            // importButton
            // 
            importButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            importButton.BackColor = Color.Red;
            importButton.ForeColor = SystemColors.ControlLightLight;
            importButton.Location = new Point(796, 6);
            importButton.Name = "importButton";
            importButton.Size = new Size(134, 34);
            importButton.TabIndex = 6;
            importButton.Text = "İçeri Aktar (CSV)";
            importButton.UseVisualStyleBackColor = false;
            importButton.Click += importButton_Click;
            // 
            // outputTab
            // 
            outputTab.Controls.Add(exportButton);
            outputTab.Controls.Add(searchButton);
            outputTab.Controls.Add(searchTextBox);
            outputTab.Controls.Add(numOfPlayersLabel);
            outputTab.Controls.Add(label2);
            outputTab.Controls.Add(ratingTypeLabel);
            outputTab.Controls.Add(label1);
            outputTab.Controls.Add(playersDataViewOutput);
            outputTab.Location = new Point(4, 24);
            outputTab.Name = "outputTab";
            outputTab.Padding = new Padding(3);
            outputTab.Size = new Size(936, 498);
            outputTab.TabIndex = 1;
            outputTab.Text = "Bulunan Oyuncular";
            outputTab.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            exportButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exportButton.BackColor = Color.Green;
            exportButton.Enabled = false;
            exportButton.ForeColor = SystemColors.ControlLightLight;
            exportButton.Location = new Point(786, 8);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(134, 34);
            exportButton.TabIndex = 7;
            exportButton.Text = "Dışarı Aktar (CSV)";
            exportButton.UseVisualStyleBackColor = false;
            exportButton.Click += exportButton_Click;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchButton.Enabled = false;
            searchButton.Location = new Point(867, 60);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(53, 23);
            searchButton.TabIndex = 6;
            searchButton.Text = "Ara";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchTextBox.Enabled = false;
            searchTextBox.Location = new Point(695, 61);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(166, 23);
            searchTextBox.TabIndex = 5;
            searchTextBox.KeyDown += searchTextBox_KeyDown;
            // 
            // numOfPlayersLabel
            // 
            numOfPlayersLabel.AutoSize = true;
            numOfPlayersLabel.Location = new Point(159, 37);
            numOfPlayersLabel.Name = "numOfPlayersLabel";
            numOfPlayersLabel.Size = new Size(13, 15);
            numOfPlayersLabel.TabIndex = 4;
            numOfPlayersLabel.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 37);
            label2.Name = "label2";
            label2.Size = new Size(133, 15);
            label2.TabIndex = 3;
            label2.Text = "Bulunan Oyuncu Sayısı:";
            // 
            // ratingTypeLabel
            // 
            ratingTypeLabel.AutoSize = true;
            ratingTypeLabel.Location = new Point(159, 12);
            ratingTypeLabel.Name = "ratingTypeLabel";
            ratingTypeLabel.Size = new Size(76, 15);
            ratingTypeLabel.TabIndex = 2;
            ratingTypeLabel.Text = "Belirtilmemiş";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 12);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 1;
            label1.Text = "Rating Türü:";
            // 
            // playersDataViewOutput
            // 
            playersDataViewOutput.AllowUserToAddRows = false;
            playersDataViewOutput.AllowUserToDeleteRows = false;
            playersDataViewOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            playersDataViewOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            playersDataViewOutput.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, fed, title, fideId, copyFideId, rating, copyRating });
            playersDataViewOutput.Location = new Point(0, 100);
            playersDataViewOutput.Name = "playersDataViewOutput";
            playersDataViewOutput.RowTemplate.Height = 25;
            playersDataViewOutput.Size = new Size(951, 398);
            playersDataViewOutput.TabIndex = 0;
            playersDataViewOutput.CellContentClick += playersDataViewOutput_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Soyad";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Ad";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Doğum Tarihi (YIL)";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // fed
            // 
            fed.HeaderText = "FED";
            fed.Name = "fed";
            // 
            // title
            // 
            title.HeaderText = "Ünvan";
            title.Name = "title";
            // 
            // fideId
            // 
            fideId.HeaderText = "FIDE ID";
            fideId.Name = "fideId";
            // 
            // copyFideId
            // 
            copyFideId.FillWeight = 80F;
            copyFideId.HeaderText = "ID Kopyala";
            copyFideId.Name = "copyFideId";
            copyFideId.ReadOnly = true;
            copyFideId.Width = 75;
            // 
            // rating
            // 
            rating.HeaderText = "Rating";
            rating.Name = "rating";
            // 
            // copyRating
            // 
            copyRating.FillWeight = 80F;
            copyRating.HeaderText = "RTG Kopyala";
            copyRating.Name = "copyRating";
            copyRating.Resizable = DataGridViewTriState.True;
            copyRating.SortMode = DataGridViewColumnSortMode.Automatic;
            copyRating.Width = 80;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 614);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(978, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(34, 17);
            statusLabel.Text = "Hazır";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { uygulamaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(978, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // uygulamaToolStripMenuItem
            // 
            uygulamaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logsToolStripMenuItem, hakkındaToolStripMenuItem, kapatToolStripMenuItem });
            uygulamaToolStripMenuItem.Name = "uygulamaToolStripMenuItem";
            uygulamaToolStripMenuItem.Size = new Size(73, 20);
            uygulamaToolStripMenuItem.Text = "Uygulama";
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(124, 22);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += logsToolStripMenuItem_Click;
            // 
            // hakkındaToolStripMenuItem
            // 
            hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            hakkındaToolStripMenuItem.Size = new Size(124, 22);
            hakkındaToolStripMenuItem.Text = "Hakkında";
            hakkındaToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // kapatToolStripMenuItem
            // 
            kapatToolStripMenuItem.Name = "kapatToolStripMenuItem";
            kapatToolStripMenuItem.Size = new Size(124, 22);
            kapatToolStripMenuItem.Text = "Kapat";
            kapatToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // redownloadRatingsButton
            // 
            redownloadRatingsButton.BackColor = SystemColors.Info;
            redownloadRatingsButton.Location = new Point(689, 49);
            redownloadRatingsButton.Name = "redownloadRatingsButton";
            redownloadRatingsButton.Size = new Size(104, 23);
            redownloadRatingsButton.TabIndex = 9;
            redownloadRatingsButton.Text = "Yeniden İndir";
            redownloadRatingsButton.UseVisualStyleBackColor = false;
            redownloadRatingsButton.Click += RedownloadRatingsButton_Click;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 636);
            Controls.Add(redownloadRatingsButton);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl);
            Controls.Add(findButton);
            Controls.Add(blitzRadioButton);
            Controls.Add(rapidRadioButton);
            Controls.Add(standardRadioButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "main";
            Text = "FIDE ID Finder (DEMO)";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)playersDataViewInput).EndInit();
            tabControl.ResumeLayout(false);
            inputTab.ResumeLayout(false);
            outputTab.ResumeLayout(false);
            outputTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playersDataViewOutput).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RadioButton standardRadioButton;
        private RadioButton rapidRadioButton;
        private RadioButton blitzRadioButton;
        private Button findButton;
        private DataGridView playersDataViewInput;
        private DataGridViewTextBoxColumn surname;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn birthday;
        private TabControl tabControl;
        private TabPage inputTab;
        private TabPage outputTab;
        private DataGridView playersDataViewOutput;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn fed;
        private DataGridViewTextBoxColumn title;
        private DataGridViewTextBoxColumn fideId;
        private DataGridViewButtonColumn copyFideId;
        private DataGridViewTextBoxColumn rating;
        private DataGridViewButtonColumn copyRating;
        private Label label2;
        private Label ratingTypeLabel;
        private Label label1;
        private Label numOfPlayersLabel;
        private Button searchButton;
        private TextBox searchTextBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem uygulamaToolStripMenuItem;
        private ToolStripMenuItem logsToolStripMenuItem;
        private ToolStripMenuItem hakkındaToolStripMenuItem;
        private ToolStripMenuItem kapatToolStripMenuItem;
        private Button redownloadRatingsButton;
        private Button exportButton;
        private Button importButton;
    }
}