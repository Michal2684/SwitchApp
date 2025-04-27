
using SharpPcap.LibPcap;
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
                MessageBox.Show($"Error loading interfaces: {ex.Message}","Initialization Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
            }
        }

        private void SetupEventHandlers()
        {
            btnAddAcl.Click += BtnAddAcl_Click;
            btnDeleteAcl.Click += BtnDeleteAcl_Click;
            btnClearAllAcl.Click += BtnClearAllAcl_Click;
            
            btnReset.Click += (s, e) =>
            {
                _switch.ResetStats();
                ClearProtocolLabels();
                UpdateStatisticsDisplay(s, e);
            };
            btnClearMac.Click += (s, e) =>
            {
                _switch.ClearMacTable(); 
                UpdateStatisticsDisplay(s, e); 
            };
            _statsUpdateTimer.Tick += UpdateStatisticsDisplay;
            _statsUpdateTimer.Start();
            btnStart.Click += (_, _) =>
            {
                try
                {
                    if (cmbInterface1.SelectedItem == null || cmbInterface2.SelectedItem == null)
                    {
                        MessageBox.Show("Please select both interfaces.");
                        return;
                    }

                    dynamic sel1 = cmbInterface1.SelectedItem;
                    dynamic sel2 = cmbInterface2.SelectedItem;
                    var if1 = (LibPcapLiveDevice)sel1.Device;
                    var if2 = (LibPcapLiveDevice)sel2.Device;
                    if (if1.Name == if2.Name)
                    {
                        MessageBox.Show("Cannot select the same interface for both ports.");
                        return;
                    }

                    _switch.SetupPorts(if1, if2);
                    _switch.Start();
                    _statsUpdateTimer.Start();
                    
                    btnStart.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Switch Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };
        }

    private void BtnAddAcl_Click(object? sender, EventArgs e)
    {
        using (var dialog = new Form {
            Text = "Add ACL Rule",
            Size = new Size(320, 480),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox  = false,
            MinimizeBox = false
        })
        {
            var lblDirection = new Label { Text = "Direction:",  Location = new Point(20, 20),  Size = new Size(80, 20) };
            var cmbDirection = new ComboBox { Location = new Point(110, 20), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbDirection.Items.AddRange(new[] { "Inbound", "Outbound" });
            cmbDirection.SelectedIndex = 0;

            var lblAction = new Label { Text = "Action:", Location = new Point(20, 60), Size = new Size(80, 20) };
            var cmbAction = new ComboBox { Location = new Point(110, 60), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbAction.Items.AddRange(new[] { "Permit", "Deny" });
            cmbAction.SelectedIndex = 0;

            var lblPort = new Label { Text = "Port (1/2):", Location = new Point(20, 100), Size = new Size(80, 20) };
            var txtPort = new TextBox { Location = new Point(110, 100), Width = 180, Text = "*" };

            var lblSrcMac = new Label { Text = "Src MAC:", Location = new Point(20, 140), Size = new Size(80, 20) };
            var txtSrcMac = new TextBox { Location = new Point(110, 140), Width = 180, Text = "*" };

            var lblDstMac = new Label { Text = "Dst MAC:", Location = new Point(20, 180), Size = new Size(80, 20) };
            var txtDstMac = new TextBox { Location = new Point(110, 180), Width = 180, Text = "*" };

            var lblSrcIp  = new Label { Text = "Src IP:",  Location = new Point(20, 220), Size = new Size(80, 20) };
            var txtSrcIp  = new TextBox { Location = new Point(110, 220), Width = 180, Text = "*" };

            var lblDstIp  = new Label { Text = "Dst IP:",  Location = new Point(20, 260), Size = new Size(80, 20) };
            var txtDstIp  = new TextBox { Location = new Point(110, 260), Width = 180, Text = "*" };

            var lblSrcPort = new Label { Text = "Src Port:", Location = new Point(20, 300), Size = new Size(80, 20) };
            var txtSrcPort = new TextBox { Location = new Point(110, 300), Width = 180, Text = "*" };

            var lblDstPort = new Label { Text = "Dst Port:", Location = new Point(20, 340), Size = new Size(80, 20) };
            var txtDstPort = new TextBox { Location = new Point(110, 340), Width = 180, Text = "*" };

            var lblIcmp = new Label { Text = "ICMP Type:", Location = new Point(20, 380), Size = new Size(80, 20) };
            var txtIcmp = new TextBox { Location = new Point(110, 380), Width = 180, Text = "*" };
            
            var btnOk = new Button {
                Text = "Add",
                Location = new Point(60, 420),
                Width  = 80,
                DialogResult = DialogResult.OK
            };
            var btnCancel = new Button {
                Text = "Cancel",
                Location = new Point(160, 420),
                Width = 80,
                DialogResult = DialogResult.Cancel
            };

            dialog.Controls.AddRange(new Control[] {
                lblDirection, cmbDirection,
                lblAction, cmbAction,
                lblPort, txtPort,
                lblSrcMac, txtSrcMac,
                lblDstMac, txtDstMac,
                lblSrcIp, txtSrcIp,
                lblDstIp, txtDstIp,
                lblSrcPort, txtSrcPort,
                lblDstPort, txtDstPort,
                lblIcmp, txtIcmp,
                btnOk, btnCancel
            });

            dialog.AcceptButton = btnOk;
            dialog.CancelButton = btnCancel;
            
            cmbDirection.DataSource = Enum.GetValues(typeof(AclDirection));
            cmbAction.DataSource = Enum.GetValues(typeof(AclAction));

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                string? Wild(string s) => (s.Trim() == "*") ? null : s.Trim();
                
                var rule = new AclRule {
                    Direction = (AclDirection)cmbDirection.SelectedItem,
                    Action = (AclAction)cmbAction.SelectedItem,
                    Port = Wild(txtPort.Text) != null ? int.Parse(txtPort.Text) : (int?)null,
                    SrcMac = Wild(txtSrcMac.Text),
                    DstMac = Wild(txtDstMac.Text),
                    SrcIp = Wild(txtSrcIp.Text),
                    DstIp = Wild(txtDstIp.Text),
                    SrcPort = Wild(txtSrcPort.Text) != null ? int.Parse(txtSrcPort.Text) : (int?)null,
                    DstPort = Wild(txtDstPort.Text) != null ? int.Parse(txtDstPort.Text) : (int?)null,
                    IcmpType = Wild(txtIcmp.Text) != null ? byte.Parse(txtIcmp.Text) : (byte?)null
                };
                _switch.AddRule(rule); 
                UpdateAclTable();
            }
        }
    }

    private void BtnDeleteAcl_Click(object? sender, EventArgs e)
    {
        if (lvAclTable.SelectedItems.Count == 0) return;
        int id = int.Parse(lvAclTable.SelectedItems[0].Text);
        _switch.RemoveRule(id);
        UpdateAclTable();
    }

    private void BtnClearAllAcl_Click(object? sender, EventArgs e)
    {
        _switch.ClearRules();
        UpdateAclTable();
    }

    private void UpdateAclTable()
    {
        lvAclTable.BeginUpdate();
        lvAclTable.Items.Clear();
        foreach (var r in _switch.AclRules)
        {
            var item = new ListViewItem(r.Id.ToString());
            item.SubItems.Add(r.Direction.ToString());
            item.SubItems.Add(r.Action.ToString());
            item.SubItems.Add(r.Port?.ToString() ?? "*");
            item.SubItems.Add(r.SrcMac ?? "*");
            item.SubItems.Add(r.DstMac ?? "*");
            item.SubItems.Add(r.SrcIp ?? "*");
            item.SubItems.Add(r.DstIp ?? "*");
            item.SubItems.Add(r.SrcPort?.ToString() ?? "*");
            item.SubItems.Add(r.DstPort?.ToString() ?? "*");
            item.SubItems.Add(r.IcmpType?.ToString() ?? "*");
            lvAclTable.Items.Add(item);
        }
        lvAclTable.EndUpdate();
    
            
        }
        private void UpdateStatisticsDisplay(object? sender, EventArgs e)
        {

            lvMacTable.BeginUpdate();
            lvMacTable.Items.Clear();
            foreach (var entry in _switch.GetMacTable())
            {
                var item = new ListViewItem(entry.Key);
                item.SubItems.Add(entry.Value.Port.ToString());
                item.SubItems.Add(entry.Value.RemainingSeconds.ToString());
                lvMacTable.Items.Add(item);
            }
            lvMacTable.EndUpdate();
            
            foreach (var kvp in _switch.Stats)
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

        private void ClearProtocolLabels()
        {
            foreach (var c in GetAllControls(this))
            {
                if (c is Label lbl
                    && (lbl.Name.StartsWith("p1_") || lbl.Name.StartsWith("p2_")) && (lbl.Name.EndsWith("_i") || lbl.Name.EndsWith("_o")))
                {
                    lbl.Text = string.Empty;
                }
            }
        }
        
        private IEnumerable<Control> GetAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                foreach (var child in GetAllControls(c))
                    yield return child;
                yield return c;
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
        

        private void SwitchForm_Load(object sender, EventArgs e)
        {
            LoadAvailableInterfaces();
            SetupEventHandlers();
        }



    }
}