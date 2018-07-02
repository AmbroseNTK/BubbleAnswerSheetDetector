namespace BubbleAnswerSheetDetector
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
            this.components = new System.ComponentModel.Container();
            this.btLoad = new System.Windows.Forms.Button();
            this.imageResult = new Emgu.CV.UI.ImageBox();
            this.btStep1 = new System.Windows.Forms.Button();
            this.btStep2 = new System.Windows.Forms.Button();
            this.btStep3 = new System.Windows.Forms.Button();
            this.btStep4 = new System.Windows.Forms.Button();
            this.btStep5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(1023, 12);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 0;
            this.btLoad.Text = "Load Image";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // imageResult
            // 
            this.imageResult.Location = new System.Drawing.Point(12, 12);
            this.imageResult.Name = "imageResult";
            this.imageResult.Size = new System.Drawing.Size(1005, 557);
            this.imageResult.TabIndex = 2;
            this.imageResult.TabStop = false;
            // 
            // btStep1
            // 
            this.btStep1.Location = new System.Drawing.Point(1023, 41);
            this.btStep1.Name = "btStep1";
            this.btStep1.Size = new System.Drawing.Size(75, 23);
            this.btStep1.TabIndex = 3;
            this.btStep1.Text = "Step 1";
            this.btStep1.UseVisualStyleBackColor = true;
            this.btStep1.Click += new System.EventHandler(this.btStep1_Click);
            // 
            // btStep2
            // 
            this.btStep2.Location = new System.Drawing.Point(1023, 70);
            this.btStep2.Name = "btStep2";
            this.btStep2.Size = new System.Drawing.Size(75, 23);
            this.btStep2.TabIndex = 4;
            this.btStep2.Text = "Step 2";
            this.btStep2.UseVisualStyleBackColor = true;
            this.btStep2.Click += new System.EventHandler(this.btStep2_Click);
            // 
            // btStep3
            // 
            this.btStep3.Location = new System.Drawing.Point(1023, 99);
            this.btStep3.Name = "btStep3";
            this.btStep3.Size = new System.Drawing.Size(75, 23);
            this.btStep3.TabIndex = 5;
            this.btStep3.Text = "Step 3";
            this.btStep3.UseVisualStyleBackColor = true;
            this.btStep3.Click += new System.EventHandler(this.btStep3_Click);
            // 
            // btStep4
            // 
            this.btStep4.Location = new System.Drawing.Point(1023, 128);
            this.btStep4.Name = "btStep4";
            this.btStep4.Size = new System.Drawing.Size(75, 23);
            this.btStep4.TabIndex = 6;
            this.btStep4.Text = "Step 4";
            this.btStep4.UseVisualStyleBackColor = true;
            this.btStep4.Click += new System.EventHandler(this.btStep4_Click);
            // 
            // btStep5
            // 
            this.btStep5.Location = new System.Drawing.Point(1023, 157);
            this.btStep5.Name = "btStep5";
            this.btStep5.Size = new System.Drawing.Size(75, 23);
            this.btStep5.TabIndex = 7;
            this.btStep5.Text = "Step 5";
            this.btStep5.UseVisualStyleBackColor = true;
            this.btStep5.Click += new System.EventHandler(this.btStep5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 581);
            this.Controls.Add(this.btStep5);
            this.Controls.Add(this.btStep4);
            this.Controls.Add(this.btStep3);
            this.Controls.Add(this.btStep2);
            this.Controls.Add(this.btStep1);
            this.Controls.Add(this.imageResult);
            this.Controls.Add(this.btLoad);
            this.Name = "Form1";
            this.Text = "Bubble Answer Sheet Dectector";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btLoad;
        private Emgu.CV.UI.ImageBox imageResult;
        private System.Windows.Forms.Button btStep1;
        private System.Windows.Forms.Button btStep2;
        private System.Windows.Forms.Button btStep3;
        private System.Windows.Forms.Button btStep4;
        private System.Windows.Forms.Button btStep5;
    }
}

