using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Drawing;
using SolidFramework;


namespace HS
{


    enum ImageType { TIFF, BMP, JPG, PNG };




    public class pdf2image
    {


        static  public void DoConversion(string file, string password, string folder,int dpi, string pagerange, ImageType iType)
        {
            System.Drawing.Imaging.ImageFormat format;
            string extension = null;

            // Setup the license
            SolidFramework.License.ActivateDeveloperLicense();

            // Set the output image type
            switch (iType)
            {
                case ImageType.BMP:
                    format = System.Drawing.Imaging.ImageFormat.Bmp;
                    extension = "bmp";
                    break;
                case ImageType.JPG:
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    extension = "jpg";
                    break;
                case ImageType.PNG:
                    format = System.Drawing.Imaging.ImageFormat.Png;
                    extension = "png";
                    break;
                case ImageType.TIFF:
                    format = System.Drawing.Imaging.ImageFormat.Tiff;
                    extension = "tif";
                    break;
                default:
                    throw new ArgumentException("DoConversion: ImageType not known");
            }

            // Load up the document
            SolidFramework.Pdf.PdfDocument doc =
                new SolidFramework.Pdf.PdfDocument(file, password);
            doc.Open();

            // Setup the outputfolder
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            // Setup the file string.
            string filename = folder + Path.DirectorySeparatorChar +
                Path.GetFileNameWithoutExtension(file);

            // Get our pages.
            List<SolidFramework.Pdf.Plumbing.PdfPage> Pages =
                new List<SolidFramework.Pdf.Plumbing.PdfPage>(doc.Catalog.Pages.PageCount);
            SolidFramework.Pdf.Catalog catalog =
                (SolidFramework.Pdf.Catalog)SolidFramework.Pdf.Catalog.Create(doc);
            SolidFramework.Pdf.Plumbing.PdfPages pages =
                (SolidFramework.Pdf.Plumbing.PdfPages)catalog.Pages;
            ProcessPages(ref pages, ref Pages);

            // Check for page ranges
            PageRange ranges = null;
            bool bHaveRanges = false;
            if (!string.IsNullOrEmpty(pagerange))
            {
                bHaveRanges = PageRange.TryParse(pagerange, out ranges);
            }

            if (bHaveRanges)
            {
                int[] pageArray = ranges.ToArray();
                foreach (int number in pageArray)
                {
                    CreateImageFromPage(Pages[number], dpi, filename, number,
                        extension, format);
                    Console.WriteLine(string.Format("Processed page {0} of {1}", number,
                        Pages.Count));
                }
            }
            else
            {
                // For each page, save off a file.
                int pageIndex = 0;
                foreach (SolidFramework.Pdf.Plumbing.PdfPage page in Pages)
                {
                    // Update the page number.
                    pageIndex++;

                    CreateImageFromPage(page, dpi, filename, pageIndex, extension, format);
                    Console.WriteLine(string.Format("Processed page {0} of {1}", pageIndex,
                        Pages.Count));
                }
            }
        }


        private static void CreateImageFromPage(SolidFramework.Pdf.Plumbing.PdfPage page,
            int dpi, string filename, int pageIndex, string extension,
            System.Drawing.Imaging.ImageFormat format)
        {
            // Create a bitmap from the page with set dpi.
            Bitmap bm = page.DrawBitmap(dpi);

            // Setup the filename.
            string filepath = string.Format(filename + "-{0}.{1}", pageIndex, extension);

            // If the file exits already, delete it. I.E. Overwrite it.
            if (System.IO.File.Exists(filepath))
                System.IO.File.Delete(filepath);

            // Save the file.
            bm.Save(filepath, format);

            // Cleanup.
            bm.Dispose();
        }


        private static void ProcessPages(ref SolidFramework.Pdf.Plumbing.PdfPages pages,
            ref List<SolidFramework.Pdf.Plumbing.PdfPage> listPages)
        {
            // Walk the Pages catalog and get all the page objects.  This will follow 
            // the references and get the actual object that we can work 
            // with recursively.
            foreach (SolidFramework.Pdf.Plumbing.PdfItem pdfItem in pages.Kids)
            {
                SolidFramework.Pdf.Plumbing.PdfDictionary dictionary =
                    (SolidFramework.Pdf.Plumbing.PdfDictionary)
                    SolidFramework.Pdf.Plumbing.PdfItem.GetIndirectionItem(pdfItem);
                if (dictionary.Type == "Pages")
                {
                    SolidFramework.Pdf.Plumbing.PdfPages nodePages =
                        (SolidFramework.Pdf.Plumbing.PdfPages)dictionary;
                    ProcessPages(ref nodePages, ref listPages);
                }
                else if (dictionary.Type == "Page")
                {
                    SolidFramework.Pdf.Plumbing.PdfPage page =
                        (SolidFramework.Pdf.Plumbing.PdfPage)dictionary;
                    listPages.Add(page);
                }
            }
        }







    }
}
