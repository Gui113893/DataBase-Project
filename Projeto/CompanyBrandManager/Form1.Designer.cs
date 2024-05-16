namespace CompanyBrandManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            FuncionarioPage = new TabPage();
            textHoras1 = new TextBox();
            HorasLabel1 = new Label();
            label1 = new Label();
            createContrato = new Button();
            ContratoLabel1 = new Label();
            textSalario1 = new TextBox();
            SalarioLabel1 = new Label();
            textCodPostal1 = new TextBox();
            CodPostalLabel1 = new Label();
            textLocalidade1 = new TextBox();
            LocalidadeLabel1 = new Label();
            textRua1 = new TextBox();
            RuaLabel1 = new Label();
            textTelefone1 = new TextBox();
            TelefoneLabel1 = new Label();
            textEmail1 = new TextBox();
            EmailLabel1 = new Label();
            textSex1 = new TextBox();
            SexoLabel1 = new Label();
            textNome1 = new TextBox();
            NomeLabel1 = new Label();
            textNif1 = new TextBox();
            nifLabel1 = new Label();
            ListPessoas = new ListBox();
            menuAdd = new MenuStrip();
            adicionarToolStripMenuItem = new ToolStripMenuItem();
            funcionárioEfetivoToolStripMenuItem = new ToolStripMenuItem();
            funcionárioPartTimeToolStripMenuItem = new ToolStripMenuItem();
            diretorToolStripMenuItem = new ToolStripMenuItem();
            tabPage2 = new TabPage();
            Addbutton1 = new Button();
            Editbutton1 = new Button();
            Deletebutton1 = new Button();
            tabControl1.SuspendLayout();
            FuncionarioPage.SuspendLayout();
            menuAdd.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(FuncionarioPage);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(946, 525);
            tabControl1.TabIndex = 0;
            // 
            // FuncionarioPage
            // 
            FuncionarioPage.Controls.Add(Deletebutton1);
            FuncionarioPage.Controls.Add(Editbutton1);
            FuncionarioPage.Controls.Add(Addbutton1);
            FuncionarioPage.Controls.Add(textHoras1);
            FuncionarioPage.Controls.Add(HorasLabel1);
            FuncionarioPage.Controls.Add(label1);
            FuncionarioPage.Controls.Add(createContrato);
            FuncionarioPage.Controls.Add(ContratoLabel1);
            FuncionarioPage.Controls.Add(textSalario1);
            FuncionarioPage.Controls.Add(SalarioLabel1);
            FuncionarioPage.Controls.Add(textCodPostal1);
            FuncionarioPage.Controls.Add(CodPostalLabel1);
            FuncionarioPage.Controls.Add(textLocalidade1);
            FuncionarioPage.Controls.Add(LocalidadeLabel1);
            FuncionarioPage.Controls.Add(textRua1);
            FuncionarioPage.Controls.Add(RuaLabel1);
            FuncionarioPage.Controls.Add(textTelefone1);
            FuncionarioPage.Controls.Add(TelefoneLabel1);
            FuncionarioPage.Controls.Add(textEmail1);
            FuncionarioPage.Controls.Add(EmailLabel1);
            FuncionarioPage.Controls.Add(textSex1);
            FuncionarioPage.Controls.Add(SexoLabel1);
            FuncionarioPage.Controls.Add(textNome1);
            FuncionarioPage.Controls.Add(NomeLabel1);
            FuncionarioPage.Controls.Add(textNif1);
            FuncionarioPage.Controls.Add(nifLabel1);
            FuncionarioPage.Controls.Add(ListPessoas);
            FuncionarioPage.Controls.Add(menuAdd);
            FuncionarioPage.Location = new Point(4, 24);
            FuncionarioPage.Name = "FuncionarioPage";
            FuncionarioPage.Padding = new Padding(3);
            FuncionarioPage.Size = new Size(938, 497);
            FuncionarioPage.TabIndex = 0;
            FuncionarioPage.Text = "Pessoas";
            FuncionarioPage.UseVisualStyleBackColor = true;
            // 
            // textHoras1
            // 
            textHoras1.Location = new Point(382, 267);
            textHoras1.Name = "textHoras1";
            textHoras1.Size = new Size(35, 23);
            textHoras1.TabIndex = 24;
            textHoras1.Visible = false;
            // 
            // HorasLabel1
            // 
            HorasLabel1.AutoSize = true;
            HorasLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HorasLabel1.Location = new Point(251, 269);
            HorasLabel1.Name = "HorasLabel1";
            HorasLabel1.RightToLeft = RightToLeft.No;
            HorasLabel1.Size = new Size(125, 21);
            HorasLabel1.TabIndex = 23;
            HorasLabel1.Text = "Horas Semanais:";
            HorasLabel1.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(140, 315);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(23, 21);
            label1.TabIndex = 22;
            label1.Text = "id";
            label1.Visible = false;
            // 
            // createContrato
            // 
            createContrato.Location = new Point(99, 315);
            createContrato.Name = "createContrato";
            createContrato.Size = new Size(106, 23);
            createContrato.TabIndex = 21;
            createContrato.Text = "Create +";
            createContrato.UseVisualStyleBackColor = true;
            createContrato.Visible = false;
            // 
            // ContratoLabel1
            // 
            ContratoLabel1.AutoSize = true;
            ContratoLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ContratoLabel1.Location = new Point(23, 314);
            ContratoLabel1.Name = "ContratoLabel1";
            ContratoLabel1.RightToLeft = RightToLeft.No;
            ContratoLabel1.Size = new Size(74, 21);
            ContratoLabel1.TabIndex = 20;
            ContratoLabel1.Text = "Contrato:";
            ContratoLabel1.Visible = false;
            // 
            // textSalario1
            // 
            textSalario1.Location = new Point(99, 271);
            textSalario1.Name = "textSalario1";
            textSalario1.Size = new Size(106, 23);
            textSalario1.TabIndex = 18;
            // 
            // SalarioLabel1
            // 
            SalarioLabel1.AutoSize = true;
            SalarioLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SalarioLabel1.Location = new Point(23, 269);
            SalarioLabel1.Name = "SalarioLabel1";
            SalarioLabel1.RightToLeft = RightToLeft.No;
            SalarioLabel1.Size = new Size(65, 21);
            SalarioLabel1.TabIndex = 17;
            SalarioLabel1.Text = "Salário: ";
            // 
            // textCodPostal1
            // 
            textCodPostal1.Location = new Point(437, 213);
            textCodPostal1.Name = "textCodPostal1";
            textCodPostal1.Size = new Size(98, 23);
            textCodPostal1.TabIndex = 16;
            // 
            // CodPostalLabel1
            // 
            CodPostalLabel1.AutoSize = true;
            CodPostalLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CodPostalLabel1.Location = new Point(349, 211);
            CodPostalLabel1.Name = "CodPostalLabel1";
            CodPostalLabel1.Size = new Size(82, 21);
            CodPostalLabel1.TabIndex = 15;
            CodPostalLabel1.Text = "CodPostal:";
            // 
            // textLocalidade1
            // 
            textLocalidade1.Location = new Point(116, 213);
            textLocalidade1.Name = "textLocalidade1";
            textLocalidade1.Size = new Size(210, 23);
            textLocalidade1.TabIndex = 14;
            // 
            // LocalidadeLabel1
            // 
            LocalidadeLabel1.AutoSize = true;
            LocalidadeLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LocalidadeLabel1.Location = new Point(23, 211);
            LocalidadeLabel1.Name = "LocalidadeLabel1";
            LocalidadeLabel1.Size = new Size(87, 21);
            LocalidadeLabel1.TabIndex = 13;
            LocalidadeLabel1.Text = "Localidade:";
            // 
            // textRua1
            // 
            textRua1.Location = new Point(258, 155);
            textRua1.Name = "textRua1";
            textRua1.Size = new Size(277, 23);
            textRua1.TabIndex = 12;
            // 
            // RuaLabel1
            // 
            RuaLabel1.AutoSize = true;
            RuaLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            RuaLabel1.Location = new Point(212, 153);
            RuaLabel1.Name = "RuaLabel1";
            RuaLabel1.Size = new Size(40, 21);
            RuaLabel1.TabIndex = 11;
            RuaLabel1.Text = "Rua:";
            RuaLabel1.Click += label1_Click_1;
            // 
            // textTelefone1
            // 
            textTelefone1.Location = new Point(99, 153);
            textTelefone1.Name = "textTelefone1";
            textTelefone1.Size = new Size(88, 23);
            textTelefone1.TabIndex = 10;
            // 
            // TelefoneLabel1
            // 
            TelefoneLabel1.AutoSize = true;
            TelefoneLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TelefoneLabel1.Location = new Point(23, 153);
            TelefoneLabel1.Name = "TelefoneLabel1";
            TelefoneLabel1.Size = new Size(70, 21);
            TelefoneLabel1.TabIndex = 9;
            TelefoneLabel1.Text = "Telefone:";
            // 
            // textEmail1
            // 
            textEmail1.Location = new Point(251, 96);
            textEmail1.Name = "textEmail1";
            textEmail1.Size = new Size(284, 23);
            textEmail1.TabIndex = 8;
            // 
            // EmailLabel1
            // 
            EmailLabel1.AutoSize = true;
            EmailLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            EmailLabel1.Location = new Point(189, 94);
            EmailLabel1.Name = "EmailLabel1";
            EmailLabel1.Size = new Size(51, 21);
            EmailLabel1.TabIndex = 7;
            EmailLabel1.Text = "Email:";
            EmailLabel1.Click += label1_Click;
            // 
            // textSex1
            // 
            textSex1.Location = new Point(75, 96);
            textSex1.Name = "textSex1";
            textSex1.Size = new Size(40, 23);
            textSex1.TabIndex = 6;
            // 
            // SexoLabel1
            // 
            SexoLabel1.AutoSize = true;
            SexoLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SexoLabel1.Location = new Point(23, 94);
            SexoLabel1.Name = "SexoLabel1";
            SexoLabel1.Size = new Size(46, 21);
            SexoLabel1.TabIndex = 5;
            SexoLabel1.Text = "Sexo:";
            // 
            // textNome1
            // 
            textNome1.Location = new Point(251, 36);
            textNome1.Name = "textNome1";
            textNome1.Size = new Size(284, 23);
            textNome1.TabIndex = 4;
            // 
            // NomeLabel1
            // 
            NomeLabel1.AutoSize = true;
            NomeLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NomeLabel1.Location = new Point(189, 34);
            NomeLabel1.Name = "NomeLabel1";
            NomeLabel1.Size = new Size(56, 21);
            NomeLabel1.TabIndex = 3;
            NomeLabel1.Text = "Nome:";
            // 
            // textNif1
            // 
            textNif1.Location = new Point(66, 36);
            textNif1.Name = "textNif1";
            textNif1.Size = new Size(97, 23);
            textNif1.TabIndex = 2;
            textNif1.TextChanged += textBox1_TextChanged;
            // 
            // nifLabel1
            // 
            nifLabel1.AutoSize = true;
            nifLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nifLabel1.Location = new Point(23, 34);
            nifLabel1.Name = "nifLabel1";
            nifLabel1.Size = new Size(37, 21);
            nifLabel1.TabIndex = 1;
            nifLabel1.Text = "NIF:";
            // 
            // ListPessoas
            // 
            ListPessoas.FormattingEnabled = true;
            ListPessoas.ItemHeight = 15;
            ListPessoas.Location = new Point(553, 7);
            ListPessoas.Name = "ListPessoas";
            ListPessoas.Size = new Size(379, 484);
            ListPessoas.TabIndex = 0;
            // 
            // menuAdd
            // 
            menuAdd.Items.AddRange(new ToolStripItem[] { adicionarToolStripMenuItem });
            menuAdd.Location = new Point(3, 3);
            menuAdd.Name = "menuAdd";
            menuAdd.Size = new Size(932, 24);
            menuAdd.TabIndex = 19;
            menuAdd.Text = "menuAdd";
            // 
            // adicionarToolStripMenuItem
            // 
            adicionarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { funcionárioEfetivoToolStripMenuItem, funcionárioPartTimeToolStripMenuItem, diretorToolStripMenuItem });
            adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            adicionarToolStripMenuItem.Size = new Size(70, 20);
            adicionarToolStripMenuItem.Text = "Adicionar";
            // 
            // funcionárioEfetivoToolStripMenuItem
            // 
            funcionárioEfetivoToolStripMenuItem.Name = "funcionárioEfetivoToolStripMenuItem";
            funcionárioEfetivoToolStripMenuItem.Size = new Size(192, 22);
            funcionárioEfetivoToolStripMenuItem.Text = "Funcionário Efetivo";
            // 
            // funcionárioPartTimeToolStripMenuItem
            // 
            funcionárioPartTimeToolStripMenuItem.Name = "funcionárioPartTimeToolStripMenuItem";
            funcionárioPartTimeToolStripMenuItem.Size = new Size(192, 22);
            funcionárioPartTimeToolStripMenuItem.Text = "Funcionário Part-Time";
            // 
            // diretorToolStripMenuItem
            // 
            diretorToolStripMenuItem.Name = "diretorToolStripMenuItem";
            diretorToolStripMenuItem.Size = new Size(192, 22);
            diretorToolStripMenuItem.Text = "Diretor";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(938, 497);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            // 
            // Addbutton1
            // 
            Addbutton1.Location = new Point(66, 404);
            Addbutton1.Name = "Addbutton1";
            Addbutton1.Size = new Size(109, 37);
            Addbutton1.TabIndex = 25;
            Addbutton1.Text = "Add";
            Addbutton1.UseVisualStyleBackColor = true;
            // 
            // Editbutton1
            // 
            Editbutton1.Location = new Point(217, 404);
            Editbutton1.Name = "Editbutton1";
            Editbutton1.Size = new Size(109, 37);
            Editbutton1.TabIndex = 26;
            Editbutton1.Text = "Edit";
            Editbutton1.UseVisualStyleBackColor = true;
            // 
            // Deletebutton1
            // 
            Deletebutton1.Location = new Point(365, 404);
            Deletebutton1.Name = "Deletebutton1";
            Deletebutton1.Size = new Size(109, 37);
            Deletebutton1.TabIndex = 27;
            Deletebutton1.Text = "Delete";
            Deletebutton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 549);
            Controls.Add(tabControl1);
            MainMenuStrip = menuAdd;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "CompanyBrandManager";
            tabControl1.ResumeLayout(false);
            FuncionarioPage.ResumeLayout(false);
            FuncionarioPage.PerformLayout();
            menuAdd.ResumeLayout(false);
            menuAdd.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage FuncionarioPage;
        private TabPage tabPage2;
        private ListBox ListPessoas;
        private Label nifLabel1;
        private TextBox textNif1;
        private TextBox textSex1;
        private Label SexoLabel1;
        private Label NomeLabel1;
        private Label TelefoneLabel1;
        private TextBox textEmail1;
        private Label EmailLabel1;
        private TextBox textNome1;
        private TextBox textTelefone1;
        private Label RuaLabel1;
        private TextBox textRua1;
        private TextBox textLocalidade1;
        private Label LocalidadeLabel1;
        private Label CodPostalLabel1;
        private TextBox textSalario1;
        private Label SalarioLabel1;
        private TextBox textCodPostal1;
        private MenuStrip menuAdd;
        private ToolStripMenuItem adicionarToolStripMenuItem;
        private ToolStripMenuItem funcionárioEfetivoToolStripMenuItem;
        private ToolStripMenuItem funcionárioPartTimeToolStripMenuItem;
        private ToolStripMenuItem diretorToolStripMenuItem;
        private Button createContrato;
        private Label ContratoLabel1;
        private Label HorasLabel1;
        private Label label1;
        private TextBox textHoras1;
        private Button Deletebutton1;
        private Button Editbutton1;
        private Button Addbutton1;
    }
}