namespace Playload.App.UI
{
    partial class AddEditForm
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
            buttonSave = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxAlias = new TextBox();
            comboBoxType = new ComboBox();
            comboBoxBreed = new ComboBox();
            comboBoxSex = new ComboBox();
            dateTimePickerBirthday = new DateTimePicker();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSave.Location = new Point(23, 273);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(100, 30);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(259, 273);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 30);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(75, 21);
            label1.TabIndex = 2;
            label1.Text = "Кличка: *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(58, 68);
            label2.Name = "label2";
            label2.Size = new Size(40, 21);
            label2.TabIndex = 3;
            label2.Text = "Вид:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(30, 115);
            label3.Name = "label3";
            label3.Size = new Size(68, 21);
            label3.TabIndex = 4;
            label3.Text = "Порода:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(57, 162);
            label4.Name = "label4";
            label4.Size = new Size(41, 21);
            label4.TabIndex = 5;
            label4.Text = "Пол:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(8, 209);
            label5.Name = "label5";
            label5.Size = new Size(90, 21);
            label5.TabIndex = 6;
            label5.Text = "Дата рожд:";
            // 
            // textBoxAlias
            // 
            textBoxAlias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxAlias.Location = new Point(104, 23);
            textBoxAlias.Name = "textBoxAlias";
            textBoxAlias.Size = new Size(255, 23);
            textBoxAlias.TabIndex = 7;
            // 
            // comboBoxType
            // 
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Location = new Point(104, 70);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(255, 23);
            comboBoxType.TabIndex = 8;
            comboBoxType.DropDownClosed += comboBoxType_DropDownClosed;
            // 
            // comboBoxBreed
            // 
            comboBoxBreed.FormattingEnabled = true;
            comboBoxBreed.Location = new Point(104, 117);
            comboBoxBreed.Name = "comboBoxBreed";
            comboBoxBreed.Size = new Size(255, 23);
            comboBoxBreed.TabIndex = 9;
            // 
            // comboBoxSex
            // 
            comboBoxSex.FormattingEnabled = true;
            comboBoxSex.Location = new Point(104, 164);
            comboBoxSex.Name = "comboBoxSex";
            comboBoxSex.Size = new Size(255, 23);
            comboBoxSex.TabIndex = 10;
            // 
            // dateTimePickerBirthday
            // 
            dateTimePickerBirthday.Format = DateTimePickerFormat.Short;
            dateTimePickerBirthday.Location = new Point(104, 209);
            dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            dateTimePickerBirthday.Size = new Size(255, 23);
            dateTimePickerBirthday.TabIndex = 11;
            // 
            // AddEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 315);
            Controls.Add(dateTimePickerBirthday);
            Controls.Add(comboBoxSex);
            Controls.Add(comboBoxBreed);
            Controls.Add(comboBoxType);
            Controls.Add(textBoxAlias);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddEditForm";
            Text = "Добавление питомца";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxAlias;
        private ComboBox comboBoxType;
        private ComboBox comboBoxBreed;
        private ComboBox comboBoxSex;
        private DateTimePicker dateTimePickerBirthday;
    }
}