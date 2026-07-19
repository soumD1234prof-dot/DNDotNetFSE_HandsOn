namespace KafkaChatWinForms
{
    partial class Form1
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
            label1 = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            lstSentMessages = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 24);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 0;
            label1.Text = "Enter your message:\r\n";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(35, 55);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(328, 27);
            txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(36, 98);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lstSentMessages
            // 
            lstSentMessages.FormattingEnabled = true;
            lstSentMessages.Location = new Point(33, 156);
            lstSentMessages.Name = "lstSentMessages";
            lstSentMessages.Size = new Size(755, 284);
            lstSentMessages.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstSentMessages);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMessage;
        private Button btnSend;
        private ListBox lstSentMessages;
    }
}
