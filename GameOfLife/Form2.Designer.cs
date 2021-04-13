
namespace GameOfLife
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.AboutButton = new System.Windows.Forms.Button();
            this.escapeButton = new System.Windows.Forms.Button();
            this.ControlPanel = new System.Windows.Forms.GroupBox();
            this.SavePoint = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pause_resume_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.GameUpdate = new System.Windows.Forms.Timer(this.components);
            this.GameMap = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameMap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(27, 407);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(55, 23);
            this.AboutButton.TabIndex = 2;
            this.AboutButton.Text = "О игре";
            this.AboutButton.UseVisualStyleBackColor = true;
            // 
            // escapeButton
            // 
            this.escapeButton.Location = new System.Drawing.Point(112, 407);
            this.escapeButton.Name = "escapeButton";
            this.escapeButton.Size = new System.Drawing.Size(55, 23);
            this.escapeButton.TabIndex = 3;
            this.escapeButton.Text = "Назад";
            this.escapeButton.UseVisualStyleBackColor = true;
            this.escapeButton.Click += new System.EventHandler(this.escapeButton_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.groupBox1);
            this.ControlPanel.Controls.Add(this.SavePoint);
            this.ControlPanel.Controls.Add(this.pictureBox2);
            this.ControlPanel.Controls.Add(this.pause_resume_button);
            this.ControlPanel.Controls.Add(this.label1);
            this.ControlPanel.Controls.Add(this.trackBar1);
            this.ControlPanel.Controls.Add(this.escapeButton);
            this.ControlPanel.Controls.Add(this.AboutButton);
            this.ControlPanel.Location = new System.Drawing.Point(639, 12);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(186, 426);
            this.ControlPanel.TabIndex = 4;
            this.ControlPanel.TabStop = false;
            // 
            // SavePoint
            // 
            this.SavePoint.Location = new System.Drawing.Point(7, 145);
            this.SavePoint.Name = "SavePoint";
            this.SavePoint.Size = new System.Drawing.Size(75, 40);
            this.SavePoint.TabIndex = 9;
            this.SavePoint.Text = "Сохранить состояние";
            this.SavePoint.UseVisualStyleBackColor = true;
            this.SavePoint.Click += new System.EventHandler(this.SavePoint_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(27, 201);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 200);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pause_resume_button
            // 
            this.pause_resume_button.Location = new System.Drawing.Point(88, 145);
            this.pause_resume_button.Name = "pause_resume_button";
            this.pause_resume_button.Size = new System.Drawing.Size(93, 40);
            this.pause_resume_button.TabIndex = 6;
            this.pause_resume_button.Text = "Возобновить";
            this.pause_resume_button.UseVisualStyleBackColor = true;
            this.pause_resume_button.Click += new System.EventHandler(this.pause_resume_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Скорость игры:";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(7, 37);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(175, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // GameUpdate
            // 
            this.GameUpdate.Tick += new System.EventHandler(this.GameUpdate_Tick);
            // 
            // GameMap
            // 
            this.GameMap.Location = new System.Drawing.Point(13, 12);
            this.GameMap.Name = "GameMap";
            this.GameMap.Size = new System.Drawing.Size(146, 139);
            this.GameMap.TabIndex = 5;
            this.GameMap.TabStop = false;
            this.GameMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameMap_MouseDown);
            this.GameMap.MouseLeave += new System.EventHandler(this.GameMap_MouseLeave);
            this.GameMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameMap_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(0, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 66);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим ручки / ластика";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 31);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ручка";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseDown);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(69, 31);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(63, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Ластик";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radioButton2_MouseDown);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 450);
            this.Controls.Add(this.GameMap);
            this.Controls.Add(this.ControlPanel);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameMap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox1;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button escapeButton;
        private System.Windows.Forms.GroupBox ControlPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button pause_resume_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button SavePoint;
        private System.Windows.Forms.Timer GameUpdate;
        private System.Windows.Forms.PictureBox GameMap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}