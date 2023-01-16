namespace Test.presentation.addNewItem
{
    partial class AddNewItemForm
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
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.linkNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.selectObjectComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.existingObjectLinkNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(466, 90);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(188, 23);
            this.typeTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(402, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "product";
            // 
            // productTextBox
            // 
            this.productTextBox.Location = new System.Drawing.Point(466, 131);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.Size = new System.Drawing.Size(188, 23);
            this.productTextBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(515, 196);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "linkName";
            // 
            // linkNameTextBox
            // 
            this.linkNameTextBox.Location = new System.Drawing.Point(466, 167);
            this.linkNameTextBox.Name = "linkNameTextBox";
            this.linkNameTextBox.Size = new System.Drawing.Size(188, 23);
            this.linkNameTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Создать новый объект";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Добавить существующий";
            // 
            // selectObjectComboBox
            // 
            this.selectObjectComboBox.FormattingEnabled = true;
            this.selectObjectComboBox.Location = new System.Drawing.Point(82, 75);
            this.selectObjectComboBox.Name = "selectObjectComboBox";
            this.selectObjectComboBox.Size = new System.Drawing.Size(188, 23);
            this.selectObjectComboBox.TabIndex = 9;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(130, 134);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "linkName";
            // 
            // existingObjectLinkNameTextBox
            // 
            this.existingObjectLinkNameTextBox.Location = new System.Drawing.Point(82, 104);
            this.existingObjectLinkNameTextBox.Name = "existingObjectLinkNameTextBox";
            this.existingObjectLinkNameTextBox.Size = new System.Drawing.Size(188, 23);
            this.existingObjectLinkNameTextBox.TabIndex = 11;
            // 
            // AddNewItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 427);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.existingObjectLinkNameTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.selectObjectComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkNameTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeTextBox);
            this.Name = "AddNewItemForm";
            this.Text = "AddNewItemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox typeTextBox;
        private Label label1;
        private Label label2;
        private TextBox productTextBox;
        private Button saveButton;
        private Label label3;
        private TextBox linkNameTextBox;
        private Label label4;
        private Label label5;
        private ComboBox selectObjectComboBox;
        private Button addButton;
        private Label label6;
        private TextBox existingObjectLinkNameTextBox;
    }
}