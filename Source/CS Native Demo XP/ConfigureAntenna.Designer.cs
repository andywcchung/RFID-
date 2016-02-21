#if CS468
namespace CS203_CALLBACK_API_DEMO
{
    partial class ConfigureAntenna
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
            this.view = new System.Windows.Forms.DataGridView();
            this.rwLabel = new System.Windows.Forms.Label();
            this.restoreDefaultsButton = new System.Windows.Forms.Button();
            this.btnApplyChange = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.AllowUserToAddRows = false;
            this.view.AllowUserToDeleteRows = false;
            this.view.BackgroundColor = System.Drawing.Color.White;
            this.view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view.Location = new System.Drawing.Point(10, 31);
            this.view.Name = "view";
            this.view.RowTemplate.Height = 24;
            this.view.Size = new System.Drawing.Size(618, 292);
            this.view.TabIndex = 2;
            // 
            // rwLabel
            // 
            this.rwLabel.AutoSize = true;
            this.rwLabel.ForeColor = System.Drawing.Color.Blue;
            this.rwLabel.Location = new System.Drawing.Point(8, 9);
            this.rwLabel.Name = "rwLabel";
            this.rwLabel.Size = new System.Drawing.Size(113, 12);
            this.rwLabel.TabIndex = 3;
            this.rwLabel.Text = "Antenna Configuration";
            // 
            // restoreDefaultsButton
            // 
            this.restoreDefaultsButton.Location = new System.Drawing.Point(523, 329);
            this.restoreDefaultsButton.Name = "restoreDefaultsButton";
            this.restoreDefaultsButton.Size = new System.Drawing.Size(105, 20);
            this.restoreDefaultsButton.TabIndex = 5;
            this.restoreDefaultsButton.Text = "Restore Default";
            this.restoreDefaultsButton.UseVisualStyleBackColor = true;
            this.restoreDefaultsButton.Click += new System.EventHandler(this.restoreDefaultsButton_Click);
            // 
            // btnApplyChange
            // 
            this.btnApplyChange.Location = new System.Drawing.Point(412, 329);
            this.btnApplyChange.Name = "btnApplyChange";
            this.btnApplyChange.Size = new System.Drawing.Size(105, 20);
            this.btnApplyChange.TabIndex = 5;
            this.btnApplyChange.Text = "Apply Change";
            this.btnApplyChange.UseVisualStyleBackColor = true;
            this.btnApplyChange.Click += new System.EventHandler(this.btnApplyChange_Click);
            // 
            // ConfigureAntenna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 352);
            this.Controls.Add(this.btnApplyChange);
            this.Controls.Add(this.restoreDefaultsButton);
            this.Controls.Add(this.rwLabel);
            this.Controls.Add(this.view);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureAntenna";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ConfigureAntenna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView view;
        private System.Windows.Forms.Label rwLabel;
        private System.Windows.Forms.Button restoreDefaultsButton;
        private System.Windows.Forms.Button btnApplyChange;
    }
}
#endif