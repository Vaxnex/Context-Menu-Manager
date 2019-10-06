using System.Drawing;

namespace ContextMenuManager
{
    partial class ContextMenuManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextMenuManager));
            this.btnAdd = new System.Windows.Forms.Button();
            this.rbShowall = new System.Windows.Forms.RadioButton();
            this.rbActived = new System.Windows.Forms.RadioButton();
            this.btnDel = new System.Windows.Forms.Button();
            this.lbKeys = new System.Windows.Forms.ListBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnMod = new System.Windows.Forms.Button();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.lbCount = new System.Windows.Forms.Label();
            this.lbNum = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(318, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(163, 44);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Thêm vào context";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rbShowall
            // 
            this.rbShowall.AutoSize = true;
            this.rbShowall.Checked = true;
            this.rbShowall.Location = new System.Drawing.Point(11, 54);
            this.rbShowall.Name = "rbShowall";
            this.rbShowall.Size = new System.Drawing.Size(56, 17);
            this.rbShowall.TabIndex = 27;
            this.rbShowall.TabStop = true;
            this.rbShowall.Text = "Tất cả";
            this.rbShowall.UseVisualStyleBackColor = true;
            this.rbShowall.CheckedChanged += new System.EventHandler(this.rbCheck_CheckedChanged);
            this.rbShowall.Click += new System.EventHandler(this.cmdLess_Click);
            // 
            // rbActived
            // 
            this.rbActived.AutoSize = true;
            this.rbActived.Location = new System.Drawing.Point(91, 54);
            this.rbActived.Name = "rbActived";
            this.rbActived.Size = new System.Drawing.Size(54, 17);
            this.rbActived.TabIndex = 26;
            this.rbActived.Text = "Đã có";
            this.rbActived.UseVisualStyleBackColor = true;
            this.rbActived.CheckedChanged += new System.EventHandler(this.rbCheck_CheckedChanged);
            this.rbActived.Click += new System.EventHandler(this.cmdMore_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(318, 166);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(163, 44);
            this.btnDel.TabIndex = 25;
            this.btnDel.Text = "Xoá";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lbKeys
            // 
            this.lbKeys.FormattingEnabled = true;
            this.lbKeys.Location = new System.Drawing.Point(12, 77);
            this.lbKeys.Name = "lbKeys";
            this.lbKeys.Size = new System.Drawing.Size(282, 186);
            this.lbKeys.TabIndex = 24;
            this.lbKeys.SelectedIndexChanged += new System.EventHandler(this.lbKeys_SelectedIndexChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(12, 11);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(49, 13);
            this.lbSearch.TabIndex = 23;
            this.lbSearch.Text = "Tìm Đuôi";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(67, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnMod
            // 
            this.btnMod.Enabled = false;
            this.btnMod.Location = new System.Drawing.Point(318, 219);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(163, 44);
            this.btnMod.TabIndex = 25;
            this.btnMod.Text = "Sửa";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(169, 54);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(65, 17);
            this.rbNone.TabIndex = 29;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "Chưa có";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbCheck_CheckedChanged);
            this.rbNone.Click += new System.EventHandler(this.cmdMore_Click);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(15, 278);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(46, 13);
            this.lbCount.TabIndex = 30;
            this.lbCount.Text = "Số key: ";
            // 
            // lbNum
            // 
            this.lbNum.AutoSize = true;
            this.lbNum.Location = new System.Drawing.Point(64, 278);
            this.lbNum.Name = "lbNum";
            this.lbNum.Size = new System.Drawing.Size(13, 13);
            this.lbNum.TabIndex = 30;
            this.lbNum.Text = "0";
            // 
            // btnRestart
            // 
            this.btnRestart.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Location = new System.Drawing.Point(-16, -18);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(42, 26);
            this.btnRestart.TabIndex = 31;
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // ContextMenuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(314, 303);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lbNum);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.rbNone);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rbShowall);
            this.Controls.Add(this.rbActived);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lbKeys);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ContextMenuManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Context Menu Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rbShowall;
        private System.Windows.Forms.RadioButton rbActived;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListBox lbKeys;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label lbNum;
        private System.Windows.Forms.Button btnRestart;
    }
}

