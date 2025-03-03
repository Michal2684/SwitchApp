namespace SwitchApp
{
    partial class SwitchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtStats;
        private System.Windows.Forms.Button btnReset;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtStats = new System.Windows.Forms.TextBox();
            btnReset = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // txtStats
            // 
            txtStats.Dock = System.Windows.Forms.DockStyle.Fill;
            txtStats.Location = new System.Drawing.Point(0, 0);
            txtStats.Multiline = true;
            txtStats.Name = "txtStats";
            txtStats.ReadOnly = true;
            txtStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtStats.Size = new System.Drawing.Size(1130, 982);
            txtStats.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnReset.Location = new System.Drawing.Point(0, 982);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(1130, 23);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset Stats";
            // 
            // SwitchForm
            // 
            ClientSize = new System.Drawing.Size(1130, 1005);
            Controls.Add(txtStats);
            Controls.Add(btnReset);
            Text = "Switch Statistics";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}