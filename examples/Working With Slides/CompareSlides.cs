using System;

class Program
{
    static void Main()
    {
        // Load the first presentation
        Aspose.Slides.Presentation presentation1 = new Aspose.Slides.Presentation("Presentation1.pptx");
        // Load the second presentation
        Aspose.Slides.Presentation presentation2 = new Aspose.Slides.Presentation("Presentation2.pptx");

        // Retrieve the first slide from each presentation
        Aspose.Slides.ISlide slide1 = presentation1.Slides[0];
        Aspose.Slides.ISlide slide2 = presentation2.Slides[0];

        // Compare the two slides for visual equality
        bool areEqual = slide1.Equals(slide2);

        Console.WriteLine("Slides are equal: " + areEqual);

        // Save the presentations before exiting
        presentation1.Save("Presentation1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation2.Save("Presentation2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation1.Dispose();
        presentation2.Dispose();
    }
}