using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddOnlineVideoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add a YouTube video frame to the first slide
                AddVideoFromYouTube(pres, "Tj75Arhq5ho");

                // Save the presentation to a PPTX file
                pres.Save("AddVideoFrameFromWebSource_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }

        private static void AddVideoFromYouTube(Aspose.Slides.Presentation pres, string videoId)
        {
            // Construct the embed URL for the YouTube video
            string videoUrl = "https://www.youtube.com/embed/" + videoId;

            // Add a video frame that references the online video
            Aspose.Slides.IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);

            // Set the video to play automatically
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

            // Load the video thumbnail from YouTube and set it as the picture for the video frame
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
                byte[] thumbnailData = client.DownloadData(thumbnailUri);
                videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(thumbnailData);
            }
        }
    }
}