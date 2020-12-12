namespace IRF_Project.UserControls
{
    partial class TableUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.postsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // playerDataGridView
            // 
            this.playerDataGridView.AllowUserToAddRows = false;
            this.playerDataGridView.AllowUserToDeleteRows = false;
            this.playerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerDataGridView.Location = new System.Drawing.Point(3, 46);
            this.playerDataGridView.Name = "playerDataGridView";
            this.playerDataGridView.ReadOnly = true;
            this.playerDataGridView.Size = new System.Drawing.Size(506, 262);
            this.playerDataGridView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // postsComboBox
            // 
            this.postsComboBox.FormattingEnabled = true;
            this.postsComboBox.Location = new System.Drawing.Point(63, 19);
            this.postsComboBox.Name = "postsComboBox";
            this.postsComboBox.Size = new System.Drawing.Size(121, 21);
            this.postsComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Poszt:";
            // 
            // TableUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postsComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playerDataGridView);
            this.Name = "TableUserControl";
            this.Size = new System.Drawing.Size(509, 376);
            ((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView playerDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox postsComboBox;
        private System.Windows.Forms.Label label1;
    }
}
