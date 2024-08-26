namespace Playload.App
{
    partial class FormSettings
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxDomain = new TextBox();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonConnect = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(28, 30);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 0;
            label1.Text = "Домен:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(32, 81);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 1;
            label2.Text = "Логин:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(23, 132);
            label3.Name = "label3";
            label3.Size = new Size(66, 21);
            label3.TabIndex = 2;
            label3.Text = "Пароль:";
            // 
            // textBoxDomain
            // 
            textBoxDomain.Location = new Point(95, 31);
            textBoxDomain.Name = "textBoxDomain";
            textBoxDomain.Size = new Size(340, 23);
            textBoxDomain.TabIndex = 3;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(95, 82);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(340, 23);
            textBoxLogin.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(95, 133);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(340, 23);
            textBoxPassword.TabIndex = 5;
            // 
            // buttonConnect
            // 
            buttonConnect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonConnect.Location = new Point(198, 185);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(100, 30);
            buttonConnect.TabIndex = 6;
            buttonConnect.Text = "Связать";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 227);
            Controls.Add(buttonConnect);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(textBoxDomain);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormSettings";
            Text = "Настройки API";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxDomain;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonConnect;
    }
}