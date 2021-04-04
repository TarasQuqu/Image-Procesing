namespace APO_TarasKuts16555
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiometricCorrectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discortionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBrightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBrightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToGrayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNFOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.convertToGrayscaleToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.cUTToolStripMenuItem,
            this.zoomOUTToolStripMenuItem,
            this.zoomINToolStripMenuItem,
            this.iNFOToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openFileToolStripMenuItem.Text = "Open file";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radiometricCorrectionToolStripMenuItem,
            this.discortionToolStripMenuItem,
            this.loadBrightToolStripMenuItem,
            this.loadDarkToolStripMenuItem,
            this.createDarkToolStripMenuItem,
            this.createBrightToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // radiometricCorrectionToolStripMenuItem
            // 
            this.radiometricCorrectionToolStripMenuItem.Name = "radiometricCorrectionToolStripMenuItem";
            this.radiometricCorrectionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.radiometricCorrectionToolStripMenuItem.Text = "Radiometric correction";
            this.radiometricCorrectionToolStripMenuItem.Click += new System.EventHandler(this.radiometricCorrectionToolStripMenuItem_Click);
            // 
            // discortionToolStripMenuItem
            // 
            this.discortionToolStripMenuItem.Name = "discortionToolStripMenuItem";
            this.discortionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.discortionToolStripMenuItem.Text = "Discortion";
            this.discortionToolStripMenuItem.Click += new System.EventHandler(this.discortionToolStripMenuItem_Click);
            // 
            // loadBrightToolStripMenuItem
            // 
            this.loadBrightToolStripMenuItem.Name = "loadBrightToolStripMenuItem";
            this.loadBrightToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.loadBrightToolStripMenuItem.Text = "Load bright image";
            this.loadBrightToolStripMenuItem.Click += new System.EventHandler(this.loadBrightToolStripMenuItem_Click);
            // 
            // loadDarkToolStripMenuItem
            // 
            this.loadDarkToolStripMenuItem.Name = "loadDarkToolStripMenuItem";
            this.loadDarkToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.loadDarkToolStripMenuItem.Text = "Load dark image";
            this.loadDarkToolStripMenuItem.Click += new System.EventHandler(this.loadDarkToolStripMenuItem_Click);
            // 
            // createDarkToolStripMenuItem
            // 
            this.createDarkToolStripMenuItem.Name = "createDarkToolStripMenuItem";
            this.createDarkToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createDarkToolStripMenuItem.Text = "Create dark image";
            this.createDarkToolStripMenuItem.Click += new System.EventHandler(this.createDarkToolStripMenuItem_Click);
            // 
            // createBrightToolStripMenuItem
            // 
            this.createBrightToolStripMenuItem.Name = "createBrightToolStripMenuItem";
            this.createBrightToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createBrightToolStripMenuItem.Text = "Create bright image";
            this.createBrightToolStripMenuItem.Click += new System.EventHandler(this.createBrightToolStripMenuItem_Click);
            // 
            // convertToGrayscaleToolStripMenuItem
            // 
            this.convertToGrayscaleToolStripMenuItem.Name = "convertToGrayscaleToolStripMenuItem";
            this.convertToGrayscaleToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.convertToGrayscaleToolStripMenuItem.Text = "Convert to grayscale";
            this.convertToGrayscaleToolStripMenuItem.Click += new System.EventHandler(this.convertToGrayscaleToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click_1);
            // 
            // cUTToolStripMenuItem
            // 
            this.cUTToolStripMenuItem.Name = "cUTToolStripMenuItem";
            this.cUTToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cUTToolStripMenuItem.Text = "CUT";
            this.cUTToolStripMenuItem.Click += new System.EventHandler(this.cUTToolStripMenuItem_Click);
            // 
            // zoomOUTToolStripMenuItem
            // 
            this.zoomOUTToolStripMenuItem.Name = "zoomOUTToolStripMenuItem";
            this.zoomOUTToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.zoomOUTToolStripMenuItem.Text = "ZoomOUT";
            this.zoomOUTToolStripMenuItem.Click += new System.EventHandler(this.zoomOUTToolStripMenuItem_Click);
            // 
            // zoomINToolStripMenuItem
            // 
            this.zoomINToolStripMenuItem.Name = "zoomINToolStripMenuItem";
            this.zoomINToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.zoomINToolStripMenuItem.Text = "ZoomIN";
            this.zoomINToolStripMenuItem.Click += new System.EventHandler(this.zoomINToolStripMenuItem_Click);
            // 
            // iNFOToolStripMenuItem
            // 
            this.iNFOToolStripMenuItem.Name = "iNFOToolStripMenuItem";
            this.iNFOToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.iNFOToolStripMenuItem.Text = "INFO";
            this.iNFOToolStripMenuItem.Click += new System.EventHandler(this.iNFOToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "APO";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiometricCorrectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discortionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBrightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBrightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNFOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToGrayscaleToolStripMenuItem;
    }
}



