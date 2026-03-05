using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);
        IAutoShape autoShape = (IAutoShape)shape;

        // Add text to the shape
        autoShape.AddTextFrame("Click me");

        // Create a hyperlink pointing to an external URL
        Hyperlink hyperlink = new Hyperlink("https://www.example.com");
        autoShape.HyperlinkClick = hyperlink;

        // Load audio data from a file (ensure the file exists at the specified path)
        byte[] audioData = File.ReadAllBytes("sound.mp3");

        // Add the audio to the presentation's audio collection
        IAudio audio = presentation.Audios.AddAudio(audioData);

        // Assign the audio as the sound for the hyperlink
        hyperlink.Sound = audio;

        // Save the presentation
        presentation.Save("HyperlinkSound.pptx", SaveFormat.Pptx);
    }
}