namespace DetailedView
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.cmbPublisher = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.TextBox();
            this.numSales = new System.Windows.Forms.NumericUpDown();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numRoyality = new System.Windows.Forms.NumericUpDown();
            this.numAdvance = new System.Windows.Forms.NumericUpDown();
            this.datePub = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRoyality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdvance)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnSave.Location = new System.Drawing.Point(354, 542);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(94, 29);
            this.BtnSave.TabIndex = 51;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cmbPublisher
            // 
            this.cmbPublisher.FormattingEnabled = true;
            this.cmbPublisher.Location = new System.Drawing.Point(131, 161);
            this.cmbPublisher.Name = "cmbPublisher";
            this.cmbPublisher.Size = new System.Drawing.Size(317, 28);
            this.cmbPublisher.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "Sales";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 44;
            this.label8.Text = "Title";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "Royalty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Advance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Notes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Publisher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "ID";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(131, 94);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(317, 27);
            this.txtTitle.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 52;
            this.label10.Text = "Pub Date";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(131, 127);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(317, 27);
            this.txtType.TabIndex = 54;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(131, 360);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(317, 150);
            this.txtNotes.TabIndex = 56;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(131, 61);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(317, 27);
            this.lblID.TabIndex = 62;
            // 
            // numSales
            // 
            this.numSales.Location = new System.Drawing.Point(131, 294);
            this.numSales.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSales.Name = "numSales";
            this.numSales.Size = new System.Drawing.Size(317, 27);
            this.numSales.TabIndex = 64;
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(131, 195);
            this.numPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(317, 27);
            this.numPrice.TabIndex = 65;
            // 
            // numRoyality
            // 
            this.numRoyality.Location = new System.Drawing.Point(131, 261);
            this.numRoyality.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numRoyality.Name = "numRoyality";
            this.numRoyality.Size = new System.Drawing.Size(317, 27);
            this.numRoyality.TabIndex = 66;
            // 
            // numAdvance
            // 
            this.numAdvance.Location = new System.Drawing.Point(131, 228);
            this.numAdvance.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAdvance.Name = "numAdvance";
            this.numAdvance.Size = new System.Drawing.Size(317, 27);
            this.numAdvance.TabIndex = 67;
            // 
            // datePub
            // 
            this.datePub.Location = new System.Drawing.Point(131, 327);
            this.datePub.Name = "datePub";
            this.datePub.Size = new System.Drawing.Size(317, 27);
            this.datePub.TabIndex = 68;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 583);
            this.Controls.Add(this.datePub);
            this.Controls.Add(this.numAdvance);
            this.Controls.Add(this.numRoyality);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.numSales);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.cmbPublisher);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Name = "Form1";
            this.Text = "Titles Detailed View";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRoyality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAdvance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private Label label10;
        private TextBox txtType;
        private TextBox txtNotes;
        private TextBox lblID;
        private NumericUpDown numSales;
        private NumericUpDown numPrice;
        private NumericUpDown numRoyality;
        private NumericUpDown numAdvance;
        private DateTimePicker datePub;
    }
}