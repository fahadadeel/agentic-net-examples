using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        using (Image image = Image.Load(inputPath))
        {
            Graphics graphics = new Graphics(image);

            Pen redPen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(redPen, new Rectangle(50, 50, 200, 150));

            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                blueBrush.Opacity = 50;
                graphics.FillEllipse(blueBrush, new Rectangle(100, 100, 150, 100));
            }

            using (SolidBrush blackBrush = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 24);
                graphics.DrawString("Hello Aspose!", font, blackBrush, new PointF(60, 220));
            }

            PngOptions saveOptions = new PngOptions();
            image.Save(outputPath, saveOptions);
        }
    }
}