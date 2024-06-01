namespace CompanyBrandManager
{
    partial class FornecerForm
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
            this.produtoTxtFornecer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.quantidadeFornecerTxt = new System.Windows.Forms.TextBox();
            this.okButtonFornecer = new System.Windows.Forms.Button();
            this.cancelButtonFornecer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Produto:";
            // 
            // produtoTxtFornecer
            // 
            this.produtoTxtFornecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtoTxtFornecer.Location = new System.Drawing.Point(104, 89);
            this.produtoTxtFornecer.Name = "produtoTxtFornecer";
            this.produtoTxtFornecer.Size = new System.Drawing.Size(62, 30);
            this.produtoTxtFornecer.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(245, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Quantidade:";
            // 
            // quantidadeFornecerTxt
            // 
            this.quantidadeFornecerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantidadeFornecerTxt.Location = new System.Drawing.Point(371, 86);
            this.quantidadeFornecerTxt.Name = "quantidadeFornecerTxt";
            this.quantidadeFornecerTxt.Size = new System.Drawing.Size(85, 30);
            this.quantidadeFornecerTxt.TabIndex = 4;
            // 
            // okButtonFornecer
            // 
            this.okButtonFornecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButtonFornecer.Location = new System.Drawing.Point(104, 160);
            this.okButtonFornecer.Name = "okButtonFornecer";
            this.okButtonFornecer.Size = new System.Drawing.Size(96, 50);
            this.okButtonFornecer.TabIndex = 5;
            this.okButtonFornecer.Text = "Ok";
            this.okButtonFornecer.UseVisualStyleBackColor = true;
            this.okButtonFornecer.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButtonFornecer
            // 
            this.cancelButtonFornecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButtonFornecer.Location = new System.Drawing.Point(269, 160);
            this.cancelButtonFornecer.Name = "cancelButtonFornecer";
            this.cancelButtonFornecer.Size = new System.Drawing.Size(96, 50);
            this.cancelButtonFornecer.TabIndex = 6;
            this.cancelButtonFornecer.Text = "Cancel";
            this.cancelButtonFornecer.UseVisualStyleBackColor = true;
            this.cancelButtonFornecer.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FornecerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 222);
            this.Controls.Add(this.cancelButtonFornecer);
            this.Controls.Add(this.okButtonFornecer);
            this.Controls.Add(this.quantidadeFornecerTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.produtoTxtFornecer);
            this.Controls.Add(this.label1);
            this.Name = "FornecerForm";
            this.Text = "FornecerForm";
            this.Load += new System.EventHandler(this.FornecerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox produtoTxtFornecer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox quantidadeFornecerTxt;
        private System.Windows.Forms.Button okButtonFornecer;
        private System.Windows.Forms.Button cancelButtonFornecer;
    }
}