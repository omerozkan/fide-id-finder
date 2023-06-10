namespace FIDE_ID_Finder
{
    partial class LogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            logsView = new ListView();
            messages = new ColumnHeader();
            SuspendLayout();
            // 
            // logsView
            // 
            logsView.Columns.AddRange(new ColumnHeader[] { messages });
            logsView.Dock = DockStyle.Fill;
            logsView.Location = new Point(0, 0);
            logsView.Name = "logsView";
            logsView.Size = new Size(800, 450);
            logsView.TabIndex = 0;
            logsView.UseCompatibleStateImageBehavior = false;
            logsView.View = View.Details;
            // 
            // messages
            // 
            messages.Text = "Messages";
            messages.Width = 500;
            // 
            // LogViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logsView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LogViewer";
            Text = "Developer Logs";
            Load += LogViewer_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView logsView;
        private ColumnHeader messages;
    }
}