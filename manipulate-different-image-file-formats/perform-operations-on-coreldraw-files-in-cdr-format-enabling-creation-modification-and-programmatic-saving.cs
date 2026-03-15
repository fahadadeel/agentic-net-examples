using System;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.cdr";

        using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var page = cdr.Pages[0] as CdrImagePage;

            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(page);
            graphics.Clear(Aspose.Imaging.Color.White);

            graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2), new Aspose.Imaging.Rectangle(100, 100, 200, 150));
            graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2), new Aspose.Imaging.Rectangle(150, 150, 100, 100));

            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Aspose.Imaging.Color.Green;
                brush.Opacity = 100;
                graphics.DrawString("Hello CDR", new Aspose.Imaging.Font("Arial", 24, Aspose.Imaging.FontStyle.Regular), brush, new Aspose.Imaging.PointF(120, 120));
            }

            cdr.Save(outputPath);
        }
    }
}