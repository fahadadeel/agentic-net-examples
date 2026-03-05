using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Paths to the source presentation, new video file and output presentation
        string inputPath = "input.pptx";
        string newVideoPath = "newVideo.mp4";
        string outputPath = "output.pptx";

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Locate the first video frame on the slide
        Aspose.Slides.IVideoFrame videoFrame = null;
        foreach (Aspose.Slides.IShape shape in slide.Shapes)
        {
            videoFrame = shape as Aspose.Slides.IVideoFrame;
            if (videoFrame != null)
            {
                break;
            }
        }

        if (videoFrame != null)
        {
            // Add the new video to the presentation's video collection
            Aspose.Slides.IVideo newVideo;
            using (FileStream videoStream = new FileStream(newVideoPath, FileMode.Open, FileAccess.Read))
            {
                newVideo = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
            }

            // Replace the embedded video while preserving the frame geometry
            videoFrame.EmbeddedVideo = newVideo;
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}