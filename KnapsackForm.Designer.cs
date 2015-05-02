namespace Knapsack
{
    partial class KnapsackForm
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
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.solve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 12);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(162, 162);
            this.input.TabIndex = 1;
            this.input.Text = "14\r\n8 4\r\n10 5\r\n15 8\r\n4 3";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(180, 12);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(464, 211);
            this.output.TabIndex = 2;
            // 
            // solve
            // 
            this.solve.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.solve.Location = new System.Drawing.Point(12, 180);
            this.solve.Name = "solve";
            this.solve.Size = new System.Drawing.Size(162, 43);
            this.solve.TabIndex = 0;
            this.solve.Text = "Решить";
            this.solve.UseVisualStyleBackColor = true;
            this.solve.Click += new System.EventHandler(this.solve_Click);
            // 
            // KnapsackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 235);
            this.Controls.Add(this.solve);
            this.Controls.Add(this.output);
            this.Controls.Add(this.input);
            this.Name = "KnapsackForm";
            this.Text = "Упаковка рюкзака";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button solve;
    }
}

