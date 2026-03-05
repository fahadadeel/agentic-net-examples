using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load the OLE object data (e.g., an Excel file)
        byte[] excelData = File.ReadAllBytes("sample.xlsx");

        // Create embedded data info for the OLE object
        Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");

        // Add the OLE object frame to the slide, covering the whole slide area
        Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
            0,
            0,
            presentation.SlideSize.Size.Width,
            presentation.SlideSize.Size.Height,
            dataInfo);

        // Prevent resizing and repositioning of the OLE object frame
        oleFrame.ShapeLock.SizeLocked = true;
        oleFrame.ShapeLock.PositionLocked = true;

        // Save the presentation
        presentation.Save("PreventResize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}