namespace Pubs_App
{
    partial class FrmDetailed
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
            components = new System.ComponentModel.Container();
            datePub = new DateTimePicker();
            numAdvance = new NumericUpDown();
            numRoyality = new NumericUpDown();
            numPrice = new NumericUpDown();
            numSales = new NumericUpDown();
            lblID = new TextBox();
            txtNotes = new TextBox();
            txtType = new TextBox();
            label10 = new Label();
            BtnSave = new Button();
            cmbPublisher = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTitle = new TextBox();
            titlesBindingSource = new BindingSource(components);
            publishersBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)numAdvance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRoyality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)titlesBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)publishersBindingSource).BeginInit();
            SuspendLayout();
            // 
            // datePub
            // 
            datePub.Location = new Point(175, 478);
            datePub.Margin = new Padding(4);
            datePub.Name = "datePub";
            datePub.Size = new Size(474, 35);
            datePub.TabIndex = 89;
            // 
            // numAdvance
            // 
            numAdvance.Location = new Point(175, 330);
            numAdvance.Margin = new Padding(4);
            numAdvance.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numAdvance.Name = "numAdvance";
            numAdvance.Size = new Size(476, 35);
            numAdvance.TabIndex = 88;
            // 
            // numRoyality
            // 
            numRoyality.Location = new Point(175, 380);
            numRoyality.Margin = new Padding(4);
            numRoyality.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numRoyality.Name = "numRoyality";
            numRoyality.Size = new Size(476, 35);
            numRoyality.TabIndex = 87;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(175, 280);
            numPrice.Margin = new Padding(4);
            numPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(476, 35);
            numPrice.TabIndex = 86;
            // 
            // numSales
            // 
            numSales.Location = new Point(175, 429);
            numSales.Margin = new Padding(4);
            numSales.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numSales.Name = "numSales";
            numSales.Size = new Size(476, 35);
            numSales.TabIndex = 85;
            // 
            // lblID
            // 
            lblID.Location = new Point(175, 80);
            lblID.Margin = new Padding(4);
            lblID.Name = "lblID";
            lblID.Size = new Size(474, 35);
            lblID.TabIndex = 84;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(175, 528);
            txtNotes.Margin = new Padding(4);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(474, 223);
            txtNotes.TabIndex = 83;
            // 
            // txtType
            // 
            txtType.Location = new Point(175, 178);
            txtType.Margin = new Padding(4);
            txtType.Name = "txtType";
            txtType.Size = new Size(474, 35);
            txtType.TabIndex = 82;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(30, 486);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(99, 30);
            label10.TabIndex = 81;
            label10.Text = "Pub Date";
            // 
            // BtnSave
            // 
            BtnSave.Anchor = AnchorStyles.Bottom;
            BtnSave.Location = new Point(510, 759);
            BtnSave.Margin = new Padding(4);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(141, 44);
            BtnSave.TabIndex = 80;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // cmbPublisher
            // 
            cmbPublisher.FormattingEnabled = true;
            cmbPublisher.Location = new Point(175, 230);
            cmbPublisher.Margin = new Padding(4);
            cmbPublisher.Name = "cmbPublisher";
            cmbPublisher.Size = new Size(474, 38);
            cmbPublisher.TabIndex = 79;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(30, 432);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(60, 30);
            label9.TabIndex = 78;
            label9.Text = "Sales";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(30, 134);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(52, 30);
            label8.TabIndex = 77;
            label8.Text = "Title";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(30, 384);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(80, 30);
            label7.TabIndex = 76;
            label7.Text = "Royalty";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 334);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(93, 30);
            label6.TabIndex = 75;
            label6.Text = "Advance";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 531);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(68, 30);
            label5.TabIndex = 74;
            label5.Text = "Notes";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 284);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 30);
            label4.TabIndex = 73;
            label4.Text = "Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 231);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 30);
            label3.TabIndex = 72;
            label3.Text = "Publisher";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 182);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(56, 30);
            label2.TabIndex = 71;
            label2.Text = "Type";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 84);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 30);
            label1.TabIndex = 70;
            label1.Text = "ID";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(175, 129);
            txtTitle.Margin = new Padding(4);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(474, 35);
            txtTitle.TabIndex = 69;
            // 
            // FrmDetailed
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 816);
            Controls.Add(datePub);
            Controls.Add(numAdvance);
            Controls.Add(numRoyality);
            Controls.Add(numPrice);
            Controls.Add(numSales);
            Controls.Add(lblID);
            Controls.Add(txtNotes);
            Controls.Add(txtType);
            Controls.Add(label10);
            Controls.Add(BtnSave);
            Controls.Add(cmbPublisher);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTitle);
            Name = "FrmDetailed";
            Text = "Form1";
            Load += FrmDetailed_Load;
            ((System.ComponentModel.ISupportInitialize)numAdvance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRoyality).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)titlesBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)publishersBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker datePub;
        private NumericUpDown numAdvance;
        private NumericUpDown numRoyality;
        private NumericUpDown numPrice;
        private NumericUpDown numSales;
        private TextBox lblID;
        private TextBox txtNotes;
        private TextBox txtType;
        private Label label10;
        private Button BtnSave;
        private ComboBox cmbPublisher;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTitle;
        private BindingSource titlesBindingSource;
        private BindingSource publishersBindingSource;
    }
}