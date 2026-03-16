using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths for the target image, output image, and source images
        string targetPath = "target.png";
        string outputPath = "output.png";
        string[] sourcePaths = { "src1.png", "src2.png", "src3.png" };

        // Positions where each source image will be drawn onto the target
        var positions = new Aspose.Imaging.Point[]
        {
            new Aspose.Imaging.Point(0, 0),
            new Aspose.Imaging.Point(100, 50),
            new Aspose.Imaging.Point(200, 150)
        };

        // Load the target image
        using (Aspose.Imaging.Image targetImage = Aspose.Imaging.Image.Load(targetPath))
        {
            // Create a Graphics instance for drawing onto the target image
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(targetImage);

            // Draw each source image onto the target at the specified position
            for (int i = 0; i < sourcePaths.Length; i++)
            {
                using (Aspose.Imaging.Image srcImage = Aspose.Imaging.Image.Load(sourcePaths[i]))
                {
                    graphics.DrawImage(srcImage, positions[i]);
                }
            }

            // Save the modified target image, preserving its original format
            targetImage.Save(outputPath);
        }
    }
}