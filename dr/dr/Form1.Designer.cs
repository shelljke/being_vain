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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nud_age = new System.Windows.Forms.NumericUpDown();
            this.l_age = new System.Windows.Forms.Label();
            this.rb_pressureNorm = new System.Windows.Forms.RadioButton();
            this.gp_pressure = new System.Windows.Forms.GroupBox();
            this.rb_pressureHigh = new System.Windows.Forms.RadioButton();
            this.very_heigh_h = new System.Windows.Forms.RadioButton();
            this.heigh_h = new System.Windows.Forms.RadioButton();
            this.norm_h = new System.Windows.Forms.RadioButton();
            this.gp_BMI = new System.Windows.Forms.GroupBox();
            this.rb_BMIFour = new System.Windows.Forms.RadioButton();
            this.rb_BMIThree = new System.Windows.Forms.RadioButton();
            this.rb_BMITwo = new System.Windows.Forms.RadioButton();
            this.rb_BMIOne = new System.Windows.Forms.RadioButton();
            this.rb_BMILow = new System.Windows.Forms.RadioButton();
            this.rb_BMINorm = new System.Windows.Forms.RadioButton();
            this.rb_BMIHigh = new System.Windows.Forms.RadioButton();
            this.gp_smoking = new System.Windows.Forms.GroupBox();
            this.rb_smokingHigh = new System.Windows.Forms.RadioButton();
            this.rb_smokingMid = new System.Windows.Forms.RadioButton();
            this.rb_smokingLight = new System.Windows.Forms.RadioButton();
            this.rb_smokingNorm = new System.Windows.Forms.RadioButton();
            this.b_recommendations = new System.Windows.Forms.Button();
            this.b_abnormalities = new System.Windows.Forms.Button();
            this.nud_cardiovisor = new System.Windows.Forms.NumericUpDown();
            this.l_cardiovisor = new System.Windows.Forms.Label();
            this.l_sugar = new System.Windows.Forms.Label();
            this.l_cholesterol = new System.Windows.Forms.Label();
            this.tl_sugar = new System.Windows.Forms.MaskedTextBox();
            this.tl_cholesterol = new System.Windows.Forms.MaskedTextBox();
            this.b_cardiovisorClear = new System.Windows.Forms.Button();
            this.b_sugarClear = new System.Windows.Forms.Button();
            this.b_cholesterolClear = new System.Windows.Forms.Button();
            this.rb_teeth = new System.Windows.Forms.CheckBox();
            this.b_conclusion = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.b_effectuation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_age)).BeginInit();
            this.gp_pressure.SuspendLayout();
            this.gp_BMI.SuspendLayout();
            this.gp_smoking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cardiovisor)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_age
            // 
            this.nud_age.Location = new System.Drawing.Point(197, 25);
            this.nud_age.Name = "nud_age";
            this.nud_age.Size = new System.Drawing.Size(157, 20);
            this.nud_age.TabIndex = 0;
            this.nud_age.ValueChanged += new System.EventHandler(this.nud_age_ValueChanged);
            this.nud_age.Click += new System.EventHandler(this.nud_age_Click);
            // 
            // l_age
            // 
            this.l_age.AutoSize = true;
            this.l_age.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_age.Location = new System.Drawing.Point(197, 9);
            this.l_age.Name = "l_age";
            this.l_age.Size = new System.Drawing.Size(60, 13);
            this.l_age.TabIndex = 1;
            this.l_age.Text = "Возраст:";
            // 
            // rb_pressureNorm
            // 
            this.rb_pressureNorm.AutoSize = true;
            this.rb_pressureNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_pressureNorm.Location = new System.Drawing.Point(6, 19);
            this.rb_pressureNorm.Name = "rb_pressureNorm";
            this.rb_pressureNorm.Size = new System.Drawing.Size(122, 17);
            this.rb_pressureNorm.TabIndex = 5;
            this.rb_pressureNorm.Text = "Нормальное (<140)";
            this.rb_pressureNorm.UseVisualStyleBackColor = true;
            this.rb_pressureNorm.CheckedChanged += new System.EventHandler(this.rb_pressureNorm_CheckedChanged);
            // 
            // gp_pressure
            // 
            this.gp_pressure.Controls.Add(this.rb_pressureHigh);
            this.gp_pressure.Controls.Add(this.rb_pressureNorm);
            this.gp_pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gp_pressure.Location = new System.Drawing.Point(9, 10);
            this.gp_pressure.Name = "gp_pressure";
            this.gp_pressure.Size = new System.Drawing.Size(178, 69);
            this.gp_pressure.TabIndex = 6;
            this.gp_pressure.TabStop = false;
            this.gp_pressure.Text = "Давление";
            // 
            // rb_pressureHigh
            // 
            this.rb_pressureHigh.AutoSize = true;
            this.rb_pressureHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_pressureHigh.Location = new System.Drawing.Point(6, 42);
            this.rb_pressureHigh.Name = "rb_pressureHigh";
            this.rb_pressureHigh.Size = new System.Drawing.Size(124, 17);
            this.rb_pressureHigh.TabIndex = 6;
            this.rb_pressureHigh.TabStop = true;
            this.rb_pressureHigh.Text = "Повышенное (≥140)";
            this.rb_pressureHigh.UseVisualStyleBackColor = true;
            this.rb_pressureHigh.CheckedChanged += new System.EventHandler(this.rb_pressureHigh_CheckedChanged);
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
            // gp_BMI
            // 
            this.gp_BMI.Controls.Add(this.rb_BMIFour);
            this.gp_BMI.Controls.Add(this.rb_BMIThree);
            this.gp_BMI.Controls.Add(this.rb_BMITwo);
            this.gp_BMI.Controls.Add(this.rb_BMIOne);
            this.gp_BMI.Controls.Add(this.rb_BMILow);
            this.gp_BMI.Controls.Add(this.rb_BMINorm);
            this.gp_BMI.Controls.Add(this.rb_BMIHigh);
            this.gp_BMI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gp_BMI.Location = new System.Drawing.Point(9, 85);
            this.gp_BMI.Name = "gp_BMI";
            this.gp_BMI.Size = new System.Drawing.Size(178, 182);
            this.gp_BMI.TabIndex = 9;
            this.gp_BMI.TabStop = false;
            this.gp_BMI.Text = "ИМД";
            // 
            // rb_BMIFour
            // 
            this.rb_BMIFour.AutoSize = true;
            this.rb_BMIFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_BMIFour.Location = new System.Drawing.Point(6, 157);
            this.rb_BMIFour.Name = "rb_BMIFour";
            this.rb_BMIFour.Size = new System.Drawing.Size(163, 17);
            this.rb_BMIFour.TabIndex = 18;
            this.rb_BMIFour.TabStop = true;
            this.rb_BMIFour.Text = "Ожирение 4 степени (40-...)";
            this.rb_BMIFour.UseVisualStyleBackColor = true;
            this.rb_BMIFour.CheckedChanged += new System.EventHandler(this.rb_BMIFour_CheckedChanged);
            // 
            // rb_BMIThree
            // 
            this.rb_BMIThree.AutoSize = true;
            this.rb_BMIThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_BMIThree.Location = new System.Drawing.Point(6, 134);
            this.rb_BMIThree.Name = "rb_BMIThree";
            this.rb_BMIThree.Size = new System.Drawing.Size(166, 17);
            this.rb_BMIThree.TabIndex = 17;
            this.rb_BMIThree.TabStop = true;
            this.rb_BMIThree.Text = "Ожирение 3 степени (37-39)";
            this.rb_BMIThree.UseVisualStyleBackColor = true;
            this.rb_BMIThree.CheckedChanged += new System.EventHandler(this.rb_BMIThree_CheckedChanged);
            // 
            // rb_BMITwo
            // 
            this.rb_BMITwo.AutoSize = true;
            this.rb_BMITwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_BMITwo.Location = new System.Drawing.Point(6, 111);
            this.rb_BMITwo.Name = "rb_BMITwo";
            this.rb_BMITwo.Size = new System.Drawing.Size(166, 17);
            this.rb_BMITwo.TabIndex = 14;
            this.rb_BMITwo.TabStop = true;
            this.rb_BMITwo.Text = "Ожирение 2 степени (34-36)";
            this.rb_BMITwo.UseVisualStyleBackColor = true;
            this.rb_BMITwo.CheckedChanged += new System.EventHandler(this.rb_BMITwo_CheckedChanged);
            // 
            // rb_BMIOne
            // 
            this.rb_BMIOne.AutoSize = true;
            this.rb_BMIOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_BMIOne.Location = new System.Drawing.Point(6, 88);
            this.rb_BMIOne.Name = "rb_BMIOne";
            this.rb_BMIOne.Size = new System.Drawing.Size(166, 17);
            this.rb_BMIOne.TabIndex = 16;
            this.rb_BMIOne.TabStop = true;
            this.rb_BMIOne.Text = "Ожирение 1 степени (30-33)";
            this.rb_BMIOne.UseVisualStyleBackColor = true;
            this.rb_BMIOne.CheckedChanged += new System.EventHandler(this.rb_BMIOne_CheckedChanged);
            // 
            // rb_BMILow
            // 
            this.rb_BMILow.AutoSize = true;
            this.rb_BMILow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_BMILow.Location = new System.Drawing.Point(6, 19);
            this.rb_BMILow.Name = "rb_BMILow";
            this.rb_BMILow.Size = new System.Drawing.Size(160, 17);
            this.rb_BMILow.TabIndex = 12;
            this.rb_BMILow.TabStop = true;
            this.rb_BMILow.Text = "Пониженное питание (<18)";
            this.rb_BMILow.UseVisualStyleBackColor = true;
            this.rb_BMILow.CheckedChanged += new System.EventHandler(this.rb_BMILow_CheckedChanged);
            // 
            // rb_BMINorm
            // 
            this.rb_BMINorm.AutoSize = true;
            this.rb_BMINorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_BMINorm.Location = new System.Drawing.Point(6, 42);
            this.rb_BMINorm.Name = "rb_BMINorm";
            this.rb_BMINorm.Size = new System.Drawing.Size(95, 17);
            this.rb_BMINorm.TabIndex = 15;
            this.rb_BMINorm.Text = "Норма (18-22)";
            this.rb_BMINorm.UseVisualStyleBackColor = true;
            this.rb_BMINorm.CheckedChanged += new System.EventHandler(this.rb_BMINorm__CheckedChanged);
            // 
            // rb_BMIHigh
            // 
            this.rb_BMIHigh.AutoSize = true;
            this.rb_BMIHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_BMIHigh.Location = new System.Drawing.Point(6, 65);
            this.rb_BMIHigh.Name = "rb_BMIHigh";
            this.rb_BMIHigh.Size = new System.Drawing.Size(171, 17);
            this.rb_BMIHigh.TabIndex = 13;
            this.rb_BMIHigh.TabStop = true;
            this.rb_BMIHigh.Text = "Повышенное питание (23-29)";
            this.rb_BMIHigh.UseVisualStyleBackColor = true;
            this.rb_BMIHigh.CheckedChanged += new System.EventHandler(this.rb_BMIHigh_CheckedChanged);
            // 
            // gp_smoking
            // 
            this.gp_smoking.Controls.Add(this.rb_smokingHigh);
            this.gp_smoking.Controls.Add(this.rb_smokingMid);
            this.gp_smoking.Controls.Add(this.rb_smokingLight);
            this.gp_smoking.Controls.Add(this.rb_smokingNorm);
            this.gp_smoking.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gp_smoking.Location = new System.Drawing.Point(9, 273);
            this.gp_smoking.Name = "gp_smoking";
            this.gp_smoking.Size = new System.Drawing.Size(177, 109);
            this.gp_smoking.TabIndex = 10;
            this.gp_smoking.TabStop = false;
            this.gp_smoking.Text = "Курение";
            // 
            // rb_smokingHigh
            // 
            this.rb_smokingHigh.AutoSize = true;
            this.rb_smokingHigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_smokingHigh.Location = new System.Drawing.Point(6, 84);
            this.rb_smokingHigh.Name = "rb_smokingHigh";
            this.rb_smokingHigh.Size = new System.Drawing.Size(105, 17);
            this.rb_smokingHigh.TabIndex = 2;
            this.rb_smokingHigh.TabStop = true;
            this.rb_smokingHigh.Text = "Тяжелый (20-...)";
            this.rb_smokingHigh.UseVisualStyleBackColor = true;
            this.rb_smokingHigh.CheckedChanged += new System.EventHandler(this.rb_smokingHigh_CheckedChanged);
            // 
            // rb_smokingMid
            // 
            this.rb_smokingMid.AutoSize = true;
            this.rb_smokingMid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_smokingMid.Location = new System.Drawing.Point(7, 61);
            this.rb_smokingMid.Name = "rb_smokingMid";
            this.rb_smokingMid.Size = new System.Drawing.Size(104, 17);
            this.rb_smokingMid.TabIndex = 2;
            this.rb_smokingMid.TabStop = true;
            this.rb_smokingMid.Text = "Средний (11-19)";
            this.rb_smokingMid.UseVisualStyleBackColor = true;
            this.rb_smokingMid.CheckedChanged += new System.EventHandler(this.rb_smokingMid_CheckedChanged);
            // 
            // rb_smokingLight
            // 
            this.rb_smokingLight.AutoSize = true;
            this.rb_smokingLight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_smokingLight.Location = new System.Drawing.Point(7, 38);
            this.rb_smokingLight.Name = "rb_smokingLight";
            this.rb_smokingLight.Size = new System.Drawing.Size(92, 17);
            this.rb_smokingLight.TabIndex = 1;
            this.rb_smokingLight.TabStop = true;
            this.rb_smokingLight.Text = "Легкий (6-10)";
            this.rb_smokingLight.UseVisualStyleBackColor = true;
            this.rb_smokingLight.CheckedChanged += new System.EventHandler(this.rb_smokingLight_CheckedChanged);
            // 
            // rb_smokingNorm
            // 
            this.rb_smokingNorm.AutoSize = true;
            this.rb_smokingNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_smokingNorm.Location = new System.Drawing.Point(7, 15);
            this.rb_smokingNorm.Name = "rb_smokingNorm";
            this.rb_smokingNorm.Size = new System.Drawing.Size(70, 17);
            this.rb_smokingNorm.TabIndex = 0;
            this.rb_smokingNorm.Text = "Не курит";
            this.rb_smokingNorm.UseVisualStyleBackColor = true;
            this.rb_smokingNorm.CheckedChanged += new System.EventHandler(this.rb_smokingNorm_CheckedChanged);
            // 
            // b_recommendations
            // 
            this.b_recommendations.BackColor = System.Drawing.Color.MediumAquamarine;
            this.b_recommendations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_recommendations.Location = new System.Drawing.Point(194, 329);
            this.b_recommendations.Name = "b_recommendations";
            this.b_recommendations.Size = new System.Drawing.Size(160, 23);
            this.b_recommendations.TabIndex = 13;
            this.b_recommendations.Text = "Копировать рекомендации";
            this.b_recommendations.UseVisualStyleBackColor = false;
            this.b_recommendations.Click += new System.EventHandler(this.b_recommendations_Click);
            // 
            // b_abnormalities
            // 
            this.b_abnormalities.BackColor = System.Drawing.Color.MediumAquamarine;
            this.b_abnormalities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_abnormalities.Location = new System.Drawing.Point(194, 220);
            this.b_abnormalities.Name = "b_abnormalities";
            this.b_abnormalities.Size = new System.Drawing.Size(160, 23);
            this.b_abnormalities.TabIndex = 13;
            this.b_abnormalities.Text = "Копировать отклонения";
            this.b_abnormalities.UseVisualStyleBackColor = false;
            this.b_abnormalities.Click += new System.EventHandler(this.b_abnormalities_Click);
            // 
            // nud_cardiovisor
            // 
            this.nud_cardiovisor.Location = new System.Drawing.Point(197, 64);
            this.nud_cardiovisor.Name = "nud_cardiovisor";
            this.nud_cardiovisor.Size = new System.Drawing.Size(131, 20);
            this.nud_cardiovisor.TabIndex = 0;
            this.nud_cardiovisor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_cardiovisor.ValueChanged += new System.EventHandler(this.nud_cardiovisor_ValueChanged);
            this.nud_cardiovisor.Click += new System.EventHandler(this.nud_cardiovisor_Click);
            // 
            // l_cardiovisor
            // 
            this.l_cardiovisor.AutoSize = true;
            this.l_cardiovisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_cardiovisor.Location = new System.Drawing.Point(197, 48);
            this.l_cardiovisor.Name = "l_cardiovisor";
            this.l_cardiovisor.Size = new System.Drawing.Size(89, 13);
            this.l_cardiovisor.TabIndex = 1;
            this.l_cardiovisor.Text = "Кардиовизор:";
            // 
            // l_sugar
            // 
            this.l_sugar.AutoSize = true;
            this.l_sugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_sugar.Location = new System.Drawing.Point(197, 126);
            this.l_sugar.Name = "l_sugar";
            this.l_sugar.Size = new System.Drawing.Size(46, 13);
            this.l_sugar.TabIndex = 1;
            this.l_sugar.Text = "Сахар:";
            // 
            // l_cholesterol
            // 
            this.l_cholesterol.AutoSize = true;
            this.l_cholesterol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_cholesterol.Location = new System.Drawing.Point(197, 87);
            this.l_cholesterol.Name = "l_cholesterol";
            this.l_cholesterol.Size = new System.Drawing.Size(81, 13);
            this.l_cholesterol.TabIndex = 1;
            this.l_cholesterol.Text = "Холестерин:";
            // 
            // tl_sugar
            // 
            this.tl_sugar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tl_sugar.Location = new System.Drawing.Point(197, 142);
            this.tl_sugar.Mask = "0.0";
            this.tl_sugar.Name = "tl_sugar";
            this.tl_sugar.PromptChar = '0';
            this.tl_sugar.RejectInputOnFirstFailure = true;
            this.tl_sugar.Size = new System.Drawing.Size(131, 20);
            this.tl_sugar.TabIndex = 15;
            this.tl_sugar.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.tl_sugar.Click += new System.EventHandler(this.tl_sugar_Click);
            this.tl_sugar.Leave += new System.EventHandler(this.tl_sugar_Leave);
            // 
            // tl_cholesterol
            // 
            this.tl_cholesterol.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.tl_cholesterol.Location = new System.Drawing.Point(197, 103);
            this.tl_cholesterol.Mask = "0.0";
            this.tl_cholesterol.Name = "tl_cholesterol";
            this.tl_cholesterol.PromptChar = '0';
            this.tl_cholesterol.Size = new System.Drawing.Size(131, 20);
            this.tl_cholesterol.TabIndex = 16;
            this.tl_cholesterol.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.tl_cholesterol.Click += new System.EventHandler(this.tl_cholesterol_Click);
            this.tl_cholesterol.Leave += new System.EventHandler(this.tl_cholesterol_Leave);
            // 
            // b_cardiovisorClear
            // 
            this.b_cardiovisorClear.BackgroundImage = global::dr.Properties.Resources.w128h1281338911337cross;
            this.b_cardiovisorClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_cardiovisorClear.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.b_cardiovisorClear.Location = new System.Drawing.Point(334, 64);
            this.b_cardiovisorClear.Name = "b_cardiovisorClear";
            this.b_cardiovisorClear.Size = new System.Drawing.Size(20, 20);
            this.b_cardiovisorClear.TabIndex = 17;
            this.b_cardiovisorClear.UseVisualStyleBackColor = true;
            this.b_cardiovisorClear.Click += new System.EventHandler(this.b_cardiovisorClear_Click);
            // 
            // b_sugarClear
            // 
            this.b_sugarClear.BackgroundImage = global::dr.Properties.Resources.w128h1281338911337cross;
            this.b_sugarClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_sugarClear.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.b_sugarClear.Location = new System.Drawing.Point(334, 141);
            this.b_sugarClear.Name = "b_sugarClear";
            this.b_sugarClear.Size = new System.Drawing.Size(20, 20);
            this.b_sugarClear.TabIndex = 17;
            this.b_sugarClear.UseVisualStyleBackColor = true;
            this.b_sugarClear.Click += new System.EventHandler(this.b_sugarClear_Click);
            // 
            // b_cholesterolClear
            // 
            this.b_cholesterolClear.BackgroundImage = global::dr.Properties.Resources.w128h1281338911337cross;
            this.b_cholesterolClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.b_cholesterolClear.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.b_cholesterolClear.Location = new System.Drawing.Point(334, 103);
            this.b_cholesterolClear.Name = "b_cholesterolClear";
            this.b_cholesterolClear.Size = new System.Drawing.Size(20, 20);
            this.b_cholesterolClear.TabIndex = 17;
            this.b_cholesterolClear.UseVisualStyleBackColor = true;
            this.b_cholesterolClear.Click += new System.EventHandler(this.b_cholesterolClear_Click);
            // 
            // rb_teeth
            // 
            this.rb_teeth.AutoSize = true;
            this.rb_teeth.Location = new System.Drawing.Point(197, 167);
            this.rb_teeth.Name = "rb_teeth";
            this.rb_teeth.Size = new System.Drawing.Size(157, 17);
            this.rb_teeth.TabIndex = 18;
            this.rb_teeth.Text = "Заболевание полости рта";
            this.rb_teeth.UseVisualStyleBackColor = true;
            this.rb_teeth.CheckedChanged += new System.EventHandler(this.rb_teeth_CheckedChanged);
            // 
            // b_conclusion
            // 
            this.b_conclusion.BackColor = System.Drawing.Color.MediumAquamarine;
            this.b_conclusion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_conclusion.Location = new System.Drawing.Point(194, 300);
            this.b_conclusion.Name = "b_conclusion";
            this.b_conclusion.Size = new System.Drawing.Size(160, 23);
            this.b_conclusion.TabIndex = 13;
            this.b_conclusion.Text = "Копировать заключение";
            this.b_conclusion.UseVisualStyleBackColor = false;
            this.b_conclusion.Click += new System.EventHandler(this.b_conclusion_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(194, 249);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 37);
            this.button5.TabIndex = 19;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(226, 249);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(32, 37);
            this.button6.TabIndex = 19;
            this.button6.Text = "button5";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(290, 249);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 37);
            this.button7.TabIndex = 19;
            this.button7.Text = "button5";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(322, 249);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(32, 37);
            this.button8.TabIndex = 19;
            this.button8.Text = "button5";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(258, 249);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(32, 37);
            this.button9.TabIndex = 19;
            this.button9.Text = "button5";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // b_effectuation
            // 
            this.b_effectuation.BackColor = System.Drawing.Color.MediumAquamarine;
            this.b_effectuation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_effectuation.Location = new System.Drawing.Point(194, 357);
            this.b_effectuation.Name = "b_effectuation";
            this.b_effectuation.Size = new System.Drawing.Size(160, 23);
            this.b_effectuation.TabIndex = 13;
            this.b_effectuation.Text = "Копировать выполнение";
            this.b_effectuation.UseVisualStyleBackColor = false;
            this.b_effectuation.Click += new System.EventHandler(this.b_effectuation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 393);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.rb_teeth);
            this.Controls.Add(this.b_cholesterolClear);
            this.Controls.Add(this.b_sugarClear);
            this.Controls.Add(this.b_cardiovisorClear);
            this.Controls.Add(this.tl_cholesterol);
            this.Controls.Add(this.tl_sugar);
            this.Controls.Add(this.b_abnormalities);
            this.Controls.Add(this.b_conclusion);
            this.Controls.Add(this.b_effectuation);
            this.Controls.Add(this.b_recommendations);
            this.Controls.Add(this.gp_smoking);
            this.Controls.Add(this.gp_BMI);
            this.Controls.Add(this.gp_pressure);
            this.Controls.Add(this.l_cholesterol);
            this.Controls.Add(this.l_sugar);
            this.Controls.Add(this.l_cardiovisor);
            this.Controls.Add(this.nud_cardiovisor);
            this.Controls.Add(this.l_age);
            this.Controls.Add(this.nud_age);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dr. Helper";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.nud_age)).EndInit();
            this.gp_pressure.ResumeLayout(false);
            this.gp_pressure.PerformLayout();
            this.gp_BMI.ResumeLayout(false);
            this.gp_BMI.PerformLayout();
            this.gp_smoking.ResumeLayout(false);
            this.gp_smoking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cardiovisor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_age;
        private System.Windows.Forms.Label l_age;
        private System.Windows.Forms.RadioButton rb_pressureNorm;
        private System.Windows.Forms.GroupBox gp_pressure;
        private System.Windows.Forms.RadioButton rb_pressureHigh;
        private System.Windows.Forms.GroupBox gp_BMI;
        private System.Windows.Forms.RadioButton rb_BMIFour;
        private System.Windows.Forms.RadioButton rb_BMIThree;
        private System.Windows.Forms.RadioButton rb_BMITwo;
        private System.Windows.Forms.RadioButton rb_BMIOne;
        private System.Windows.Forms.RadioButton rb_BMILow;
        private System.Windows.Forms.RadioButton rb_BMINorm;
        private System.Windows.Forms.RadioButton rb_BMIHigh;
        private System.Windows.Forms.GroupBox gp_smoking;
        private System.Windows.Forms.RadioButton very_heigh_h;
        private System.Windows.Forms.RadioButton heigh_h;
        private System.Windows.Forms.RadioButton norm_h;
        private System.Windows.Forms.RadioButton rb_smokingHigh;
        private System.Windows.Forms.RadioButton rb_smokingMid;
        private System.Windows.Forms.RadioButton rb_smokingLight;
        private System.Windows.Forms.RadioButton rb_smokingNorm;
        private System.Windows.Forms.Button b_recommendations;
        private System.Windows.Forms.Button b_abnormalities;
        private System.Windows.Forms.NumericUpDown nud_cardiovisor;
        private System.Windows.Forms.Label l_cardiovisor;
        private System.Windows.Forms.Label l_sugar;
        private System.Windows.Forms.Label l_cholesterol;
        private System.Windows.Forms.MaskedTextBox tl_sugar;
        private System.Windows.Forms.MaskedTextBox tl_cholesterol;
        private System.Windows.Forms.Button b_cardiovisorClear;
        private System.Windows.Forms.Button b_sugarClear;
        private System.Windows.Forms.Button b_cholesterolClear;
        private System.Windows.Forms.CheckBox rb_teeth;
        private System.Windows.Forms.Button b_conclusion;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button b_effectuation;
    }
}

