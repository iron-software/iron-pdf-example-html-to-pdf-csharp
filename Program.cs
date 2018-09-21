using System;
using System.IO;
using IronPdf;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hold on tight!");

        Example1();
        Example2();

        Console.WriteLine("Done. Please find results under '{0}' directory.", Directory.GetCurrentDirectory());
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public static void Example1()
    {
        // read html from file
        var html = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestInvoice1.html"));

        var htmlToPdf = new HtmlToPdf();
        var pdf = htmlToPdf.RenderHtmlAsPdf(html);
        pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "HtmlToPdfExample1.Pdf"));
    }

    public static void Example2()
    {
        var html = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestInvoice1.html"));

        var pdfPrintOptions = new PdfPrintOptions()
        {
            MarginTop = 50,
            MarginBottom = 50,
            Header = new SimpleHeaderFooter()
            {
                CenterText = "{pdf-title}",
                DrawDividerLine = true,
                FontSize = 16
            },
            Footer = new SimpleHeaderFooter()
            {
                LeftText = "{date} {time}",
                RightText = "Page {page} of {total-pages}",
                DrawDividerLine = true,
                FontSize = 14
            },
            CssMediaType = PdfPrintOptions.PdfCssMediaType.Print
        };

        var htmlToPdf = new HtmlToPdf(pdfPrintOptions);
        var pdf = htmlToPdf.RenderHtmlAsPdf(html);
        pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "HtmlToPdfExample2.Pdf"));
    }
}