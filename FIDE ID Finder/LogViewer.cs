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
    public partial class LogViewer : Form
    {
        private readonly LogService _logService = LogService.Get();
        public LogViewer()
        {
            InitializeComponent();
            _logService.LogSubmitted += LogServiceOnLogSubmitted;
        }

        private void LogServiceOnLogSubmitted(object? sender, string e)
        {
            logsView.Items.Add(e);
        }

        private void LogViewer_Load(object sender, EventArgs e)
        {
            ApplyLogs();
        }

        private void ApplyLogs()
        {
            var logs = _logService.GetLogs();
            foreach (var log in logs)
            {
                logsView.Items.Add(log);
            }
        }
    }
}
