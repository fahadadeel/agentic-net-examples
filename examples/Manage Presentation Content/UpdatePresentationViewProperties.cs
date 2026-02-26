using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve view properties
        Aspose.Slides.IViewProperties viewProps = presentation.ViewProperties;

        // Access current view settings
        int currentSlideScale = viewProps.SlideViewProperties.Scale;
        int currentNotesScale = viewProps.NotesViewProperties.Scale;
        float currentGridSpacing = viewProps.GridSpacing;
        Aspose.Slides.NullableBool? currentShowComments = viewProps.ShowComments;

        // Update view properties
        viewProps.SlideViewProperties.Scale = 120; // Zoom to 120% for slide view
        viewProps.NotesViewProperties.Scale = 100; // Zoom to 100% for notes view
        viewProps.GridSpacing = 10f; // Set grid spacing to 10 points
        viewProps.ShowComments = Aspose.Slides.NullableBool.True; // Show comments

        // Save the modified presentation
        presentation.Save("output.ppt", SaveFormat.Ppt);
    }
}