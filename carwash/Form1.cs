using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Questo progetto simula il funzionamento di un auto-lavaggio, dove inizialmente si potrà decidere cosa lavare(un'auto o una moto).
 * Affinchè tutto avvenga nel giusto modo bisognerà pagare 10 euro per la macchina e 5 euro per la moto.
 * Finiti i processi i veicoli verranno disposti negli appositi parcheggi dove il cliente potrà ritirare il proprio mezzo*/

namespace carwash
{
    public partial class Form1 : Form
    {                           
        int xMotoPos = 0;
        int yMotoPos = 0;
        int xAutoPos = 0;
        int yAutoPos = 0;
        int passoVerticale = 21;
        int passoOrizzontale = 60;
        int spostamentoOrizzontale = 406;
        int spostamentoVerticale = 146;
        int spostamentoMotoVerticaleMax = 146;
        int spostamentoAutoVerticaleMax = 146;
        int ascissaInizialeAutoEMoto = 117;
        int ordinataInizialeAutoEMoto = 3;
        int posizioneFinaleAuto = 921;

        public Form1()
        {
            InitializeComponent();
        }

        /*START*/
        private void startButton_Click(object sender, EventArgs e)
        {
            DialogResult startMessage = MessageBox.Show("Hai cliccato START");
            DialogResult dialogResult = MessageBox.Show("Seleziona il veicolo!!!...al resto ci penseremo noi");
            startText.Text = "True";
            resetText.Text = "False";
            pauseText.Text = "False";
            masterTimer.Enabled = true;
            startTimer.Enabled = true;
            fineProcessiText.Text = "False";
            preLavaggioText.Text = "False";
            lavaggioInternoText.Text = "False";
            saponeText.Text = "False";
            risciacquoText.Text = "False";
            posPreparazioneText.Text = "False";
            saponeText.Text = "False";
            fineProcessiText.Text = "False";
            allarmeText.Text = "False";
            dxText.Text = "False";
            sxText.Text = "False";
            giuText.Text = "False";
            postoAutoText.Text = "False";
            postoMotoText.Text = "False";
            motoText.Text = "False";
            autoText.Text = "False";
            costoMotoText.Text = "0";
            costoAutoText.Text = "0";
            poliziaText.Text = "False";
        }
        private void startTimer_Tick(object sender, EventArgs e)
        {
            startText.Text = "False";
        }

        /*RESET*/
        private void resetButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hai cliccato RESET");
            MessageBox.Show("Forse hai cambiato idea sul veicolo da lavare...Riseleziona il veicolo!!!...al resto ci penseremo noi");
            resetText.Text = "True";
            startText.Text = "False";
            pauseText.Text = "False";
            fineProcessiText.Text = "False";
            preLavaggioText.Text = "False";
            lavaggioInternoText.Text = "False";
            saponeText.Text = "False";
            risciacquoText.Text = "False";
            posPreparazioneText.Text = "False";
            startText.Text = "False";
            fineProcessiText.Text = "False";
            allarmeText.Text = "False";
            dxText.Text = "False";
            sxText.Text = "False";
            giuText.Text = "False";
            postoAutoText.Text = "False";
            postoMotoText.Text = "False";
            motoText.Text = "False";
            autoText.Text = "False";
            costoAutoText.Text = "0";
            costoMotoText.Text = "0";
            poliziaText.Text = "False";
            posPreparazionePicture.BackColor = Color.Black;
            preLavaggioPicture.BackColor = Color.Black;
            lavaggioInternoPicture.BackColor = Color.Black;
            saponePicture.BackColor = Color.Black;
            risciacquoPicture.BackColor = Color.Black;
            postoMotoPicture.BackColor = Color.Black;
            postoAutoPicture.BackColor = Color.Black;
            lavaggioPicture.Visible = false;
            lavaggioInternoPictureBox.Visible = false;
            insaponamentoPicture.Visible = false;
            risciacquoPictureBox.Visible = false;
            watchdogPictureBox.Visible = false;
            allarmePictureBox.Visible = false;
            motoPicture.Hide();
            autoPicture.Visible = false;
            motoPicture.Location = new Point(ascissaInizialeAutoEMoto,ordinataInizialeAutoEMoto);
            autoPicture.Location = new Point(ascissaInizialeAutoEMoto, ordinataInizialeAutoEMoto);
            xMotoPos = 0;
            yMotoPos = 0;
            xAutoPos = 0;
            yAutoPos = 0;
            passoVerticale = 21;
            passoOrizzontale = 60;
            spostamentoOrizzontale = 406;
            spostamentoVerticale = 146;
            spostamentoMotoVerticaleMax = 146;
            spostamentoAutoVerticaleMax = 146;
            ascissaInizialeAutoEMoto = 117;
            ordinataInizialeAutoEMoto = 3;
            posizioneFinaleAuto = 921;
        }

        /*PAUSE*/
        private void pauseButton_Click(object sender, EventArgs e)
        {
            pauseText.Text = "True";
            masterTimer.Enabled = false;
            startTimer.Enabled = false;
        }


        /*FUNZIONE PRINCIPALE*/
        private void masterTimer_Tick(object sender, EventArgs e)
        {

            /*MOTO*/
            if (motoText.Text.Equals("True"))
            {
                autoText.Text = "False";
                motoPicture.Show();

                /*POSIZIONAMENTO PREPARAZIONE LAVAGGIO*/
                if (dxText.Text.Equals("True") && posPreparazioneText.Text.Equals("False") && preLavaggioText.Text.Equals("False")
                   && lavaggioInternoText.Text.Equals("False") && saponeText.Text.Equals("False")
                    && risciacquoText.Text.Equals("False") && fineProcessiText.Text.Equals("False"))
                {
                    xMotoPos = xMotoPos + passoOrizzontale;
                    if (xMotoPos >= spostamentoOrizzontale)
                    {
                        xMotoPos = spostamentoOrizzontale;
                        posPreparazionePicture.BackColor = Color.Green;
                        posPreparazioneText.Text = "True";
                    }
                    else
                    {
                        posPreparazionePicture.BackColor = Color.Red;
                        posPreparazioneText.Text = "False";
                    }
                    motoPicture.Left = ascissaInizialeAutoEMoto + xMotoPos;
                }
      

                
                /*PRELAVAGGIO*/
                if (giuText.Text.Equals("True") && dxText.Text.Equals("True") && posPreparazioneText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale; //(int)(spostamentoVerticale * deltaMasterTimer) / durataVerticale;

                    if (yMotoPos >= spostamentoMotoVerticaleMax) 
                    {
                        posPreparazionePicture.BackColor = Color.Red;
                        posPreparazioneText.Text = "False";
                        yMotoPos = spostamentoVerticale;
                        dxText.Text = "False";
                        giuText.Text = "False";
                        preLavaggioPicture.BackColor = Color.Green;
                        preLavaggioText.Text = "True";
                        lavaggioPicture.Visible = true;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                    }
                    else
                    {
                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                    }
                    motoPicture.Top =  yMotoPos;
                }
              

                /*LAVAGGIO INTERNO*/
                if (giuText.Text.Equals("True") && preLavaggioText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale;

                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    { 
                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        giuText.Text = "False";
                        lavaggioInternoPicture.BackColor = Color.Green;
                        lavaggioInternoText.Text = "True";
                        lavaggioPicture.Hide();
                        lavaggioInternoPictureBox.Visible = true;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                    }
                    else
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";

                    }
                    motoPicture.Top = yMotoPos;
                }
                
                
                /*INSAPONAMENTO*/
                if (giuText.Text.Equals("True") && lavaggioInternoText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale;

                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        giuText.Text = "False";
                        saponePicture.BackColor = Color.Green;
                        saponeText.Text = "True";
                        insaponamentoPicture.Visible = true;
                        lavaggioInternoPictureBox.Visible = false;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                    }
                    else
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";

                    }
                    motoPicture.Top = yMotoPos;
                }

                /*RISCIACQUO*/
                if ((giuText.Text.Equals("True") && saponeText.Text.Equals("True")))
                {
                    yMotoPos = yMotoPos + passoVerticale;
                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";
                        giuText.Text = "False";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        risciacquoPicture.BackColor = Color.Green;
                        risciacquoText.Text = "True";
                        risciacquoPictureBox.Visible = true;
                        insaponamentoPicture.Visible = false;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                    }
                    else
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                    }
                    motoPicture.Top = yMotoPos;   
                }

                /*FINE PROCESSI*/
                if (giuText.Text.Equals("True") && risciacquoText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale;
                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                        giuText.Text = "False";
                        fineProcessiText.Text = "True";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        risciacquoPictureBox.Visible = false;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                    }
                    motoPicture.Top = yMotoPos;
                }

                /*PARCHEGGIO MOTO*/
                if (sxText.Text.Equals("True") && fineProcessiText.Text.Equals("True")&& giuText.Text.Equals("False")&& costoMotoText.Text.Equals("5"))
                {
                    xMotoPos = xMotoPos - passoOrizzontale;
                    if (xMotoPos <= ascissaInizialeAutoEMoto)
                    {
                        xMotoPos = ascissaInizialeAutoEMoto;
                        postoMotoPicture.BackColor = Color.Green;
                        postoMotoText.Text = "True";
                        sxText.Text = "False";
                        motoText.Text = "False";
                        fineProcessiText.Text = "False";
                    }
                    else
                    {
                        postoMotoPicture.BackColor = Color.Red;
                        postoMotoText.Text = "False";
                    }
                    motoPicture.Left = xMotoPos;
                 
                }

                /*PAGAMENTO LAVAGGIO MOTO*/
                if (!costoMotoText.Text.Equals("5") && fineProcessiText.Text.Equals("True"))
                {
                    watchdogPictureBox.Visible = true;
                    poliziaText.Text = "113";
                  
                }
                else
                {
                    watchdogPictureBox.Visible = false;
                }
                
            }

            /*AUTO*/
            if (autoText.Text.Equals("True"))
            {
                autoPicture.Visible = true;
                motoText.Text = "False";

                /*POSIZIONAMENTO PREPARAZIONE LAVAGGIO*/
                if (dxText.Text.Equals("True") && fineProcessiText.Text.Equals("False") && posPreparazioneText.Text.Equals("False") &&
                    preLavaggioText.Text.Equals("False") && lavaggioInternoText.Text.Equals("False") && saponeText.Text.Equals("False")
                    && risciacquoText.Text.Equals("False"))
                {
                    xAutoPos = xAutoPos + passoOrizzontale;
                    if (xAutoPos >= spostamentoOrizzontale)
                    {
                        xAutoPos = spostamentoOrizzontale;
                        posPreparazionePicture.BackColor = Color.Green;
                        posPreparazioneText.Text = "True";
                    }
                    else
                    {
                        posPreparazionePicture.BackColor = Color.Red;
                        posPreparazioneText.Text = "False";
                    }
                    autoPicture.Left = ascissaInizialeAutoEMoto + xAutoPos;
                    xAutoPos = ascissaInizialeAutoEMoto + xAutoPos;
                }

                /*PRELAVAGGIO*/
                if (giuText.Text.Equals("True") && dxText.Text.Equals("True") && posPreparazioneText.Text.Equals("True"))
                {
                    yAutoPos = yAutoPos + passoVerticale; //(int)(spostamentoVerticale * deltaMasterTimer) / durataVerticale;

                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        posPreparazionePicture.BackColor = Color.Red;
                        posPreparazioneText.Text = "False";
                        yAutoPos = spostamentoVerticale;
                        dxText.Text = "False";
                        giuText.Text = "False";
                        preLavaggioPicture.BackColor = Color.Green;
                        preLavaggioText.Text = "True";
                        lavaggioPicture.Visible = true;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;

                    }
                    else
                    {
                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                    }
                    autoPicture.Top = yAutoPos;
                }

                /*LAVAGGIO INTERNO*/
                if (giuText.Text.Equals("True") && preLavaggioText.Text.Equals("True"))
                {
                    yAutoPos = yAutoPos + passoVerticale;
                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {

                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        giuText.Text = "False";
                        lavaggioInternoPicture.BackColor = Color.Green;
                        lavaggioInternoText.Text = "True";
                        lavaggioPicture.Visible = false;
                        lavaggioInternoPictureBox.Visible = true;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                    }
                    else
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";
                    }
                    autoPicture.Top = yAutoPos;
                }
                
                /*INSAPONAMENTO*/
                if (giuText.Text.Equals("True") && lavaggioInternoText.Text.Equals("True"))
                {

                    yAutoPos = yAutoPos + passoVerticale;

                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        giuText.Text = "False";
                        saponePicture.BackColor = Color.Green;
                        saponeText.Text = "True";
                        insaponamentoPicture.Visible = true;
                        lavaggioInternoPictureBox.Visible = false;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                    }
                    else
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";

                    }
                    autoPicture.Top = yAutoPos;
                }

                /*RISCIACQUO*/
                if ((giuText.Text.Equals("True") && saponeText.Text.Equals("True")))
                {
                    yAutoPos = yAutoPos + passoVerticale;
                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";
                        giuText.Text = "False";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        risciacquoPicture.BackColor = Color.Green;
                        risciacquoText.Text = "True";
                        risciacquoPictureBox.Visible = true;
                        insaponamentoPicture.Visible = false;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                    }
                    else
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                    }
                    autoPicture.Top = yAutoPos;
                }

                /*FINE PROCESSI*/
                if (giuText.Text.Equals("True") && risciacquoText.Text.Equals("True"))
                {
                    yAutoPos = yAutoPos + passoVerticale;

                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                        giuText.Text = "False";
                        fineProcessiText.Text = "True";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        risciacquoPictureBox.Visible = false;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;

                    }
                    autoPicture.Top = yAutoPos;

                }
                /*PARCHEGGIO AUTO*/
                if (dxText.Text.Equals("True") && fineProcessiText.Text.Equals("True") && giuText.Text.Equals("False")&& autoText.Text.Equals("10"))
                {
                    xAutoPos = xAutoPos + passoOrizzontale;

                    if (xAutoPos >= posizioneFinaleAuto)
                    {
                        xAutoPos =posizioneFinaleAuto;
                        postoAutoPicture.BackColor = Color.Green;
                        postoAutoText.Text = "True";
                        dxText.Text = "False";
                        autoText.Text = "False";
                        fineProcessiText.Text = "False";
                    }
                    else
                    {

                        postoAutoPicture.BackColor = Color.Red;
                        postoAutoText.Text = "False";
                    }
                    autoPicture.Left =  xAutoPos;
                    fineProcessiText.Text = "True";
                }
                /*PAGAMENTO LAVAGGIO AUTO*/
                if (!costoAutoText.Text.Equals("10") && fineProcessiText.Text.Equals("True"))
                {
                    watchdogPictureBox.Visible = true;
                    poliziaText.Text = "113";
                }
                else
                {
                    watchdogPictureBox.Visible = false;
                }
            }

            /*ALLARME FINE LAVAGGIO*/
            if (allarmeText.Text.Equals("True"))
            {
                allarmePictureBox.Visible = true;
                
            }
            else
            {
                allarmePictureBox.Visible = false;
            }   
        }

    }
}