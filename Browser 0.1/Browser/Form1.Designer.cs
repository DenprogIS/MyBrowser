namespace Browser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.webBrowser = new Awesomium.Windows.Forms.WebControl(this.components);
            this.omniBox = new System.Windows.Forms.TextBox();
            this.elementHostForwardBtn = new System.Windows.Forms.Integration.ElementHost();
            this.forward_btn1 = new BrowserStyle.forward_btn();
            this.elementHostBackBtn = new System.Windows.Forms.Integration.ElementHost();
            this.back_btn1 = new BrowserStyle.back_btn();
            this.radioButtonGoogleOrYandex = new System.Windows.Forms.RadioButton();
            this.radioButtonYandexOrGoogle = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(-118, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(960, 31);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(2, 31);
            this.webBrowser.Size = new System.Drawing.Size(813, 485);
            this.webBrowser.Source = new System.Uri("http://www.google.com/", System.UriKind.Absolute);
            this.webBrowser.TabIndex = 1;
            // 
            // omniBox
            // 
            this.omniBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.omniBox.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.omniBox.Location = new System.Drawing.Point(54, 5);
            this.omniBox.Name = "omniBox";
            this.omniBox.Size = new System.Drawing.Size(613, 21);
            this.omniBox.TabIndex = 2;
            // 
            // elementHostForwardBtn
            // 
            this.elementHostForwardBtn.Location = new System.Drawing.Point(28, 5);
            this.elementHostForwardBtn.Name = "elementHostForwardBtn";
            this.elementHostForwardBtn.Size = new System.Drawing.Size(20, 20);
            this.elementHostForwardBtn.TabIndex = 4;
            this.elementHostForwardBtn.Text = "elementHost2";
            this.elementHostForwardBtn.Child = this.forward_btn1;
            // 
            // elementHostBackBtn
            // 
            this.elementHostBackBtn.Location = new System.Drawing.Point(2, 5);
            this.elementHostBackBtn.Name = "elementHostBackBtn";
            this.elementHostBackBtn.Size = new System.Drawing.Size(20, 20);
            this.elementHostBackBtn.TabIndex = 3;
            this.elementHostBackBtn.Text = "elementHost1";
            this.elementHostBackBtn.Child = this.back_btn1;
            // 
            // radioButtonGoogleOrYandex
            // 
            this.radioButtonGoogleOrYandex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonGoogleOrYandex.AutoSize = true;
            this.radioButtonGoogleOrYandex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.radioButtonGoogleOrYandex.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGoogleOrYandex.Location = new System.Drawing.Point(673, 5);
            this.radioButtonGoogleOrYandex.Name = "radioButtonGoogleOrYandex";
            this.radioButtonGoogleOrYandex.Size = new System.Drawing.Size(67, 18);
            this.radioButtonGoogleOrYandex.TabIndex = 5;
            this.radioButtonGoogleOrYandex.TabStop = true;
            this.radioButtonGoogleOrYandex.Text = "Google";
            this.radioButtonGoogleOrYandex.UseVisualStyleBackColor = false;
            // 
            // radioButtonYandexOrGoogle
            // 
            this.radioButtonYandexOrGoogle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonYandexOrGoogle.AutoSize = true;
            this.radioButtonYandexOrGoogle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.radioButtonYandexOrGoogle.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonYandexOrGoogle.Location = new System.Drawing.Point(746, 5);
            this.radioButtonYandexOrGoogle.Name = "radioButtonYandexOrGoogle";
            this.radioButtonYandexOrGoogle.Size = new System.Drawing.Size(69, 18);
            this.radioButtonYandexOrGoogle.TabIndex = 6;
            this.radioButtonYandexOrGoogle.TabStop = true;
            this.radioButtonYandexOrGoogle.Text = "Yandex";
            this.radioButtonYandexOrGoogle.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 516);
            this.Controls.Add(this.radioButtonYandexOrGoogle);
            this.Controls.Add(this.radioButtonGoogleOrYandex);
            this.Controls.Add(this.elementHostForwardBtn);
            this.Controls.Add(this.elementHostBackBtn);
            this.Controls.Add(this.omniBox);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Awesomium.Windows.Forms.WebControl webBrowser;
        private System.Windows.Forms.TextBox omniBox;
        private System.Windows.Forms.Integration.ElementHost elementHostBackBtn;
        private BrowserStyle.back_btn back_btn1;
        private System.Windows.Forms.Integration.ElementHost elementHostForwardBtn;
        private BrowserStyle.forward_btn forward_btn1;
        private System.Windows.Forms.RadioButton radioButtonGoogleOrYandex;
        private System.Windows.Forms.RadioButton radioButtonYandexOrGoogle;
    }
}

