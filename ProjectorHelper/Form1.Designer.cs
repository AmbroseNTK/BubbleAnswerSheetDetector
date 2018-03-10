namespace ProjectorHelper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbLoad = new System.Windows.Forms.ToolStripButton();
            this.canvas1 = new ProjectorHelper.Canvas();
            this.btZoomIn = new System.Windows.Forms.ToolStripButton();
            this.btZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbLoad,
            this.btZoomIn,
            this.btZoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(611, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbLoad
            // 
            this.tbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tbLoad.Image")));
            this.tbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLoad.Name = "tbLoad";
            this.tbLoad.Size = new System.Drawing.Size(56, 22);
            this.tbLoad.Text = "Load file";
            this.tbLoad.ToolTipText = "Load File";
            this.tbLoad.Click += new System.EventHandler(this.tbLoad_Click);
            // 
            // canvas1
            // 
            this.canvas1.AutoScroll = true;
            this.canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas1.Location = new System.Drawing.Point(0, 25);
            this.canvas1.Name = "canvas1";
            this.canvas1.Points = null;
            this.canvas1.Size = new System.Drawing.Size(611, 425);
            this.canvas1.TabIndex = 1;
            // 
            // btZoomIn
            // 
            this.btZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btZoomIn.Image")));
            this.btZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btZoomIn.Name = "btZoomIn";
            this.btZoomIn.Size = new System.Drawing.Size(56, 22);
            this.btZoomIn.Text = "Zoom In";
            this.btZoomIn.Click += new System.EventHandler(this.btZoomIn_Click);
            // 
            // btZoomOut
            // 
            this.btZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btZoomOut.Image")));
            this.btZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btZoomOut.Name = "btZoomOut";
            this.btZoomOut.Size = new System.Drawing.Size(66, 22);
            this.btZoomOut.Text = "Zoom Out";
            this.btZoomOut.Click += new System.EventHandler(this.btZoomOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 450);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Projector Helper";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbLoad;
        private Canvas canvas1;
        private System.Windows.Forms.ToolStripButton btZoomIn;
        private System.Windows.Forms.ToolStripButton btZoomOut;
    }
}

