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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.omniBox = new System.Windows.Forms.TextBox();
            this.radioButtonGoogleOrYandex = new System.Windows.Forms.RadioButton();
            this.radioButtonYandexOrGoogle = new System.Windows.Forms.RadioButton();
            this.elementHostHeadpiece = new System.Windows.Forms.Integration.ElementHost();
            this.blinds1 = new BrowserStyle.blinds();
            this.elementHostForwardBtn = new System.Windows.Forms.Integration.ElementHost();
            this.forward_btn1 = new BrowserStyle.forward_btn();
            this.elementHostBackBtn = new System.Windows.Forms.Integration.ElementHost();
            this.back_btn1 = new BrowserStyle.back_btn();
            this.newTabButton = new System.Windows.Forms.PictureBox();
            this.viewTabButton = new System.Windows.Forms.PictureBox();
            this.VKButton = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.PictureBox();
            this.headpiceHideTimer = new System.Windows.Forms.Timer(this.components);
            this.searchButton = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newTabButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTabButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VKButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).BeginInit();
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
            // omniBox
            // 
            this.omniBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.omniBox.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.omniBox.Location = new System.Drawing.Point(54, 5);
            this.omniBox.Name = "omniBox";
            this.omniBox.Size = new System.Drawing.Size(506, 21);
            this.omniBox.TabIndex = 2;
            this.omniBox.DoubleClick += new System.EventHandler(this.omniBox_DoubleClick);
            // 
            // radioButtonGoogleOrYandex
            // 
            this.radioButtonGoogleOrYandex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonGoogleOrYandex.AutoSize = true;
            this.radioButtonGoogleOrYandex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.radioButtonGoogleOrYandex.Font = new System.Drawing.Font("Showcard Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGoogleOrYandex.Location = new System.Drawing.Point(566, 6);
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
            this.radioButtonYandexOrGoogle.Location = new System.Drawing.Point(639, 6);
            this.radioButtonYandexOrGoogle.Name = "radioButtonYandexOrGoogle";
            this.radioButtonYandexOrGoogle.Size = new System.Drawing.Size(69, 18);
            this.radioButtonYandexOrGoogle.TabIndex = 6;
            this.radioButtonYandexOrGoogle.TabStop = true;
            this.radioButtonYandexOrGoogle.Text = "Yandex";
            this.radioButtonYandexOrGoogle.UseVisualStyleBackColor = false;
            // 
            // elementHostHeadpiece
            // 
            this.elementHostHeadpiece.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHostHeadpiece.Location = new System.Drawing.Point(2, 32);
            this.elementHostHeadpiece.Name = "elementHostHeadpiece";
            this.elementHostHeadpiece.Size = new System.Drawing.Size(813, 487);
            this.elementHostHeadpiece.TabIndex = 7;
            this.elementHostHeadpiece.Text = "elementHost1";
            this.elementHostHeadpiece.Child = this.blinds1;
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
            // newTabButton
            // 
            this.newTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newTabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.newTabButton.Image = global::Browser.Properties.Resources.add_plus_icon_in_flat_style_with_long_shadow_1937825212;
            this.newTabButton.Location = new System.Drawing.Point(714, 5);
            this.newTabButton.Name = "newTabButton";
            this.newTabButton.Size = new System.Drawing.Size(20, 20);
            this.newTabButton.TabIndex = 9;
            this.newTabButton.TabStop = false;
            this.newTabButton.Click += new System.EventHandler(this.newTabButton_Click);
            // 
            // viewTabButton
            // 
            this.viewTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewTabButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.viewTabButton.Image = global::Browser.Properties.Resources.gnome_window_manager__1_;
            this.viewTabButton.Location = new System.Drawing.Point(740, 5);
            this.viewTabButton.Name = "viewTabButton";
            this.viewTabButton.Size = new System.Drawing.Size(20, 20);
            this.viewTabButton.TabIndex = 10;
            this.viewTabButton.TabStop = false;
            this.viewTabButton.Click += new System.EventHandler(this.viewTabButton_Click);
            // 
            // VKButton
            // 
            this.VKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.VKButton.Image = global::Browser.Properties.Resources.vkontakte_logo__1_;
            this.VKButton.Location = new System.Drawing.Point(766, 5);
            this.VKButton.Name = "VKButton";
            this.VKButton.Size = new System.Drawing.Size(20, 20);
            this.VKButton.TabIndex = 11;
            this.VKButton.TabStop = false;
            this.VKButton.Click += new System.EventHandler(this.VKButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.SettingsButton.Image = global::Browser.Properties.Resources._31;
            this.SettingsButton.Location = new System.Drawing.Point(792, 5);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(20, 20);
            this.SettingsButton.TabIndex = 12;
            this.SettingsButton.TabStop = false;
            // 
            // headpiceHideTimer
            // 
            this.headpiceHideTimer.Tick += new System.EventHandler(this.headpiceHideTimer_Tick);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.searchButton.Image = global::Browser.Properties.Resources.SEARCH__3_;
            this.searchButton.Location = new System.Drawing.Point(540, 6);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(20, 20);
            this.searchButton.TabIndex = 13;
            this.searchButton.TabStop = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(201)))), ((int)(((byte)(224)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 33;
            this.listBox1.Location = new System.Drawing.Point(566, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(249, 431);
            this.listBox1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 516);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.VKButton);
            this.Controls.Add(this.viewTabButton);
            this.Controls.Add(this.newTabButton);
            this.Controls.Add(this.radioButtonYandexOrGoogle);
            this.Controls.Add(this.radioButtonGoogleOrYandex);
            this.Controls.Add(this.elementHostForwardBtn);
            this.Controls.Add(this.elementHostBackBtn);
            this.Controls.Add(this.omniBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.elementHostHeadpiece);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Flying";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newTabButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewTabButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VKButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Integration.ElementHost elementHostHeadpiece;
        private System.Windows.Forms.PictureBox newTabButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox omniBox;
        private System.Windows.Forms.Integration.ElementHost elementHostBackBtn;
        private BrowserStyle.back_btn back_btn1;
        private System.Windows.Forms.Integration.ElementHost elementHostForwardBtn;
        private System.Windows.Forms.RadioButton radioButtonGoogleOrYandex;
        private System.Windows.Forms.RadioButton radioButtonYandexOrGoogle;
        private BrowserStyle.blinds blinds1;
        private System.Windows.Forms.PictureBox viewTabButton;
        private System.Windows.Forms.PictureBox VKButton;
        private System.Windows.Forms.PictureBox SettingsButton;
        private System.Windows.Forms.Timer headpiceHideTimer;
        private System.Windows.Forms.PictureBox searchButton;
        private BrowserStyle.forward_btn forward_btn1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

