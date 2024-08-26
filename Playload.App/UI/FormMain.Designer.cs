namespace Playload.App
{
    partial class FormMain
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
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonSettingAPI = new Button();
            label1 = new Label();
            comboBoxClients = new ComboBox();
            dataGridViewPets = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPets).BeginInit();
            SuspendLayout();
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAdd.Enabled = false;
            buttonAdd.Location = new Point(464, 115);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(100, 30);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdit.Enabled = false;
            buttonEdit.Location = new Point(570, 115);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(100, 30);
            buttonEdit.TabIndex = 2;
            buttonEdit.Text = "Редактировать";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.Enabled = false;
            buttonDelete.Location = new Point(676, 115);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 30);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSettingAPI
            // 
            buttonSettingAPI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSettingAPI.Location = new Point(626, 15);
            buttonSettingAPI.Name = "buttonSettingAPI";
            buttonSettingAPI.Size = new Size(150, 30);
            buttonSettingAPI.TabIndex = 0;
            buttonSettingAPI.Text = "Настройки API";
            buttonSettingAPI.UseVisualStyleBackColor = true;
            buttonSettingAPI.Click += buttonSettingAPI_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(63, 21);
            label1.TabIndex = 4;
            label1.Text = "Клиент:";
            // 
            // comboBoxClients
            // 
            comboBoxClients.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClients.FormattingEnabled = true;
            comboBoxClients.Location = new Point(81, 20);
            comboBoxClients.Name = "comboBoxClients";
            comboBoxClients.Size = new Size(209, 23);
            comboBoxClients.TabIndex = 4;
            comboBoxClients.SelectedIndexChanged += comboBoxClients_SelectedIndexChanged;
            // 
            // dataGridViewPets
            // 
            dataGridViewPets.AllowUserToAddRows = false;
            dataGridViewPets.AllowUserToDeleteRows = false;
            dataGridViewPets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewPets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPets.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridViewPets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPets.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewPets.Location = new Point(12, 151);
            dataGridViewPets.MultiSelect = false;
            dataGridViewPets.Name = "dataGridViewPets";
            dataGridViewPets.Size = new Size(776, 287);
            dataGridViewPets.TabIndex = 6;
            dataGridViewPets.RowEnter += dataGridViewPets_RowEnter;
            dataGridViewPets.RowLeave += dataGridViewPets_RowLeave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 130);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 7;
            label2.Text = "Питомцы клиента:";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(dataGridViewPets);
            Controls.Add(comboBoxClients);
            Controls.Add(label1);
            Controls.Add(buttonSettingAPI);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Name = "FormMain";
            Text = "Vetmanager";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonSettingAPI;
        private Label label1;
        private ComboBox comboBoxClients;
        private DataGridView dataGridViewPets;
        private Label label2;
    }
}
