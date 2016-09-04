namespace one_click
{
    partial class mainwindow
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.hi = new System.Windows.Forms.Label();
            this.begin = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.power = new System.Windows.Forms.TrackBar();
            this.clock = new System.Windows.Forms.PictureBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.ht = new System.Windows.Forms.PictureBox();
            this.clg = new System.Windows.Forms.PictureBox();
            this.wlw = new System.Windows.Forms.PictureBox();
            this.nshv = new System.Windows.Forms.PictureBox();
            this.hp = new System.Windows.Forms.PictureBox();
            this.cld = new System.Windows.Forms.PictureBox();
            this.blr = new System.Windows.Forms.PictureBox();
            this.shrp = new System.Windows.Forms.PictureBox();
            this.inv = new System.Windows.Forms.PictureBox();
            this.beginpic = new System.Windows.Forms.PictureBox();
            this.fon = new System.Windows.Forms.PictureBox();
            this.reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.power)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wlw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nshv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fon)).BeginInit();
            this.SuspendLayout();
            // 
            // hi
            // 
            this.hi.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.hi.Location = new System.Drawing.Point(0, 22);
            this.hi.Name = "hi";
            this.hi.Size = new System.Drawing.Size(838, 118);
            this.hi.TabIndex = 1;
            this.hi.Text = "Приветствую в программе One Click Image Editor! Для продолжения просто нажмите \"Н" +
    "ачать\", а затем выберите изображение, которое хотите обработать.";
            this.hi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hi.Click += new System.EventHandler(this.hi_Click);
            // 
            // begin
            // 
            this.begin.AutoSize = true;
            this.begin.BackColor = System.Drawing.Color.Transparent;
            this.begin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.begin.Location = new System.Drawing.Point(388, 255);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(99, 29);
            this.begin.TabIndex = 2;
            this.begin.Text = "Начать!";
            this.begin.Click += new System.EventHandler(this.begin_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(-1, -4);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(243, 23);
            this.open.TabIndex = 3;
            this.open.Text = "Открыть";
            this.open.UseVisualStyleBackColor = true;
            this.open.Visible = false;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(601, -4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(243, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Visible = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // power
            // 
            this.power.AutoSize = false;
            this.power.BackColor = System.Drawing.Color.DimGray;
            this.power.Location = new System.Drawing.Point(12, 422);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(300, 19);
            this.power.TabIndex = 10;
            this.power.TickStyle = System.Windows.Forms.TickStyle.None;
            this.power.Visible = false;
            // 
            // clock
            // 
            this.clock.Image = global::one_click.Properties.Resources._12205100050348185;
            this.clock.Location = new System.Drawing.Point(55, 177);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(100, 107);
            this.clock.TabIndex = 12;
            this.clock.TabStop = false;
            this.clock.Visible = false;
            // 
            // pb
            // 
            this.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb.Location = new System.Drawing.Point(592, 547);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(78, 50);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb.TabIndex = 9;
            this.pb.TabStop = false;
            this.pb.Visible = false;
            this.pb.Click += new System.EventHandler(this.pb_Click);
            // 
            // ht
            // 
            this.ht.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ht.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ht.Location = new System.Drawing.Point(676, 547);
            this.ht.Name = "ht";
            this.ht.Size = new System.Drawing.Size(78, 50);
            this.ht.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ht.TabIndex = 9;
            this.ht.TabStop = false;
            this.ht.Visible = false;
            this.ht.Click += new System.EventHandler(this.ht_Click);
            // 
            // clg
            // 
            this.clg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.clg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clg.Location = new System.Drawing.Point(760, 547);
            this.clg.Name = "clg";
            this.clg.Size = new System.Drawing.Size(78, 50);
            this.clg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clg.TabIndex = 9;
            this.clg.TabStop = false;
            this.clg.Visible = false;
            this.clg.Click += new System.EventHandler(this.clg_Click);
            // 
            // wlw
            // 
            this.wlw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.wlw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wlw.Location = new System.Drawing.Point(508, 547);
            this.wlw.Name = "wlw";
            this.wlw.Size = new System.Drawing.Size(78, 50);
            this.wlw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.wlw.TabIndex = 9;
            this.wlw.TabStop = false;
            this.wlw.Visible = false;
            this.wlw.Click += new System.EventHandler(this.wlw_Click);
            // 
            // nshv
            // 
            this.nshv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.nshv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nshv.Location = new System.Drawing.Point(424, 547);
            this.nshv.Name = "nshv";
            this.nshv.Size = new System.Drawing.Size(78, 50);
            this.nshv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.nshv.TabIndex = 9;
            this.nshv.TabStop = false;
            this.nshv.Visible = false;
            this.nshv.Click += new System.EventHandler(this.nshv_Click);
            // 
            // hp
            // 
            this.hp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.hp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hp.Location = new System.Drawing.Point(340, 547);
            this.hp.Name = "hp";
            this.hp.Size = new System.Drawing.Size(78, 50);
            this.hp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.hp.TabIndex = 9;
            this.hp.TabStop = false;
            this.hp.Visible = false;
            this.hp.Click += new System.EventHandler(this.hp_Click);
            // 
            // cld
            // 
            this.cld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cld.Location = new System.Drawing.Point(256, 547);
            this.cld.Name = "cld";
            this.cld.Size = new System.Drawing.Size(78, 50);
            this.cld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.cld.TabIndex = 9;
            this.cld.TabStop = false;
            this.cld.Visible = false;
            this.cld.Click += new System.EventHandler(this.cld_Click);
            // 
            // blr
            // 
            this.blr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.blr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blr.Location = new System.Drawing.Point(172, 547);
            this.blr.Name = "blr";
            this.blr.Size = new System.Drawing.Size(78, 50);
            this.blr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.blr.TabIndex = 8;
            this.blr.TabStop = false;
            this.blr.Visible = false;
            this.blr.Click += new System.EventHandler(this.blur_Click);
            // 
            // shrp
            // 
            this.shrp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.shrp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shrp.Location = new System.Drawing.Point(88, 547);
            this.shrp.Name = "shrp";
            this.shrp.Size = new System.Drawing.Size(78, 50);
            this.shrp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.shrp.TabIndex = 7;
            this.shrp.TabStop = false;
            this.shrp.Visible = false;
            this.shrp.WaitOnLoad = true;
            this.shrp.Click += new System.EventHandler(this.shrp_Click);
            // 
            // inv
            // 
            this.inv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.inv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inv.Location = new System.Drawing.Point(4, 547);
            this.inv.Name = "inv";
            this.inv.Size = new System.Drawing.Size(78, 50);
            this.inv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.inv.TabIndex = 6;
            this.inv.TabStop = false;
            this.inv.Visible = false;
            this.inv.WaitOnLoad = true;
            this.inv.Click += new System.EventHandler(this.inv_Click);
            // 
            // beginpic
            // 
            this.beginpic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.beginpic.Image = global::one_click.Properties.Resources.begin;
            this.beginpic.Location = new System.Drawing.Point(312, 143);
            this.beginpic.Name = "beginpic";
            this.beginpic.Size = new System.Drawing.Size(250, 250);
            this.beginpic.TabIndex = 0;
            this.beginpic.TabStop = false;
            this.beginpic.Click += new System.EventHandler(this.beginpic_Click_1);
            // 
            // fon
            // 
            this.fon.BackColor = System.Drawing.Color.Gray;
            this.fon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fon.Image = global::one_click.Properties.Resources.fon;
            this.fon.InitialImage = null;
            this.fon.Location = new System.Drawing.Point(-1, 542);
            this.fon.Name = "fon";
            this.fon.Size = new System.Drawing.Size(856, 65);
            this.fon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fon.TabIndex = 11;
            this.fon.TabStop = false;
            this.fon.Visible = false;
            // 
            // reset
            // 
            this.reset.Enabled = false;
            this.reset.Location = new System.Drawing.Point(307, -4);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(243, 23);
            this.reset.TabIndex = 13;
            this.reset.Text = "Показать оригинал";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Visible = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(843, 600);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.power);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.ht);
            this.Controls.Add(this.clg);
            this.Controls.Add(this.wlw);
            this.Controls.Add(this.nshv);
            this.Controls.Add(this.hp);
            this.Controls.Add(this.cld);
            this.Controls.Add(this.blr);
            this.Controls.Add(this.shrp);
            this.Controls.Add(this.inv);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Controls.Add(this.begin);
            this.Controls.Add(this.beginpic);
            this.Controls.Add(this.hi);
            this.Controls.Add(this.fon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainwindow";
            this.Text = "One Click Editor";
            ((System.ComponentModel.ISupportInitialize)(this.power)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wlw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nshv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beginpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox beginpic;
        private System.Windows.Forms.Label hi;
        private System.Windows.Forms.Label begin;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.PictureBox inv;
        private System.Windows.Forms.PictureBox shrp;
        private System.Windows.Forms.PictureBox blr;
        private System.Windows.Forms.PictureBox cld;
        private System.Windows.Forms.PictureBox hp;
        private System.Windows.Forms.PictureBox nshv;
        private System.Windows.Forms.PictureBox wlw;
        private System.Windows.Forms.PictureBox clg;
        private System.Windows.Forms.TrackBar power;
        private System.Windows.Forms.PictureBox fon;
        private System.Windows.Forms.PictureBox ht;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.PictureBox clock;
        private System.Windows.Forms.Button reset;
    }
}

