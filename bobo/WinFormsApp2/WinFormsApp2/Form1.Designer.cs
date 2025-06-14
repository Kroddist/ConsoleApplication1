namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button compileButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windo
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.compileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.compileButton.Location = new System.Drawing.Point(350, 200);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(100, 30);
            this.compileButton.TabIndex = 0;
            this.compileButton.Text = "Компилировать";
            this.compileButton.UseVisualStyleBackColor = true;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.compileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
