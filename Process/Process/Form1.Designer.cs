
namespace Process
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FCSLabel = new System.Windows.Forms.Label();
            this.FCSText = new System.Windows.Forms.TextBox();
            this.FCDText = new System.Windows.Forms.TextBox();
            this.FCDLabel = new System.Windows.Forms.Label();
            this.SensoriBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RESETLabel = new System.Windows.Forms.Label();
            this.RESEText = new System.Windows.Forms.TextBox();
            this.STARTLabel = new System.Windows.Forms.Label();
            this.STARTText = new System.Windows.Forms.TextBox();
            this.FCBLabel = new System.Windows.Forms.Label();
            this.FCBText = new System.Windows.Forms.TextBox();
            this.FCALabel = new System.Windows.Forms.Label();
            this.FCAText = new System.Windows.Forms.TextBox();
            this.AttuatoriBox = new System.Windows.Forms.GroupBox();
            this.ALLARMELabel = new System.Windows.Forms.Label();
            this.ALLARMEText = new System.Windows.Forms.TextBox();
            this.GIULabel = new System.Windows.Forms.Label();
            this.GIUText = new System.Windows.Forms.TextBox();
            this.SULabel = new System.Windows.Forms.Label();
            this.SUText = new System.Windows.Forms.TextBox();
            this.SXLabel = new System.Windows.Forms.Label();
            this.SXText = new System.Windows.Forms.TextBox();
            this.DXText = new System.Windows.Forms.TextBox();
            this.DXLabel = new System.Windows.Forms.Label();
            this.BottoniPanel = new System.Windows.Forms.Panel();
            this.RESETButton = new System.Windows.Forms.Button();
            this.STARTButton = new System.Windows.Forms.Button();
            this.MasterTimer = new System.Windows.Forms.Timer(this.components);
            this.STARTTimer = new System.Windows.Forms.Timer(this.components);
            this.AnimazionePanel = new System.Windows.Forms.Panel();
            this.FCSPicture = new System.Windows.Forms.PictureBox();
            this.FCDPicture = new System.Windows.Forms.PictureBox();
            this.FCBPicture = new System.Windows.Forms.PictureBox();
            this.FCAPicture = new System.Windows.Forms.PictureBox();
            this.CablePicture = new System.Windows.Forms.PictureBox();
            this.CranePicture = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ALLARMEPanel = new System.Windows.Forms.Panel();
            this.SensoriBox.SuspendLayout();
            this.AttuatoriBox.SuspendLayout();
            this.BottoniPanel.SuspendLayout();
            this.AnimazionePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FCSPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCDPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCBPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCAPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CablePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CranePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FCSLabel
            // 
            this.FCSLabel.AutoSize = true;
            this.FCSLabel.Location = new System.Drawing.Point(28, 42);
            this.FCSLabel.Name = "FCSLabel";
            this.FCSLabel.Size = new System.Drawing.Size(38, 18);
            this.FCSLabel.TabIndex = 0;
            this.FCSLabel.Text = "FCS";
            // 
            // FCSText
            // 
            this.FCSText.Location = new System.Drawing.Point(141, 36);
            this.FCSText.Name = "FCSText";
            this.FCSText.Size = new System.Drawing.Size(100, 24);
            this.FCSText.TabIndex = 1;
            // 
            // FCDText
            // 
            this.FCDText.Location = new System.Drawing.Point(141, 66);
            this.FCDText.Name = "FCDText";
            this.FCDText.Size = new System.Drawing.Size(100, 24);
            this.FCDText.TabIndex = 2;
            // 
            // FCDLabel
            // 
            this.FCDLabel.AutoSize = true;
            this.FCDLabel.Location = new System.Drawing.Point(28, 72);
            this.FCDLabel.Name = "FCDLabel";
            this.FCDLabel.Size = new System.Drawing.Size(39, 18);
            this.FCDLabel.TabIndex = 3;
            this.FCDLabel.Text = "FCD";
            // 
            // SensoriBox
            // 
            this.SensoriBox.Controls.Add(this.panel1);
            this.SensoriBox.Controls.Add(this.RESETLabel);
            this.SensoriBox.Controls.Add(this.RESEText);
            this.SensoriBox.Controls.Add(this.STARTLabel);
            this.SensoriBox.Controls.Add(this.STARTText);
            this.SensoriBox.Controls.Add(this.FCBLabel);
            this.SensoriBox.Controls.Add(this.FCBText);
            this.SensoriBox.Controls.Add(this.FCALabel);
            this.SensoriBox.Controls.Add(this.FCAText);
            this.SensoriBox.Controls.Add(this.FCDLabel);
            this.SensoriBox.Controls.Add(this.FCDText);
            this.SensoriBox.Controls.Add(this.FCSText);
            this.SensoriBox.Controls.Add(this.FCSLabel);
            this.SensoriBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SensoriBox.Location = new System.Drawing.Point(12, 153);
            this.SensoriBox.Name = "SensoriBox";
            this.SensoriBox.Size = new System.Drawing.Size(303, 235);
            this.SensoriBox.TabIndex = 0;
            this.SensoriBox.TabStop = false;
            this.SensoriBox.Text = "Sensori";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(354, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 417);
            this.panel1.TabIndex = 11;
            // 
            // RESETLabel
            // 
            this.RESETLabel.AutoSize = true;
            this.RESETLabel.Location = new System.Drawing.Point(28, 195);
            this.RESETLabel.Name = "RESETLabel";
            this.RESETLabel.Size = new System.Drawing.Size(58, 18);
            this.RESETLabel.TabIndex = 11;
            this.RESETLabel.Text = "RESET";
            // 
            // RESEText
            // 
            this.RESEText.Location = new System.Drawing.Point(141, 189);
            this.RESEText.Name = "RESEText";
            this.RESEText.Size = new System.Drawing.Size(100, 24);
            this.RESEText.TabIndex = 10;
            // 
            // STARTLabel
            // 
            this.STARTLabel.AutoSize = true;
            this.STARTLabel.Location = new System.Drawing.Point(28, 162);
            this.STARTLabel.Name = "STARTLabel";
            this.STARTLabel.Size = new System.Drawing.Size(56, 18);
            this.STARTLabel.TabIndex = 9;
            this.STARTLabel.Text = "START";
            // 
            // STARTText
            // 
            this.STARTText.Location = new System.Drawing.Point(141, 156);
            this.STARTText.Name = "STARTText";
            this.STARTText.Size = new System.Drawing.Size(100, 24);
            this.STARTText.TabIndex = 8;
            // 
            // FCBLabel
            // 
            this.FCBLabel.AutoSize = true;
            this.FCBLabel.Location = new System.Drawing.Point(28, 132);
            this.FCBLabel.Name = "FCBLabel";
            this.FCBLabel.Size = new System.Drawing.Size(38, 18);
            this.FCBLabel.TabIndex = 7;
            this.FCBLabel.Text = "FCB";
            // 
            // FCBText
            // 
            this.FCBText.Location = new System.Drawing.Point(141, 126);
            this.FCBText.Name = "FCBText";
            this.FCBText.Size = new System.Drawing.Size(100, 24);
            this.FCBText.TabIndex = 6;
            // 
            // FCALabel
            // 
            this.FCALabel.AutoSize = true;
            this.FCALabel.Location = new System.Drawing.Point(28, 102);
            this.FCALabel.Name = "FCALabel";
            this.FCALabel.Size = new System.Drawing.Size(37, 18);
            this.FCALabel.TabIndex = 5;
            this.FCALabel.Text = "FCA";
            // 
            // FCAText
            // 
            this.FCAText.Location = new System.Drawing.Point(141, 96);
            this.FCAText.Name = "FCAText";
            this.FCAText.Size = new System.Drawing.Size(100, 24);
            this.FCAText.TabIndex = 4;
            // 
            // AttuatoriBox
            // 
            this.AttuatoriBox.Controls.Add(this.ALLARMELabel);
            this.AttuatoriBox.Controls.Add(this.ALLARMEText);
            this.AttuatoriBox.Controls.Add(this.GIULabel);
            this.AttuatoriBox.Controls.Add(this.GIUText);
            this.AttuatoriBox.Controls.Add(this.SULabel);
            this.AttuatoriBox.Controls.Add(this.SUText);
            this.AttuatoriBox.Controls.Add(this.SXLabel);
            this.AttuatoriBox.Controls.Add(this.SXText);
            this.AttuatoriBox.Controls.Add(this.DXText);
            this.AttuatoriBox.Controls.Add(this.DXLabel);
            this.AttuatoriBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttuatoriBox.Location = new System.Drawing.Point(12, 409);
            this.AttuatoriBox.Name = "AttuatoriBox";
            this.AttuatoriBox.Size = new System.Drawing.Size(303, 235);
            this.AttuatoriBox.TabIndex = 1;
            this.AttuatoriBox.TabStop = false;
            this.AttuatoriBox.Text = "Attuatori";
            // 
            // ALLARMELabel
            // 
            this.ALLARMELabel.AutoSize = true;
            this.ALLARMELabel.Location = new System.Drawing.Point(28, 162);
            this.ALLARMELabel.Name = "ALLARMELabel";
            this.ALLARMELabel.Size = new System.Drawing.Size(76, 18);
            this.ALLARMELabel.TabIndex = 9;
            this.ALLARMELabel.Text = "ALLARME";
            // 
            // ALLARMEText
            // 
            this.ALLARMEText.Location = new System.Drawing.Point(141, 156);
            this.ALLARMEText.Name = "ALLARMEText";
            this.ALLARMEText.Size = new System.Drawing.Size(100, 24);
            this.ALLARMEText.TabIndex = 8;
            // 
            // GIULabel
            // 
            this.GIULabel.AutoSize = true;
            this.GIULabel.Location = new System.Drawing.Point(28, 132);
            this.GIULabel.Name = "GIULabel";
            this.GIULabel.Size = new System.Drawing.Size(34, 18);
            this.GIULabel.TabIndex = 7;
            this.GIULabel.Text = "GIU";
            // 
            // GIUText
            // 
            this.GIUText.Location = new System.Drawing.Point(141, 126);
            this.GIUText.Name = "GIUText";
            this.GIUText.Size = new System.Drawing.Size(100, 24);
            this.GIUText.TabIndex = 6;
            // 
            // SULabel
            // 
            this.SULabel.AutoSize = true;
            this.SULabel.Location = new System.Drawing.Point(28, 102);
            this.SULabel.Name = "SULabel";
            this.SULabel.Size = new System.Drawing.Size(29, 18);
            this.SULabel.TabIndex = 5;
            this.SULabel.Text = "SU";
            // 
            // SUText
            // 
            this.SUText.Location = new System.Drawing.Point(141, 96);
            this.SUText.Name = "SUText";
            this.SUText.Size = new System.Drawing.Size(100, 24);
            this.SUText.TabIndex = 4;
            // 
            // SXLabel
            // 
            this.SXLabel.AutoSize = true;
            this.SXLabel.Location = new System.Drawing.Point(28, 72);
            this.SXLabel.Name = "SXLabel";
            this.SXLabel.Size = new System.Drawing.Size(28, 18);
            this.SXLabel.TabIndex = 3;
            this.SXLabel.Text = "SX";
            // 
            // SXText
            // 
            this.SXText.Location = new System.Drawing.Point(141, 66);
            this.SXText.Name = "SXText";
            this.SXText.Size = new System.Drawing.Size(100, 24);
            this.SXText.TabIndex = 2;
            // 
            // DXText
            // 
            this.DXText.Location = new System.Drawing.Point(141, 36);
            this.DXText.Name = "DXText";
            this.DXText.Size = new System.Drawing.Size(100, 24);
            this.DXText.TabIndex = 1;
            // 
            // DXLabel
            // 
            this.DXLabel.AutoSize = true;
            this.DXLabel.Location = new System.Drawing.Point(28, 42);
            this.DXLabel.Name = "DXLabel";
            this.DXLabel.Size = new System.Drawing.Size(29, 18);
            this.DXLabel.TabIndex = 0;
            this.DXLabel.Text = "DX";
            // 
            // BottoniPanel
            // 
            this.BottoniPanel.Controls.Add(this.RESETButton);
            this.BottoniPanel.Controls.Add(this.STARTButton);
            this.BottoniPanel.Location = new System.Drawing.Point(0, 53);
            this.BottoniPanel.Name = "BottoniPanel";
            this.BottoniPanel.Size = new System.Drawing.Size(435, 97);
            this.BottoniPanel.TabIndex = 10;
            // 
            // RESETButton
            // 
            this.RESETButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RESETButton.Location = new System.Drawing.Point(239, 9);
            this.RESETButton.Name = "RESETButton";
            this.RESETButton.Size = new System.Drawing.Size(192, 85);
            this.RESETButton.TabIndex = 1;
            this.RESETButton.Text = "RESET";
            this.RESETButton.UseVisualStyleBackColor = true;
            this.RESETButton.Click += new System.EventHandler(this.RESETButton_Click);
            // 
            // STARTButton
            // 
            this.STARTButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STARTButton.Location = new System.Drawing.Point(3, 9);
            this.STARTButton.Name = "STARTButton";
            this.STARTButton.Size = new System.Drawing.Size(195, 85);
            this.STARTButton.TabIndex = 0;
            this.STARTButton.Text = "START";
            this.STARTButton.UseVisualStyleBackColor = true;
            this.STARTButton.Click += new System.EventHandler(this.STARTButton_Click);
            // 
            // MasterTimer
            // 
            this.MasterTimer.Tick += new System.EventHandler(this.MasterTimer_Tick);
            // 
            // STARTTimer
            // 
            this.STARTTimer.Interval = 500;
            this.STARTTimer.Tick += new System.EventHandler(this.STARTTimer_Tick);
            // 
            // AnimazionePanel
            // 
            this.AnimazionePanel.Controls.Add(this.ALLARMEPanel);
            this.AnimazionePanel.Controls.Add(this.FCSPicture);
            this.AnimazionePanel.Controls.Add(this.FCDPicture);
            this.AnimazionePanel.Controls.Add(this.FCBPicture);
            this.AnimazionePanel.Controls.Add(this.FCAPicture);
            this.AnimazionePanel.Controls.Add(this.CablePicture);
            this.AnimazionePanel.Controls.Add(this.CranePicture);
            this.AnimazionePanel.Controls.Add(this.pictureBox3);
            this.AnimazionePanel.Controls.Add(this.pictureBox2);
            this.AnimazionePanel.Controls.Add(this.pictureBox1);
            this.AnimazionePanel.Location = new System.Drawing.Point(640, 28);
            this.AnimazionePanel.Name = "AnimazionePanel";
            this.AnimazionePanel.Size = new System.Drawing.Size(757, 591);
            this.AnimazionePanel.TabIndex = 11;
            // 
            // FCSPicture
            // 
            this.FCSPicture.BackColor = System.Drawing.Color.Black;
            this.FCSPicture.Location = new System.Drawing.Point(85, 537);
            this.FCSPicture.Name = "FCSPicture";
            this.FCSPicture.Size = new System.Drawing.Size(32, 32);
            this.FCSPicture.TabIndex = 8;
            this.FCSPicture.TabStop = false;
            // 
            // FCDPicture
            // 
            this.FCDPicture.BackColor = System.Drawing.Color.Black;
            this.FCDPicture.Location = new System.Drawing.Point(643, 537);
            this.FCDPicture.Name = "FCDPicture";
            this.FCDPicture.Size = new System.Drawing.Size(32, 32);
            this.FCDPicture.TabIndex = 7;
            this.FCDPicture.TabStop = false;
            // 
            // FCBPicture
            // 
            this.FCBPicture.BackColor = System.Drawing.Color.Black;
            this.FCBPicture.Location = new System.Drawing.Point(13, 499);
            this.FCBPicture.Name = "FCBPicture";
            this.FCBPicture.Size = new System.Drawing.Size(32, 32);
            this.FCBPicture.TabIndex = 6;
            this.FCBPicture.TabStop = false;
            // 
            // FCAPicture
            // 
            this.FCAPicture.BackColor = System.Drawing.Color.Black;
            this.FCAPicture.Location = new System.Drawing.Point(13, 96);
            this.FCAPicture.Name = "FCAPicture";
            this.FCAPicture.Size = new System.Drawing.Size(32, 32);
            this.FCAPicture.TabIndex = 5;
            this.FCAPicture.TabStop = false;
            // 
            // CablePicture
            // 
            this.CablePicture.BackColor = System.Drawing.Color.Black;
            this.CablePicture.Location = new System.Drawing.Point(125, 90);
            this.CablePicture.Name = "CablePicture";
            this.CablePicture.Size = new System.Drawing.Size(24, 26);
            this.CablePicture.TabIndex = 4;
            this.CablePicture.TabStop = false;
            // 
            // CranePicture
            // 
            this.CranePicture.BackColor = System.Drawing.Color.Gold;
            this.CranePicture.Location = new System.Drawing.Point(85, 13);
            this.CranePicture.Name = "CranePicture";
            this.CranePicture.Size = new System.Drawing.Size(100, 50);
            this.CranePicture.TabIndex = 3;
            this.CranePicture.TabStop = false;
            this.CranePicture.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Blue;
            this.pictureBox3.Location = new System.Drawing.Point(23, 64);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(707, 26);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gray;
            this.pictureBox2.Location = new System.Drawing.Point(680, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 495);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(51, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 495);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ALLARMEPanel
            // 
            this.ALLARMEPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ALLARMEPanel.BackgroundImage")));
            this.ALLARMEPanel.Location = new System.Drawing.Point(216, 210);
            this.ALLARMEPanel.Name = "ALLARMEPanel";
            this.ALLARMEPanel.Size = new System.Drawing.Size(277, 220);
            this.ALLARMEPanel.TabIndex = 9;
            this.ALLARMEPanel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 795);
            this.Controls.Add(this.AnimazionePanel);
            this.Controls.Add(this.BottoniPanel);
            this.Controls.Add(this.AttuatoriBox);
            this.Controls.Add(this.SensoriBox);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SensoriBox.ResumeLayout(false);
            this.SensoriBox.PerformLayout();
            this.AttuatoriBox.ResumeLayout(false);
            this.AttuatoriBox.PerformLayout();
            this.BottoniPanel.ResumeLayout(false);
            this.AnimazionePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FCSPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCDPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCBPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FCAPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CablePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CranePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label FCSLabel;
        private System.Windows.Forms.TextBox FCSText;
        private System.Windows.Forms.TextBox FCDText;
        private System.Windows.Forms.Label FCDLabel;
        private System.Windows.Forms.GroupBox SensoriBox;
        private System.Windows.Forms.Label RESETLabel;
        private System.Windows.Forms.TextBox RESEText;
        private System.Windows.Forms.Label STARTLabel;
        private System.Windows.Forms.TextBox STARTText;
        private System.Windows.Forms.Label FCBLabel;
        private System.Windows.Forms.TextBox FCBText;
        private System.Windows.Forms.Label FCALabel;
        private System.Windows.Forms.TextBox FCAText;
        private System.Windows.Forms.GroupBox AttuatoriBox;
        private System.Windows.Forms.Label ALLARMELabel;
        private System.Windows.Forms.TextBox ALLARMEText;
        private System.Windows.Forms.Label GIULabel;
        private System.Windows.Forms.TextBox GIUText;
        private System.Windows.Forms.Label SULabel;
        private System.Windows.Forms.TextBox SUText;
        private System.Windows.Forms.Label SXLabel;
        private System.Windows.Forms.TextBox SXText;
        private System.Windows.Forms.TextBox DXText;
        private System.Windows.Forms.Label DXLabel;
        private System.Windows.Forms.Panel BottoniPanel;
        private System.Windows.Forms.Button STARTButton;
        private System.Windows.Forms.Button RESETButton;
        private System.Windows.Forms.Timer MasterTimer;
        private System.Windows.Forms.Timer STARTTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel AnimazionePanel;
        private System.Windows.Forms.PictureBox CranePicture;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox FCSPicture;
        private System.Windows.Forms.PictureBox FCDPicture;
        private System.Windows.Forms.PictureBox FCBPicture;
        private System.Windows.Forms.PictureBox FCAPicture;
        private System.Windows.Forms.PictureBox CablePicture;
        private System.Windows.Forms.Panel ALLARMEPanel;
    }
}

