using System;
using System.Text;
using System.Windows.Forms;
using SharpPcap.LibPcap;
using System.Timers;
namespace SwitchApp
{
     public partial class SwitchForm : Form
    {
        private readonly Switch _switch = new();
        private readonly System.Windows.Forms.Timer _statsUpdateTimer = new() { Interval = 1000 };

        public SwitchForm()
        {
            InitializeComponent();
            LoadAvailableInterfaces();
            SetupEventHandlers();
        }

        private void LoadAvailableInterfaces()
        {
            try
            {
                var interfaces = _switch.GetAvailableDevices();
            
                cmbInterface1.DataSource = interfaces;
                cmbInterface1.DisplayMember = "Description";
            
                cmbInterface2.DataSource = interfaces.ToList();
                cmbInterface2.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading interfaces: {ex.Message}", 
                    "Initialization Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                Close();
            }
        }

        private void SetupEventHandlers()
        {
            btnReset.Click += (s, e) =>
            {
                _switch.ResetStats();
                UpdateStatisticsDisplay(s,e);
            };
            _statsUpdateTimer.Tick += UpdateStatisticsDisplay;
            _statsUpdateTimer.Start();
            btnStart.Click += (s, e) =>
            {
                try
                {
                    
                    if (cmbInterface1.SelectedItem == null || cmbInterface2.SelectedItem == null)
                    {
                        MessageBox.Show("Please select both interfaces.");
                        return;
                    }

                    
                    dynamic selected1 = cmbInterface1.SelectedItem;
                    dynamic selected2 = cmbInterface2.SelectedItem;

                   
                    var if1 = (LibPcapLiveDevice)selected1.Device;
                    var if2 = (LibPcapLiveDevice)selected2.Device;

                    if (if1 == null || if2 == null)
                    {
                        MessageBox.Show("Invalid interface selection.");
                        return;
                    }

                    
                    if (if1.Name == if2.Name)
                    {
                        MessageBox.Show("Cannot select the same interface for both ports.");
                        return;
                    }

                    
                    _switch.InitializePorts(if1, if2);
                    _switch.Start();

                    btnStart.Enabled = false;
                    _statsUpdateTimer.Start();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to start: {ex.Message}", 
                        "Operation Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                }
            };

            _statsUpdateTimer.Tick += UpdateStatisticsDisplay;
        }
        private void UpdateStatisticsDisplay(object sender, EventArgs e)
        {
            
            foreach (var kvp in _switch.PortStatistics)
            {
                int portNumber = kvp.Key;
                PortStats stats = kvp.Value;

                
                foreach (var proto in stats.In)
                {
                    string protocol = proto.Key; 
                    int count = proto.Value;

                    
                    string labelName = $"p{portNumber}_{protocol}_i";

                    UpdateLabelText(labelName, count.ToString());
                }

                
                foreach (var proto in stats.Out)
                {
                    string protocol = proto.Key; 
                    int count = proto.Value;

                    
                    string labelName = $"p{portNumber}_{protocol}_o";

                    UpdateLabelText(labelName, count.ToString());
                }
            }
        }


        private void UpdateLabelText(string labelName, string text)
        {
            if (InvokeRequired) 
            {
                Invoke((Action)(() => UpdateLabelText(labelName, text)));
                return;
            }

            
            Control[] matches = Controls.Find(labelName, true);
            if (matches.Length > 0 && matches[0] is Label label)
            {
                label.Text = text;
            }
        }

        private void cmbInterface1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selectedInterface = cmbInterface1.SelectedItem as LibPcapLiveDevice;
            if (selectedInterface != null)
            {
                
            }
        }

        private void SwitchForm_Load(object sender, EventArgs e)
        {
            LoadAvailableInterfaces();
            SetupEventHandlers();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        

        private void label12_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
  
        
    }
}