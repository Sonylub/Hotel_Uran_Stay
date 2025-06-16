namespace WindowsFormsApp1
{
    partial class AvailableRooms
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRooms;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanelRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelRooms
            // 
            this.flowLayoutPanelRooms.AutoScroll = true;
            this.flowLayoutPanelRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelRooms.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelRooms.WrapContents = false;
            this.flowLayoutPanelRooms.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
            this.flowLayoutPanelRooms.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelRooms.Name = "flowLayoutPanelRooms";
            this.flowLayoutPanelRooms.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelRooms.Size = new System.Drawing.Size(535, 600);
            this.flowLayoutPanelRooms.TabIndex = 0;
            // 
            // AvailableRooms
            // 
            this.BackColor = System.Drawing.Color.FromArgb(46, 46, 50);
            this.Controls.Add(this.flowLayoutPanelRooms);
            this.Name = "AvailableRooms";
            this.Size = new System.Drawing.Size(535, 600);
            this.ResumeLayout(false);
        }
    }
}
