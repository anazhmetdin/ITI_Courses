namespace ProductsDetailedView
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
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.lblPrdID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.numOrder = new System.Windows.Forms.NumericUpDown();
            this.numReorder = new System.Windows.Forms.NumericUpDown();
            this.checkDiscontinued = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorder)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(188, 73);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.Size = new System.Drawing.Size(317, 27);
            this.txtPrdName.TabIndex = 9;
            // 
            // lblPrdID
            // 
            this.lblPrdID.AutoSize = true;
            this.lblPrdID.Location = new System.Drawing.Point(188, 45);
            this.lblPrdID.Name = "lblPrdID";
            this.lblPrdID.Size = new System.Drawing.Size(50, 20);
            this.lblPrdID.TabIndex = 8;
            this.lblPrdID.Text = "Prd ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Supplier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Unit Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "In Stock";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "On Order";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "Reorder level";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(188, 106);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(317, 28);
            this.cmbSupplier.TabIndex = 27;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(188, 140);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(317, 28);
            this.cmbCategory.TabIndex = 28;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(188, 173);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(317, 27);
            this.txtQuantity.TabIndex = 29;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnSave.Location = new System.Drawing.Point(247, 392);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(94, 29);
            this.BtnSave.TabIndex = 31;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(91, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "Discontinued";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(188, 206);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(317, 27);
            this.numPrice.TabIndex = 38;
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(188, 239);
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(317, 27);
            this.numStock.TabIndex = 39;
            // 
            // numOrder
            // 
            this.numOrder.Location = new System.Drawing.Point(188, 270);
            this.numOrder.Name = "numOrder";
            this.numOrder.Size = new System.Drawing.Size(317, 27);
            this.numOrder.TabIndex = 40;
            // 
            // numReorder
            // 
            this.numReorder.Location = new System.Drawing.Point(188, 303);
            this.numReorder.Name = "numReorder";
            this.numReorder.Size = new System.Drawing.Size(317, 27);
            this.numReorder.TabIndex = 41;
            // 
            // checkDiscontinued
            // 
            this.checkDiscontinued.AutoSize = true;
            this.checkDiscontinued.Location = new System.Drawing.Point(188, 341);
            this.checkDiscontinued.Name = "checkDiscontinued";
            this.checkDiscontinued.Size = new System.Drawing.Size(18, 17);
            this.checkDiscontinued.TabIndex = 42;
            this.checkDiscontinued.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 433);
            this.Controls.Add(this.checkDiscontinued);
            this.Controls.Add(this.numReorder);
            this.Controls.Add(this.numOrder);
            this.Controls.Add(this.numStock);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.lblPrdID);
            this.Name = "Form1";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtPrdName;
        private Label lblPrdID;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cmbSupplier;
        private ComboBox cmbCategory;
        private TextBox txtQuantity;
        private Button BtnSave;
        private Label label10;
        private NumericUpDown numPrice;
        private NumericUpDown numStock;
        private NumericUpDown numOrder;
        private NumericUpDown numReorder;
        private CheckBox checkDiscontinued;
    }
}