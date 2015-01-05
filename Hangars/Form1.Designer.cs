namespace Hangars
{
    partial class Form1
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hangarPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hangarSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aircraftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hangarBuildingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hangarBuildingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hangarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(410, 305);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(410, 329);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.billingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(410, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hangarBuildingToolStripMenuItem,
            this.hangarsToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "New";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem1,
            this.hangarPriceToolStripMenuItem,
            this.hangarSlotsToolStripMenuItem,
            this.aircraftToolStripMenuItem,
            this.invoiceToolStripMenuItem1,
            this.hangarBuildingToolStripMenuItem1});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // customerToolStripMenuItem1
            // 
            this.customerToolStripMenuItem1.Name = "customerToolStripMenuItem1";
            this.customerToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.customerToolStripMenuItem1.Text = "Customer";
            this.customerToolStripMenuItem1.Click += new System.EventHandler(this.customerToolStripMenuItem1_Click);
            // 
            // hangarPriceToolStripMenuItem
            // 
            this.hangarPriceToolStripMenuItem.Name = "hangarPriceToolStripMenuItem";
            this.hangarPriceToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hangarPriceToolStripMenuItem.Text = "Hangar Price";
            // 
            // hangarSlotsToolStripMenuItem
            // 
            this.hangarSlotsToolStripMenuItem.Name = "hangarSlotsToolStripMenuItem";
            this.hangarSlotsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hangarSlotsToolStripMenuItem.Text = "Hangar Slots";
            this.hangarSlotsToolStripMenuItem.Click += new System.EventHandler(this.hangarSlotsToolStripMenuItem_Click);
            // 
            // aircraftToolStripMenuItem
            // 
            this.aircraftToolStripMenuItem.Name = "aircraftToolStripMenuItem";
            this.aircraftToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.aircraftToolStripMenuItem.Text = "Aircraft";
            this.aircraftToolStripMenuItem.Click += new System.EventHandler(this.aircraftToolStripMenuItem_Click);
            // 
            // invoiceToolStripMenuItem1
            // 
            this.invoiceToolStripMenuItem1.Name = "invoiceToolStripMenuItem1";
            this.invoiceToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.invoiceToolStripMenuItem1.Text = "Invoice";
            this.invoiceToolStripMenuItem1.Click += new System.EventHandler(this.invoiceToolStripMenuItem1_Click);
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoiceToolStripMenuItem,
            this.monthlyBillToolStripMenuItem});
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.billingToolStripMenuItem.Text = "Billing";
            // 
            // monthlyBillToolStripMenuItem
            // 
            this.monthlyBillToolStripMenuItem.Name = "monthlyBillToolStripMenuItem";
            this.monthlyBillToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.monthlyBillToolStripMenuItem.Text = "Monthly Bill";
            this.monthlyBillToolStripMenuItem.Click += new System.EventHandler(this.monthlyBillToolStripMenuItem_Click);
            // 
            // hangarBuildingToolStripMenuItem1
            // 
            this.hangarBuildingToolStripMenuItem1.Name = "hangarBuildingToolStripMenuItem1";
            this.hangarBuildingToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.hangarBuildingToolStripMenuItem1.Text = "Hangar Building";
            this.hangarBuildingToolStripMenuItem1.Click += new System.EventHandler(this.hangarBuildingToolStripMenuItem1_Click);
            // 
            // hangarBuildingToolStripMenuItem
            // 
            this.hangarBuildingToolStripMenuItem.Name = "hangarBuildingToolStripMenuItem";
            this.hangarBuildingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hangarBuildingToolStripMenuItem.Text = "Hangar Building";
            // 
            // hangarsToolStripMenuItem
            // 
            this.hangarsToolStripMenuItem.Name = "hangarsToolStripMenuItem";
            this.hangarsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hangarsToolStripMenuItem.Text = "Hangars";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.invoiceToolStripMenuItem.Text = "New Invoice";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 329);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Total HangerStuff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hangarPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hangarSlotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aircraftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hangarBuildingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hangarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hangarBuildingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
    }
}

