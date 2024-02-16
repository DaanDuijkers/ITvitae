namespace Phoneshop.WinForms
{
    partial class AddPhone
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
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbBrand = new System.Windows.Forms.TextBox();
            this.txbType = new System.Windows.Forms.TextBox();
            this.txbDescription = new System.Windows.Forms.TextBox();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.txbStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Merk:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 346);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(113, 29);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Toepassen";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(131, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Annuleren";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Voorraad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Prijs (exclusief BTW):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Omschrijving:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type:";
            // 
            // txbBrand
            // 
            this.txbBrand.Location = new System.Drawing.Point(12, 35);
            this.txbBrand.Name = "txbBrand";
            this.txbBrand.Size = new System.Drawing.Size(300, 30);
            this.txbBrand.TabIndex = 7;
            // 
            // txbType
            // 
            this.txbType.Location = new System.Drawing.Point(12, 104);
            this.txbType.Name = "txbType";
            this.txbType.Size = new System.Drawing.Size(300, 30);
            this.txbType.TabIndex = 8;
            // 
            // txbDescription
            // 
            this.txbDescription.Location = new System.Drawing.Point(12, 173);
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(300, 30);
            this.txbDescription.TabIndex = 9;
            // 
            // txbPrice
            // 
            this.txbPrice.Location = new System.Drawing.Point(37, 241);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(125, 30);
            this.txbPrice.TabIndex = 10;
            this.txbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPrice_KeyPress);
            // 
            // txbStock
            // 
            this.txbStock.Location = new System.Drawing.Point(12, 310);
            this.txbStock.Name = "txbStock";
            this.txbStock.Size = new System.Drawing.Size(150, 30);
            this.txbStock.TabIndex = 11;
            this.txbStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbStock_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "€";
            // 
            // AddPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 387);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbStock);
            this.Controls.Add(this.txbPrice);
            this.Controls.Add(this.txbDescription);
            this.Controls.Add(this.txbType);
            this.Controls.Add(this.txbBrand);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "AddPhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPhone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbBrand;
        private System.Windows.Forms.TextBox txbType;
        private System.Windows.Forms.TextBox txbDescription;
        private System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.TextBox txbStock;
        private System.Windows.Forms.Label label6;
    }
}