using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify that input and output file paths are provided
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: ConvertPptxToPpt <input.pptx> <output.ppt>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the PPTX file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Save the presentation in PPT format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}