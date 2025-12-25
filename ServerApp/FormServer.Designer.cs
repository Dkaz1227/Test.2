namespace ServerApp
{
    partial class FormServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtIp = new TextBox();
            txtPort = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            lbClients = new ListBox();
            txtBroadcast = new TextBox();
            btnBroadcast = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            rtbLog = new RichTextBox();
            SuspendLayout();
            // 
            // txtIp
            // 
            txtIp.Location = new Point(110, 30);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(200, 39);
            txtIp.TabIndex = 0;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(430, 30);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(200, 39);
            txtPort.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(895, 244);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 46);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(895, 346);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(150, 46);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // lbClients
            // 
            lbClients.FormattingEnabled = true;
            lbClients.Location = new Point(12, 165);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(786, 452);
            lbClients.TabIndex = 4;
            // 
            // txtBroadcast
            // 
            txtBroadcast.Location = new Point(1001, 123);
            txtBroadcast.Name = "txtBroadcast";
            txtBroadcast.Size = new Size(200, 39);
            txtBroadcast.TabIndex = 7;
            // 
            // btnBroadcast
            // 
            btnBroadcast.Location = new Point(895, 448);
            btnBroadcast.Name = "btnBroadcast";
            btnBroadcast.Size = new Size(150, 46);
            btnBroadcast.TabIndex = 8;
            btnBroadcast.Text = "Broadcast";
            btnBroadcast.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 37);
            label1.Name = "label1";
            label1.Size = new Size(38, 32);
            label1.TabIndex = 9;
            label1.Text = "IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(363, 37);
            label2.Name = "label2";
            label2.Size = new Size(61, 32);
            label2.TabIndex = 10;
            label2.Text = "Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 662);
            label3.Name = "label3";
            label3.Size = new Size(58, 32);
            label3.TabIndex = 11;
            label3.Text = "Log:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(878, 123);
            label4.Name = "label4";
            label4.Size = new Size(117, 32);
            label4.TabIndex = 12;
            label4.Text = "Broadcast";
            // 
            // rtbLog
            // 
            rtbLog.Location = new Point(76, 662);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(734, 192);
            rtbLog.TabIndex = 13;
            rtbLog.Text = "";
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1345, 910);
            Controls.Add(rtbLog);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBroadcast);
            Controls.Add(txtBroadcast);
            Controls.Add(lbClients);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtPort);
            Controls.Add(txtIp);
            Name = "FormServer";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIp;
        private TextBox txtPort;
        private Button btnStart;
        private Button btnStop;
        private ListBox lbClients;
        private TextBox txtBroadcast;
        private Button btnBroadcast;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox rtbLog;
    }
}
