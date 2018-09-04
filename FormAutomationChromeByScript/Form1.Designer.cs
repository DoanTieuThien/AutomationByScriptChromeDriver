namespace FormAutomationChromeByScript
{
    partial class FormAutomationByScript
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
            this.txtScript = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtLogAction = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtScript
            // 
            this.txtScript.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtScript.Location = new System.Drawing.Point(2, 2);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(661, 240);
            this.txtScript.TabIndex = 0;
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(669, 2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(113, 35);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtLogAction
            // 
            this.txtLogAction.Location = new System.Drawing.Point(2, 249);
            this.txtLogAction.Multiline = true;
            this.txtLogAction.Name = "txtLogAction";
            this.txtLogAction.ReadOnly = true;
            this.txtLogAction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogAction.Size = new System.Drawing.Size(661, 120);
            this.txtLogAction.TabIndex = 2;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(669, 249);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(113, 35);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // FormAutomationByScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 375);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.txtLogAction);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtScript);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "FormAutomationByScript";
            this.Text = "Automation By Script";
            this.Load += new System.EventHandler(this.FormAutomationByScript_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtLogAction;
        private System.Windows.Forms.Button btnClearLog;
    }
}

