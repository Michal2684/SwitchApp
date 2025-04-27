namespace SwitchApp
{
    partial class SwitchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtStats;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvMacTable;
        private System.Windows.Forms.Button btnClearMac;
        private System.Windows.Forms.NumericUpDown nudTimeout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            
            base.Dispose(disposing);
        }

        private System.Windows.Forms.ComboBox cmbInterface1;
        private System.Windows.Forms.ComboBox cmbInterface2;
        private System.Windows.Forms.Button btnStart;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvMacTable = new System.Windows.Forms.ListView();
            btnClearMac = new System.Windows.Forms.Button();
            nudTimeout = new System.Windows.Forms.NumericUpDown();
            txtStats = new System.Windows.Forms.TextBox();
            btnReset = new System.Windows.Forms.Button();
            cmbInterface1 = new System.Windows.Forms.ComboBox();
            cmbInterface2 = new System.Windows.Forms.ComboBox();
            btnStart = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            p1_tcp_i = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            p1_tcp_o = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            p1_EthernetII_i = new System.Windows.Forms.Label();
            p1_udp_o = new System.Windows.Forms.Label();
            p1_udp_i = new System.Windows.Forms.Label();
            p1_icmp_o = new System.Windows.Forms.Label();
            p1_icmp_i = new System.Windows.Forms.Label();
            p1_ip_o = new System.Windows.Forms.Label();
            p1_ip_i = new System.Windows.Forms.Label();
            p1_EthernetII_o = new System.Windows.Forms.Label();
            p1_http_o = new System.Windows.Forms.Label();
            p1_http_i = new System.Windows.Forms.Label();
            p1_arp_o = new System.Windows.Forms.Label();
            p1_arp_i = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            p2_ip_o = new System.Windows.Forms.Label();
            p2_ip_i = new System.Windows.Forms.Label();
            p2_EthernetII_o = new System.Windows.Forms.Label();
            p2_EthernetII_i = new System.Windows.Forms.Label();
            p2_udp_i = new System.Windows.Forms.Label();
            p2_udp_o = new System.Windows.Forms.Label();
            p2_tcp_o = new System.Windows.Forms.Label();
            p2_tcp_i = new System.Windows.Forms.Label();
            p2_http_i = new System.Windows.Forms.Label();
            p2_arp_o = new System.Windows.Forms.Label();
            p2_arp_i = new System.Windows.Forms.Label();
            p2_icmp_o = new System.Windows.Forms.Label();
            p2_icmp_i = new System.Windows.Forms.Label();
            p2_http_o = new System.Windows.Forms.Label();
            label47 = new System.Windows.Forms.Label();
            label48 = new System.Windows.Forms.Label();
            lvAclTable = new System.Windows.Forms.ListView();
            btnAddAcl = new System.Windows.Forms.Button();
            btnDeleteAcl = new System.Windows.Forms.Button();
            btnClearAllAcl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)nudTimeout).BeginInit();
            SuspendLayout();
            // 
            // lvMacTable
            // 
            lvMacTable.Location = new System.Drawing.Point(274, 441);
            lvMacTable.Name = "lvMacTable";
            lvMacTable.Size = new System.Drawing.Size(400, 200);
            lvMacTable.TabIndex = 0;
            lvMacTable.Columns.AddRange(new[] {
                new ColumnHeader() { Text = "MAC Address", Width = 200 },
                new ColumnHeader() { Text = "Port", Width = 80 },
                new ColumnHeader() { Text = "TTL (sec)", Width = 100 }
            });
            lvMacTable.UseCompatibleStateImageBehavior = false;
            lvMacTable.View = System.Windows.Forms.View.Details;
            // 
            // btnClearMac
            // 
            btnClearMac.Location = new System.Drawing.Point(274, 647);
            btnClearMac.Name = "btnClearMac";
            btnClearMac.Size = new System.Drawing.Size(80, 30);
            btnClearMac.TabIndex = 1;
            btnClearMac.Text = "Clear";
            // 
            // nudTimeout
            // 
            nudTimeout.Location = new System.Drawing.Point(554, 647);
            nudTimeout.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nudTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTimeout.Name = "nudTimeout";
            nudTimeout.Size = new System.Drawing.Size(120, 31);
            nudTimeout.TabIndex = 2;
            nudTimeout.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // txtStats
            // 
            txtStats.BackColor = System.Drawing.SystemColors.ScrollBar;
            txtStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtStats.Dock = System.Windows.Forms.DockStyle.Fill;
            txtStats.Location = new System.Drawing.Point(0, 0);
            txtStats.Name = "txtStats";
            txtStats.ReadOnly = true;
            txtStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtStats.Size = new System.Drawing.Size(978, 24);
            txtStats.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            btnReset.Location = new System.Drawing.Point(478, 387);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(125, 38);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset Stats";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // cmbInterface1
            // 
            cmbInterface1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            cmbInterface1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbInterface1.Location = new System.Drawing.Point(0, 314);
            cmbInterface1.Name = "cmbInterface1";
            cmbInterface1.Size = new System.Drawing.Size(284, 33);
            cmbInterface1.TabIndex = 2;
            // 
            // cmbInterface2
            // 
            cmbInterface2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            cmbInterface2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbInterface2.Location = new System.Drawing.Point(672, 314);
            cmbInterface2.Name = "cmbInterface2";
            cmbInterface2.Size = new System.Drawing.Size(306, 33);
            cmbInterface2.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            btnStart.Location = new System.Drawing.Point(347, 387);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(125, 38);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label1.Location = new System.Drawing.Point(0, 268);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(189, 43);
            label1.TabIndex = 5;
            label1.Text = "Interface 1";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.SystemColors.ScrollBar;
            label2.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label2.Location = new System.Drawing.Point(778, 268);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(200, 43);
            label2.TabIndex = 6;
            label2.Text = "Interface 2";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.SystemColors.ScrollBar;
            label3.Font = new System.Drawing.Font("Tahoma", 10F);
            label3.Location = new System.Drawing.Point(55, 455);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 27);
            label3.TabIndex = 7;
            label3.Text = "TCP";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label4.Location = new System.Drawing.Point(0, 506);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(108, 27);
            label4.TabIndex = 10;
            label4.Text = "Ethernet II";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.BackColor = System.Drawing.SystemColors.ScrollBar;
            label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label9.Location = new System.Drawing.Point(77, 764);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(84, 43);
            label9.TabIndex = 15;
            label9.Text = "HTTP";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_tcp_i
            // 
            p1_tcp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_tcp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_tcp_i.Location = new System.Drawing.Point(108, 455);
            p1_tcp_i.Name = "p1_tcp_i";
            p1_tcp_i.Size = new System.Drawing.Size(53, 27);
            p1_tcp_i.TabIndex = 21;
            p1_tcp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.BackColor = System.Drawing.SystemColors.ScrollBar;
            label10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label10.Location = new System.Drawing.Point(126, 427);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(26, 28);
            label10.TabIndex = 29;
            label10.Text = "I";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.BackColor = System.Drawing.SystemColors.ScrollBar;
            label11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label11.Location = new System.Drawing.Point(167, 427);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(33, 28);
            label11.TabIndex = 30;
            label11.Text = "O";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.BackColor = System.Drawing.SystemColors.ScrollBar;
            label12.Font = new System.Drawing.Font("Tahoma", 10F);
            label12.Location = new System.Drawing.Point(55, 483);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(53, 27);
            label12.TabIndex = 55;
            label12.Text = "UDP";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_tcp_o
            // 
            p1_tcp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_tcp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_tcp_o.Location = new System.Drawing.Point(158, 455);
            p1_tcp_o.Name = "p1_tcp_o";
            p1_tcp_o.Size = new System.Drawing.Size(53, 27);
            p1_tcp_o.TabIndex = 57;
            p1_tcp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            label5.Font = new System.Drawing.Font("Tahoma", 10F);
            label5.Location = new System.Drawing.Point(46, 560);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 27);
            label5.TabIndex = 58;
            label5.Text = "ICMP";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BackColor = System.Drawing.SystemColors.ScrollBar;
            label6.Font = new System.Drawing.Font("Tahoma", 10F);
            label6.Location = new System.Drawing.Point(55, 533);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(53, 27);
            label6.TabIndex = 59;
            label6.Text = "IP";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BackColor = System.Drawing.SystemColors.ScrollBar;
            label7.Font = new System.Drawing.Font("Tahoma", 10F);
            label7.Location = new System.Drawing.Point(55, 587);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(53, 27);
            label7.TabIndex = 60;
            label7.Text = "ARP";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = System.Drawing.SystemColors.ScrollBar;
            label8.Font = new System.Drawing.Font("Tahoma", 10F);
            label8.Location = new System.Drawing.Point(46, 614);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(62, 27);
            label8.TabIndex = 61;
            label8.Text = "HTTP";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_EthernetII_i
            // 
            p1_EthernetII_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_EthernetII_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_EthernetII_i.Location = new System.Drawing.Point(108, 506);
            p1_EthernetII_i.Name = "p1_EthernetII_i";
            p1_EthernetII_i.Size = new System.Drawing.Size(53, 27);
            p1_EthernetII_i.TabIndex = 62;
            p1_EthernetII_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_udp_o
            // 
            p1_udp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_udp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_udp_o.Location = new System.Drawing.Point(158, 479);
            p1_udp_o.Name = "p1_udp_o";
            p1_udp_o.Size = new System.Drawing.Size(53, 27);
            p1_udp_o.TabIndex = 63;
            p1_udp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_udp_i
            // 
            p1_udp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_udp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_udp_i.Location = new System.Drawing.Point(108, 479);
            p1_udp_i.Name = "p1_udp_i";
            p1_udp_i.Size = new System.Drawing.Size(53, 27);
            p1_udp_i.TabIndex = 64;
            p1_udp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_icmp_o
            // 
            p1_icmp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_icmp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_icmp_o.Location = new System.Drawing.Point(158, 560);
            p1_icmp_o.Name = "p1_icmp_o";
            p1_icmp_o.Size = new System.Drawing.Size(53, 27);
            p1_icmp_o.TabIndex = 65;
            p1_icmp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_icmp_i
            // 
            p1_icmp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_icmp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_icmp_i.Location = new System.Drawing.Point(108, 560);
            p1_icmp_i.Name = "p1_icmp_i";
            p1_icmp_i.Size = new System.Drawing.Size(53, 27);
            p1_icmp_i.TabIndex = 66;
            p1_icmp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_ip_o
            // 
            p1_ip_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_ip_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_ip_o.Location = new System.Drawing.Point(158, 533);
            p1_ip_o.Name = "p1_ip_o";
            p1_ip_o.Size = new System.Drawing.Size(53, 27);
            p1_ip_o.TabIndex = 67;
            p1_ip_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_ip_i
            // 
            p1_ip_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_ip_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_ip_i.Location = new System.Drawing.Point(108, 533);
            p1_ip_i.Name = "p1_ip_i";
            p1_ip_i.Size = new System.Drawing.Size(53, 27);
            p1_ip_i.TabIndex = 68;
            p1_ip_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_EthernetII_o
            // 
            p1_EthernetII_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_EthernetII_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_EthernetII_o.Location = new System.Drawing.Point(158, 506);
            p1_EthernetII_o.Name = "p1_EthernetII_o";
            p1_EthernetII_o.Size = new System.Drawing.Size(53, 27);
            p1_EthernetII_o.TabIndex = 69;
            p1_EthernetII_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_http_o
            // 
            p1_http_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_http_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_http_o.Location = new System.Drawing.Point(158, 614);
            p1_http_o.Name = "p1_http_o";
            p1_http_o.Size = new System.Drawing.Size(53, 27);
            p1_http_o.TabIndex = 70;
            p1_http_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_http_i
            // 
            p1_http_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_http_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_http_i.Location = new System.Drawing.Point(108, 614);
            p1_http_i.Name = "p1_http_i";
            p1_http_i.Size = new System.Drawing.Size(53, 27);
            p1_http_i.TabIndex = 71;
            p1_http_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_arp_o
            // 
            p1_arp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_arp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_arp_o.Location = new System.Drawing.Point(158, 587);
            p1_arp_o.Name = "p1_arp_o";
            p1_arp_o.Size = new System.Drawing.Size(53, 27);
            p1_arp_o.TabIndex = 72;
            p1_arp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_arp_i
            // 
            p1_arp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p1_arp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p1_arp_i.Location = new System.Drawing.Point(108, 587);
            p1_arp_i.Name = "p1_arp_i";
            p1_arp_i.Size = new System.Drawing.Size(53, 27);
            p1_arp_i.TabIndex = 73;
            p1_arp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            label26.BackColor = System.Drawing.SystemColors.ScrollBar;
            label26.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label26.Location = new System.Drawing.Point(870, 506);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(108, 27);
            label26.TabIndex = 74;
            label26.Text = "Ethernet II";
            label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            label27.BackColor = System.Drawing.SystemColors.ScrollBar;
            label27.Font = new System.Drawing.Font("Tahoma", 10F);
            label27.Location = new System.Drawing.Point(870, 479);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(53, 27);
            label27.TabIndex = 75;
            label27.Text = "UDP";
            label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            label28.BackColor = System.Drawing.SystemColors.ScrollBar;
            label28.Font = new System.Drawing.Font("Tahoma", 10F);
            label28.Location = new System.Drawing.Point(870, 452);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(53, 27);
            label28.TabIndex = 76;
            label28.Text = "TCP";
            label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            label29.BackColor = System.Drawing.SystemColors.ScrollBar;
            label29.Font = new System.Drawing.Font("Tahoma", 10F);
            label29.Location = new System.Drawing.Point(870, 533);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(53, 27);
            label29.TabIndex = 77;
            label29.Text = "IP";
            label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            label30.BackColor = System.Drawing.SystemColors.ScrollBar;
            label30.Font = new System.Drawing.Font("Tahoma", 10F);
            label30.Location = new System.Drawing.Point(870, 560);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(62, 27);
            label30.TabIndex = 78;
            label30.Text = "ICMP";
            label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            label31.BackColor = System.Drawing.SystemColors.ScrollBar;
            label31.Font = new System.Drawing.Font("Tahoma", 10F);
            label31.Location = new System.Drawing.Point(870, 587);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(53, 27);
            label31.TabIndex = 79;
            label31.Text = "ARP";
            label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            label32.BackColor = System.Drawing.SystemColors.ScrollBar;
            label32.Font = new System.Drawing.Font("Tahoma", 10F);
            label32.Location = new System.Drawing.Point(870, 614);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(62, 27);
            label32.TabIndex = 80;
            label32.Text = "HTTP";
            label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_ip_o
            // 
            p2_ip_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_ip_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_ip_o.Location = new System.Drawing.Point(763, 533);
            p2_ip_o.Name = "p2_ip_o";
            p2_ip_o.Size = new System.Drawing.Size(53, 27);
            p2_ip_o.TabIndex = 81;
            p2_ip_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_ip_i
            // 
            p2_ip_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_ip_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_ip_i.Location = new System.Drawing.Point(811, 533);
            p2_ip_i.Name = "p2_ip_i";
            p2_ip_i.Size = new System.Drawing.Size(53, 27);
            p2_ip_i.TabIndex = 82;
            p2_ip_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_EthernetII_o
            // 
            p2_EthernetII_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_EthernetII_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_EthernetII_o.Location = new System.Drawing.Point(763, 506);
            p2_EthernetII_o.Name = "p2_EthernetII_o";
            p2_EthernetII_o.Size = new System.Drawing.Size(53, 27);
            p2_EthernetII_o.TabIndex = 83;
            p2_EthernetII_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_EthernetII_i
            // 
            p2_EthernetII_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_EthernetII_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_EthernetII_i.Location = new System.Drawing.Point(811, 506);
            p2_EthernetII_i.Name = "p2_EthernetII_i";
            p2_EthernetII_i.Size = new System.Drawing.Size(53, 27);
            p2_EthernetII_i.TabIndex = 84;
            p2_EthernetII_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_udp_i
            // 
            p2_udp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_udp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_udp_i.Location = new System.Drawing.Point(811, 479);
            p2_udp_i.Name = "p2_udp_i";
            p2_udp_i.Size = new System.Drawing.Size(53, 27);
            p2_udp_i.TabIndex = 85;
            p2_udp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_udp_o
            // 
            p2_udp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_udp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_udp_o.Location = new System.Drawing.Point(763, 479);
            p2_udp_o.Name = "p2_udp_o";
            p2_udp_o.Size = new System.Drawing.Size(53, 27);
            p2_udp_o.TabIndex = 86;
            p2_udp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_tcp_o
            // 
            p2_tcp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_tcp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_tcp_o.Location = new System.Drawing.Point(763, 452);
            p2_tcp_o.Name = "p2_tcp_o";
            p2_tcp_o.Size = new System.Drawing.Size(53, 27);
            p2_tcp_o.TabIndex = 87;
            p2_tcp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_tcp_i
            // 
            p2_tcp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_tcp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_tcp_i.Location = new System.Drawing.Point(811, 452);
            p2_tcp_i.Name = "p2_tcp_i";
            p2_tcp_i.Size = new System.Drawing.Size(53, 27);
            p2_tcp_i.TabIndex = 88;
            p2_tcp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_http_i
            // 
            p2_http_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_http_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_http_i.Location = new System.Drawing.Point(811, 614);
            p2_http_i.Name = "p2_http_i";
            p2_http_i.Size = new System.Drawing.Size(53, 27);
            p2_http_i.TabIndex = 89;
            p2_http_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_arp_o
            // 
            p2_arp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_arp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_arp_o.Location = new System.Drawing.Point(763, 587);
            p2_arp_o.Name = "p2_arp_o";
            p2_arp_o.Size = new System.Drawing.Size(53, 27);
            p2_arp_o.TabIndex = 90;
            p2_arp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_arp_i
            // 
            p2_arp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_arp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_arp_i.Location = new System.Drawing.Point(811, 587);
            p2_arp_i.Name = "p2_arp_i";
            p2_arp_i.Size = new System.Drawing.Size(53, 27);
            p2_arp_i.TabIndex = 91;
            p2_arp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_icmp_o
            // 
            p2_icmp_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_icmp_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_icmp_o.Location = new System.Drawing.Point(763, 560);
            p2_icmp_o.Name = "p2_icmp_o";
            p2_icmp_o.Size = new System.Drawing.Size(53, 27);
            p2_icmp_o.TabIndex = 92;
            p2_icmp_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_icmp_i
            // 
            p2_icmp_i.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_icmp_i.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_icmp_i.Location = new System.Drawing.Point(811, 560);
            p2_icmp_i.Name = "p2_icmp_i";
            p2_icmp_i.Size = new System.Drawing.Size(53, 27);
            p2_icmp_i.TabIndex = 93;
            p2_icmp_i.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p2_http_o
            // 
            p2_http_o.BackColor = System.Drawing.SystemColors.HighlightText;
            p2_http_o.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            p2_http_o.Location = new System.Drawing.Point(763, 614);
            p2_http_o.Name = "p2_http_o";
            p2_http_o.Size = new System.Drawing.Size(53, 27);
            p2_http_o.TabIndex = 94;
            p2_http_o.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            label47.BackColor = System.Drawing.SystemColors.ScrollBar;
            label47.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label47.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label47.Location = new System.Drawing.Point(772, 424);
            label47.Name = "label47";
            label47.Size = new System.Drawing.Size(33, 28);
            label47.TabIndex = 95;
            label47.Text = "O";
            label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            label48.BackColor = System.Drawing.SystemColors.ScrollBar;
            label48.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)238));
            label48.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label48.Location = new System.Drawing.Point(822, 424);
            label48.Name = "label48";
            label48.Size = new System.Drawing.Size(26, 28);
            label48.TabIndex = 96;
            label48.Text = "I";
            label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvAclTable
            // 
            lvAclTable.FullRowSelect = true;
            lvAclTable.Location = new System.Drawing.Point(108, 44);
            lvAclTable.Name = "lvAclTable";
            lvAclTable.Size = new System.Drawing.Size(800, 160);
            lvAclTable.TabIndex = 97;
            lvAclTable.Columns.AddRange(new[] {
                new ColumnHeader() { Text = "№",     Width = 40  },
                new ColumnHeader() { Text = "In/Out",Width = 60  },
                new ColumnHeader() { Text = "Action",Width = 60  },
                new ColumnHeader() { Text = "Port",  Width = 30  },
                new ColumnHeader() { Text = "S MAC", Width = 120 },
                new ColumnHeader() { Text = "D MAC", Width = 120 },
                new ColumnHeader() { Text = "S IP",  Width = 100 },
                new ColumnHeader() { Text = "D IP",  Width = 100 },
                new ColumnHeader() { Text = "S PORT",  Width = 60 },
                new ColumnHeader() { Text = "D PORT",  Width = 60 },
                new ColumnHeader() { Text = "Type",  Width = 60 },
            });
            lvAclTable.UseCompatibleStateImageBehavior = false;
            lvAclTable.View = System.Windows.Forms.View.Details;
            // 
            // btnAddAcl
            // 
            btnAddAcl.Location = new System.Drawing.Point(298, 224);
            btnAddAcl.Name = "btnAddAcl";
            btnAddAcl.Size = new System.Drawing.Size(80, 30);
            btnAddAcl.TabIndex = 98;
            btnAddAcl.Text = "Add";
            btnAddAcl.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAcl
            // 
            btnDeleteAcl.Location = new System.Drawing.Point(392, 224);
            btnDeleteAcl.Name = "btnDeleteAcl";
            btnDeleteAcl.Size = new System.Drawing.Size(80, 30);
            btnDeleteAcl.TabIndex = 99;
            btnDeleteAcl.Text = "Delete";
            btnDeleteAcl.UseVisualStyleBackColor = true;
            // 
            // btnClearAllAcl
            // 
            btnClearAllAcl.Location = new System.Drawing.Point(501, 224);
            btnClearAllAcl.Name = "btnClearAllAcl";
            btnClearAllAcl.Size = new System.Drawing.Size(80, 30);
            btnClearAllAcl.TabIndex = 100;
            btnClearAllAcl.Text = "Clear All";
            btnClearAllAcl.UseVisualStyleBackColor = true;
            // 
            // SwitchForm
            // 
            BackColor = System.Drawing.SystemColors.ScrollBar;
            ClientSize = new System.Drawing.Size(978, 744);
            Controls.Add(label48);
            Controls.Add(label47);
            Controls.Add(p2_http_o);
            Controls.Add(p2_icmp_i);
            Controls.Add(p2_icmp_o);
            Controls.Add(p2_arp_i);
            Controls.Add(p2_arp_o);
            Controls.Add(p2_http_i);
            Controls.Add(p2_tcp_i);
            Controls.Add(p2_tcp_o);
            Controls.Add(p2_udp_o);
            Controls.Add(p2_udp_i);
            Controls.Add(p2_EthernetII_i);
            Controls.Add(p2_EthernetII_o);
            Controls.Add(p2_ip_i);
            Controls.Add(p2_ip_o);
            Controls.Add(label32);
            Controls.Add(label31);
            Controls.Add(label30);
            Controls.Add(label29);
            Controls.Add(label28);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(p1_arp_i);
            Controls.Add(p1_arp_o);
            Controls.Add(p1_http_i);
            Controls.Add(p1_http_o);
            Controls.Add(p1_EthernetII_o);
            Controls.Add(p1_ip_i);
            Controls.Add(p1_ip_o);
            Controls.Add(p1_icmp_i);
            Controls.Add(p1_icmp_o);
            Controls.Add(p1_udp_i);
            Controls.Add(p1_udp_o);
            Controls.Add(p1_EthernetII_i);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(p1_tcp_o);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(p1_tcp_i);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbInterface2);
            Controls.Add(btnReset);
            Controls.Add(cmbInterface1);
            Controls.Add(btnStart);
            Controls.Add(txtStats);
            Controls.Add(lvMacTable);
            Controls.Add(btnClearMac);
            Controls.Add(nudTimeout);
            Controls.Add(lvAclTable);
            Controls.Add(btnAddAcl);
            Controls.Add(btnDeleteAcl);
            Controls.Add(btnClearAllAcl);
            Text = "Switch Statistics";
            Load += SwitchForm_Load;
            ((System.ComponentModel.ISupportInitialize)nudTimeout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        
private System.Windows.Forms.Label label47;
private System.Windows.Forms.Label label48;

private System.Windows.Forms.Label label26;
private System.Windows.Forms.Label label27;
private System.Windows.Forms.Label label28;
private System.Windows.Forms.Label label29;
private System.Windows.Forms.Label label30;
private System.Windows.Forms.Label label31;
private System.Windows.Forms.Label label32;
private System.Windows.Forms.Label p2_ip_o;
private System.Windows.Forms.Label p2_ip_i;
private System.Windows.Forms.Label p2_EthernetII_o;
private System.Windows.Forms.Label p2_EthernetII_i;
private System.Windows.Forms.Label p2_udp_i;
private System.Windows.Forms.Label p2_udp_o;
private System.Windows.Forms.Label p2_tcp_o;
private System.Windows.Forms.Label p2_tcp_i;
private System.Windows.Forms.Label p2_http_i;
private System.Windows.Forms.Label p2_arp_o;
private System.Windows.Forms.Label p2_arp_i;
private System.Windows.Forms.Label p2_icmp_o;
private System.Windows.Forms.Label p2_icmp_i;
private System.Windows.Forms.Label p2_http_o;

private System.Windows.Forms.Label p1_icmp_o;
private System.Windows.Forms.Label p1_icmp_i;
private System.Windows.Forms.Label p1_ip_o;
private System.Windows.Forms.Label p1_ip_i;
private System.Windows.Forms.Label p1_EthernetII_o;
private System.Windows.Forms.Label p1_http_o;
private System.Windows.Forms.Label p1_http_i;
private System.Windows.Forms.Label p1_arp_o;
private System.Windows.Forms.Label p1_arp_i;

private System.Windows.Forms.Label label7;
private System.Windows.Forms.Label label8;
private System.Windows.Forms.Label p1_EthernetII_i;
private System.Windows.Forms.Label p1_udp_o;

private System.Windows.Forms.Label p1_tcp_o;
private System.Windows.Forms.Label p1_tcp_i;
private System.Windows.Forms.Label label12;

private System.Windows.Forms.Label label11;

private System.Windows.Forms.Label label10;
private System.Windows.Forms.Label p1_udp_i;

private System.Windows.Forms.Label label9;

private System.Windows.Forms.Label label4;
private System.Windows.Forms.Label label5;
private System.Windows.Forms.Label label6;

private System.Windows.Forms.Label label3;

private System.Windows.Forms.Label label2;

private System.Windows.Forms.Label label1;
private System.Windows.Forms.ListView lvAclTable;
private System.Windows.Forms.Button btnAddAcl;
private System.Windows.Forms.Button btnDeleteAcl;
private System.Windows.Forms.Button btnClearAllAcl;
    }
}