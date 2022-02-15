namespace OPC_UA_TEST
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.getBrower = new System.Windows.Forms.Button();
            this.getServer = new System.Windows.Forms.Button();
            this.ReadNote = new System.Windows.Forms.Button();
            this.readNotes = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.writeNote = new System.Windows.Forms.Button();
            this.writeNotes = new System.Windows.Forms.Button();
            this.btn_subscription = new System.Windows.Forms.Button();
            this.btn_getlog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // getBrower
            // 
            this.getBrower.Location = new System.Drawing.Point(680, 32);
            this.getBrower.Name = "getBrower";
            this.getBrower.Size = new System.Drawing.Size(88, 32);
            this.getBrower.TabIndex = 0;
            this.getBrower.Text = "FromBrowerServer";
            this.getBrower.UseVisualStyleBackColor = true;
            this.getBrower.Click += new System.EventHandler(this.getBrower_Click);
            // 
            // getServer
            // 
            this.getServer.Location = new System.Drawing.Point(680, 70);
            this.getServer.Name = "getServer";
            this.getServer.Size = new System.Drawing.Size(88, 32);
            this.getServer.TabIndex = 0;
            this.getServer.Text = "getOPCServer";
            this.getServer.UseVisualStyleBackColor = true;
            this.getServer.Click += new System.EventHandler(this.getServer_Click);
            // 
            // ReadNote
            // 
            this.ReadNote.Location = new System.Drawing.Point(565, 32);
            this.ReadNote.Name = "ReadNote";
            this.ReadNote.Size = new System.Drawing.Size(88, 32);
            this.ReadNote.TabIndex = 0;
            this.ReadNote.Text = "ReadNote";
            this.ReadNote.UseVisualStyleBackColor = true;
            this.ReadNote.Click += new System.EventHandler(this.ReadNote_Click);
            // 
            // readNotes
            // 
            this.readNotes.Location = new System.Drawing.Point(565, 70);
            this.readNotes.Name = "readNotes";
            this.readNotes.Size = new System.Drawing.Size(88, 32);
            this.readNotes.TabIndex = 0;
            this.readNotes.Text = "ReadNotes";
            this.readNotes.UseVisualStyleBackColor = true;
            this.readNotes.Click += new System.EventHandler(this.readNotes_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, -1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(547, 439);
            this.textBox1.TabIndex = 1;
            // 
            // writeNote
            // 
            this.writeNote.Location = new System.Drawing.Point(565, 127);
            this.writeNote.Name = "writeNote";
            this.writeNote.Size = new System.Drawing.Size(88, 32);
            this.writeNote.TabIndex = 0;
            this.writeNote.Text = "WriteNote";
            this.writeNote.UseVisualStyleBackColor = true;
            this.writeNote.Click += new System.EventHandler(this.writeNote_Click);
            // 
            // writeNotes
            // 
            this.writeNotes.Location = new System.Drawing.Point(565, 165);
            this.writeNotes.Name = "writeNotes";
            this.writeNotes.Size = new System.Drawing.Size(88, 32);
            this.writeNotes.TabIndex = 0;
            this.writeNotes.Text = "WriteNotes";
            this.writeNotes.UseVisualStyleBackColor = true;
            this.writeNotes.Click += new System.EventHandler(this.writeNotes_Click);
            // 
            // btn_subscription
            // 
            this.btn_subscription.Location = new System.Drawing.Point(565, 235);
            this.btn_subscription.Name = "btn_subscription";
            this.btn_subscription.Size = new System.Drawing.Size(88, 32);
            this.btn_subscription.TabIndex = 0;
            this.btn_subscription.Text = "Subscription";
            this.btn_subscription.UseVisualStyleBackColor = true;
            this.btn_subscription.Click += new System.EventHandler(this.btn_subscription_Click);
            // 
            // btn_getlog
            // 
            this.btn_getlog.Location = new System.Drawing.Point(565, 287);
            this.btn_getlog.Name = "btn_getlog";
            this.btn_getlog.Size = new System.Drawing.Size(88, 32);
            this.btn_getlog.TabIndex = 0;
            this.btn_getlog.Text = "GetLog";
            this.btn_getlog.UseVisualStyleBackColor = true;
            this.btn_getlog.Click += new System.EventHandler(this.btn_getlog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.readNotes);
            this.Controls.Add(this.btn_getlog);
            this.Controls.Add(this.btn_subscription);
            this.Controls.Add(this.writeNotes);
            this.Controls.Add(this.writeNote);
            this.Controls.Add(this.ReadNote);
            this.Controls.Add(this.getServer);
            this.Controls.Add(this.getBrower);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getBrower;
        private System.Windows.Forms.Button getServer;
        private System.Windows.Forms.Button ReadNote;
        private System.Windows.Forms.Button readNotes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button writeNote;
        private System.Windows.Forms.Button writeNotes;
        private System.Windows.Forms.Button btn_subscription;
        private System.Windows.Forms.Button btn_getlog;
    }
}

