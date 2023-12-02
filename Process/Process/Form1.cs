using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Process
{
    public partial class Form1 : Form
    {
        int durataOrizzontale = 5000; //in milliseconds
        int spostamentoOrizz = 490; //in pixel
        int spostamentoVert = 415;
        int delta;
        int initOrizz= 85;
        int xpos = 0;
        int ypos = 0;
        int deltaCable = 40; //in pixel

        public Form1()
        {
            InitializeComponent();
        }

        private void STARTButton_Click(object sender, EventArgs e)
        {
            STARTText.Text = "True";
            MasterTimer.Enabled = true;
            STARTTimer.Enabled = true;
        }

        private void RESETButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Hai cliccato RESET");
        }

        private void MasterTimer_Tick(object sender, EventArgs e)
        {
            delta = MasterTimer.Interval;

            //Movimento orizzontale del carroponte
            if (DXText.Text.Equals("True"))
            {
                xpos = xpos + (int)(spostamentoOrizz * delta) / durataOrizzontale;
            }
            if (SXText.Text.Equals("True"))
            {
                xpos = xpos - (int)(spostamentoOrizz * delta) / durataOrizzontale;
            }
            if (xpos >= spostamentoOrizz)
            {
                xpos = spostamentoOrizz;
                FCDPicture.BackColor = Color.Green;
                FCDText.Text = "True";
            }
            else
            {
                FCDPicture.BackColor = Color.Red;
                FCDText.Text = "False";
            }
            if (xpos <= 0)
            {
                xpos = 0;
                FCSPicture.BackColor = Color.Green;
                FCSText.Text = "True";
            }
            else
            {
                FCSPicture.BackColor = Color.Red;
                FCSText.Text = "False";
            }

            CranePicture.Left = initOrizz + xpos;
            CablePicture.Left = initOrizz + xpos + deltaCable;

            //Movimento Verticale
            if (GIUText.Text.Equals("True"))
            {
                ypos = ypos + (int)(spostamentoVert * delta) / durataOrizzontale;
            }
            if (SUText.Text.Equals("True"))
            {
                ypos = ypos - (int)(spostamentoVert * delta) / durataOrizzontale;
            }
            if(ypos >= spostamentoVert)
            {
                ypos = spostamentoVert;
                FCBPicture.BackColor = Color.Green;
                FCBText.Text = "True";
            }
            else
            {
                FCBPicture.BackColor = Color.Red;
                FCBText.Text = "False";
            }
            if (ypos <= 0)
            {
                ypos = 0;
                FCAPicture.BackColor = Color.Green;
                FCAText.Text = "True";
            }
            else
            {
                FCBPicture.BackColor = Color.Red;
                FCBText.Text = "False";
            }
            
            CablePicture.Height = ypos + 10;

            //allarme
            if (ALLARMEText.Text.Equals("True"))
            {
                ALLARMEPanel.Visible = true;
            }
            else
            {
                ALLARMEPanel.Visible = false;
            }

        }

        private void STARTTimer_Tick(object sender, EventArgs e)
        {
            STARTText.Text  =  "False";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
