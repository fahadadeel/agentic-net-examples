using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing presentation from file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Access the first master slide in the presentation
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Example operation: display the number of shapes on the master slide
            Console.WriteLine("Master slide contains {0} shapes.", masterSlide.Shapes.Count);

            // Save the presentation after accessing the master slide
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
    }
}