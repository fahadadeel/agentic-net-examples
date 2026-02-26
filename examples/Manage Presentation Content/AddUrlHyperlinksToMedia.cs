using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an image and assign a hyperlink to it
        byte[] imageBytes = File.ReadAllBytes("image.png");
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 150, image);
        pictureFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com/image");
        pictureFrame.HyperlinkClick.Tooltip = "Image link";

        // Add an audio file and assign a hyperlink to it
        byte[] audioBytes = File.ReadAllBytes("audio.mp3");
        Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioBytes);
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(
            300, 50, 100, 100, audio);
        audioFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com/audio");
        audioFrame.HyperlinkClick.Tooltip = "Audio link";

        // Add a video file and assign a hyperlink to it
        byte[] videoBytes = File.ReadAllBytes("video.mp4");
        Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoBytes);
        Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(
            300, 200, 200, 150, video);
        videoFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com/video");
        videoFrame.HyperlinkClick.Tooltip = "Video link";

        // Add a textbox with a hyperlink using HyperlinkManager
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 250, 300, 50);
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("Click here");
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = paragraph.Portions[0];
        Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
        hyperlinkManager.SetExternalHyperlinkClick("https://www.example.com/text");

        // Save the presentation
        presentation.Save("MediaHyperlinks.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}