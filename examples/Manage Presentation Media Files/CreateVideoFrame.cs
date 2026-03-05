using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            AddVideoFromYouTube(pres, "Tj75Arhq5ho");
            pres.Save("AddVideoFrameFromWebSource_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }

    private static void AddVideoFromYouTube(Aspose.Slides.Presentation pres, string videoId)
    {
        Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10f, 10f, 427f, 240f,
            "https://www.youtube.com/embed/" + videoId);
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
        using (System.Net.WebClient client = new System.Net.WebClient())
        {
            string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
            byte[] imageData = client.DownloadData(thumbnailUri);
            videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(imageData);
        }
    }
}