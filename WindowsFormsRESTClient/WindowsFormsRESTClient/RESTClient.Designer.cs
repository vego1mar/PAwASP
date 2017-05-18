namespace WindowsFormsRESTClient
{
    partial class RestClient
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
            this.tlpMainWindow = new System.Windows.Forms.TableLayoutPanel();
            this.cbRestType = new System.Windows.Forms.ComboBox();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.cbContentType = new System.Windows.Forms.ComboBox();
            this.btnPerform = new System.Windows.Forms.Button();
            this.tbResponseCode = new System.Windows.Forms.TextBox();
            this.tbResponseCodeOutput = new System.Windows.Forms.TextBox();
            this.tbReceivedMessage = new System.Windows.Forms.TextBox();
            this.tctrlMainWindow = new System.Windows.Forms.TabControl();
            this.tpgClient = new System.Windows.Forms.TabPage();
            this.tpgLastRequestHeader = new System.Windows.Forms.TabPage();
            this.tlpMainWindow.SuspendLayout();
            this.tctrlMainWindow.SuspendLayout();
            this.tpgClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainWindow
            // 
            this.tlpMainWindow.AutoSize = true;
            this.tlpMainWindow.ColumnCount = 4;
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMainWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMainWindow.Controls.Add(this.cbRestType, 0, 0);
            this.tlpMainWindow.Controls.Add(this.tbURL, 1, 0);
            this.tlpMainWindow.Controls.Add(this.cbContentType, 2, 0);
            this.tlpMainWindow.Controls.Add(this.btnPerform, 3, 0);
            this.tlpMainWindow.Controls.Add(this.tbResponseCode, 0, 1);
            this.tlpMainWindow.Controls.Add(this.tbResponseCodeOutput, 1, 1);
            this.tlpMainWindow.Controls.Add(this.tbReceivedMessage, 0, 2);
            this.tlpMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainWindow.Location = new System.Drawing.Point(3, 3);
            this.tlpMainWindow.Name = "tlpMainWindow";
            this.tlpMainWindow.RowCount = 3;
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMainWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpMainWindow.Size = new System.Drawing.Size(1044, 493);
            this.tlpMainWindow.TabIndex = 0;
            // 
            // cbRESTType
            // 
            this.cbRestType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbRestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRestType.FormattingEnabled = true;
            this.cbRestType.Location = new System.Drawing.Point(3, 3);
            this.cbRestType.Name = "cbRESTType";
            this.cbRestType.Size = new System.Drawing.Size(98, 21);
            this.cbRestType.TabIndex = 0;
            this.cbRestType.SelectedIndexChanged += new System.EventHandler(this.CbRestType_SelectedIndexChanged);
            // 
            // tbURL
            // 
            this.tbURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbURL.Location = new System.Drawing.Point(107, 3);
            this.tbURL.Multiline = true;
            this.tbURL.Name = "tbURL";
            this.tbURL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbURL.Size = new System.Drawing.Size(620, 43);
            this.tbURL.TabIndex = 1;
            this.tbURL.Text = "http://www.";
            // 
            // cbContentType
            // 
            this.cbContentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbContentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContentType.FormattingEnabled = true;
            this.cbContentType.Location = new System.Drawing.Point(733, 3);
            this.cbContentType.Name = "cbContentType";
            this.cbContentType.Size = new System.Drawing.Size(202, 21);
            this.cbContentType.TabIndex = 2;
            // 
            // btnPerform
            // 
            this.btnPerform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPerform.Location = new System.Drawing.Point(941, 3);
            this.btnPerform.Name = "btnPerform";
            this.btnPerform.Size = new System.Drawing.Size(100, 43);
            this.btnPerform.TabIndex = 3;
            this.btnPerform.Text = "Perform";
            this.btnPerform.UseVisualStyleBackColor = true;
            this.btnPerform.Click += new System.EventHandler(this.BtnPerform_Click);
            // 
            // tbResponseCode
            // 
            this.tbResponseCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResponseCode.Location = new System.Drawing.Point(3, 52);
            this.tbResponseCode.Name = "tbResponseCode";
            this.tbResponseCode.ReadOnly = true;
            this.tbResponseCode.Size = new System.Drawing.Size(98, 20);
            this.tbResponseCode.TabIndex = 4;
            this.tbResponseCode.Text = "Response code:";
            // 
            // tbResponseCodeOutput
            // 
            this.tlpMainWindow.SetColumnSpan(this.tbResponseCodeOutput, 3);
            this.tbResponseCodeOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResponseCodeOutput.Location = new System.Drawing.Point(107, 52);
            this.tbResponseCodeOutput.Name = "tbResponseCodeOutput";
            this.tbResponseCodeOutput.ReadOnly = true;
            this.tbResponseCodeOutput.Size = new System.Drawing.Size(934, 20);
            this.tbResponseCodeOutput.TabIndex = 5;
            // 
            // tbReceivedMessage
            // 
            this.tlpMainWindow.SetColumnSpan(this.tbReceivedMessage, 4);
            this.tbReceivedMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReceivedMessage.Location = new System.Drawing.Point(3, 76);
            this.tbReceivedMessage.Multiline = true;
            this.tbReceivedMessage.Name = "tbReceivedMessage";
            this.tbReceivedMessage.ReadOnly = true;
            this.tbReceivedMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbReceivedMessage.Size = new System.Drawing.Size(1038, 414);
            this.tbReceivedMessage.TabIndex = 6;
            // 
            // tctrlMainWindow
            // 
            this.tctrlMainWindow.Controls.Add(this.tpgClient);
            this.tctrlMainWindow.Controls.Add(this.tpgLastRequestHeader);
            this.tctrlMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tctrlMainWindow.Location = new System.Drawing.Point(0, 0);
            this.tctrlMainWindow.Name = "tctrlMainWindow";
            this.tctrlMainWindow.SelectedIndex = 0;
            this.tctrlMainWindow.Size = new System.Drawing.Size(1058, 525);
            this.tctrlMainWindow.TabIndex = 1;
            // 
            // tpgClient
            // 
            this.tpgClient.Controls.Add(this.tlpMainWindow);
            this.tpgClient.Location = new System.Drawing.Point(4, 22);
            this.tpgClient.Name = "tpgClient";
            this.tpgClient.Padding = new System.Windows.Forms.Padding(3);
            this.tpgClient.Size = new System.Drawing.Size(1050, 499);
            this.tpgClient.TabIndex = 0;
            this.tpgClient.Text = "Client";
            this.tpgClient.UseVisualStyleBackColor = true;
            // 
            // tpgLastRequestHeader
            // 
            this.tpgLastRequestHeader.Location = new System.Drawing.Point(4, 22);
            this.tpgLastRequestHeader.Name = "tpgLastRequestHeader";
            this.tpgLastRequestHeader.Padding = new System.Windows.Forms.Padding(3);
            this.tpgLastRequestHeader.Size = new System.Drawing.Size(1050, 499);
            this.tpgLastRequestHeader.TabIndex = 1;
            this.tpgLastRequestHeader.Text = "Last request header";
            this.tpgLastRequestHeader.UseVisualStyleBackColor = true;
            // 
            // RestClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 525);
            this.Controls.Add(this.tctrlMainWindow);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "RestClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Forms REST Client";
            this.Load += new System.EventHandler(this.RestClient_Load);
            this.tlpMainWindow.ResumeLayout(false);
            this.tlpMainWindow.PerformLayout();
            this.tctrlMainWindow.ResumeLayout(false);
            this.tpgClient.ResumeLayout(false);
            this.tpgClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMainWindow;
        private System.Windows.Forms.ComboBox cbRestType;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.ComboBox cbContentType;
        private System.Windows.Forms.TabControl tctrlMainWindow;
        private System.Windows.Forms.TabPage tpgClient;
        private System.Windows.Forms.TabPage tpgLastRequestHeader;
        private System.Windows.Forms.Button btnPerform;
        private System.Windows.Forms.TextBox tbResponseCode;
        private System.Windows.Forms.TextBox tbResponseCodeOutput;
        private System.Windows.Forms.TextBox tbReceivedMessage;
    }
}

