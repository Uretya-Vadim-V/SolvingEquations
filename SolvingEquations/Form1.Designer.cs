
namespace SolvingEquations
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelOfEnterEqual = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxFifthDegree = new System.Windows.Forms.TextBox();
            this.labelFifthDegree = new System.Windows.Forms.Label();
            this.labelFourthDegree = new System.Windows.Forms.Label();
            this.textBoxFourthDegree = new System.Windows.Forms.TextBox();
            this.labelThirdDegree = new System.Windows.Forms.Label();
            this.textBoxThirdDegree = new System.Windows.Forms.TextBox();
            this.labelSecondDegree = new System.Windows.Forms.Label();
            this.textBoxSecondDegree = new System.Windows.Forms.TextBox();
            this.labelFirstDegree = new System.Windows.Forms.Label();
            this.textBoxFirstDegree = new System.Windows.Forms.TextBox();
            this.textBoxFreeMember = new System.Windows.Forms.TextBox();
            this.labelEquals = new System.Windows.Forms.Label();
            this.buttonFindRoofs = new System.Windows.Forms.Button();
            this.textBoxFindRoofs = new System.Windows.Forms.TextBox();
            this.buttonVerification = new System.Windows.Forms.Button();
            this.buttonBuildGraph = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ClearButton = new System.Windows.Forms.Button();
            this.StartX = new System.Windows.Forms.TextBox();
            this.EndX = new System.Windows.Forms.TextBox();
            this.ListResults = new System.Windows.Forms.TextBox();
            this.EndY = new System.Windows.Forms.TextBox();
            this.StartY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOfEnterEqual
            // 
            this.labelOfEnterEqual.AutoSize = true;
            this.labelOfEnterEqual.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfEnterEqual.ForeColor = System.Drawing.Color.White;
            this.labelOfEnterEqual.Location = new System.Drawing.Point(10, 9);
            this.labelOfEnterEqual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOfEnterEqual.Name = "labelOfEnterEqual";
            this.labelOfEnterEqual.Size = new System.Drawing.Size(322, 28);
            this.labelOfEnterEqual.TabIndex = 0;
            this.labelOfEnterEqual.Text = "Выберите степень уравнения:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(340, 6);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 35);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // textBoxFifthDegree
            // 
            this.textBoxFifthDegree.BackColor = System.Drawing.Color.Black;
            this.textBoxFifthDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFifthDegree.Enabled = false;
            this.textBoxFifthDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFifthDegree.ForeColor = System.Drawing.Color.White;
            this.textBoxFifthDegree.Location = new System.Drawing.Point(15, 70);
            this.textBoxFifthDegree.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFifthDegree.Name = "textBoxFifthDegree";
            this.textBoxFifthDegree.Size = new System.Drawing.Size(120, 34);
            this.textBoxFifthDegree.TabIndex = 3;
            this.textBoxFifthDegree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFifthDegree_KeyPress);
            // 
            // labelFifthDegree
            // 
            this.labelFifthDegree.AutoSize = true;
            this.labelFifthDegree.Enabled = false;
            this.labelFifthDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFifthDegree.ForeColor = System.Drawing.Color.White;
            this.labelFifthDegree.Location = new System.Drawing.Point(136, 73);
            this.labelFifthDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFifthDegree.Name = "labelFifthDegree";
            this.labelFifthDegree.Size = new System.Drawing.Size(52, 28);
            this.labelFifthDegree.TabIndex = 4;
            this.labelFifthDegree.Text = "x⁵ +";
            // 
            // labelFourthDegree
            // 
            this.labelFourthDegree.AutoSize = true;
            this.labelFourthDegree.Enabled = false;
            this.labelFourthDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFourthDegree.ForeColor = System.Drawing.Color.White;
            this.labelFourthDegree.Location = new System.Drawing.Point(316, 73);
            this.labelFourthDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFourthDegree.Name = "labelFourthDegree";
            this.labelFourthDegree.Size = new System.Drawing.Size(52, 28);
            this.labelFourthDegree.TabIndex = 6;
            this.labelFourthDegree.Text = "x⁴ +";
            // 
            // textBoxFourthDegree
            // 
            this.textBoxFourthDegree.BackColor = System.Drawing.Color.Black;
            this.textBoxFourthDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFourthDegree.Enabled = false;
            this.textBoxFourthDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFourthDegree.ForeColor = System.Drawing.Color.White;
            this.textBoxFourthDegree.Location = new System.Drawing.Point(195, 70);
            this.textBoxFourthDegree.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFourthDegree.Name = "textBoxFourthDegree";
            this.textBoxFourthDegree.Size = new System.Drawing.Size(120, 34);
            this.textBoxFourthDegree.TabIndex = 5;
            this.textBoxFourthDegree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFourthDegree_KeyPress);
            // 
            // labelThirdDegree
            // 
            this.labelThirdDegree.AutoSize = true;
            this.labelThirdDegree.Enabled = false;
            this.labelThirdDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThirdDegree.ForeColor = System.Drawing.Color.White;
            this.labelThirdDegree.Location = new System.Drawing.Point(496, 73);
            this.labelThirdDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelThirdDegree.Name = "labelThirdDegree";
            this.labelThirdDegree.Size = new System.Drawing.Size(53, 28);
            this.labelThirdDegree.TabIndex = 8;
            this.labelThirdDegree.Text = "x³ +";
            // 
            // textBoxThirdDegree
            // 
            this.textBoxThirdDegree.BackColor = System.Drawing.Color.Black;
            this.textBoxThirdDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxThirdDegree.Enabled = false;
            this.textBoxThirdDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxThirdDegree.ForeColor = System.Drawing.Color.White;
            this.textBoxThirdDegree.Location = new System.Drawing.Point(374, 70);
            this.textBoxThirdDegree.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxThirdDegree.Name = "textBoxThirdDegree";
            this.textBoxThirdDegree.Size = new System.Drawing.Size(120, 34);
            this.textBoxThirdDegree.TabIndex = 7;
            this.textBoxThirdDegree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxThirdDegree_KeyPress);
            // 
            // labelSecondDegree
            // 
            this.labelSecondDegree.AutoSize = true;
            this.labelSecondDegree.Enabled = false;
            this.labelSecondDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSecondDegree.ForeColor = System.Drawing.Color.White;
            this.labelSecondDegree.Location = new System.Drawing.Point(676, 73);
            this.labelSecondDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSecondDegree.Name = "labelSecondDegree";
            this.labelSecondDegree.Size = new System.Drawing.Size(53, 28);
            this.labelSecondDegree.TabIndex = 10;
            this.labelSecondDegree.Text = "x² +";
            // 
            // textBoxSecondDegree
            // 
            this.textBoxSecondDegree.BackColor = System.Drawing.Color.Black;
            this.textBoxSecondDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSecondDegree.Enabled = false;
            this.textBoxSecondDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSecondDegree.ForeColor = System.Drawing.Color.White;
            this.textBoxSecondDegree.Location = new System.Drawing.Point(553, 70);
            this.textBoxSecondDegree.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSecondDegree.Name = "textBoxSecondDegree";
            this.textBoxSecondDegree.Size = new System.Drawing.Size(120, 34);
            this.textBoxSecondDegree.TabIndex = 9;
            this.textBoxSecondDegree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSecondDegree_KeyPress);
            // 
            // labelFirstDegree
            // 
            this.labelFirstDegree.AutoSize = true;
            this.labelFirstDegree.Enabled = false;
            this.labelFirstDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFirstDegree.ForeColor = System.Drawing.Color.White;
            this.labelFirstDegree.Location = new System.Drawing.Point(856, 73);
            this.labelFirstDegree.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstDegree.Name = "labelFirstDegree";
            this.labelFirstDegree.Size = new System.Drawing.Size(45, 28);
            this.labelFirstDegree.TabIndex = 12;
            this.labelFirstDegree.Text = "x +";
            // 
            // textBoxFirstDegree
            // 
            this.textBoxFirstDegree.BackColor = System.Drawing.Color.Black;
            this.textBoxFirstDegree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFirstDegree.Enabled = false;
            this.textBoxFirstDegree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstDegree.ForeColor = System.Drawing.Color.White;
            this.textBoxFirstDegree.Location = new System.Drawing.Point(734, 70);
            this.textBoxFirstDegree.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFirstDegree.Name = "textBoxFirstDegree";
            this.textBoxFirstDegree.Size = new System.Drawing.Size(120, 34);
            this.textBoxFirstDegree.TabIndex = 11;
            this.textBoxFirstDegree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFirstDegree_KeyPress);
            // 
            // textBoxFreeMember
            // 
            this.textBoxFreeMember.BackColor = System.Drawing.Color.Black;
            this.textBoxFreeMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFreeMember.Enabled = false;
            this.textBoxFreeMember.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFreeMember.ForeColor = System.Drawing.Color.White;
            this.textBoxFreeMember.Location = new System.Drawing.Point(906, 70);
            this.textBoxFreeMember.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFreeMember.Name = "textBoxFreeMember";
            this.textBoxFreeMember.Size = new System.Drawing.Size(120, 34);
            this.textBoxFreeMember.TabIndex = 13;
            this.textBoxFreeMember.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxFreeMember_KeyPress);
            // 
            // labelEquals
            // 
            this.labelEquals.AutoSize = true;
            this.labelEquals.Enabled = false;
            this.labelEquals.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEquals.ForeColor = System.Drawing.Color.White;
            this.labelEquals.Location = new System.Drawing.Point(1030, 73);
            this.labelEquals.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEquals.Name = "labelEquals";
            this.labelEquals.Size = new System.Drawing.Size(46, 28);
            this.labelEquals.TabIndex = 14;
            this.labelEquals.Text = "= 0";
            // 
            // buttonFindRoofs
            // 
            this.buttonFindRoofs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindRoofs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.buttonFindRoofs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFindRoofs.Enabled = false;
            this.buttonFindRoofs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFindRoofs.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindRoofs.ForeColor = System.Drawing.Color.White;
            this.buttonFindRoofs.Location = new System.Drawing.Point(1093, 53);
            this.buttonFindRoofs.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFindRoofs.Name = "buttonFindRoofs";
            this.buttonFindRoofs.Size = new System.Drawing.Size(156, 76);
            this.buttonFindRoofs.TabIndex = 15;
            this.buttonFindRoofs.Text = "Найти корни";
            this.buttonFindRoofs.UseVisualStyleBackColor = false;
            this.buttonFindRoofs.Click += new System.EventHandler(this.buttonFindRoofs_Click);
            // 
            // textBoxFindRoofs
            // 
            this.textBoxFindRoofs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFindRoofs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.textBoxFindRoofs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFindRoofs.Enabled = false;
            this.textBoxFindRoofs.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFindRoofs.ForeColor = System.Drawing.Color.White;
            this.textBoxFindRoofs.Location = new System.Drawing.Point(734, 139);
            this.textBoxFindRoofs.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFindRoofs.Multiline = true;
            this.textBoxFindRoofs.Name = "textBoxFindRoofs";
            this.textBoxFindRoofs.ReadOnly = true;
            this.textBoxFindRoofs.Size = new System.Drawing.Size(515, 145);
            this.textBoxFindRoofs.TabIndex = 16;
            // 
            // buttonVerification
            // 
            this.buttonVerification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.buttonVerification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVerification.Enabled = false;
            this.buttonVerification.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonVerification.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVerification.ForeColor = System.Drawing.Color.White;
            this.buttonVerification.Location = new System.Drawing.Point(1093, 289);
            this.buttonVerification.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVerification.Name = "buttonVerification";
            this.buttonVerification.Size = new System.Drawing.Size(156, 50);
            this.buttonVerification.TabIndex = 17;
            this.buttonVerification.Text = "Проверка";
            this.buttonVerification.UseVisualStyleBackColor = false;
            this.buttonVerification.Click += new System.EventHandler(this.buttonVerification_Click);
            // 
            // buttonBuildGraph
            // 
            this.buttonBuildGraph.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonBuildGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.buttonBuildGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBuildGraph.Enabled = false;
            this.buttonBuildGraph.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBuildGraph.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuildGraph.ForeColor = System.Drawing.Color.White;
            this.buttonBuildGraph.Location = new System.Drawing.Point(185, 600);
            this.buttonBuildGraph.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBuildGraph.Name = "buttonBuildGraph";
            this.buttonBuildGraph.Size = new System.Drawing.Size(400, 50);
            this.buttonBuildGraph.TabIndex = 23;
            this.buttonBuildGraph.Text = "Построить график";
            this.buttonBuildGraph.UseVisualStyleBackColor = false;
            this.buttonBuildGraph.Click += new System.EventHandler(this.buttonBuildGraph_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Enabled = false;
            this.chart1.Location = new System.Drawing.Point(50, 139);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.MinimumSize = new System.Drawing.Size(400, 70);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Blue;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Black;
            series2.Name = "Series2";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "Series3";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(674, 420);
            this.chart1.TabIndex = 24;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            this.chart1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseWheel);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(1093, 600);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(156, 50);
            this.ClearButton.TabIndex = 25;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // StartX
            // 
            this.StartX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartX.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartX.Location = new System.Drawing.Point(50, 563);
            this.StartX.Multiline = true;
            this.StartX.Name = "StartX";
            this.StartX.Size = new System.Drawing.Size(120, 30);
            this.StartX.TabIndex = 28;
            this.StartX.Text = "-10";
            this.StartX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StartX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartX_KeyPress);
            // 
            // EndX
            // 
            this.EndX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EndX.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndX.Location = new System.Drawing.Point(604, 563);
            this.EndX.Multiline = true;
            this.EndX.Name = "EndX";
            this.EndX.Size = new System.Drawing.Size(120, 30);
            this.EndX.TabIndex = 29;
            this.EndX.Text = "10";
            this.EndX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EndX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndX_KeyPress);
            // 
            // ListResults
            // 
            this.ListResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ListResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ListResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListResults.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListResults.ForeColor = System.Drawing.Color.White;
            this.ListResults.Location = new System.Drawing.Point(735, 346);
            this.ListResults.Multiline = true;
            this.ListResults.Name = "ListResults";
            this.ListResults.ReadOnly = true;
            this.ListResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListResults.Size = new System.Drawing.Size(515, 247);
            this.ListResults.TabIndex = 30;
            // 
            // EndY
            // 
            this.EndY.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndY.Location = new System.Drawing.Point(15, 139);
            this.EndY.Multiline = true;
            this.EndY.Name = "EndY";
            this.EndY.Size = new System.Drawing.Size(30, 120);
            this.EndY.TabIndex = 31;
            this.EndY.Text = "10";
            this.EndY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EndY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EndY_KeyPress);
            // 
            // StartY
            // 
            this.StartY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartY.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartY.Location = new System.Drawing.Point(15, 439);
            this.StartY.Multiline = true;
            this.StartY.Name = "StartY";
            this.StartY.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartY.Size = new System.Drawing.Size(30, 120);
            this.StartY.TabIndex = 32;
            this.StartY.Text = "-10";
            this.StartY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StartY.WordWrap = false;
            this.StartY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartY_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.StartY);
            this.Controls.Add(this.EndY);
            this.Controls.Add(this.ListResults);
            this.Controls.Add(this.EndX);
            this.Controls.Add(this.StartX);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.buttonBuildGraph);
            this.Controls.Add(this.buttonVerification);
            this.Controls.Add(this.textBoxFindRoofs);
            this.Controls.Add(this.buttonFindRoofs);
            this.Controls.Add(this.labelEquals);
            this.Controls.Add(this.textBoxFreeMember);
            this.Controls.Add(this.labelFirstDegree);
            this.Controls.Add(this.textBoxFirstDegree);
            this.Controls.Add(this.labelSecondDegree);
            this.Controls.Add(this.textBoxSecondDegree);
            this.Controls.Add(this.labelThirdDegree);
            this.Controls.Add(this.textBoxThirdDegree);
            this.Controls.Add(this.labelFourthDegree);
            this.Controls.Add(this.textBoxFourthDegree);
            this.Controls.Add(this.labelFifthDegree);
            this.Controls.Add(this.textBoxFifthDegree);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelOfEnterEqual);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.Text = "Решение уравнений";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOfEnterEqual;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxFifthDegree;
        private System.Windows.Forms.Label labelFifthDegree;
        private System.Windows.Forms.Label labelFourthDegree;
        private System.Windows.Forms.TextBox textBoxFourthDegree;
        private System.Windows.Forms.Label labelThirdDegree;
        private System.Windows.Forms.TextBox textBoxThirdDegree;
        private System.Windows.Forms.Label labelSecondDegree;
        private System.Windows.Forms.TextBox textBoxSecondDegree;
        private System.Windows.Forms.Label labelFirstDegree;
        private System.Windows.Forms.TextBox textBoxFirstDegree;
        private System.Windows.Forms.TextBox textBoxFreeMember;
        private System.Windows.Forms.Label labelEquals;
        private System.Windows.Forms.Button buttonFindRoofs;
        private System.Windows.Forms.TextBox textBoxFindRoofs;
        private System.Windows.Forms.Button buttonBuildGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button buttonVerification;
        private System.Windows.Forms.TextBox StartX;
        private System.Windows.Forms.TextBox EndX;
        private System.Windows.Forms.TextBox ListResults;
        private System.Windows.Forms.TextBox EndY;
        private System.Windows.Forms.TextBox StartY;
    }
}

