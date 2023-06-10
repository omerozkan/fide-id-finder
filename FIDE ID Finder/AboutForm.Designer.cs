namespace FIDE_ID_Finder
{
    partial class AboutForm
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
            Label label1;
            Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 24);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "FIDE ID Bulucu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 49);
            label2.MaximumSize = new Size(150, 0);
            label2.Name = "label2";
            label2.Size = new Size(149, 45);
            label2.TabIndex = 1;
            label2.Text = "Bu uygulama Ömer Özkan tarafından TSF Hakemleri için geliştirilmiştir.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 119);
            label3.Name = "label3";
            label3.Size = new Size(143, 15);
            label3.TabIndex = 2;
            label3.Text = "İletisim: omer@ozkan.dev";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 187);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AboutForm";
            Text = "Hakkında";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
    }
}