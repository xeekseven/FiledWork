using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;

namespace MyPrintBarCode
{
    class PrintBarCode
    {
        private PrintDocument barCodePrint = new PrintDocument();
        private string _barCode = string.Empty;
        private int _height = 100;
        private int _width = 300;
        private string _barCodeType = string.Empty;
        public PrintBarCode()
        {
            barCodePrint.PrintPage += new PrintPageEventHandler(this.print_PrintPage);

        }
        public void Print(string barCodeType, int height, int width, string barCode)
        {
            this._barCodeType = barCodeType;
            this._height = height == 0 ? 100 : height;
            this._width = width == 0 ? 200 : width;
            this._barCode = barCode;

            try
            {
                barCodePrint.PrinterSettings.Copies = Convert.ToInt16(1);
                barCodePrint.PrintController = new StandardPrintController();
                barCodePrint.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void print_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Bitmap barCodeBtm;
                Point barCodePoint = new Point(60, 37);
                if (this._barCodeType.Equals("QRCode"))
                {
                    //生成二维条码
                    QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                    qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                    qrCodeEncoder.QRCodeScale = 4;
                    qrCodeEncoder.QRCodeVersion = 7;
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                    //获取二维码图片
                    Bitmap barBtm = qrCodeEncoder.Encode(this._barCode);
                    barCodeBtm = new Bitmap(barBtm, this._width, this._height);

                }
                else
                {
                    Code128.Code128 code128 = new Code128.Code128();
                    Bitmap barBtm = code128.GetCodeImage(this._barCode, this.GetBarCodeType());
                    barCodeBtm = new Bitmap(barBtm, this._width, this._height);

                    e.Graphics.DrawString("条码:" + this._barCode, new Font("宋体", 12, FontStyle.Bold), Brushes.Black, barCodePoint.X + barCodeBtm.Width - ("条码:" + this._barCode).Length * 12, barCodePoint.Y + barCodeBtm.Height + 10);
                }
                e.Graphics.DrawImage(barCodeBtm, barCodePoint);//开始绘图
                e.Graphics.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Code128.Code128.Encode GetBarCodeType()
        {
            Code128.Code128.Encode codeType = Code128.Code128.Encode.Code128A;
              switch (this._barCodeType)
            {
                case "Code128A":
                    codeType = Code128.Code128.Encode.Code128A;
                    break;
                case "Code128B":
                    codeType = Code128.Code128.Encode.Code128B;
                    break;
                case "Code128C":
                    codeType = Code128.Code128.Encode.Code128C;
                    break;
                case "EAN128":
                    codeType = Code128.Code128.Encode.EAN128;
                    break;
            }
            return codeType;
        }
    }
}


