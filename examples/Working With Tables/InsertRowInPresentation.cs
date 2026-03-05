using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation (contains one empty slide by default)
        var pres = new Aspose.Slides.Presentation();

        // Get the first (and only) slide
        var firstSlide = pres.Slides[0];

        // Insert a copy of the first slide at index 1 (adds a new slide after the first one)
        pres.Slides.InsertClone(1, firstSlide);

        // Save the modified presentation to disk
        pres.Save("InsertedRowPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}