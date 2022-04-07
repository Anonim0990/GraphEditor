
namespace lab
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteAll = new System.Windows.Forms.Button();
            this.buttonDeleteV = new System.Windows.Forms.Button();
            this.kolorek = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonEng = new System.Windows.Forms.Button();
            this.buttonPl = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.Map = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Map, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(630, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(151, 555);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDeleteAll);
            this.groupBox1.Controls.Add(this.buttonDeleteV);
            this.groupBox1.Controls.Add(this.kolorek);
            this.groupBox1.Controls.Add(this.buttonColor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 309);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edycja";
            // 
            // buttonDeleteAll
            // 
            this.buttonDeleteAll.Location = new System.Drawing.Point(7, 103);
            this.buttonDeleteAll.Name = "buttonDeleteAll";
            this.buttonDeleteAll.Size = new System.Drawing.Size(121, 30);
            this.buttonDeleteAll.TabIndex = 3;
            this.buttonDeleteAll.Text = "Wyczyść graf";
            this.buttonDeleteAll.UseVisualStyleBackColor = true;
            this.buttonDeleteAll.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // buttonDeleteV
            // 
            this.buttonDeleteV.Location = new System.Drawing.Point(7, 67);
            this.buttonDeleteV.Name = "buttonDeleteV";
            this.buttonDeleteV.Size = new System.Drawing.Size(121, 30);
            this.buttonDeleteV.TabIndex = 2;
            this.buttonDeleteV.Text = "Usuń wierzchołek";
            this.buttonDeleteV.UseVisualStyleBackColor = true;
            this.buttonDeleteV.Click += new System.EventHandler(this.buttonDeleteV_Click);
            // 
            // kolorek
            // 
            this.kolorek.BackColor = System.Drawing.Color.Black;
            this.kolorek.Location = new System.Drawing.Point(88, 31);
            this.kolorek.Margin = new System.Windows.Forms.Padding(0);
            this.kolorek.Name = "kolorek";
            this.kolorek.Size = new System.Drawing.Size(40, 30);
            this.kolorek.TabIndex = 1;
            this.kolorek.UseVisualStyleBackColor = false;
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(6, 31);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(79, 30);
            this.buttonColor.TabIndex = 0;
            this.buttonColor.Text = "Kolor";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonEng);
            this.groupBox2.Controls.Add(this.buttonPl);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 114);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Język";
            // 
            // buttonEng
            // 
            this.buttonEng.Enabled = false;
            this.buttonEng.Location = new System.Drawing.Point(6, 68);
            this.buttonEng.Name = "buttonEng";
            this.buttonEng.Size = new System.Drawing.Size(133, 40);
            this.buttonEng.TabIndex = 1;
            this.buttonEng.Text = "Angielski";
            this.buttonEng.UseVisualStyleBackColor = true;
            // 
            // buttonPl
            // 
            this.buttonPl.Enabled = false;
            this.buttonPl.Location = new System.Drawing.Point(6, 22);
            this.buttonPl.Name = "buttonPl";
            this.buttonPl.Size = new System.Drawing.Size(133, 40);
            this.buttonPl.TabIndex = 0;
            this.buttonPl.Text = "Polski";
            this.buttonPl.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonLoad);
            this.groupBox3.Controls.Add(this.buttonSave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 438);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 114);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Import/Eksport";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(6, 68);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(133, 40);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Wczytaj";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(6, 22);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(133, 40);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Map
            // 
            this.Map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Map.BackColor = System.Drawing.Color.White;
            this.Map.Location = new System.Drawing.Point(3, 3);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(621, 555);
            this.Map.TabIndex = 1;
            this.Map.TabStop = false;
            this.Map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Map_MouseClick);
            this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
            this.Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_MouseMove);
            this.Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edytor Grafów";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonEng;
        private System.Windows.Forms.Button buttonPl;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox Map;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Button kolorek;
        private System.Windows.Forms.Button buttonDeleteAll;
        private System.Windows.Forms.Button buttonDeleteV;
    }
}

