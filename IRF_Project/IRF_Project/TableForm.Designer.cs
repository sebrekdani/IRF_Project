namespace IRF_Project
{
    partial class TableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.label1 = new System.Windows.Forms.Label();
            this.postsComboBox = new System.Windows.Forms.ComboBox();
            this.playerDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(60, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Poszt:";
            // 
            // postsComboBox
            // 
            this.postsComboBox.BackColor = System.Drawing.Color.Yellow;
            this.postsComboBox.FormattingEnabled = true;
            this.postsComboBox.Location = new System.Drawing.Point(123, 15);
            this.postsComboBox.Name = "postsComboBox";
            this.postsComboBox.Size = new System.Drawing.Size(121, 21);
            this.postsComboBox.TabIndex = 6;
            this.postsComboBox.SelectedValueChanged += new System.EventHandler(this.postsComboBox_SelectedValueChanged);
            // 
            // playerDataGridView
            // 
            this.playerDataGridView.AllowUserToAddRows = false;
            this.playerDataGridView.AllowUserToDeleteRows = false;
            this.playerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.playerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playerDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerDataGridView.Location = new System.Drawing.Point(0, 52);
            this.playerDataGridView.Name = "playerDataGridView";
            this.playerDataGridView.ReadOnly = true;
            this.playerDataGridView.Size = new System.Drawing.Size(800, 398);
            this.playerDataGridView.TabIndex = 4;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.postsComboBox);
            this.Controls.Add(this.playerDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableForm";
            this.Text = "Manchester United Squad";
            ((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox postsComboBox;
        private System.Windows.Forms.DataGridView playerDataGridView;
    }
}