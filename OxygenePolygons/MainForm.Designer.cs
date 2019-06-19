namespace OxygenePolygons
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
            this.butStepBack = new System.Windows.Forms.Button();
            this.butPlay = new System.Windows.Forms.Button();
            this.butStepForward = new System.Windows.Forms.Button();
            this.labelFrameNumber = new System.Windows.Forms.Label();
            this.numericUpDownFramesPerSecond = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFramesPerSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // butStepBack
            // 
            this.butStepBack.Location = new System.Drawing.Point(0, 0);
            this.butStepBack.Name = "butStepBack";
            this.butStepBack.Size = new System.Drawing.Size(75, 23);
            this.butStepBack.TabIndex = 0;
            this.butStepBack.Text = "<";
            this.butStepBack.UseVisualStyleBackColor = true;
            this.butStepBack.Click += new System.EventHandler(this.ButStepBack_Click);
            // 
            // butPlay
            // 
            this.butPlay.Location = new System.Drawing.Point(81, 0);
            this.butPlay.Name = "butPlay";
            this.butPlay.Size = new System.Drawing.Size(75, 23);
            this.butPlay.TabIndex = 1;
            this.butPlay.Text = "||";
            this.butPlay.UseVisualStyleBackColor = true;
            this.butPlay.Click += new System.EventHandler(this.ButPlay_Click);
            // 
            // butStepForward
            // 
            this.butStepForward.Location = new System.Drawing.Point(162, 0);
            this.butStepForward.Name = "butStepForward";
            this.butStepForward.Size = new System.Drawing.Size(75, 23);
            this.butStepForward.TabIndex = 2;
            this.butStepForward.Text = ">";
            this.butStepForward.UseVisualStyleBackColor = true;
            this.butStepForward.Click += new System.EventHandler(this.ButStepForward_Click);
            // 
            // labelFrameNumber
            // 
            this.labelFrameNumber.AutoSize = true;
            this.labelFrameNumber.Location = new System.Drawing.Point(327, 5);
            this.labelFrameNumber.Name = "labelFrameNumber";
            this.labelFrameNumber.Size = new System.Drawing.Size(35, 13);
            this.labelFrameNumber.TabIndex = 3;
            this.labelFrameNumber.Text = "label1";
            // 
            // numericUpDownFramesPerSecond
            // 
            this.numericUpDownFramesPerSecond.Location = new System.Drawing.Point(244, 2);
            this.numericUpDownFramesPerSecond.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFramesPerSecond.Name = "numericUpDownFramesPerSecond";
            this.numericUpDownFramesPerSecond.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownFramesPerSecond.TabIndex = 4;
            this.numericUpDownFramesPerSecond.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(7, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 600);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 638);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDownFramesPerSecond);
            this.Controls.Add(this.labelFrameNumber);
            this.Controls.Add(this.butStepForward);
            this.Controls.Add(this.butPlay);
            this.Controls.Add(this.butStepBack);
            this.Name = "MainForm";
            this.Text = "STNICCC 2000  By Oxygene .Net version By Michael South";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFramesPerSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butStepBack;
        private System.Windows.Forms.Button butPlay;
        private System.Windows.Forms.Button butStepForward;
        private System.Windows.Forms.Label labelFrameNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownFramesPerSecond;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer;
    }
}

