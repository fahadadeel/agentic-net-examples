using System;

class Program
{
    static void Main()
    {
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.pptx";

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        System.Console.WriteLine("Number of slides: " + presentation.Slides.Count);

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}