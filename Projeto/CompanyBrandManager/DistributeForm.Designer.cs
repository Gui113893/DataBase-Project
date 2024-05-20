namespace CompanyBrandManager
{
    partial class DistributeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lojaTxtDistribute = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.quantidadeDistributeTxt = new System.Windows.Forms.TextBox();
            this.okButtonDistribute = new System.Windows.Forms.Button();
            this.cancelButtonDistribute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loja:";
            // 
            // lojaTxtDistribute
            // 
            this.lojaTxtDistribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lojaTxtDistribute.Location = new System.Drawing.Point(88, 70);
            this.lojaTxtDistribute.Name = "lojaTxtDistribute";
            this.lojaTxtDistribute.Size = new System.Drawing.Size(62, 30);
            this.lojaTxtDistribute.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade:";
            // 
            // quantidadeDistributeTxt
            // 
            this.quantidadeDistributeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantidadeDistributeTxt.Location = new System.Drawing.Point(355, 67);
            this.quantidadeDistributeTxt.Name = "quantidadeDistributeTxt";
            this.quantidadeDistributeTxt.Size = new System.Drawing.Size(85, 30);
            this.quantidadeDistributeTxt.TabIndex = 3;
            // 
            // okButtonDistribute
            // 
            this.okButtonDistribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButtonDistribute.Location = new System.Drawing.Point(88, 157);
            this.okButtonDistribute.Name = "okButtonDistribute";
            this.okButtonDistribute.Size = new System.Drawing.Size(96, 50);
            this.okButtonDistribute.TabIndex = 4;
            this.okButtonDistribute.Text = "Ok";
            this.okButtonDistribute.UseVisualStyleBackColor = true;
            this.okButtonDistribute.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButtonDistribute
            // 
            this.cancelButtonDistribute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButtonDistribute.Location = new System.Drawing.Point(305, 157);
            this.cancelButtonDistribute.Name = "cancelButtonDistribute";
            this.cancelButtonDistribute.Size = new System.Drawing.Size(96, 50);
            this.cancelButtonDistribute.TabIndex = 5;
            this.cancelButtonDistribute.Text = "Cancel";
            this.cancelButtonDistribute.UseVisualStyleBackColor = true;
            this.cancelButtonDistribute.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // DistributeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 228);
            this.Controls.Add(this.cancelButtonDistribute);
            this.Controls.Add(this.okButtonDistribute);
            this.Controls.Add(this.quantidadeDistributeTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lojaTxtDistribute);
            this.Controls.Add(this.label1);
            this.Name = "DistributeForm";
            this.Text = "DistributeForm";
            this.Load += new System.EventHandler(this.DistributeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lojaTxtDistribute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantidadeDistributeTxt;
        private System.Windows.Forms.Button okButtonDistribute;
        private System.Windows.Forms.Button cancelButtonDistribute;
    }
}