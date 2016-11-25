using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace PrintBarCode
{
    public class PrintBarcodeSingle
    {
        private int top = 10;
        private int left = 30;
        private int textTop = 110;
        private int textLeft = 30;
        private string fontName = "宋体";
        private float fontSize = 9;
        private bool isBold = false;
        private Bitmap bmpBarcode = null;
        private string barcodeText = "";
        private PrintDocument barcodePrint = new PrintDocument();
        private PrintDocument textPrint = new PrintDocument();
        private PrintDocument testPrint = new PrintDocument();

        public PrintBarcodeSingle()
        {
            barcodePrint.PrintPage += new PrintPageEventHandler(barcodePrint_PrintPage);
            textPrint.PrintPage += new PrintPageEventHandler(textPrint_PrintPage);
            this.testPrint.PrintPage += new PrintPageEventHandler(testPrint_PrintPage);
        }

        void testPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            FontStyle fontStyle = FontStyle.Regular;
            if (isBold)
            {
                fontStyle = FontStyle.Bold;
            }
            e.Graphics.DrawString(barcodeText, new Font(this.fontName, fontSize, fontStyle), Brushes.Black, 20, 20);
            e.Graphics.DrawString(barcodeText, new Font(this.fontName, fontSize, fontStyle), Brushes.Black, 210, 20);
            e.Graphics.DrawString(barcodeText, new Font(this.fontName, fontSize, fontStyle), Brushes.Black, 20, 150);
            e.Graphics.DrawString(barcodeText, new Font(this.fontName, fontSize, fontStyle), Brushes.Black, 210, 150);

            e.Graphics.Dispose();
        }

        private void textPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            FontStyle fontStyle = FontStyle.Regular;
            if (isBold)
            {
                fontStyle = FontStyle.Bold;
            }
            e.Graphics.DrawString(barcodeText, new Font(this.fontName, fontSize, fontStyle), Brushes.Black, textLeft, textTop);
            e.Graphics.Dispose();

        }
        private void barcodePrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmpBarcode, new Point(left, top));
            FontStyle fontStyle = FontStyle.Regular;
            if (isBold)
            {
                fontStyle = FontStyle.Bold;
            }
            e.Graphics.DrawString(barcodeText, new Font(this.fontName, fontSize, fontStyle), Brushes.Black, textLeft, textTop);
            e.Graphics.Dispose();
        }
        public void PrintBarcode(string barcodeText, Bitmap bmpBarcode, int top, int left, string fontName, float fontSize, bool isBold, int textTop, int textLeft)
        {
            this.barcodeText = barcodeText;
            this.bmpBarcode = bmpBarcode;
            this.textTop = textTop;
            this.textLeft = textLeft;
            this.top = top;
            this.left = left;
            this.fontName = fontName;
            this.fontSize = fontSize;
            this.isBold = isBold;

            barcodePrint.PrinterSettings.Copies = 1;				//打印份数
            barcodePrint.PrintController = new StandardPrintController();                  //定义一个打印控制器，可取消打印进度显示框的弹出
            barcodePrint.Print();
        }
        public void PrintText(string printText, int top, int left, string fontName, float fontSize, bool isBold, int textTop, int textLeft)
        {
            this.barcodeText = printText;
            this.top = top;
            this.left = left;
            this.textLeft = textLeft;
            this.textTop = textTop;
            this.fontName = fontName;
            this.fontSize = fontSize;
            this.isBold = isBold;

            this.textPrint.PrinterSettings.Copies = 1;				//打印份数
            this.textPrint.PrintController = new StandardPrintController();                  //定义一个打印控制器，可取消打印进度显示框的弹出
            this.textPrint.Print();
        }
        public void PrintTestText(string printText, string fontName, float fontSize, bool isBold)
        {
            this.barcodeText = printText;

            this.fontName = fontName;
            this.fontSize = fontSize;
            this.isBold = isBold;
            this.testPrint.PrinterSettings.Copies = 1;				//打印份数
            this.testPrint.PrintController = new StandardPrintController();                  //定义一个打印控制器，可取消打印进度显示框的弹出
            this.testPrint.Print();
        }

    }

}