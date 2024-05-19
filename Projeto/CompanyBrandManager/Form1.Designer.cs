namespace CompanyBrandManager
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlLojasPessoas = new System.Windows.Forms.TabControl();
            this.pessoasTab = new System.Windows.Forms.TabPage();
            this.fimContratoTxt = new System.Windows.Forms.TextBox();
            this.inicioContratoTxt = new System.Windows.Forms.TextBox();
            this.fimContratoLabel = new System.Windows.Forms.Label();
            this.inicioContratoLabel = new System.Windows.Forms.Label();
            this.deleteButtonPessoa = new System.Windows.Forms.Button();
            this.editButtonPessoa = new System.Windows.Forms.Button();
            this.addButtonPessoa = new System.Windows.Forms.Button();
            this.lojaTxtPessoa = new System.Windows.Forms.TextBox();
            this.lojaLabelPessoa = new System.Windows.Forms.Label();
            this.contratoLabelPessoa = new System.Windows.Forms.Label();
            this.horasTxtPessoa = new System.Windows.Forms.TextBox();
            this.horasLabelPessoa = new System.Windows.Forms.Label();
            this.eurosign = new System.Windows.Forms.Label();
            this.salarioTxtPessoa = new System.Windows.Forms.TextBox();
            this.salarioLabelPessoa = new System.Windows.Forms.Label();
            this.codpostalTxtPessoa = new System.Windows.Forms.TextBox();
            this.codpostalLabelPessoa = new System.Windows.Forms.Label();
            this.localidadeTxtPessoa = new System.Windows.Forms.TextBox();
            this.loacalidadeLabelPessoa = new System.Windows.Forms.Label();
            this.ruaTxtPessoa = new System.Windows.Forms.TextBox();
            this.ruaLabelPessoa = new System.Windows.Forms.Label();
            this.telefoneTxtPessoa = new System.Windows.Forms.TextBox();
            this.telefoneLabelPessoa = new System.Windows.Forms.Label();
            this.emailTxtPessoa = new System.Windows.Forms.TextBox();
            this.emailLabelPessoa = new System.Windows.Forms.Label();
            this.sexoTxtPessoa = new System.Windows.Forms.TextBox();
            this.SexoLabelPessoa = new System.Windows.Forms.Label();
            this.PessoasList = new System.Windows.Forms.ListBox();
            this.nomeTxtPessoa = new System.Windows.Forms.TextBox();
            this.NomeLabelPessoa = new System.Windows.Forms.Label();
            this.nifTxtPessoa = new System.Windows.Forms.TextBox();
            this.nifLabelPessoa = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionárioEfetivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionárioPartTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diretorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diretorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efetivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerFiltroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lojasTab = new System.Windows.Forms.TabPage();
            this.gerenteTxtLoja = new System.Windows.Forms.TextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.adicionarLojaToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsButtonLoja = new System.Windows.Forms.Button();
            this.deleteButtonLoja = new System.Windows.Forms.Button();
            this.editButtonLoja = new System.Windows.Forms.Button();
            this.addButtonLoja = new System.Windows.Forms.Button();
            this.gerenteLabelLoja = new System.Windows.Forms.Label();
            this.subempresaTxtLoja = new System.Windows.Forms.TextBox();
            this.subempresaLabelLoja = new System.Windows.Forms.Label();
            this.codpostalTxtLoja = new System.Windows.Forms.TextBox();
            this.codpostalLabelLoja = new System.Windows.Forms.Label();
            this.localidadeTxtLoja = new System.Windows.Forms.TextBox();
            this.localidadeLabelLoja = new System.Windows.Forms.Label();
            this.ruaTxtLoja = new System.Windows.Forms.TextBox();
            this.ruaLabelLoja = new System.Windows.Forms.Label();
            this.telefoneTxtLoja = new System.Windows.Forms.TextBox();
            this.telefoneLabelLoja = new System.Windows.Forms.Label();
            this.LojasList = new System.Windows.Forms.ListBox();
            this.tabControlLojasPessoas.SuspendLayout();
            this.pessoasTab.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.lojasTab.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlLojasPessoas
            // 
            this.tabControlLojasPessoas.Controls.Add(this.pessoasTab);
            this.tabControlLojasPessoas.Controls.Add(this.lojasTab);
            this.tabControlLojasPessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlLojasPessoas.Location = new System.Drawing.Point(28, 25);
            this.tabControlLojasPessoas.Name = "tabControlLojasPessoas";
            this.tabControlLojasPessoas.SelectedIndex = 0;
            this.tabControlLojasPessoas.Size = new System.Drawing.Size(1206, 619);
            this.tabControlLojasPessoas.TabIndex = 0;
            this.tabControlLojasPessoas.Click += new System.EventHandler(this.TabControlPessoasLojas_Click);
            // 
            // pessoasTab
            // 
            this.pessoasTab.Controls.Add(this.fimContratoTxt);
            this.pessoasTab.Controls.Add(this.inicioContratoTxt);
            this.pessoasTab.Controls.Add(this.fimContratoLabel);
            this.pessoasTab.Controls.Add(this.inicioContratoLabel);
            this.pessoasTab.Controls.Add(this.deleteButtonPessoa);
            this.pessoasTab.Controls.Add(this.editButtonPessoa);
            this.pessoasTab.Controls.Add(this.addButtonPessoa);
            this.pessoasTab.Controls.Add(this.lojaTxtPessoa);
            this.pessoasTab.Controls.Add(this.lojaLabelPessoa);
            this.pessoasTab.Controls.Add(this.contratoLabelPessoa);
            this.pessoasTab.Controls.Add(this.horasTxtPessoa);
            this.pessoasTab.Controls.Add(this.horasLabelPessoa);
            this.pessoasTab.Controls.Add(this.eurosign);
            this.pessoasTab.Controls.Add(this.salarioTxtPessoa);
            this.pessoasTab.Controls.Add(this.salarioLabelPessoa);
            this.pessoasTab.Controls.Add(this.codpostalTxtPessoa);
            this.pessoasTab.Controls.Add(this.codpostalLabelPessoa);
            this.pessoasTab.Controls.Add(this.localidadeTxtPessoa);
            this.pessoasTab.Controls.Add(this.loacalidadeLabelPessoa);
            this.pessoasTab.Controls.Add(this.ruaTxtPessoa);
            this.pessoasTab.Controls.Add(this.ruaLabelPessoa);
            this.pessoasTab.Controls.Add(this.telefoneTxtPessoa);
            this.pessoasTab.Controls.Add(this.telefoneLabelPessoa);
            this.pessoasTab.Controls.Add(this.emailTxtPessoa);
            this.pessoasTab.Controls.Add(this.emailLabelPessoa);
            this.pessoasTab.Controls.Add(this.sexoTxtPessoa);
            this.pessoasTab.Controls.Add(this.SexoLabelPessoa);
            this.pessoasTab.Controls.Add(this.PessoasList);
            this.pessoasTab.Controls.Add(this.nomeTxtPessoa);
            this.pessoasTab.Controls.Add(this.NomeLabelPessoa);
            this.pessoasTab.Controls.Add(this.nifTxtPessoa);
            this.pessoasTab.Controls.Add(this.nifLabelPessoa);
            this.pessoasTab.Controls.Add(this.menuStrip1);
            this.pessoasTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pessoasTab.Location = new System.Drawing.Point(4, 34);
            this.pessoasTab.Name = "pessoasTab";
            this.pessoasTab.Padding = new System.Windows.Forms.Padding(3);
            this.pessoasTab.Size = new System.Drawing.Size(1198, 581);
            this.pessoasTab.TabIndex = 0;
            this.pessoasTab.Text = "Pessoas";
            this.pessoasTab.UseVisualStyleBackColor = true;
            // 
            // fimContratoTxt
            // 
            this.fimContratoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fimContratoTxt.Location = new System.Drawing.Point(182, 422);
            this.fimContratoTxt.Name = "fimContratoTxt";
            this.fimContratoTxt.Size = new System.Drawing.Size(141, 30);
            this.fimContratoTxt.TabIndex = 34;
            this.fimContratoTxt.Visible = false;
            this.fimContratoTxt.TextChanged += new System.EventHandler(this.fimContratoTxt_TextChanged);
            // 
            // inicioContratoTxt
            // 
            this.inicioContratoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioContratoTxt.Location = new System.Drawing.Point(182, 385);
            this.inicioContratoTxt.Name = "inicioContratoTxt";
            this.inicioContratoTxt.Size = new System.Drawing.Size(141, 30);
            this.inicioContratoTxt.TabIndex = 33;
            this.inicioContratoTxt.Visible = false;
            // 
            // fimContratoLabel
            // 
            this.fimContratoLabel.AutoSize = true;
            this.fimContratoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fimContratoLabel.Location = new System.Drawing.Point(67, 422);
            this.fimContratoLabel.Name = "fimContratoLabel";
            this.fimContratoLabel.Size = new System.Drawing.Size(96, 25);
            this.fimContratoLabel.TabIndex = 32;
            this.fimContratoLabel.Text = "Data Fim:";
            this.fimContratoLabel.Visible = false;
            // 
            // inicioContratoLabel
            // 
            this.inicioContratoLabel.AutoSize = true;
            this.inicioContratoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inicioContratoLabel.Location = new System.Drawing.Point(67, 385);
            this.inicioContratoLabel.Name = "inicioContratoLabel";
            this.inicioContratoLabel.Size = new System.Drawing.Size(109, 25);
            this.inicioContratoLabel.TabIndex = 31;
            this.inicioContratoLabel.Text = "Data Início:";
            this.inicioContratoLabel.Visible = false;
            // 
            // deleteButtonPessoa
            // 
            this.deleteButtonPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButtonPessoa.Location = new System.Drawing.Point(480, 488);
            this.deleteButtonPessoa.Name = "deleteButtonPessoa";
            this.deleteButtonPessoa.Size = new System.Drawing.Size(120, 45);
            this.deleteButtonPessoa.TabIndex = 29;
            this.deleteButtonPessoa.Text = "Delete";
            this.deleteButtonPessoa.UseVisualStyleBackColor = true;
            this.deleteButtonPessoa.Click += new System.EventHandler(this.DeleteButtonPessoa_Click);
            // 
            // editButtonPessoa
            // 
            this.editButtonPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButtonPessoa.Location = new System.Drawing.Point(275, 488);
            this.editButtonPessoa.Name = "editButtonPessoa";
            this.editButtonPessoa.Size = new System.Drawing.Size(120, 45);
            this.editButtonPessoa.TabIndex = 28;
            this.editButtonPessoa.Text = "Edit";
            this.editButtonPessoa.UseVisualStyleBackColor = true;
            this.editButtonPessoa.Click += new System.EventHandler(this.EditButtonPessoa_Click);
            // 
            // addButtonPessoa
            // 
            this.addButtonPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButtonPessoa.Location = new System.Drawing.Point(72, 488);
            this.addButtonPessoa.Name = "addButtonPessoa";
            this.addButtonPessoa.Size = new System.Drawing.Size(120, 45);
            this.addButtonPessoa.TabIndex = 27;
            this.addButtonPessoa.Text = "Add";
            this.addButtonPessoa.UseVisualStyleBackColor = true;
            this.addButtonPessoa.Click += new System.EventHandler(this.AddButtonPessoa_Click);
            // 
            // lojaTxtPessoa
            // 
            this.lojaTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lojaTxtPessoa.Location = new System.Drawing.Point(426, 360);
            this.lojaTxtPessoa.Name = "lojaTxtPessoa";
            this.lojaTxtPessoa.Size = new System.Drawing.Size(69, 30);
            this.lojaTxtPessoa.TabIndex = 26;
            this.lojaTxtPessoa.Visible = false;
            // 
            // lojaLabelPessoa
            // 
            this.lojaLabelPessoa.AutoSize = true;
            this.lojaLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lojaLabelPessoa.Location = new System.Drawing.Point(365, 360);
            this.lojaLabelPessoa.Name = "lojaLabelPessoa";
            this.lojaLabelPessoa.Size = new System.Drawing.Size(55, 25);
            this.lojaLabelPessoa.TabIndex = 25;
            this.lojaLabelPessoa.Text = "Loja:";
            this.lojaLabelPessoa.Visible = false;
            // 
            // contratoLabelPessoa
            // 
            this.contratoLabelPessoa.AutoSize = true;
            this.contratoLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contratoLabelPessoa.Location = new System.Drawing.Point(33, 360);
            this.contratoLabelPessoa.Name = "contratoLabelPessoa";
            this.contratoLabelPessoa.Size = new System.Drawing.Size(93, 25);
            this.contratoLabelPessoa.TabIndex = 22;
            this.contratoLabelPessoa.Text = "Contrato:";
            this.contratoLabelPessoa.Visible = false;
            // 
            // horasTxtPessoa
            // 
            this.horasTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horasTxtPessoa.Location = new System.Drawing.Point(530, 300);
            this.horasTxtPessoa.Name = "horasTxtPessoa";
            this.horasTxtPessoa.Size = new System.Drawing.Size(70, 30);
            this.horasTxtPessoa.TabIndex = 21;
            this.horasTxtPessoa.Visible = false;
            // 
            // horasLabelPessoa
            // 
            this.horasLabelPessoa.AutoSize = true;
            this.horasLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horasLabelPessoa.Location = new System.Drawing.Point(365, 300);
            this.horasLabelPessoa.Name = "horasLabelPessoa";
            this.horasLabelPessoa.Size = new System.Drawing.Size(163, 25);
            this.horasLabelPessoa.TabIndex = 20;
            this.horasLabelPessoa.Text = "Horas Semanais:";
            this.horasLabelPessoa.Visible = false;
            // 
            // eurosign
            // 
            this.eurosign.AutoSize = true;
            this.eurosign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eurosign.Location = new System.Drawing.Point(210, 304);
            this.eurosign.Name = "eurosign";
            this.eurosign.Size = new System.Drawing.Size(23, 25);
            this.eurosign.TabIndex = 19;
            this.eurosign.Text = "€";
            // 
            // salarioTxtPessoa
            // 
            this.salarioTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salarioTxtPessoa.Location = new System.Drawing.Point(118, 301);
            this.salarioTxtPessoa.Name = "salarioTxtPessoa";
            this.salarioTxtPessoa.Size = new System.Drawing.Size(86, 30);
            this.salarioTxtPessoa.TabIndex = 18;
            // 
            // salarioLabelPessoa
            // 
            this.salarioLabelPessoa.AutoSize = true;
            this.salarioLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salarioLabelPessoa.Location = new System.Drawing.Point(33, 300);
            this.salarioLabelPessoa.Name = "salarioLabelPessoa";
            this.salarioLabelPessoa.Size = new System.Drawing.Size(79, 25);
            this.salarioLabelPessoa.TabIndex = 17;
            this.salarioLabelPessoa.Text = "Salário:";
            // 
            // codpostalTxtPessoa
            // 
            this.codpostalTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codpostalTxtPessoa.Location = new System.Drawing.Point(480, 239);
            this.codpostalTxtPessoa.Name = "codpostalTxtPessoa";
            this.codpostalTxtPessoa.Size = new System.Drawing.Size(124, 30);
            this.codpostalTxtPessoa.TabIndex = 16;
            // 
            // codpostalLabelPessoa
            // 
            this.codpostalLabelPessoa.AutoSize = true;
            this.codpostalLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codpostalLabelPessoa.Location = new System.Drawing.Point(365, 239);
            this.codpostalLabelPessoa.Name = "codpostalLabelPessoa";
            this.codpostalLabelPessoa.Size = new System.Drawing.Size(109, 25);
            this.codpostalLabelPessoa.TabIndex = 15;
            this.codpostalLabelPessoa.Text = "CodPostal:";
            // 
            // localidadeTxtPessoa
            // 
            this.localidadeTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localidadeTxtPessoa.Location = new System.Drawing.Point(152, 239);
            this.localidadeTxtPessoa.Name = "localidadeTxtPessoa";
            this.localidadeTxtPessoa.Size = new System.Drawing.Size(194, 30);
            this.localidadeTxtPessoa.TabIndex = 14;
            // 
            // loacalidadeLabelPessoa
            // 
            this.loacalidadeLabelPessoa.AutoSize = true;
            this.loacalidadeLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loacalidadeLabelPessoa.Location = new System.Drawing.Point(33, 239);
            this.loacalidadeLabelPessoa.Name = "loacalidadeLabelPessoa";
            this.loacalidadeLabelPessoa.Size = new System.Drawing.Size(113, 25);
            this.loacalidadeLabelPessoa.TabIndex = 13;
            this.loacalidadeLabelPessoa.Text = "Localidade:";
            // 
            // ruaTxtPessoa
            // 
            this.ruaTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruaTxtPessoa.Location = new System.Drawing.Point(341, 176);
            this.ruaTxtPessoa.Name = "ruaTxtPessoa";
            this.ruaTxtPessoa.Size = new System.Drawing.Size(297, 30);
            this.ruaTxtPessoa.TabIndex = 12;
            // 
            // ruaLabelPessoa
            // 
            this.ruaLabelPessoa.AutoSize = true;
            this.ruaLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruaLabelPessoa.Location = new System.Drawing.Point(270, 176);
            this.ruaLabelPessoa.Name = "ruaLabelPessoa";
            this.ruaLabelPessoa.Size = new System.Drawing.Size(53, 25);
            this.ruaLabelPessoa.TabIndex = 11;
            this.ruaLabelPessoa.Text = "Rua:";
            // 
            // telefoneTxtPessoa
            // 
            this.telefoneTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefoneTxtPessoa.Location = new System.Drawing.Point(132, 176);
            this.telefoneTxtPessoa.Name = "telefoneTxtPessoa";
            this.telefoneTxtPessoa.Size = new System.Drawing.Size(127, 30);
            this.telefoneTxtPessoa.TabIndex = 10;
            // 
            // telefoneLabelPessoa
            // 
            this.telefoneLabelPessoa.AutoSize = true;
            this.telefoneLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefoneLabelPessoa.Location = new System.Drawing.Point(33, 176);
            this.telefoneLabelPessoa.Name = "telefoneLabelPessoa";
            this.telefoneLabelPessoa.Size = new System.Drawing.Size(95, 25);
            this.telefoneLabelPessoa.TabIndex = 9;
            this.telefoneLabelPessoa.Text = "Telefone:";
            // 
            // emailTxtPessoa
            // 
            this.emailTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTxtPessoa.Location = new System.Drawing.Point(341, 116);
            this.emailTxtPessoa.Name = "emailTxtPessoa";
            this.emailTxtPessoa.Size = new System.Drawing.Size(297, 30);
            this.emailTxtPessoa.TabIndex = 8;
            // 
            // emailLabelPessoa
            // 
            this.emailLabelPessoa.AutoSize = true;
            this.emailLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabelPessoa.Location = new System.Drawing.Point(265, 116);
            this.emailLabelPessoa.Name = "emailLabelPessoa";
            this.emailLabelPessoa.Size = new System.Drawing.Size(66, 25);
            this.emailLabelPessoa.TabIndex = 7;
            this.emailLabelPessoa.Text = "Email:";
            // 
            // sexoTxtPessoa
            // 
            this.sexoTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexoTxtPessoa.Location = new System.Drawing.Point(103, 113);
            this.sexoTxtPessoa.Name = "sexoTxtPessoa";
            this.sexoTxtPessoa.Size = new System.Drawing.Size(32, 30);
            this.sexoTxtPessoa.TabIndex = 6;
            // 
            // SexoLabelPessoa
            // 
            this.SexoLabelPessoa.AutoSize = true;
            this.SexoLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SexoLabelPessoa.Location = new System.Drawing.Point(33, 113);
            this.SexoLabelPessoa.Name = "SexoLabelPessoa";
            this.SexoLabelPessoa.Size = new System.Drawing.Size(64, 25);
            this.SexoLabelPessoa.TabIndex = 5;
            this.SexoLabelPessoa.Text = "Sexo:";
            // 
            // PessoasList
            // 
            this.PessoasList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PessoasList.FormattingEnabled = true;
            this.PessoasList.ItemHeight = 25;
            this.PessoasList.Location = new System.Drawing.Point(674, 48);
            this.PessoasList.Name = "PessoasList";
            this.PessoasList.Size = new System.Drawing.Size(505, 504);
            this.PessoasList.TabIndex = 4;
            this.PessoasList.SelectedIndexChanged += new System.EventHandler(this.PessoasList_SelectedIndexChanged);
            // 
            // nomeTxtPessoa
            // 
            this.nomeTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeTxtPessoa.Location = new System.Drawing.Point(341, 48);
            this.nomeTxtPessoa.Name = "nomeTxtPessoa";
            this.nomeTxtPessoa.Size = new System.Drawing.Size(297, 30);
            this.nomeTxtPessoa.TabIndex = 3;
            // 
            // NomeLabelPessoa
            // 
            this.NomeLabelPessoa.AutoSize = true;
            this.NomeLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomeLabelPessoa.Location = new System.Drawing.Point(265, 48);
            this.NomeLabelPessoa.Name = "NomeLabelPessoa";
            this.NomeLabelPessoa.Size = new System.Drawing.Size(70, 25);
            this.NomeLabelPessoa.TabIndex = 2;
            this.NomeLabelPessoa.Text = "Nome:";
            // 
            // nifTxtPessoa
            // 
            this.nifTxtPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nifTxtPessoa.Location = new System.Drawing.Point(88, 48);
            this.nifTxtPessoa.Name = "nifTxtPessoa";
            this.nifTxtPessoa.Size = new System.Drawing.Size(171, 30);
            this.nifTxtPessoa.TabIndex = 1;
            // 
            // nifLabelPessoa
            // 
            this.nifLabelPessoa.AutoSize = true;
            this.nifLabelPessoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nifLabelPessoa.Location = new System.Drawing.Point(33, 48);
            this.nifLabelPessoa.Name = "nifLabelPessoa";
            this.nifLabelPessoa.Size = new System.Drawing.Size(49, 25);
            this.nifLabelPessoa.TabIndex = 0;
            this.nifLabelPessoa.Text = "NIF:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.filtrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1192, 36);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionárioEfetivoToolStripMenuItem,
            this.funcionárioPartTimeToolStripMenuItem,
            this.diretorToolStripMenuItem});
            this.adicionarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(110, 32);
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripPessoa_Click);
            // 
            // funcionárioEfetivoToolStripMenuItem
            // 
            this.funcionárioEfetivoToolStripMenuItem.Name = "funcionárioEfetivoToolStripMenuItem";
            this.funcionárioEfetivoToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.funcionárioEfetivoToolStripMenuItem.Text = "Funcionário Efetivo";
            this.funcionárioEfetivoToolStripMenuItem.Click += new System.EventHandler(this.AddEfetivo_Click);
            // 
            // funcionárioPartTimeToolStripMenuItem
            // 
            this.funcionárioPartTimeToolStripMenuItem.Name = "funcionárioPartTimeToolStripMenuItem";
            this.funcionárioPartTimeToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.funcionárioPartTimeToolStripMenuItem.Text = "Funcionário Part-Time";
            this.funcionárioPartTimeToolStripMenuItem.Click += new System.EventHandler(this.AddPartTime_Click);
            // 
            // diretorToolStripMenuItem
            // 
            this.diretorToolStripMenuItem.Name = "diretorToolStripMenuItem";
            this.diretorToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.diretorToolStripMenuItem.Text = "Diretor";
            // 
            // filtrarToolStripMenuItem
            // 
            this.filtrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diretorToolStripMenuItem1,
            this.funcionarioToolStripMenuItem,
            this.removerFiltroToolStripMenuItem});
            this.filtrarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filtrarToolStripMenuItem.Name = "filtrarToolStripMenuItem";
            this.filtrarToolStripMenuItem.Size = new System.Drawing.Size(77, 32);
            this.filtrarToolStripMenuItem.Text = "Filtrar";
            // 
            // diretorToolStripMenuItem1
            // 
            this.diretorToolStripMenuItem1.Name = "diretorToolStripMenuItem1";
            this.diretorToolStripMenuItem1.Size = new System.Drawing.Size(226, 32);
            this.diretorToolStripMenuItem1.Text = "Diretor";
            this.diretorToolStripMenuItem1.Click += new System.EventHandler(this.PessoaFilterByDiretor_Click);
            // 
            // funcionarioToolStripMenuItem
            // 
            this.funcionarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.efetivoToolStripMenuItem,
            this.partTimeToolStripMenuItem});
            this.funcionarioToolStripMenuItem.Name = "funcionarioToolStripMenuItem";
            this.funcionarioToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.funcionarioToolStripMenuItem.Text = "Funcionario";
            // 
            // efetivoToolStripMenuItem
            // 
            this.efetivoToolStripMenuItem.Name = "efetivoToolStripMenuItem";
            this.efetivoToolStripMenuItem.Size = new System.Drawing.Size(182, 32);
            this.efetivoToolStripMenuItem.Text = "Efetivo";
            this.efetivoToolStripMenuItem.Click += new System.EventHandler(this.PessoaFilterByEfetivo_Click);
            // 
            // partTimeToolStripMenuItem
            // 
            this.partTimeToolStripMenuItem.Name = "partTimeToolStripMenuItem";
            this.partTimeToolStripMenuItem.Size = new System.Drawing.Size(182, 32);
            this.partTimeToolStripMenuItem.Text = "Part-Time";
            this.partTimeToolStripMenuItem.Click += new System.EventHandler(this.PessoaFilterByPartTime_Click);
            // 
            // removerFiltroToolStripMenuItem
            // 
            this.removerFiltroToolStripMenuItem.Name = "removerFiltroToolStripMenuItem";
            this.removerFiltroToolStripMenuItem.Size = new System.Drawing.Size(226, 32);
            this.removerFiltroToolStripMenuItem.Text = "Remover Filtro";
            this.removerFiltroToolStripMenuItem.Click += new System.EventHandler(this.PessoaRemoveFilter_Click);
            // 
            // lojasTab
            // 
            this.lojasTab.Controls.Add(this.gerenteTxtLoja);
            this.lojasTab.Controls.Add(this.menuStrip2);
            this.lojasTab.Controls.Add(this.detailsButtonLoja);
            this.lojasTab.Controls.Add(this.deleteButtonLoja);
            this.lojasTab.Controls.Add(this.editButtonLoja);
            this.lojasTab.Controls.Add(this.addButtonLoja);
            this.lojasTab.Controls.Add(this.gerenteLabelLoja);
            this.lojasTab.Controls.Add(this.subempresaTxtLoja);
            this.lojasTab.Controls.Add(this.subempresaLabelLoja);
            this.lojasTab.Controls.Add(this.codpostalTxtLoja);
            this.lojasTab.Controls.Add(this.codpostalLabelLoja);
            this.lojasTab.Controls.Add(this.localidadeTxtLoja);
            this.lojasTab.Controls.Add(this.localidadeLabelLoja);
            this.lojasTab.Controls.Add(this.ruaTxtLoja);
            this.lojasTab.Controls.Add(this.ruaLabelLoja);
            this.lojasTab.Controls.Add(this.telefoneTxtLoja);
            this.lojasTab.Controls.Add(this.telefoneLabelLoja);
            this.lojasTab.Controls.Add(this.LojasList);
            this.lojasTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lojasTab.Location = new System.Drawing.Point(4, 34);
            this.lojasTab.Name = "lojasTab";
            this.lojasTab.Padding = new System.Windows.Forms.Padding(3);
            this.lojasTab.Size = new System.Drawing.Size(1198, 581);
            this.lojasTab.TabIndex = 1;
            this.lojasTab.Text = "Lojas";
            this.lojasTab.UseVisualStyleBackColor = true;
            // 
            // gerenteTxtLoja
            // 
            this.gerenteTxtLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerenteTxtLoja.Location = new System.Drawing.Point(449, 260);
            this.gerenteTxtLoja.Name = "gerenteTxtLoja";
            this.gerenteTxtLoja.Size = new System.Drawing.Size(190, 30);
            this.gerenteTxtLoja.TabIndex = 42;
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarLojaToolStrip});
            this.menuStrip2.Location = new System.Drawing.Point(3, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1192, 36);
            this.menuStrip2.TabIndex = 41;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // adicionarLojaToolStrip
            // 
            this.adicionarLojaToolStrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adicionarLojaToolStrip.Name = "adicionarLojaToolStrip";
            this.adicionarLojaToolStrip.Size = new System.Drawing.Size(110, 32);
            this.adicionarLojaToolStrip.Text = "Adicionar";
            this.adicionarLojaToolStrip.Click += new System.EventHandler(this.AddToolStripLoja_Click);
            // 
            // detailsButtonLoja
            // 
            this.detailsButtonLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsButtonLoja.Location = new System.Drawing.Point(493, 457);
            this.detailsButtonLoja.Name = "detailsButtonLoja";
            this.detailsButtonLoja.Size = new System.Drawing.Size(120, 45);
            this.detailsButtonLoja.TabIndex = 40;
            this.detailsButtonLoja.Text = "Details";
            this.detailsButtonLoja.UseVisualStyleBackColor = true;
            // 
            // deleteButtonLoja
            // 
            this.deleteButtonLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButtonLoja.Location = new System.Drawing.Point(342, 457);
            this.deleteButtonLoja.Name = "deleteButtonLoja";
            this.deleteButtonLoja.Size = new System.Drawing.Size(120, 45);
            this.deleteButtonLoja.TabIndex = 35;
            this.deleteButtonLoja.Text = "Delete";
            this.deleteButtonLoja.UseVisualStyleBackColor = true;
            this.deleteButtonLoja.Click += new System.EventHandler(this.DeleteButtonLoja_Click);
            // 
            // editButtonLoja
            // 
            this.editButtonLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButtonLoja.Location = new System.Drawing.Point(187, 457);
            this.editButtonLoja.Name = "editButtonLoja";
            this.editButtonLoja.Size = new System.Drawing.Size(120, 45);
            this.editButtonLoja.TabIndex = 35;
            this.editButtonLoja.Text = "Edit";
            this.editButtonLoja.UseVisualStyleBackColor = true;
            // 
            // addButtonLoja
            // 
            this.addButtonLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButtonLoja.Location = new System.Drawing.Point(33, 457);
            this.addButtonLoja.Name = "addButtonLoja";
            this.addButtonLoja.Size = new System.Drawing.Size(120, 45);
            this.addButtonLoja.TabIndex = 35;
            this.addButtonLoja.Text = "Add";
            this.addButtonLoja.UseVisualStyleBackColor = true;
            this.addButtonLoja.Click += new System.EventHandler(this.AddButtonLoja_Click);
            // 
            // gerenteLabelLoja
            // 
            this.gerenteLabelLoja.AutoSize = true;
            this.gerenteLabelLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gerenteLabelLoja.Location = new System.Drawing.Point(355, 263);
            this.gerenteLabelLoja.Name = "gerenteLabelLoja";
            this.gerenteLabelLoja.Size = new System.Drawing.Size(88, 25);
            this.gerenteLabelLoja.TabIndex = 38;
            this.gerenteLabelLoja.Text = "Gerente:";
            // 
            // subempresaTxtLoja
            // 
            this.subempresaTxtLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subempresaTxtLoja.Location = new System.Drawing.Point(159, 260);
            this.subempresaTxtLoja.Name = "subempresaTxtLoja";
            this.subempresaTxtLoja.Size = new System.Drawing.Size(69, 30);
            this.subempresaTxtLoja.TabIndex = 35;
            // 
            // subempresaLabelLoja
            // 
            this.subempresaLabelLoja.AutoSize = true;
            this.subempresaLabelLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subempresaLabelLoja.Location = new System.Drawing.Point(21, 263);
            this.subempresaLabelLoja.Name = "subempresaLabelLoja";
            this.subempresaLabelLoja.Size = new System.Drawing.Size(132, 25);
            this.subempresaLabelLoja.TabIndex = 37;
            this.subempresaLabelLoja.Text = "SubEmpresa:";
            // 
            // codpostalTxtLoja
            // 
            this.codpostalTxtLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codpostalTxtLoja.Location = new System.Drawing.Point(470, 189);
            this.codpostalTxtLoja.Name = "codpostalTxtLoja";
            this.codpostalTxtLoja.Size = new System.Drawing.Size(124, 30);
            this.codpostalTxtLoja.TabIndex = 35;
            // 
            // codpostalLabelLoja
            // 
            this.codpostalLabelLoja.AutoSize = true;
            this.codpostalLabelLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codpostalLabelLoja.Location = new System.Drawing.Point(355, 192);
            this.codpostalLabelLoja.Name = "codpostalLabelLoja";
            this.codpostalLabelLoja.Size = new System.Drawing.Size(109, 25);
            this.codpostalLabelLoja.TabIndex = 35;
            this.codpostalLabelLoja.Text = "CodPostal:";
            // 
            // localidadeTxtLoja
            // 
            this.localidadeTxtLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localidadeTxtLoja.Location = new System.Drawing.Point(140, 189);
            this.localidadeTxtLoja.Name = "localidadeTxtLoja";
            this.localidadeTxtLoja.Size = new System.Drawing.Size(194, 30);
            this.localidadeTxtLoja.TabIndex = 35;
            // 
            // localidadeLabelLoja
            // 
            this.localidadeLabelLoja.AutoSize = true;
            this.localidadeLabelLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localidadeLabelLoja.Location = new System.Drawing.Point(21, 192);
            this.localidadeLabelLoja.Name = "localidadeLabelLoja";
            this.localidadeLabelLoja.Size = new System.Drawing.Size(113, 25);
            this.localidadeLabelLoja.TabIndex = 35;
            this.localidadeLabelLoja.Text = "Localidade:";
            // 
            // ruaTxtLoja
            // 
            this.ruaTxtLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruaTxtLoja.Location = new System.Drawing.Point(342, 108);
            this.ruaTxtLoja.Name = "ruaTxtLoja";
            this.ruaTxtLoja.Size = new System.Drawing.Size(297, 30);
            this.ruaTxtLoja.TabIndex = 35;
            // 
            // ruaLabelLoja
            // 
            this.ruaLabelLoja.AutoSize = true;
            this.ruaLabelLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruaLabelLoja.Location = new System.Drawing.Point(283, 108);
            this.ruaLabelLoja.Name = "ruaLabelLoja";
            this.ruaLabelLoja.Size = new System.Drawing.Size(53, 25);
            this.ruaLabelLoja.TabIndex = 36;
            this.ruaLabelLoja.Text = "Rua:";
            // 
            // telefoneTxtLoja
            // 
            this.telefoneTxtLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefoneTxtLoja.Location = new System.Drawing.Point(122, 108);
            this.telefoneTxtLoja.Name = "telefoneTxtLoja";
            this.telefoneTxtLoja.Size = new System.Drawing.Size(127, 30);
            this.telefoneTxtLoja.TabIndex = 35;
            // 
            // telefoneLabelLoja
            // 
            this.telefoneLabelLoja.AutoSize = true;
            this.telefoneLabelLoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefoneLabelLoja.Location = new System.Drawing.Point(21, 108);
            this.telefoneLabelLoja.Name = "telefoneLabelLoja";
            this.telefoneLabelLoja.Size = new System.Drawing.Size(95, 25);
            this.telefoneLabelLoja.TabIndex = 35;
            this.telefoneLabelLoja.Text = "Telefone:";
            // 
            // LojasList
            // 
            this.LojasList.FormattingEnabled = true;
            this.LojasList.ItemHeight = 25;
            this.LojasList.Location = new System.Drawing.Point(664, 48);
            this.LojasList.Name = "LojasList";
            this.LojasList.Size = new System.Drawing.Size(510, 504);
            this.LojasList.TabIndex = 0;
            this.LojasList.SelectedIndexChanged += new System.EventHandler(this.LojasList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 670);
            this.Controls.Add(this.tabControlLojasPessoas);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CompanyBrandManager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlLojasPessoas.ResumeLayout(false);
            this.pessoasTab.ResumeLayout(false);
            this.pessoasTab.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.lojasTab.ResumeLayout(false);
            this.lojasTab.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlLojasPessoas;
        private System.Windows.Forms.TabPage pessoasTab;
        private System.Windows.Forms.Button deleteButtonPessoa;
        private System.Windows.Forms.Button editButtonPessoa;
        private System.Windows.Forms.Button addButtonPessoa;
        private System.Windows.Forms.TextBox lojaTxtPessoa;
        private System.Windows.Forms.Label lojaLabelPessoa;
        private System.Windows.Forms.Label contratoLabelPessoa;
        private System.Windows.Forms.TextBox horasTxtPessoa;
        private System.Windows.Forms.Label horasLabelPessoa;
        private System.Windows.Forms.Label eurosign;
        private System.Windows.Forms.TextBox salarioTxtPessoa;
        private System.Windows.Forms.Label salarioLabelPessoa;
        private System.Windows.Forms.TextBox codpostalTxtPessoa;
        private System.Windows.Forms.Label codpostalLabelPessoa;
        private System.Windows.Forms.TextBox localidadeTxtPessoa;
        private System.Windows.Forms.Label loacalidadeLabelPessoa;
        private System.Windows.Forms.TextBox ruaTxtPessoa;
        private System.Windows.Forms.Label ruaLabelPessoa;
        private System.Windows.Forms.TextBox telefoneTxtPessoa;
        private System.Windows.Forms.Label telefoneLabelPessoa;
        private System.Windows.Forms.TextBox emailTxtPessoa;
        private System.Windows.Forms.Label emailLabelPessoa;
        private System.Windows.Forms.TextBox sexoTxtPessoa;
        private System.Windows.Forms.Label SexoLabelPessoa;
        private System.Windows.Forms.ListBox PessoasList;
        private System.Windows.Forms.TextBox nomeTxtPessoa;
        private System.Windows.Forms.Label NomeLabelPessoa;
        private System.Windows.Forms.TextBox nifTxtPessoa;
        private System.Windows.Forms.Label nifLabelPessoa;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionárioEfetivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionárioPartTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diretorToolStripMenuItem;
        private System.Windows.Forms.TabPage lojasTab;
        private System.Windows.Forms.TextBox fimContratoTxt;
        private System.Windows.Forms.TextBox inicioContratoTxt;
        private System.Windows.Forms.Label fimContratoLabel;
        private System.Windows.Forms.Label inicioContratoLabel;
        private System.Windows.Forms.ToolStripMenuItem filtrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diretorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem funcionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efetivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerFiltroToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem adicionarLojaToolStrip;
        private System.Windows.Forms.Button detailsButtonLoja;
        private System.Windows.Forms.Button deleteButtonLoja;
        private System.Windows.Forms.Button editButtonLoja;
        private System.Windows.Forms.Button addButtonLoja;
        private System.Windows.Forms.Label gerenteLabelLoja;
        private System.Windows.Forms.TextBox subempresaTxtLoja;
        private System.Windows.Forms.Label subempresaLabelLoja;
        private System.Windows.Forms.TextBox codpostalTxtLoja;
        private System.Windows.Forms.Label codpostalLabelLoja;
        private System.Windows.Forms.TextBox localidadeTxtLoja;
        private System.Windows.Forms.Label localidadeLabelLoja;
        private System.Windows.Forms.TextBox ruaTxtLoja;
        private System.Windows.Forms.Label ruaLabelLoja;
        private System.Windows.Forms.TextBox telefoneTxtLoja;
        private System.Windows.Forms.Label telefoneLabelLoja;
        private System.Windows.Forms.ListBox LojasList;
        private System.Windows.Forms.TextBox gerenteTxtLoja;
    }
}

