// Path to the source PSD file
string inputPsdPath = @"C:\Images\sample.psd";

// Desired output PDF file path
string outputPdfPath = @"C:\Images\sample.pdf";

// Load the PSD image using Aspose.Imaging's built‑in load method
using (Aspose.Imaging.Image psdImage = Aspose.Imaging.Image.Load(inputPsdPath))
{
    // Save the loaded image directly as PDF.
    // Aspose.Imaging automatically preserves image layers and color fidelity
    // when converting to PDF using the default save options.
    psdImage.Save(outputPdfPath);
}