using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;

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
        //Initialization of ADS client
        private TcAdsClient tcClient;
        private int[] hConnect;

        private AdsStream dataStream;
        private AdsBinaryReader binRead;

        private int[] hvar_name;

        private string[] dataPLC = {"MAIN.preLavaggio", "MAIN.lavaggioInterno", "MAIN.sapone", "MAIN.risciacquo", "MAIN.posPreparazione",
          "MAIN.polizia", "MAIN.postoAuto","MAIN.postoMoto","MAIN.start","MAIN.reset","MAIN.pause",
        "MAIN.moto","MAIN.auto","MAIN.fineProcessi","MAIN.costoAuto","MAIN.costoMoto","MAIN.numeroStep",
        "MAIN.dx","MAIN.sx","MAIN.giu","MAIN.allarme"};
        private int NUM_ELEM_BOOL = 18;
        private int NUM_ELEM_INT = 3;

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
            numeroStepText.Text = "0";
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
            numeroStepText.Text = "0";
            poliziaText.Text = "False";
            posPreparazionePicture.BackColor = Color.Black;
            preLavaggioPicture.BackColor = Color.Black;
            lavaggioInternoPicture.BackColor = Color.Black;
            saponePicture.BackColor = Color.Black;
            risciacquoPicture.BackColor = Color.Black;
            postoMotoPicture.BackColor = Color.Black;
            postoAutoPicture.BackColor = Color.Black;
            preLavaggioMotoPictureBox.Visible = false;
            lavaggioInternoMotoPictureBox.Visible = false;
            lavaggioInternoAutoPictureBox.Visible = false;
            insaponamentoMotoPictureBox.Visible = false;
            risciacquoAutoPictureBox.Visible = false;
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
                if (dxText.Text.Equals("True") && numeroStepText.Text.Equals("1") && posPreparazioneText.Text.Equals("False") && preLavaggioText.Text.Equals("False")
                   && lavaggioInternoText.Text.Equals("False") && saponeText.Text.Equals("False")
                    && risciacquoText.Text.Equals("False") && fineProcessiText.Text.Equals("False"))
                {
                    xMotoPos = xMotoPos + passoOrizzontale;
                    if (xMotoPos >= spostamentoOrizzontale)
                    {
                        xMotoPos = spostamentoOrizzontale;
                        posPreparazionePicture.BackColor = Color.Green;
                        posPreparazioneText.Text = "True";
                        // dxText.Text = "False";
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        posPreparazionePicture.BackColor = Color.Red;
                        posPreparazioneText.Text = "False";
                    }
                    motoPicture.Left = ascissaInizialeAutoEMoto + xMotoPos;
                   
                }
      

                
                /*PRELAVAGGIO*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("2"))//dxText.Text.Equals("True") && posPreparazioneText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale; 

                    if (yMotoPos >= spostamentoMotoVerticaleMax) 
                    {
                        posPreparazionePicture.BackColor = Color.Red;
                        posPreparazioneText.Text = "False";
                        yMotoPos = spostamentoVerticale;
                        dxText.Text = "False";
                        //giuText.Text = "False";
                        preLavaggioPicture.BackColor = Color.Green;
                        preLavaggioText.Text = "True";
                        preLavaggioMotoPictureBox.Visible = true;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";

                    }
                    else
                    {
                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                    }
                    motoPicture.Top =  yMotoPos;
                 
                }
              

                /*LAVAGGIO INTERNO*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("3")) //preLavaggioText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale;

                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    { 
                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        //giuText.Text = "False";
                        lavaggioInternoPicture.BackColor = Color.Green;
                        lavaggioInternoText.Text = "True";
                        preLavaggioMotoPictureBox.Hide();
                        lavaggioInternoMotoPictureBox.Visible = true;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";

                    }
                    else
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";

                    }
                    motoPicture.Top = yMotoPos;
                  
                }
                
                
                /*INSAPONAMENTO*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("4"))//lavaggioInternoText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale;

                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        //giuText.Text = "False";
                        saponePicture.BackColor = Color.Green;
                        saponeText.Text = "True";
                        insaponamentoMotoPictureBox.Visible = true;
                        lavaggioInternoMotoPictureBox.Visible = false;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";

                    }
                    motoPicture.Top = yMotoPos;
                }

                /*RISCIACQUO*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("5"))//saponeText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale;
                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";
                        //giuText.Text = "False";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        risciacquoPicture.BackColor = Color.Green;
                        risciacquoText.Text = "True";
                        risciacquoMotoPictureBox.Visible = true;
                        insaponamentoMotoPictureBox.Visible = false;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                    }
                    motoPicture.Top = yMotoPos;   
                }

                /*FINE PROCESSI*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("6"))//risciacquoText.Text.Equals("True"))
                {
                    yMotoPos = yMotoPos + passoVerticale;
                    if (yMotoPos >= spostamentoMotoVerticaleMax)
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                        giuText.Text = "False";
                        fineProcessiText.Text = "True";
                        yMotoPos = spostamentoMotoVerticaleMax;
                        risciacquoMotoPictureBox.Visible = false;
                        spostamentoMotoVerticaleMax = spostamentoMotoVerticaleMax + spostamentoVerticale;
                      
                    }
                    motoPicture.Top = yMotoPos;
                }

                /*PARCHEGGIO MOTO*/
                if (sxText.Text.Equals("True") && numeroStepText.Text.Equals("7"))//fineProcessiText.Text.Equals("True")&& giuText.Text.Equals("False")&& costoMotoText.Text.Equals("5"))
                {
                    xMotoPos = xMotoPos - passoOrizzontale;
                    if (xMotoPos <= ascissaInizialeAutoEMoto)
                    {
                        xMotoPos = ascissaInizialeAutoEMoto;
                        postoMotoPicture.BackColor = Color.Green;
                        postoMotoText.Text = "True";
                        //sxText.Text = "False";
                        motoText.Text = "False";
                        fineProcessiText.Text = "False";
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        postoMotoPicture.BackColor = Color.Red;
                        postoMotoText.Text = "False";
                    }
                    motoPicture.Left = xMotoPos;
                 
                }

                /*PAGAMENTO LAVAGGIO MOTO*/
                if (!costoMotoText.Text.Equals("5") && fineProcessiText.Text.Equals("True")&& !numeroStepText.Text.Equals("7"))
                {
                    watchdogPictureBox.Visible = true;
                    poliziaText.Text = "True";
                }
                else
                {
                    watchdogPictureBox.Visible = false;
                    poliziaText.Text = "False";
                }
            }

            /*AUTO*/
            if (autoText.Text.Equals("True"))
            {
                autoPicture.Visible = true;
                motoText.Text = "False";

                /*POSIZIONAMENTO PREPARAZIONE LAVAGGIO*/
                if (dxText.Text.Equals("True") && numeroStepText.Text.Equals("1") && fineProcessiText.Text.Equals("False") && posPreparazioneText.Text.Equals("False") &&
                    preLavaggioText.Text.Equals("False") && lavaggioInternoText.Text.Equals("False") && saponeText.Text.Equals("False")
                    && risciacquoText.Text.Equals("False"))
                {
                    xAutoPos = xAutoPos + passoOrizzontale;
                    if (xAutoPos >= spostamentoOrizzontale)
                    {
                        xAutoPos = spostamentoOrizzontale;
                        posPreparazionePicture.BackColor = Color.Green;
                        posPreparazioneText.Text = "True";
                        numeroStepText.Text = "0";
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
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("2"))// dxText.Text.Equals("True") && posPreparazioneText.Text.Equals("True"))
                {
                    yAutoPos = yAutoPos + passoVerticale; //(int)(spostamentoVerticale * deltaMasterTimer) / durataVerticale;

                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        posPreparazionePicture.BackColor = Color.Red;
                        posPreparazioneText.Text = "False";
                        yAutoPos = spostamentoVerticale;
                        dxText.Text = "False";
                        //giuText.Text = "False";
                        preLavaggioPicture.BackColor = Color.Green;
                        preLavaggioText.Text = "True";
                        preLavaggioAutoPictureBox.Visible = true;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                    }
                    autoPicture.Top = yAutoPos;
                }

                /*LAVAGGIO INTERNO*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("3")) //preLavaggioText.Text.Equals("True"))
                {
                    yAutoPos = yAutoPos + passoVerticale;
                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {

                        preLavaggioPicture.BackColor = Color.Red;
                        preLavaggioText.Text = "False";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        //giuText.Text = "False";
                        lavaggioInternoPicture.BackColor = Color.Green;
                        lavaggioInternoText.Text = "True";
                        preLavaggioAutoPictureBox.Visible = false;
                        lavaggioInternoAutoPictureBox.Visible = true;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";
                    }
                    autoPicture.Top = yAutoPos;
                }
                
                /*INSAPONAMENTO*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("4"))
                {

                    yAutoPos = yAutoPos + passoVerticale;

                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        lavaggioInternoPicture.BackColor = Color.Red;
                        lavaggioInternoText.Text = "False";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        //giuText.Text = "False";
                        saponePicture.BackColor = Color.Green;
                        saponeText.Text = "True";
                        insaponamentoAutoPictureBox.Visible = true;
                        lavaggioInternoAutoPictureBox.Visible = false;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";

                    }
                    autoPicture.Top = yAutoPos;
                }

                /*RISCIACQUO*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("5"))
                {
                    yAutoPos = yAutoPos + passoVerticale;
                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        saponePicture.BackColor = Color.Red;
                        saponeText.Text = "False";
                        //giuText.Text = "False";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        risciacquoPicture.BackColor = Color.Green;
                        risciacquoText.Text = "True";
                        risciacquoAutoPictureBox.Visible = true;
                        insaponamentoAutoPictureBox.Visible = false;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                        numeroStepText.Text = "0";
                    }
                    else
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                    }
                    autoPicture.Top = yAutoPos;
                }

                /*FINE PROCESSI*/
                if (giuText.Text.Equals("True") && numeroStepText.Text.Equals("6"))
                {
                    yAutoPos = yAutoPos + passoVerticale;

                    if (yAutoPos >= spostamentoAutoVerticaleMax)
                    {
                        risciacquoPicture.BackColor = Color.Red;
                        risciacquoText.Text = "False";
                        giuText.Text = "False";
                        fineProcessiText.Text = "True";
                        yAutoPos = spostamentoAutoVerticaleMax;
                        risciacquoAutoPictureBox.Visible = false;
                        spostamentoAutoVerticaleMax = spostamentoAutoVerticaleMax + spostamentoVerticale;
                       

                    }
                    autoPicture.Top = yAutoPos;

                }
                /*PARCHEGGIO AUTO*/
                if (dxText.Text.Equals("True") && numeroStepText.Text.Equals("7"))//fineProcessiText.Text.Equals("True") && giuText.Text.Equals("False")&& costoAutoText.Text.Equals("10"))
                {
                    xAutoPos = xAutoPos + passoOrizzontale;

                    if (xAutoPos >= posizioneFinaleAuto)
                    {
                        xAutoPos =posizioneFinaleAuto;
                        postoAutoPicture.BackColor = Color.Green;
                        postoAutoText.Text = "True";
                        //dxText.Text = "False";
                        autoText.Text = "False";
                        fineProcessiText.Text = "False";
                        numeroStepText.Text = "0";
                    }
                    else
                    {

                        postoAutoPicture.BackColor = Color.Red;
                        postoAutoText.Text = "False";
                    }
                    autoPicture.Left =  xAutoPos;
                 
                }
                /*PAGAMENTO LAVAGGIO AUTO*/
                if (!costoAutoText.Text.Equals("10") && fineProcessiText.Text.Equals("True"))
                {
                    watchdogPictureBox.Visible = true;
                    poliziaText.Text = "True";
                }
                else
                {
                    watchdogPictureBox.Visible = false;
                    poliziaText.Text = "False";
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

        private void connectButton_Click(object sender, EventArgs e)
        {
            tcClient = new TcAdsClient();
            tcClient.Connect("127.0.0.1.1.1",851);

            dataStream = new AdsStream(NUM_ELEM_BOOL + NUM_ELEM_INT*2);
            binRead = new AdsBinaryReader(dataStream);

            hConnect = new int[NUM_ELEM_BOOL + NUM_ELEM_INT];
            hConnect[0] = tcClient.AddDeviceNotification(dataPLC[0], dataStream, 0 ,1, AdsTransMode.OnChange, 100, 0, preLavaggioText);
            hConnect[1] = tcClient.AddDeviceNotification(dataPLC[1], dataStream, 1, 1, AdsTransMode.OnChange, 100, 0, lavaggioInternoText);
            hConnect[2] = tcClient.AddDeviceNotification(dataPLC[2], dataStream, 2, 1, AdsTransMode.OnChange, 100, 0, saponeText);
            hConnect[3] = tcClient.AddDeviceNotification(dataPLC[3], dataStream, 3, 1, AdsTransMode.OnChange, 100, 0, risciacquoText);
            hConnect[4] = tcClient.AddDeviceNotification(dataPLC[4], dataStream, 4, 1, AdsTransMode.OnChange, 100, 0, posPreparazioneText);
            hConnect[5] = tcClient.AddDeviceNotification(dataPLC[5], dataStream, 5, 1, AdsTransMode.OnChange, 100, 0, poliziaText);
            hConnect[6] = tcClient.AddDeviceNotification(dataPLC[6], dataStream, 6, 1, AdsTransMode.OnChange, 100, 0, postoAutoText);
            hConnect[7] = tcClient.AddDeviceNotification(dataPLC[7], dataStream, 7, 1, AdsTransMode.OnChange, 100, 0, postoMotoText);
            hConnect[8] = tcClient.AddDeviceNotification(dataPLC[8], dataStream, 8, 1, AdsTransMode.OnChange, 100, 0, startText);
            hConnect[9] = tcClient.AddDeviceNotification(dataPLC[9], dataStream, 9, 1, AdsTransMode.OnChange, 100, 0, resetText);
            hConnect[10] = tcClient.AddDeviceNotification(dataPLC[10], dataStream, 10, 1, AdsTransMode.OnChange, 100, 0, pauseText);
            hConnect[11] = tcClient.AddDeviceNotification(dataPLC[11], dataStream, 11, 1, AdsTransMode.OnChange, 100, 0, motoText);
            hConnect[12] = tcClient.AddDeviceNotification(dataPLC[12], dataStream, 12, 1, AdsTransMode.OnChange, 100, 0, autoText);
            hConnect[13] = tcClient.AddDeviceNotification(dataPLC[13], dataStream, 13, 1, AdsTransMode.OnChange, 100, 0, fineProcessiText);
            hConnect[14] = tcClient.AddDeviceNotification(dataPLC[14], dataStream, 14, 2, AdsTransMode.OnChange, 100, 0, costoAutoText);
            hConnect[15] = tcClient.AddDeviceNotification(dataPLC[15], dataStream, 15, 2, AdsTransMode.OnChange, 100, 0, costoMotoText);
            hConnect[16] = tcClient.AddDeviceNotification(dataPLC[16], dataStream, 16, 2, AdsTransMode.OnChange, 100, 0, numeroStepText);
            hConnect[17] = tcClient.AddDeviceNotification(dataPLC[17], dataStream, 17, 1, AdsTransMode.OnChange, 100, 0, dxText);
            hConnect[18] = tcClient.AddDeviceNotification(dataPLC[18], dataStream, 18, 1, AdsTransMode.OnChange, 100, 0, sxText);
            hConnect[19] = tcClient.AddDeviceNotification(dataPLC[19], dataStream, 19, 1, AdsTransMode.OnChange, 100, 0, giuText);
            hConnect[20] = tcClient.AddDeviceNotification(dataPLC[20], dataStream, 20, 1, AdsTransMode.OnChange, 100, 0, allarmeText);
           
            
            tcClient.AdsNotification += new AdsNotificationEventHandler(OnNotification);
            connectText.Text = "OK";

            hvar_name = new int[NUM_ELEM_BOOL + NUM_ELEM_INT];
            for(int i=0; i < 21; i++)
            {
                hvar_name[i] = tcClient.CreateVariableHandle(dataPLC[i]);
            }
        }

        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            string strValue = "";

            if(e.NotificationHandle == hConnect[0])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[1])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[2])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[3])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[4])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[5])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[6])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[7])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[8])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[9])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[10])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[11])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[12])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[13])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[14])
                strValue = binRead.ReadInt16().ToString();
            if (e.NotificationHandle == hConnect[15])
                strValue = binRead.ReadInt16().ToString();
            if (e.NotificationHandle == hConnect[16])
                strValue = binRead.ReadInt16().ToString();
            if (e.NotificationHandle == hConnect[17])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[18])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[19])
                strValue = binRead.ReadBoolean().ToString();
            if (e.NotificationHandle == hConnect[20])
                strValue = binRead.ReadBoolean().ToString();
        

            ((TextBox)e.UserData).Invoke(new Action(() => ((TextBox)e.UserData).Text = String.Format(strValue)));
      
        }

        private void preLavaggioText_TextChanged(object sender, EventArgs e)
        {
            if(hvar_name != null)
            {
                if (preLavaggioText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[0], true);
                if (preLavaggioText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[0], false);
            }
        }

        private void lavaggioInternoText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (lavaggioInternoText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[1], true);
                if (lavaggioInternoText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[1], false);
            }
        }

        private void saponeText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (saponeText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[2], true);
                if (saponeText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[2], false);
            }
        }

        private void risciacquoText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (risciacquoText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[3], true);
                if (risciacquoText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[3], false);
            }
        }

        private void posPreparazioneText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (posPreparazioneText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[4], true);
                if (posPreparazioneText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[4], false);
            }
        }

        private void poliziaText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (poliziaText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[5], true);
                if (poliziaText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[5], false);
            }
        }

        private void postoAutoText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (postoAutoText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[6], true);
                if (postoAutoText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[6], false);
            }
        }

        private void postoMotoText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (postoMotoText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[7], true);
                if (postoMotoText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[7], false);
            }
        }

        private void startText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (startText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[8], true);
                if (startText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[8], false);
            }
        }

        private void resetText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (resetText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[9], true);
                if (resetText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[9], false);
            }
        }

        private void pauseText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (pauseText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[10], true);
                if (pauseText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[10], false);
            }
        }

        private void motoText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (motoText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[11], true);
                if (motoText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[11], false);
            }
        }

        private void autoText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (autoText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[12], true);
                if (autoText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[12], false);
            }
        }

        private void fineProcessiText_TextChanged(object sender, EventArgs e)
        {
            if (hvar_name != null)
            {
                if (fineProcessiText.Text.Equals("True"))
                    tcClient.WriteAny(hvar_name[13], true);
                if (fineProcessiText.Text.Equals("False"))
                    tcClient.WriteAny(hvar_name[13], false);
            }
        }

        private void costoAutoText_TextChanged(object sender, EventArgs e)
        {
            short i = 10;
            short j = 0;
            if (hvar_name != null)
            {
                if (costoAutoText.Text.Equals("10"))
                    tcClient.WriteAny(hvar_name[14], i);
                if (costoAutoText.Text.Equals("0"))
                    tcClient.WriteAny(hvar_name[14], j);
            }
        }

        private void costoMotoText_TextChanged(object sender, EventArgs e)
        {
            short i = 5;
            short j = 0;
            if (hvar_name != null)
            {
                if (costoMotoText.Text.Equals("5"))
                    tcClient.WriteAny(hvar_name[15], i);
               if (costoMotoText.Text.Equals("0"))
                    tcClient.WriteAny(hvar_name[15], j);
            }
        }

        private void numeroStepText_TextChanged(object sender, EventArgs e)
        {
            short a = 0;
            short b = 1;
            short c = 2;
            short d = 3;
            short f = 4;
            short g = 5;
            short h = 6;
            short i = 7;
            if (hvar_name != null)
            {
                if (numeroStepText.Text.Equals("0"))
                    tcClient.WriteAny(hvar_name[16], a );
                if (numeroStepText.Text.Equals("1"))
                    tcClient.WriteAny(hvar_name[16], b);
                if (numeroStepText.Text.Equals("2"))
                    tcClient.WriteAny(hvar_name[16], c);
                if (numeroStepText.Text.Equals("3"))
                    tcClient.WriteAny(hvar_name[16], d);
                if (numeroStepText.Text.Equals("4"))
                    tcClient.WriteAny(hvar_name[16], f);
                if (numeroStepText.Text.Equals("5"))
                        tcClient.WriteAny(hvar_name[16], g);
                if (numeroStepText.Text.Equals("6"))
                    tcClient.WriteAny(hvar_name[16], h);
                if (numeroStepText.Text.Equals("7"))
                    tcClient.WriteAny(hvar_name[16], i);
            }

            
        }   
    }
}