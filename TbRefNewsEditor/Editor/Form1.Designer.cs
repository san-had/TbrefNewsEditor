namespace Editor
{
    partial class Form1
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
            this.txtVerb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEvents = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateScript = new System.Windows.Forms.Button();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.btnCopyScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVerb
            // 
            this.txtVerb.Location = new System.Drawing.Point(178, 33);
            this.txtVerb.Name = "txtVerb";
            this.txtVerb.Size = new System.Drawing.Size(517, 20);
            this.txtVerb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ige:";
            // 
            // txtEvents
            // 
            this.txtEvents.Location = new System.Drawing.Point(178, 89);
            this.txtEvents.Multiline = true;
            this.txtEvents.Name = "txtEvents";
            this.txtEvents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEvents.Size = new System.Drawing.Size(274, 100);
            this.txtEvents.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alkalmak:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(178, 259);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(517, 274);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Hírek:";
            // 
            // btnGenerateScript
            // 
            this.btnGenerateScript.BackColor = System.Drawing.Color.Cornsilk;
            this.btnGenerateScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateScript.Location = new System.Drawing.Point(298, 556);
            this.btnGenerateScript.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerateScript.Name = "btnGenerateScript";
            this.btnGenerateScript.Size = new System.Drawing.Size(154, 37);
            this.btnGenerateScript.TabIndex = 23;
            this.btnGenerateScript.Text = "Script generál";
            this.btnGenerateScript.UseVisualStyleBackColor = false;
            // 
            // txtScript
            // 
            this.txtScript.Location = new System.Drawing.Point(178, 624);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(517, 141);
            this.txtScript.TabIndex = 24;
            // 
            // btnCopyScript
            // 
            this.btnCopyScript.Location = new System.Drawing.Point(83, 624);
            this.btnCopyScript.Margin = new System.Windows.Forms.Padding(2);
            this.btnCopyScript.Name = "btnCopyScript";
            this.btnCopyScript.Size = new System.Drawing.Size(71, 30);
            this.btnCopyScript.TabIndex = 25;
            this.btnCopyScript.Text = "Másol";
            this.btnCopyScript.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 777);
            this.Controls.Add(this.btnCopyScript);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.btnGenerateScript);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVerb);
            this.Name = "Form1";
            this.Text = "TbrefNewsEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVerb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEvents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateScript;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.Button btnCopyScript;
    }
}

