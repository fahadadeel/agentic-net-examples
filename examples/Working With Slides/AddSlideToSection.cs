using System;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISection section = presentation.Sections.AddSection("Introduction", presentation.Slides[0]);
            presentation.Save("Introduction.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}