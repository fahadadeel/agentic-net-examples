using System;

class Program
{
    static void Main()
    {
        // Load an existing PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first master slide in the presentation
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Example operation: display the master slide's name
        Console.WriteLine("Master slide name: " + masterSlide.Name);

        // Save the presentation (required before exiting)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}