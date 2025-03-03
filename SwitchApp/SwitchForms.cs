using System;
using System.Text;
using System.Windows.Forms;

namespace SwitchApp
{
    public partial class SwitchForm : Form
    {
        private readonly Switch _switch = new();
        private readonly System.Windows.Forms.Timer _statsTimer = new() { Interval = 1000 };

        public SwitchForm()
        {
            InitializeComponent();
            SetupEventHandlers();
            StartSwitch();
        }

        private void SetupEventHandlers()
        {
            btnReset.Click += (s, e) => _switch.ResetStats();
            _statsTimer.Tick += UpdateStatisticsDisplay;
            _statsTimer.Start();
        }

        private void StartSwitch()
        {
            try
            {
                _switch.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void UpdateStatisticsDisplay(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            
            foreach (var kvp in _switch.PortStatistics)
            {
                var portNumber = kvp.Key;
                PortStats stats = kvp.Value;
        
                sb.AppendLine($"Port {portNumber} - IN:");
                foreach (var proto in stats.In)
                    sb.AppendLine($"  {proto.Key}: {proto.Value}");
        
                sb.AppendLine($"Port {portNumber} - OUT:");
                foreach (var proto in stats.Out)
                    sb.AppendLine($"  {proto.Key}: {proto.Value}");
        
                sb.AppendLine();
            }
            
            txtStats.Invoke(() => txtStats.Text = sb.ToString());
        }
    }
}