namespace dr
{
    partial class Form1
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
            this.age = new System.Windows.Forms.NumericUpDown();
            this.age_l = new System.Windows.Forms.Label();
            this.norm_b = new System.Windows.Forms.RadioButton();
            this.bar = new System.Windows.Forms.GroupBox();
            this.height_b = new System.Windows.Forms.RadioButton();
            this.very_heigh_h = new System.Windows.Forms.RadioButton();
            this.heigh_h = new System.Windows.Forms.RadioButton();
            this.norm_h = new System.Windows.Forms.RadioButton();
            this.imd = new System.Windows.Forms.GroupBox();
            this.four_w = new System.Windows.Forms.RadioButton();
            this.three_w = new System.Windows.Forms.RadioButton();
            this.two_w = new System.Windows.Forms.RadioButton();
            this.one_w = new System.Windows.Forms.RadioButton();
            this.low_w = new System.Windows.Forms.RadioButton();
            this.norm_w = new System.Windows.Forms.RadioButton();
            this.height_w = new System.Windows.Forms.RadioButton();
            this.smoke = new System.Windows.Forms.GroupBox();
            this.heigh_s = new System.Windows.Forms.RadioButton();
            this.mid_s = new System.Windows.Forms.RadioButton();
            this.light_s = new System.Windows.Forms.RadioButton();
            this.norm_s = new System.Windows.Forms.RadioButton();
            this.recommended = new System.Windows.Forms.TextBox();
            this.recomm = new System.Windows.Forms.Label();
            this.zakl = new System.Windows.Forms.TextBox();
            this.diagnoz = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.priglas = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cardio_ = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.asd = new System.Windows.Forms.Label();
            this.sahar_ = new System.Windows.Forms.MaskedTextBox();
            this.holest_ = new System.Windows.Forms.MaskedTextBox();
            this.clear_card = new System.Windows.Forms.Button();
            this.clear_s = new System.Windows.Forms.Button();
            this.clear_ho = new System.Windows.Forms.Button();
            this.zuby = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.age)).BeginInit();
            this.bar.SuspendLayout();
            this.imd.SuspendLayout();
            this.smoke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardio_)).BeginInit();
            this.SuspendLayout();
            // 
            // age
            // 
            this.age.Location = new System.Drawing.Point(211, 25);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(200, 20);
            this.age.TabIndex = 0;
            this.age.ValueChanged += new System.EventHandler(this.age_ValueChanged);
            this.age.Click += new System.EventHandler(this.age_Click);
            // 
            // age_l
            // 
            this.age_l.AutoSize = true;
            this.age_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_l.Location = new System.Drawing.Point(208, 9);
            this.age_l.Name = "age_l";
            this.age_l.Size = new System.Drawing.Size(60, 13);
            this.age_l.TabIndex = 1;
            this.age_l.Text = "Возраст:";
            this.age_l.Click += new System.EventHandler(this.age_l_Click);
            // 
            // norm_b
            // 
            this.norm_b.AutoSize = true;
            this.norm_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.norm_b.Location = new System.Drawing.Point(6, 19);
            this.norm_b.Name = "norm_b";
            this.norm_b.Size = new System.Drawing.Size(122, 17);
            this.norm_b.TabIndex = 5;
            this.norm_b.Text = "Нормальное (<140)";
            this.norm_b.UseVisualStyleBackColor = true;
            this.norm_b.CheckedChanged += new System.EventHandler(this.norm_b_CheckedChanged);
            // 
            // bar
            // 
            this.bar.Controls.Add(this.height_b);
            this.bar.Controls.Add(this.norm_b);
            this.bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bar.Location = new System.Drawing.Point(9, 10);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(193, 69);
            this.bar.TabIndex = 6;
            this.bar.TabStop = false;
            this.bar.Text = "Давление";
            // 
            // height_b
            // 
            this.height_b.AutoSize = true;
            this.height_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.height_b.Location = new System.Drawing.Point(6, 42);
            this.height_b.Name = "height_b";
            this.height_b.Size = new System.Drawing.Size(124, 17);
            this.height_b.TabIndex = 6;
            this.height_b.TabStop = true;
            this.height_b.Text = "Повышенное (≥140)";
            this.height_b.UseVisualStyleBackColor = true;
            this.height_b.CheckedChanged += new System.EventHandler(this.height_b_CheckedChanged);
            // 
            // very_heigh_h
            // 
            this.very_heigh_h.Location = new System.Drawing.Point(0, 0);
            this.very_heigh_h.Name = "very_heigh_h";
            this.very_heigh_h.Size = new System.Drawing.Size(104, 24);
            this.very_heigh_h.TabIndex = 0;
            // 
            // heigh_h
            // 
            this.heigh_h.Location = new System.Drawing.Point(0, 0);
            this.heigh_h.Name = "heigh_h";
            this.heigh_h.Size = new System.Drawing.Size(104, 24);
            this.heigh_h.TabIndex = 0;
            // 
            // norm_h
            // 
            this.norm_h.Location = new System.Drawing.Point(0, 0);
            this.norm_h.Name = "norm_h";
            this.norm_h.Size = new System.Drawing.Size(104, 24);
            this.norm_h.TabIndex = 0;
            // 
            // imd
            // 
            this.imd.Controls.Add(this.four_w);
            this.imd.Controls.Add(this.three_w);
            this.imd.Controls.Add(this.two_w);
            this.imd.Controls.Add(this.one_w);
            this.imd.Controls.Add(this.low_w);
            this.imd.Controls.Add(this.norm_w);
            this.imd.Controls.Add(this.height_w);
            this.imd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imd.Location = new System.Drawing.Point(9, 85);
            this.imd.Name = "imd";
            this.imd.Size = new System.Drawing.Size(193, 182);
            this.imd.TabIndex = 9;
            this.imd.TabStop = false;
            this.imd.Text = "ИМД";
            this.imd.Enter += new System.EventHandler(this.imd_Enter);
            // 
            // four_w
            // 
            this.four_w.AutoSize = true;
            this.four_w.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.four_w.Location = new System.Drawing.Point(6, 157);
            this.four_w.Name = "four_w";
            this.four_w.Size = new System.Drawing.Size(163, 17);
            this.four_w.TabIndex = 18;
            this.four_w.TabStop = true;
            this.four_w.Text = "Ожирение 4 степени (40-...)";
            this.four_w.UseVisualStyleBackColor = true;
            this.four_w.CheckedChanged += new System.EventHandler(this.four_w_CheckedChanged);
            // 
            // three_w
            // 
            this.three_w.AutoSize = true;
            this.three_w.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.three_w.Location = new System.Drawing.Point(6, 134);
            this.three_w.Name = "three_w";
            this.three_w.Size = new System.Drawing.Size(166, 17);
            this.three_w.TabIndex = 17;
            this.three_w.TabStop = true;
            this.three_w.Text = "Ожирение 3 степени (37-39)";
            this.three_w.UseVisualStyleBackColor = true;
            this.three_w.CheckedChanged += new System.EventHandler(this.three_w_CheckedChanged);
            // 
            // two_w
            // 
            this.two_w.AutoSize = true;
            this.two_w.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.two_w.Location = new System.Drawing.Point(6, 111);
            this.two_w.Name = "two_w";
            this.two_w.Size = new System.Drawing.Size(166, 17);
            this.two_w.TabIndex = 14;
            this.two_w.TabStop = true;
            this.two_w.Text = "Ожирение 2 степени (34-36)";
            this.two_w.UseVisualStyleBackColor = true;
            this.two_w.CheckedChanged += new System.EventHandler(this.two_w_CheckedChanged);
            // 
            // one_w
            // 
            this.one_w.AutoSize = true;
            this.one_w.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.one_w.Location = new System.Drawing.Point(6, 88);
            this.one_w.Name = "one_w";
            this.one_w.Size = new System.Drawing.Size(166, 17);
            this.one_w.TabIndex = 16;
            this.one_w.TabStop = true;
            this.one_w.Text = "Ожирение 1 степени (30-33)";
            this.one_w.UseVisualStyleBackColor = true;
            this.one_w.CheckedChanged += new System.EventHandler(this.one_w_CheckedChanged);
            // 
            // low_w
            // 
            this.low_w.AutoSize = true;
            this.low_w.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.low_w.Location = new System.Drawing.Point(6, 19);
            this.low_w.Name = "low_w";
            this.low_w.Size = new System.Drawing.Size(160, 17);
            this.low_w.TabIndex = 12;
            this.low_w.TabStop = true;
            this.low_w.Text = "Пониженное питание (<18)";
            this.low_w.UseVisualStyleBackColor = true;
            this.low_w.CheckedChanged += new System.EventHandler(this.low_w_CheckedChanged);
            // 
            // norm_w
            // 
            this.norm_w.AutoSize = true;
            this.norm_w.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.norm_w.Location = new System.Drawing.Point(6, 42);
            this.norm_w.Name = "norm_w";
            this.norm_w.Size = new System.Drawing.Size(95, 17);
            this.norm_w.TabIndex = 15;
            this.norm_w.Text = "Норма (18-22)";
            this.norm_w.UseVisualStyleBackColor = true;
            this.norm_w.CheckedChanged += new System.EventHandler(this.norm_w_CheckedChanged);
            // 
            // height_w
            // 
            this.height_w.AutoSize = true;
            this.height_w.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.height_w.Location = new System.Drawing.Point(6, 65);
            this.height_w.Name = "height_w";
            this.height_w.Size = new System.Drawing.Size(171, 17);
            this.height_w.TabIndex = 13;
            this.height_w.TabStop = true;
            this.height_w.Text = "Повышенное питание (23-29)";
            this.height_w.UseVisualStyleBackColor = true;
            this.height_w.CheckedChanged += new System.EventHandler(this.height_w_CheckedChanged);
            // 
            // smoke
            // 
            this.smoke.Controls.Add(this.heigh_s);
            this.smoke.Controls.Add(this.mid_s);
            this.smoke.Controls.Add(this.light_s);
            this.smoke.Controls.Add(this.norm_s);
            this.smoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.smoke.Location = new System.Drawing.Point(9, 273);
            this.smoke.Name = "smoke";
            this.smoke.Size = new System.Drawing.Size(193, 109);
            this.smoke.TabIndex = 10;
            this.smoke.TabStop = false;
            this.smoke.Text = "Курение";
            // 
            // heigh_s
            // 
            this.heigh_s.AutoSize = true;
            this.heigh_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.heigh_s.Location = new System.Drawing.Point(7, 84);
            this.heigh_s.Name = "heigh_s";
            this.heigh_s.Size = new System.Drawing.Size(105, 17);
            this.heigh_s.TabIndex = 3;
            this.heigh_s.TabStop = true;
            this.heigh_s.Text = "Тяжелый (20-...)";
            this.heigh_s.UseVisualStyleBackColor = true;
            this.heigh_s.CheckedChanged += new System.EventHandler(this.heigh_s_CheckedChanged);
            // 
            // mid_s
            // 
            this.mid_s.AutoSize = true;
            this.mid_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mid_s.Location = new System.Drawing.Point(7, 61);
            this.mid_s.Name = "mid_s";
            this.mid_s.Size = new System.Drawing.Size(104, 17);
            this.mid_s.TabIndex = 2;
            this.mid_s.TabStop = true;
            this.mid_s.Text = "Средний (11-19)";
            this.mid_s.UseVisualStyleBackColor = true;
            this.mid_s.CheckedChanged += new System.EventHandler(this.mid_s_CheckedChanged);
            // 
            // light_s
            // 
            this.light_s.AutoSize = true;
            this.light_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.light_s.Location = new System.Drawing.Point(7, 38);
            this.light_s.Name = "light_s";
            this.light_s.Size = new System.Drawing.Size(92, 17);
            this.light_s.TabIndex = 1;
            this.light_s.TabStop = true;
            this.light_s.Text = "Легкий (6-10)";
            this.light_s.UseVisualStyleBackColor = true;
            this.light_s.CheckedChanged += new System.EventHandler(this.light_s_CheckedChanged);
            // 
            // norm_s
            // 
            this.norm_s.AutoSize = true;
            this.norm_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.norm_s.Location = new System.Drawing.Point(7, 15);
            this.norm_s.Name = "norm_s";
            this.norm_s.Size = new System.Drawing.Size(70, 17);
            this.norm_s.TabIndex = 0;
            this.norm_s.Text = "Не курит";
            this.norm_s.UseVisualStyleBackColor = true;
            this.norm_s.CheckedChanged += new System.EventHandler(this.norm_s_CheckedChanged);
            // 
            // recommended
            // 
            this.recommended.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recommended.Location = new System.Drawing.Point(417, 26);
            this.recommended.Multiline = true;
            this.recommended.Name = "recommended";
            this.recommended.ReadOnly = true;
            this.recommended.Size = new System.Drawing.Size(239, 325);
            this.recommended.TabIndex = 12;
            // 
            // recomm
            // 
            this.recomm.AutoSize = true;
            this.recomm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recomm.Location = new System.Drawing.Point(414, 10);
            this.recomm.Name = "recomm";
            this.recomm.Size = new System.Drawing.Size(98, 13);
            this.recomm.TabIndex = 1;
            this.recomm.Text = "Рекомендации:";
            // 
            // zakl
            // 
            this.zakl.Location = new System.Drawing.Point(662, 26);
            this.zakl.Multiline = true;
            this.zakl.Name = "zakl";
            this.zakl.ReadOnly = true;
            this.zakl.Size = new System.Drawing.Size(245, 262);
            this.zakl.TabIndex = 12;
            // 
            // diagnoz
            // 
            this.diagnoz.AutoSize = true;
            this.diagnoz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diagnoz.Location = new System.Drawing.Point(659, 10);
            this.diagnoz.Name = "diagnoz";
            this.diagnoz.Size = new System.Drawing.Size(83, 13);
            this.diagnoz.TabIndex = 1;
            this.diagnoz.Text = "Заключение:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(417, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Копировать в буфер";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(662, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(245, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Копировать в буфер";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // priglas
            // 
            this.priglas.Location = new System.Drawing.Point(662, 323);
            this.priglas.Name = "priglas";
            this.priglas.ReadOnly = true;
            this.priglas.Size = new System.Drawing.Size(245, 20);
            this.priglas.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(662, 354);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(245, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Копировать в буфер";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cardio_
            // 
            this.cardio_.Location = new System.Drawing.Point(211, 71);
            this.cardio_.Name = "cardio_";
            this.cardio_.Size = new System.Drawing.Size(174, 20);
            this.cardio_.TabIndex = 0;
            this.cardio_.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cardio_.ValueChanged += new System.EventHandler(this.card_ValueChanged);
            this.cardio_.Click += new System.EventHandler(this.cardio__Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(208, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Кардиовизор:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(208, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сахар:";
            // 
            // asd
            // 
            this.asd.AutoSize = true;
            this.asd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.asd.Location = new System.Drawing.Point(208, 107);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(81, 13);
            this.asd.TabIndex = 1;
            this.asd.Text = "Холестерин:";
            // 
            // sahar_
            // 
            this.sahar_.Location = new System.Drawing.Point(211, 167);
            this.sahar_.Mask = "0.0";
            this.sahar_.Name = "sahar_";
            this.sahar_.Size = new System.Drawing.Size(174, 20);
            this.sahar_.TabIndex = 15;
            this.sahar_.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sahar__MouseClick);
            this.sahar_.TextChanged += new System.EventHandler(this.sahar__TextChanged_1);
            // 
            // holest_
            // 
            this.holest_.Location = new System.Drawing.Point(211, 124);
            this.holest_.Mask = "0.0";
            this.holest_.Name = "holest_";
            this.holest_.Size = new System.Drawing.Size(174, 20);
            this.holest_.TabIndex = 16;
            this.holest_.Click += new System.EventHandler(this.holest__Click);
            this.holest_.TextChanged += new System.EventHandler(this.holest__TextChanged);
            // 
            // clear_card
            // 
            this.clear_card.BackgroundImage = global::dr.Properties.Resources.w128h1281338911337cross;
            this.clear_card.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clear_card.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.clear_card.Location = new System.Drawing.Point(391, 71);
            this.clear_card.Name = "clear_card";
            this.clear_card.Size = new System.Drawing.Size(20, 20);
            this.clear_card.TabIndex = 17;
            this.clear_card.UseVisualStyleBackColor = true;
            this.clear_card.Click += new System.EventHandler(this.clear_card_Click);
            // 
            // clear_s
            // 
            this.clear_s.BackgroundImage = global::dr.Properties.Resources.w128h1281338911337cross;
            this.clear_s.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clear_s.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.clear_s.Location = new System.Drawing.Point(391, 166);
            this.clear_s.Name = "clear_s";
            this.clear_s.Size = new System.Drawing.Size(20, 20);
            this.clear_s.TabIndex = 17;
            this.clear_s.UseVisualStyleBackColor = true;
            this.clear_s.Click += new System.EventHandler(this.clear_s_Click);
            // 
            // clear_ho
            // 
            this.clear_ho.BackgroundImage = global::dr.Properties.Resources.w128h1281338911337cross;
            this.clear_ho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clear_ho.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.clear_ho.Location = new System.Drawing.Point(391, 124);
            this.clear_ho.Name = "clear_ho";
            this.clear_ho.Size = new System.Drawing.Size(20, 20);
            this.clear_ho.TabIndex = 17;
            this.clear_ho.UseVisualStyleBackColor = true;
            this.clear_ho.Click += new System.EventHandler(this.clear_ho_Click);
            // 
            // zuby
            // 
            this.zuby.AutoSize = true;
            this.zuby.Location = new System.Drawing.Point(211, 197);
            this.zuby.Name = "zuby";
            this.zuby.Size = new System.Drawing.Size(105, 17);
            this.zuby.TabIndex = 18;
            this.zuby.Text = "Здоровые зубы";
            this.zuby.UseVisualStyleBackColor = true;
            this.zuby.CheckedChanged += new System.EventHandler(this.zuby_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 393);
            this.Controls.Add(this.zuby);
            this.Controls.Add(this.clear_ho);
            this.Controls.Add(this.clear_s);
            this.Controls.Add(this.clear_card);
            this.Controls.Add(this.holest_);
            this.Controls.Add(this.sahar_);
            this.Controls.Add(this.priglas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zakl);
            this.Controls.Add(this.recommended);
            this.Controls.Add(this.smoke);
            this.Controls.Add(this.imd);
            this.Controls.Add(this.bar);
            this.Controls.Add(this.diagnoz);
            this.Controls.Add(this.recomm);
            this.Controls.Add(this.asd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cardio_);
            this.Controls.Add(this.age_l);
            this.Controls.Add(this.age);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Dr. Helper";
            ((System.ComponentModel.ISupportInitialize)(this.age)).EndInit();
            this.bar.ResumeLayout(false);
            this.bar.PerformLayout();
            this.imd.ResumeLayout(false);
            this.imd.PerformLayout();
            this.smoke.ResumeLayout(false);
            this.smoke.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cardio_)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown age;
        private System.Windows.Forms.Label age_l;
        private System.Windows.Forms.RadioButton norm_b;
        private System.Windows.Forms.GroupBox bar;
        private System.Windows.Forms.RadioButton height_b;
        private System.Windows.Forms.GroupBox imd;
        private System.Windows.Forms.RadioButton four_w;
        private System.Windows.Forms.RadioButton three_w;
        private System.Windows.Forms.RadioButton two_w;
        private System.Windows.Forms.RadioButton one_w;
        private System.Windows.Forms.RadioButton low_w;
        private System.Windows.Forms.RadioButton norm_w;
        private System.Windows.Forms.RadioButton height_w;
        private System.Windows.Forms.GroupBox smoke;
        private System.Windows.Forms.RadioButton very_heigh_h;
        private System.Windows.Forms.RadioButton heigh_h;
        private System.Windows.Forms.RadioButton norm_h;
        private System.Windows.Forms.RadioButton heigh_s;
        private System.Windows.Forms.RadioButton mid_s;
        private System.Windows.Forms.RadioButton light_s;
        private System.Windows.Forms.RadioButton norm_s;
        private System.Windows.Forms.TextBox recommended;
        private System.Windows.Forms.Label recomm;
        private System.Windows.Forms.TextBox zakl;
        private System.Windows.Forms.Label diagnoz;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox priglas;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown cardio_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label asd;
        private System.Windows.Forms.MaskedTextBox sahar_;
        private System.Windows.Forms.MaskedTextBox holest_;
        private System.Windows.Forms.Button clear_card;
        private System.Windows.Forms.Button clear_s;
        private System.Windows.Forms.Button clear_ho;
        private System.Windows.Forms.CheckBox zuby;
    }
}

