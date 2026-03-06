using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the last view to Slide Master view
        presentation.ViewProperties.LastView = Aspose.Slides.ViewType.SlideMasterView;

        // Save the presentation
        presentation.Save("PredefinedView.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}