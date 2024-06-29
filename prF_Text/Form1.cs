using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using autoreplyprint.cs;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ThermalPrinting
{
    public partial class prF : Form
    {
        string filePath = "D:\\MY_QR\\";
        UIntPtr h = UIntPtr.Zero;
        public prF()
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            InitializeComponent();
  
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    printfComBox_15.Items.Add(port);
                    Console.WriteLine(port);
                }

                printfComBox_15.Text = printfComBox_15.Items[0].ToString();
            }
            else
            {
                MessageBox.Show("未检测到可用串口！");
            }
            printfComBox_15.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort serialPort = new SerialPort();

            h = AutoReplyPrint.CP_Port_OpenCom(
                    "COM37", 115200,
                    AutoReplyPrint.CP_ComDataBits_8,
                    AutoReplyPrint.CP_ComParity_NoParity,
                    AutoReplyPrint.CP_ComStopBits_One,
                    AutoReplyPrint.CP_ComFlowControl_None,
                    1);
        }
        Bitmap nu_bit=new Bitmap(50,50);
        byte[] data = new byte[5100];
        private void printfQR_15mm()
        {
            AutoReplyPrint.CP_Pos_SetPrintSpeed(H_15MM, 200);
            AutoReplyPrint.CP_Pos_SetAlignment(H_15MM, AutoReplyPrint.CP_Pos_Alignment_HCenter);

            AutoReplyPrint.CP_Pos_PrintRasterImageFromData(H_15MM, 350, 95, image_15_15MM_Byte, image_15_15MM_Byte.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);


            using (Graphics graphics = Graphics.FromImage(nu_bit))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, 50, 50);
            }

            MemoryStream memoryStream = new MemoryStream();
            nu_bit.Save(memoryStream, ImageFormat.Png);
            data = memoryStream.GetBuffer();
            AutoReplyPrint.CP_Pos_PrintRasterImageFromData(H_15MM, 1, 1, data, data.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
        }

        private void cbxComName_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
        }
        UIntPtr H_15MM = UIntPtr.Zero;
        private void printfButtoon_15_Click(object sender, EventArgs e)
        {
            string selectedPort = printfComBox_15.SelectedItem.ToString();
            Console.WriteLine(selectedPort);
            if (AutoReplyPrint.CP_Port_IsOpened(H_15MM) == 0)
            {
                H_15MM = AutoReplyPrint.CP_Port_OpenCom(
                   selectedPort, 115200,
                   AutoReplyPrint.CP_ComDataBits_8,
                   AutoReplyPrint.CP_ComParity_NoParity,
                   AutoReplyPrint.CP_ComStopBits_One,
                   AutoReplyPrint.CP_ComFlowControl_None,
                   1);
                button5.BackColor = Color.FromArgb(30, 215, 109);
            }
            else
            {
                AutoReplyPrint.CP_Port_Close(H_15MM);
                H_15MM = UIntPtr.Zero;
                button5.BackColor = System.Drawing.SystemColors.Info;
            }


        }
        UIntPtr H_40MM = UIntPtr.Zero;
        private void printfButtoon_40_Click(object sender, EventArgs e)
        {
        }
        private void printfComBox_15_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            printfComBox_15.Items.Clear();
            if (ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    printfComBox_15.Items.Add(port);
                    Console.WriteLine(port);
                }
                printfComBox_15.Text = printfComBox_15.Items[0].ToString();
            }
        }
        private void printfComBox_40_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
  
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;

            //AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 100, 100, str, AutoReplyPrint.CP_ImageBinarizationMethod_Dithering, AutoReplyPrint.CP_ImageCompressionMethod_None);
            //AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 200, 200, str, AutoReplyPrint.CP_ImageBinarizationMethod_Thresholding, AutoReplyPrint.CP_ImageCompressionMethod_None);

            AutoReplyPrint.CP_Pos_SetPrintSpeed(h, 27);
            AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
            AutoReplyPrint.CP_Pos_PrintRasterImageFromFile(h, 200, 200, str, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);


            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 1);
            if (result == 0)
                MessageBox.Show("Write failed");
        }

        int With, Hight ,Seep= 0;
        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image File|*.png;*.bmp;*.jpg";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            String str = openFileDialog.FileName;
            byte[] data = FileUtils.ReadFromFile(str);
            if (data == null)
                return;
            int.TryParse(boBox_Seep.Text, out Seep);
            AutoReplyPrint.CP_Pos_SetPrintSpeed(h, Seep);
            AutoReplyPrint.CP_Pos_SetAlignment(h, AutoReplyPrint.CP_Pos_Alignment_HCenter);
            int.TryParse(textBox_X.Text, out With);
            int.TryParse(textBox_Y.Text, out Hight);
            
            AutoReplyPrint.CP_Pos_PrintRasterImageFromData(h, With, Hight, data, data.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);

            int result = AutoReplyPrint.CP_Pos_FeedLine(h, 2);
            if (result == 0)
                MessageBox.Show("Write failed");
        }
        public static string CodeDecoder(string f_arr)
        {
            if (!System.IO.File.Exists(f_arr))
                return null;
            Bitmap myBitmap = new Bitmap((f_arr));
            QRCodeDecoder decoder = new QRCodeDecoder();
            string decodedString = decoder.decode(new QRCodeBitmapImage(myBitmap), Encoding.UTF8);
            myBitmap.Dispose();
            return decodedString;
        }
        static byte[] image_15_15MM_Byte = new byte[1024 * 1024];

        private void textBox_QR_TextChanged(object sender, EventArgs e)
        {

        }

        private void boBox_Seep_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Y_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_X_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int n = 55;
            while(n>1)
            {
                n--;
                printfQR_15mm();
                Thread.Sleep(100);
            }
        }
        static byte[] image_5MM_Byte = new byte[1024 * 1024];
        //static string filePath5mm = "D:\\VS\\C#\\ThermalPrinting_15_5\\new -00.jpg";
        //Bitmap imag_5mm_B = new Bitmap(filePath5mm);
        private void button3_Click_1(object sender, EventArgs e)
        {
            Bitmap imag_5mm = new Bitmap(1300, 300);
            using (Graphics g = Graphics.FromImage(imag_5mm))
            {
                g.FillRectangle(Brushes.White, 0, 0, 1300, 300);
                //g.DrawImage(imag_5mm_B, 700, 0, 750, 200);
            }
            MemoryStream memoryStream_5mm = new MemoryStream();
            imag_5mm.Save(memoryStream_5mm, ImageFormat.Png);
            image_5MM_Byte = memoryStream_5mm.GetBuffer();


            printfQR_15_5mm();
            string filename = @filePath + $"{"xieTU-QR"}-05.jpg";
            imag_5mm.Save(filename, ImageFormat.Jpeg);
            imag_5mm.Dispose();
        }
        int num = 0;
        private void printfQR_15_5mm()
        {
            int.TryParse(boBox_Seep.Text, out Seep);
            AutoReplyPrint.CP_Pos_SetPrintSpeed(H_15MM, Seep);
            AutoReplyPrint.CP_Pos_SetAlignment(H_15MM, AutoReplyPrint.CP_Pos_Alignment_HCenter);

            AutoReplyPrint.CP_Pos_PrintRasterImageFromData(H_15MM, 350, 96, image_5MM_Byte, image_15_15MM_Byte.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
            num++;
            textBox_Num.Text= num.ToString();
        }
        private void printfBuffer(byte[] buffer)
        {
            int.TryParse(boBox_Seep.Text, out Seep);
            AutoReplyPrint.CP_Pos_SetPrintSpeed(H_15MM, Seep);
            AutoReplyPrint.CP_Pos_SetAlignment(H_15MM, AutoReplyPrint.CP_Pos_Alignment_HCenter);

            AutoReplyPrint.CP_Pos_PrintRasterImageFromData(H_15MM, 496, 493, buffer, buffer.Length, AutoReplyPrint.CP_ImageBinarizationMethod_ErrorDiffusion, AutoReplyPrint.CP_ImageCompressionMethod_None);
            num++;
            textBox_Num.Text = num.ToString();
        }

        private void buttonTextSpr(object sender, EventArgs e)
        {
            string prfText = textBoxPrfText.Text;
            Bitmap image_Text = new Bitmap(800, 800);
            using (Graphics graphics = Graphics.FromImage(image_Text))
            {
                Font font = new Font("Arial Black", 70, FontStyle.Bold); // 使用 Arial Black 字体

                graphics.FillRectangle(Brushes.White, 0, 0, image_Text.Width, image_Text.Height);
                StringFormat stringFormat = new StringFormat();
                graphics.DrawString(prfText, font, Brushes.Black, new RectangleF(0, 0, image_Text.Width, image_Text.Height), stringFormat);

            }
            MemoryStream memoryStream = new MemoryStream();
            image_Text.Save(memoryStream, ImageFormat.Png);
            byte[] imageTextBuffer = memoryStream.GetBuffer();
            string filename = @filePath + "A-Text.jpg";
            image_Text.Save(filename, ImageFormat.Jpeg);
            memoryStream.Dispose();

            printfBuffer(imageTextBuffer);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static byte[] image_40_60MM_Byte = new byte[1024 * 1024];

        private void button_QR_Click(object sender, EventArgs e)
        {
            string arr = textBox_QR.Text;
            Console.Write(arr);
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 10;
            qrCodeEncoder.QRCodeVersion = 3;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            System.Drawing.Image qrCodeImage = qrCodeEncoder.Encode(arr, Encoding.UTF8);

            Bitmap image_PC = new Bitmap(qrCodeImage.Width + 60, qrCodeImage.Height + 60 + 30);
            using (Graphics graphics = Graphics.FromImage(image_PC))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, qrCodeImage.Width + 60, qrCodeImage.Height + 60 + 30);
                graphics.DrawImage(qrCodeImage, 30, 30);
                using (Font font = new Font("Arial", 20, FontStyle.Bold))
                {
                    StringFormat stringFormat = new StringFormat();

                    SizeF textSize = graphics.MeasureString("xieTU", font);
                    float x1 = 30 + (qrCodeImage.Width - textSize.Width) / 2;
                    graphics.DrawString("xieTU", font, Brushes.Black, new RectangleF(x1, qrCodeImage.Height + 30, textSize.Width, textSize.Height), stringFormat);
                }
            }
            //qrCodeImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            Bitmap image_15MM = new Bitmap(1300, 300);
            using (Graphics graphics = Graphics.FromImage(image_15MM))
            {
                int x = 820, y = 1, width = 80;
                graphics.FillRectangle(Brushes.White, 0, 0, 1300, 300);
                using (Font font = new Font("Arial", 55, FontStyle.Bold))
                {
                    StringFormat stringFormat = new StringFormat();
                    graphics.DrawString("10204A", font, Brushes.Black, new RectangleF(x + 10, y, 1000, width), stringFormat);
                    graphics.DrawString("003A001", font, Brushes.Black, new RectangleF(x, y + width, 1000, width), stringFormat);

                    //graphics.DrawString("10204A003A001", font, Brushes.Black, new RectangleF(680, y+40, 1000, width), stringFormat);

                }
            }
            Bitmap image_40_60MM = new Bitmap(600, 600);
            using (Graphics graphics = Graphics.FromImage(image_40_60MM))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, 600, 600);
                graphics.DrawImage(qrCodeImage, 230, 80);
                using (Font font = new Font("Arial", 35, FontStyle.Bold))
                {
                    StringFormat stringFormat = new StringFormat();
                    SizeF textSize = graphics.MeasureString("xieTU", font);
                    float x1 =230+(qrCodeImage.Width - textSize.Width) / 2;
                    graphics.DrawString("0", font, Brushes.Black, new RectangleF(x1, qrCodeImage.Height + 80, image_40_60MM.Width , 100), stringFormat);
                }
            }

            MemoryStream memoryStream = new MemoryStream();
            image_15MM.Save(memoryStream, ImageFormat.Png);
            image_15_15MM_Byte = memoryStream.GetBuffer();

            //memoryStream.Seek(0, SeekOrigin.Begin);
            //image_40_60MM.RotateFlip(RotateFlipType.Rotate270FlipNone);
            //image_40_60MM.Save(memoryStream, ImageFormat.Png);
            //image_40_60MM_Byte = memoryStream.GetBuffer();


            MemoryStream memoryStream1 = new MemoryStream();
            image_40_60MM.RotateFlip(RotateFlipType.Rotate270FlipNone);
            image_40_60MM.Save(memoryStream, ImageFormat.Png);
            image_40_60MM_Byte = memoryStream.GetBuffer();

            printfQR_15mm();



            string filename = @filePath + "xieTU-QR-15.jpg";
            image_15MM.Save(filename, ImageFormat.Jpeg);
            image_15MM.Dispose();

            

            filename = @filePath + $"{"xieTU-QR"}-40.jpg";
            image_40_60MM.Save(filename, ImageFormat.Jpeg);
            image_40_60MM.Dispose();

            filename = @filePath + $"{"xieTU-QR"}.jpg";
            image_PC.Save(filename, ImageFormat.Jpeg);
            image_PC.Dispose();


            string codeDecoder = CodeDecoder(filename);
            if (arr == codeDecoder)
            {
                Console.WriteLine($"二维码内容：{codeDecoder}");
                Invoke(new Action(() =>
                {
                    //label2.Text = codeDecoder;
                    //label3.Text = "已保存至 " + filename + "\r\n二维码生成成功";
                }));
            }
            else
            {
                Console.WriteLine($"二维码内容：{"失败"}");
                Invoke(new Action(() =>
                {
                    //label2.Text = "失败";
                }));
            }


        }


    }
    class FileUtils
    {
        public static byte[] ReadFromFile(String fileName)
        {
            byte[] data = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
            }
            return data;
        }
    }
}
