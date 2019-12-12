namespace AsyncClientTest
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
            this.Tbx_Read = new System.Windows.Forms.TextBox();
            this.Tbx_Type = new System.Windows.Forms.TextBox();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_Listen = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Tbx_Read
            // 
            this.Tbx_Read.Location = new System.Drawing.Point(12, 12);
            this.Tbx_Read.Multiline = true;
            this.Tbx_Read.Name = "Tbx_Read";
            this.Tbx_Read.ReadOnly = true;
            this.Tbx_Read.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tbx_Read.Size = new System.Drawing.Size(276, 193);
            this.Tbx_Read.TabIndex = 1;
            // 
            // Tbx_Type
            // 
            this.Tbx_Type.Location = new System.Drawing.Point(12, 211);
            this.Tbx_Type.Multiline = true;
            this.Tbx_Type.Name = "Tbx_Type";
            this.Tbx_Type.Size = new System.Drawing.Size(276, 57);
            this.Tbx_Type.TabIndex = 2;
            // 
            // Btn_Send
            // 
            this.Btn_Send.Location = new System.Drawing.Point(12, 274);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(75, 23);
            this.Btn_Send.TabIndex = 3;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = true;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // Btn_Close
            // 
            this.Btn_Close.Location = new System.Drawing.Point(213, 274);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(75, 23);
            this.Btn_Close.TabIndex = 5;
            this.Btn_Close.Text = "Close";
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Btn_Listen
            // 
            this.Btn_Listen.Location = new System.Drawing.Point(110, 274);
            this.Btn_Listen.Name = "Btn_Listen";
            this.Btn_Listen.Size = new System.Drawing.Size(75, 23);
            this.Btn_Listen.TabIndex = 6;
            this.Btn_Listen.Text = "Listen";
            this.Btn_Listen.UseVisualStyleBackColor = true;
            this.Btn_Listen.Click += new System.EventHandler(this.Btn_Listen_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 320);
            this.Controls.Add(this.Btn_Listen);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.Btn_Send);
            this.Controls.Add(this.Tbx_Type);
            this.Controls.Add(this.Tbx_Read);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tbx_Read;
        private System.Windows.Forms.TextBox Tbx_Type;
        private System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_Listen;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

