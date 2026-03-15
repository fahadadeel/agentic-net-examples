using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.cdr";

        // Load the CDR image.
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Emboss effect cannot be applied directly to vector CDR images.
            throw new NotSupportedException("Emboss effect cannot be applied directly to CDR vector images.");

            // If supported, processing would occur here, followed by:
            // cdr.Save(outputPath);
        }
    }
}