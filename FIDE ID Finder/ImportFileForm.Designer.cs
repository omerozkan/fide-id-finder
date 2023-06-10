namespace FIDE_ID_Finder
{
    partial class ImportFileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFileForm));
            openFileDialog = new OpenFileDialog();
            openFileButton = new Button();
            filePathLabel = new Label();
            skipFirstLineBox = new CheckBox();
            dataGridView = new DataGridView();
            applyButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "CSV file (*.csv)|*.csv";
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(27, 31);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(77, 28);
            openFileButton.TabIndex = 0;
            openFileButton.Text = "Dosya Seç";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButton_Click;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Location = new Point(122, 38);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(93, 15);
            filePathLabel.TabIndex = 1;
            filePathLabel.Text = "Dosya Seçilmedi";
            // 
            // skipFirstLineBox
            // 
            skipFirstLineBox.AutoSize = true;
            skipFirstLineBox.Location = new Point(27, 90);
            skipFirstLineBox.Name = "skipFirstLineBox";
            skipFirstLineBox.Size = new Size(88, 19);
            skipFirstLineBox.TabIndex = 2;
            skipFirstLineBox.Text = "İlk satırı atla";
            skipFirstLineBox.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(27, 138);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(761, 300);
            dataGridView.TabIndex = 3;
            // 
            // applyButton
            // 
            applyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyButton.Location = new Point(704, 458);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(84, 28);
            applyButton.TabIndex = 4;
            applyButton.Text = "Aktar";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // ImportFileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(809, 498);
            Controls.Add(applyButton);
            Controls.Add(dataGridView);
            Controls.Add(skipFirstLineBox);
            Controls.Add(filePathLabel);
            Controls.Add(openFileButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ImportFileForm";
            Text = "ImportFileForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button openFileButton;
        private Label filePathLabel;
        private CheckBox skipFirstLineBox;
        private DataGridView dataGridView;
        private Button applyButton;
    }
}