namespace Regression.Presentation
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.initilizationButton = new System.Windows.Forms.Button();
            this.performButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.loadDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(13, 13);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(346, 207);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // initilizationButton
            // 
            this.initilizationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.initilizationButton.Location = new System.Drawing.Point(13, 226);
            this.initilizationButton.Name = "initilizationButton";
            this.initilizationButton.Size = new System.Drawing.Size(75, 23);
            this.initilizationButton.TabIndex = 1;
            this.initilizationButton.Text = "Initialize";
            this.initilizationButton.UseVisualStyleBackColor = true;
            this.initilizationButton.Click += new System.EventHandler(this.initilizationButton_Click);
            // 
            // performButton
            // 
            this.performButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.performButton.Location = new System.Drawing.Point(175, 226);
            this.performButton.Name = "performButton";
            this.performButton.Size = new System.Drawing.Size(75, 23);
            this.performButton.TabIndex = 2;
            this.performButton.Text = "Perform";
            this.performButton.UseVisualStyleBackColor = true;
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(256, 231);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(41, 13);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "Ready!";
            // 
            // loadDataButton
            // 
            this.loadDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadDataButton.Location = new System.Drawing.Point(94, 226);
            this.loadDataButton.Name = "loadDataButton";
            this.loadDataButton.Size = new System.Drawing.Size(75, 23);
            this.loadDataButton.TabIndex = 4;
            this.loadDataButton.Text = "Load data";
            this.loadDataButton.UseVisualStyleBackColor = true;
            this.loadDataButton.Click += new System.EventHandler(this.loadDataButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 261);
            this.Controls.Add(this.loadDataButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.performButton);
            this.Controls.Add(this.initilizationButton);
            this.Controls.Add(this.canvas);
            this.MinimumSize = new System.Drawing.Size(387, 300);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button initilizationButton;
        private System.Windows.Forms.Button performButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button loadDataButton;
    }
}

