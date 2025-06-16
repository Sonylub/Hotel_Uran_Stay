using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class AvailableRoomsForm
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(46, 46, 50); // #2E2E32
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(535, 600);
            this.flowLayoutPanel.Visible = true; // Убедимся, что панель видима
            // 
            // AvailableRoomsForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(46, 46, 50); // #2E2E32
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "AvailableRoomsForm";
            this.Size = new System.Drawing.Size(535, 600);
            this.Visible = true; // Убедимся, что форма видима
            this.ResumeLayout(false);
        }
    }
}