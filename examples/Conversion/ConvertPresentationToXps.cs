using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths to source presentations
        string pptPath = "sample.ppt";
        string pptxPath = "sample.pptx";

        // Convert PPT to XPS using default options
        Aspose.Slides.Presentation pptPresentation = new Aspose.Slides.Presentation(pptPath);
        pptPresentation.Save("sample_converted_from_ppt.xps", Aspose.Slides.Export.SaveFormat.Xps);
        pptPresentation.Dispose();

        // Convert PPTX to XPS using custom XpsOptions
        Aspose.Slides.Presentation pptxPresentation = new Aspose.Slides.Presentation(pptxPath);
        Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
        xpsOptions.SaveMetafilesAsPng = true; // Example custom option
        pptxPresentation.Save("sample_converted_from_pptx.xps", Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);
        pptxPresentation.Dispose();
    }
}