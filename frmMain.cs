using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Memorize
{
    public partial class frmMain : Form
    {
        private string mstrFileContents;
        private byte[] marrFileContents;
        private string[] mstrLines;
        private Bitmap mobjFormBitmap;
        private Graphics mobjBitmapGraphics;
        private int mintFormWidth;
        private int mintFormHeight;
        private Boolean mblnDoneOnce = false;
        private int mintDrawingAreaX1;
        private int mintDrawingAreaY1;
        private int mintDrawingAreaX2;
        private int mintDrawingAreaY2;
        private int mintFirstLine;
        private int mintLastLine;
        System.Diagnostics.Process mobjProcess;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            char[] ChrSplitter = {'\n'};

            if (!mblnDoneOnce)
            {
                mblnDoneOnce = true;
                mintFormWidth = this.Width;
                mintFormHeight = this.Height;
                mobjFormBitmap = new Bitmap(mintFormWidth, mintFormHeight, this.CreateGraphics());
                mobjBitmapGraphics = Graphics.FromImage(mobjFormBitmap);
                mintDrawingAreaX1 = 10;
                mintDrawingAreaY1 = 10;
                mintDrawingAreaX2 = mintFormWidth - 20;
                mintDrawingAreaY2 = mintFormHeight - 40;
                ReadListFile();
                mstrFileContents = mstrFileContents.Replace("\r", "");

                mstrLines = mstrFileContents.Split(ChrSplitter, StringSplitOptions.RemoveEmptyEntries);
                mintFirstLine = 0;
                mintLastLine = 0;
                DisplayFile();
            }
        }

        private void ReadListFile()
        {
            // read the file into the byte array, used this method to read non ascii characters
            FileStream objFileStream = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "List.txt", FileMode.Open, FileAccess.Read);
            try
            {
                int intLength = (int)objFileStream.Length;
                marrFileContents = new byte[intLength];
                int intCount;
                int intOffset = 0;
                while ((intCount = objFileStream.Read(marrFileContents, intOffset, intLength - intOffset)) > 0)
                    intOffset += intCount;
            }
            finally
            {
                objFileStream.Close();
            }

            mstrFileContents = Encoding.Default.GetString(marrFileContents);

        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(mobjFormBitmap, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Do nothing
        }

        private void DisplayFile()
        {
            int intYPosition;
            Font objFont;
            string strWord;
            string strTranslation;

            mobjBitmapGraphics.FillRectangle(Brushes.White, 0, 0, mintFormWidth, mintFormHeight);
            mobjBitmapGraphics.DrawRectangle(Pens.Black, mintDrawingAreaX1, mintDrawingAreaY1, mintDrawingAreaX2 - mintDrawingAreaX1 , mintDrawingAreaY2 - mintDrawingAreaY1 );
            objFont = new Font("MS Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            intYPosition = mintDrawingAreaY1 + 5;
            for (int intLineCounter = mintFirstLine; intLineCounter <= mintLastLine; intLineCounter++)
            {
                if (intLineCounter <= mstrLines.Length - 1)
                {
                    if (intLineCounter == mintLastLine - 1)
                    {
                        mobjBitmapGraphics.FillRectangle(Brushes.LightGray, mintDrawingAreaX1 + 1, intYPosition,mintDrawingAreaX2 - mintDrawingAreaX1 - 2,  24);
                    }
                    if (mnuEnglishFirst.Checked)
                    {
                        strWord = mstrLines[intLineCounter].Split('\t')[0];
                        if (intLineCounter < mintLastLine)
                            strTranslation = mstrLines[intLineCounter].Split('\t')[1];
                        else
                            strTranslation = "";
                    }
                    else
                    {
                        strWord = mstrLines[intLineCounter].Split('\t')[1];
                        if (intLineCounter < mintLastLine)
                            strTranslation = mstrLines[intLineCounter].Split('\t')[0];
                        else
                            strTranslation = "";
                    }
                    mobjBitmapGraphics.DrawString(strWord, objFont, Brushes.Black, mintDrawingAreaX1 + 5, intYPosition);
                    mobjBitmapGraphics.DrawString(strTranslation, objFont, Brushes.Black, mintDrawingAreaX1 + ((mintDrawingAreaX2 - mintDrawingAreaX1) / 2), intYPosition);
                }
                intYPosition += 20;
            }

            this.Invalidate();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (mintLastLine < mstrLines.Length)
                    {
                        mintLastLine += 1;
                        if (mintLastLine - mintFirstLine > 33)
                        {
                            mintFirstLine = mintLastLine - 1; // scroll to a new page
                        }
                        DisplayFile();
                        if (mintLastLine == mstrLines.Length)
                        {
                            mobjBitmapGraphics.FillRectangle(Brushes.Gray, 0, 0, mintFormWidth, mintFormHeight);
                            this.Invalidate();
                            Application.DoEvents();
                            Thread.Sleep(100);
                            DisplayFile();
                            Application.DoEvents();
                            Thread.Sleep(100);
                            mobjBitmapGraphics.FillRectangle(Brushes.Gray, 0, 0, mintFormWidth, mintFormHeight);
                            this.Invalidate();
                            Application.DoEvents();
                            Thread.Sleep(100);
                            DisplayFile();
                            Application.DoEvents();
                            Thread.Sleep(100);
                            mobjBitmapGraphics.FillRectangle(Brushes.Gray, 0, 0, mintFormWidth, mintFormHeight);
                            this.Invalidate();
                            Application.DoEvents();
                            Thread.Sleep(100);
                            DisplayFile();
                        }
                    }
                    break;
            }
        }

        private void mnuEnglishFirst_Click(object sender, EventArgs e)
        {
            DisplayFile();
        }

        private void mnuEditWords_Click(object sender, EventArgs e)
        {
            mobjProcess = new System.Diagnostics.Process();
            mobjProcess.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "List.txt";
            mobjProcess.EnableRaisingEvents = true;
            mobjProcess.Start();
            mobjProcess.Exited += new System.EventHandler(NotePad_Exit);
        }

        private void NotePad_Exit(object sender, EventArgs e)
        {
            char[] ChrSplitter = { '\n' };

            ReadListFile();
            mstrFileContents = mstrFileContents.Replace("\r", "");

            mstrLines = mstrFileContents.Split(ChrSplitter, StringSplitOptions.RemoveEmptyEntries);
            mintFirstLine = 0;
            mintLastLine = 0;
            DisplayFile();
        }
    }
}
