using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPT or PPTX file
        string inputPath = "example.pptx";

        // Folder where SVG files will be saved
        string outputFolder = "output";

        // Ensure the output folder exists
        System.IO.Directory.CreateDirectory(outputFolder);

        // Format string for naming each SVG file (slide numbers start from 1)
        string formatString = System.IO.Path.Combine(outputFolder, "slide_{0}.svg");

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides and save each as an SVG file
        for (int index = 0; index < pres.Slides.Count; index++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[index];
            using (System.IO.FileStream stream = new System.IO.FileStream(
                string.Format(formatString, index + 1),
                System.IO.FileMode.Create,
                System.IO.FileAccess.Write))
            {
                slide.WriteAsSvg(stream);
            }
        }

        // Dispose the presentation to release resources
        pres.Dispose();
    }
}