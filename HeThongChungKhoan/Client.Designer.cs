namespace HeThongChungKhoan
{
    partial class Client
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTKGD = new System.Windows.Forms.TabPage();
            this.lblDate = new System.Windows.Forms.Label();
            this.numSize = new System.Windows.Forms.NumericUpDown();
            this.dayDate = new System.Windows.Forms.DateTimePicker();
            this.lblReceiveMail = new System.Windows.Forms.Label();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.txtReceiveMail = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnMail = new System.Windows.Forms.Button();
            this.btnTruyVan = new System.Windows.Forms.Button();
            this.tabMail = new System.Windows.Forms.TabPage();
            this.lstAnoucement = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.tabTKGD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.tabMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTKGD);
            this.tabControl.Controls.Add(this.tabMail);
            this.tabControl.Location = new System.Drawing.Point(26, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(738, 414);
            this.tabControl.TabIndex = 0;
            // 
            // tabTKGD
            // 
            this.tabTKGD.Controls.Add(this.lblDate);
            this.tabTKGD.Controls.Add(this.numSize);
            this.tabTKGD.Controls.Add(this.dayDate);
            this.tabTKGD.Controls.Add(this.lblReceiveMail);
            this.tabTKGD.Controls.Add(this.GridView);
            this.tabTKGD.Controls.Add(this.txtReceiveMail);
            this.tabTKGD.Controls.Add(this.lblSize);
            this.tabTKGD.Controls.Add(this.btnMail);
            this.tabTKGD.Controls.Add(this.btnTruyVan);
            this.tabTKGD.Location = new System.Drawing.Point(4, 25);
            this.tabTKGD.Name = "tabTKGD";
            this.tabTKGD.Padding = new System.Windows.Forms.Padding(3);
            this.tabTKGD.Size = new System.Drawing.Size(730, 385);
            this.tabTKGD.TabIndex = 0;
            this.tabTKGD.Text = "Thống kê giao dịch";
            this.tabTKGD.UseVisualStyleBackColor = true;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(16, 48);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 16);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "Date";
            // 
            // numSize
            // 
            this.numSize.Location = new System.Drawing.Point(79, 12);
            this.numSize.Name = "numSize";
            this.numSize.Size = new System.Drawing.Size(200, 22);
            this.numSize.TabIndex = 7;
            // 
            // dayDate
            // 
            this.dayDate.Location = new System.Drawing.Point(79, 51);
            this.dayDate.Name = "dayDate";
            this.dayDate.Size = new System.Drawing.Size(200, 22);
            this.dayDate.TabIndex = 6;
            // 
            // lblReceiveMail
            // 
            this.lblReceiveMail.AutoSize = true;
            this.lblReceiveMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveMail.Location = new System.Drawing.Point(327, 14);
            this.lblReceiveMail.Name = "lblReceiveMail";
            this.lblReceiveMail.Size = new System.Drawing.Size(73, 16);
            this.lblReceiveMail.TabIndex = 5;
            this.lblReceiveMail.Text = "Mail nhận";
            // 
            // GridView
            // 
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Location = new System.Drawing.Point(7, 92);
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.RowHeadersWidth = 51;
            this.GridView.RowTemplate.Height = 24;
            this.GridView.Size = new System.Drawing.Size(717, 263);
            this.GridView.TabIndex = 4;
            // 
            // txtReceiveMail
            // 
            this.txtReceiveMail.Location = new System.Drawing.Point(432, 12);
            this.txtReceiveMail.Name = "txtReceiveMail";
            this.txtReceiveMail.Size = new System.Drawing.Size(292, 22);
            this.txtReceiveMail.TabIndex = 3;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(16, 14);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(37, 16);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Size";
            // 
            // btnMail
            // 
            this.btnMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMail.Location = new System.Drawing.Point(547, 51);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(177, 35);
            this.btnMail.TabIndex = 1;
            this.btnMail.Text = "Xuất và Gửi Mail";
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.GuiMail_Click);
            // 
            // btnTruyVan
            // 
            this.btnTruyVan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruyVan.Location = new System.Drawing.Point(330, 51);
            this.btnTruyVan.Name = "btnTruyVan";
            this.btnTruyVan.Size = new System.Drawing.Size(177, 35);
            this.btnTruyVan.TabIndex = 0;
            this.btnTruyVan.Text = "Truy Vấn";
            this.btnTruyVan.UseVisualStyleBackColor = true;
            this.btnTruyVan.Click += new System.EventHandler(this.TimKiem_Click);
            // 
            // tabMail
            // 
            this.tabMail.Controls.Add(this.lstAnoucement);
            this.tabMail.Location = new System.Drawing.Point(4, 25);
            this.tabMail.Name = "tabMail";
            this.tabMail.Padding = new System.Windows.Forms.Padding(3);
            this.tabMail.Size = new System.Drawing.Size(730, 385);
            this.tabMail.TabIndex = 1;
            this.tabMail.Text = "Thông báo hệ thống";
            this.tabMail.UseVisualStyleBackColor = true;
            // 
            // lstAnoucement
            // 
            this.lstAnoucement.FormattingEnabled = true;
            this.lstAnoucement.ItemHeight = 16;
            this.lstAnoucement.Location = new System.Drawing.Point(7, 7);
            this.lstAnoucement.Name = "lstAnoucement";
            this.lstAnoucement.Size = new System.Drawing.Size(720, 372);
            this.lstAnoucement.TabIndex = 0;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "Client";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabTKGD.ResumeLayout(false);
            this.tabTKGD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.tabMail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTKGD;
        private System.Windows.Forms.TabPage tabMail;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.NumericUpDown numSize;
        private System.Windows.Forms.DateTimePicker dayDate;
        private System.Windows.Forms.Label lblReceiveMail;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.TextBox txtReceiveMail;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.Button btnTruyVan;
        private System.Windows.Forms.ListBox lstAnoucement;
    }
}

