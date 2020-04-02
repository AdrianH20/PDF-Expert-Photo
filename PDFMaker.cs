using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;


using System.Windows.Forms;

using iText.Layout;
using iText.Layout.Element;
using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using UnitValue = iText.Layout.Properties.UnitValue;

using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;
using VerticalAlignment = iText.Layout.Properties.VerticalAlignment;
using NUnit.Framework;
using iTextSharp.text.pdf;
using iText.Kernel.Colors;
using iText.Layout.Renderer;
using iText.Layout.Layout;
using MetadataExtractor.Util;
using MetadataExtractor.Formats;
using MetadataExtractor.IO;
using Org.BouncyCastle.Asn1.Cms;
using NPOI.Util;
using MetadataExtractor.Formats.Exif;

namespace JPEGtoPDF
{ 


    class PDFMaker
    {
        public static bool setOrientation = false;
        public static void createDocument(List<ImageSelection> listImages, Appearance appearance, PageSize pageSize, string exportFile, Format format)
        {

            checkSameDocuments(ref exportFile);

            using (PdfWriter writer = new PdfWriter(exportFile))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document pdoc = new Document(pdf, pageSize);
                    pdoc.SetMargins(8.5f, 8.5f, 8.5f, 8.5f);
                    Appearance coverAppearance = new Appearance(appearance.getAppearanceType(), format, 1);

                    Table table = tableStyle(coverAppearance, pageSize, pdoc);
                    table = tableStyle(coverAppearance, pageSize, pdoc);
                    Image imgc = null;
                    try
                    {
                         imgc = new Image(iText.IO.Image.ImageDataFactory.Create(listImages.ElementAt(0).getPath()));
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                        MessageBox.Show("There's no image selected !", "",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pdoc = null;
                        //pdf = null;
                        pdf.AddNewPage();
                        pdf.Close();
                        writer.Close();
                        File.Delete(exportFile);
                        
                        return;
                    }
                        
                    imgStyle(ref imgc, listImages.ElementAt(0));

                    table.GetCell(0, 0).Add(imgc);
                    pdoc.Add(table);



                    table = tableStyle(appearance, pageSize, pdoc);
                    pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));

                    for (int k = 1, i = 0, j = 0; k < listImages.Count - 1; k++, j++)
                    {
                        if (j == appearance.getDimensions().Length)
                        { j = 0; i++; }
                        if (i == appearance.getHeightRatio())
                        {
                            pdoc.Add(table);
                            table = tableStyle(appearance, pageSize, pdoc);

                            pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
                            j = i = 0;
                        }

                        Image img = new Image(iText.IO.Image.ImageDataFactory.Create(listImages.ElementAt(k).getPath()));

                        imgStyle(ref img, listImages.ElementAt(k));
                        Console.WriteLine(listImages.ElementAt(k).format);


                        table.GetCell(i, j).Add(img);



                    }
                    pdoc.Add(table);

                    pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));


                    table = tableStyle(coverAppearance, pageSize, pdoc);
                    imgc = new Image(iText.IO.Image.ImageDataFactory.Create(listImages.ElementAt(listImages.Count - 1).getPath()));
                    imgStyle(ref imgc, listImages.ElementAt(listImages.Count - 1));
                    table.GetCell(0, 0).Add(imgc);
                    pdoc.Add(table);


                    pdoc.Close();

                }
            }


        }
        public static void createDocument(List<ImageSelection> listImages, Appearance appearance, PageSize pageSize, string exportFile, Format format, bool value)
        {

            checkSameDocuments(ref exportFile);

            Console.WriteLine();
            using (PdfWriter writer = new PdfWriter(exportFile))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document pdoc = new Document(pdf, pageSize);
                    pdoc.SetMargins(0f, 0f, 0f, 0f);
                    Appearance coverAppearance = new Appearance(appearance.getAppearanceType(), format, 1);
                    Appearance currentAppearance;


                    
                    List<ImageSelection> currentImgsList = new List<ImageSelection>();
                    List<Image> imgs = new List<Image>();
                    List<Image> currentImgs = new List<Image>();
                    
                    for (int i = 0; i < listImages.Count; i++)
                    {
                       
                        imgs.Add(new Image(iText.IO.Image.ImageDataFactory.Create(listImages.ElementAt(i).getPath())));
                        imgs.ElementAt(i).SetHorizontalAlignment(HorizontalAlignment.CENTER);
                        imgs.ElementAt(i).SetAutoScale(true);
                        

                        imgStyle(imgs.ElementAt(i), listImages.ElementAt(i)) ;
                        
                    }
                    setOrientation = true;


                    /// First page
                    Table table = null;
                    try
                    {
                        imgs.ElementAt(0).SetAutoScale(true);
                        
                        table = tableStyle(coverAppearance, pageSize, pdoc);
                        

                        table.GetCell(0, 0).SetMargins(0f, 0f, 0f, 0f);
                        table.GetCell(0,0).SetPaddings(0f, 0f, 0f, 0f);


                        table.SetMargins(0f, 0f, 0f, 0f);
                        table.SetPaddings( 0f, 0f, 0f, 0f);
                        //table.GetCell(0, 0).SetBorder(BorderStyle.FixedSingle);
                        table.GetCell(0, 0).SetVerticalAlignment(VerticalAlignment.MIDDLE);
                        table.GetCell(0, 0).Add(imgs.ElementAt(0));

                        pdoc.Add(table);
                        
                        if (imgs.Count >2) pdoc.SetMargins(8.5f, 8.5f, 8.5f, 8.5f);
                        pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        MessageBox.Show("There's no image selected !", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pdoc = null;
                        //pdf = null;
                        pdf.AddNewPage();
                        pdf.Close();
                        writer.Close();
                        File.Delete(exportFile);

                        return;
                    }


                    

                    for (int k = 1, p = 0; k < listImages.Count - 1; k++)
                    {
                        
                        currentImgsList.Add(listImages.ElementAt(k));
                        currentImgs.Add(imgs.ElementAt(k));
                        if (k % appearance.getImgNumber() == 0)
                        {

                            currentAppearance = new Appearance(appearance.getAppearanceType(),format, appearance.getImgNumber(), getLandscape(currentImgsList), getPortrait(currentImgsList));
                            Console.WriteLine(currentAppearance.specialCond);
                            switch(currentAppearance.specialCond)
                            {
                                case "21x15_4P0L": table = Custom.customTable1(currentAppearance, pageSize, pdoc,currentImgsList,currentImgs);break;
                                case "21x15_3P1L": table = Custom.customTable2(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x15_2P2L": table = Custom.customTable3(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x15_1P3L": table = Custom.customTable3(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x15_0P4L": table = Custom.customTable3(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;


                                case "20x20_1P2L": table = Custom.customTable4(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "20x20_2P1L": table = Custom.customTable5(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "20x20_0P3L": table = Custom.customTable6(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "20x20_3P0L": table = Custom.customTable7(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;

                                case "20x20_4_1P3L": table = Custom.customTable8(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "20x20_4_2P2L": table = Custom.customTable9(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "20x20_4_0P4L": table = Custom.customTable10(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "20x20_4_3P1L": table = Custom.customTable11(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "20x20_4_4P0L": table = Custom.customTable12(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;


                                case "21x30_4_1P3L": table = Custom.customTable13(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_4_2P2L": table = Custom.customTable14(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_4_3P1L": table = Custom.customTable15(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_4_0P4L": table = Custom.customTable16(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_4_4P0L": table = Custom.customTable17(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;

                                case "21x30_6_5P1L": table = Custom.customTable18(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_6_1P5L": table = Custom.customTable19(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_6_2P4L": table = Custom.customTable20(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_6_3P3L": table = Custom.customTable21(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_6_4P2L": table = Custom.customTable22(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_6_0P6L": table = Custom.customTable23(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;
                                case "21x30_6_6P0L": table = Custom.customTable24(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs); break;

                            }
                            Console.WriteLine("Portraits: "+getPortrait(currentImgsList)+"Landscapes: "+ getLandscape(currentImgsList));
                            currentImgsList.Clear();
                            currentImgs.Clear();
                           
                           
                            
                            p++;
                            if(((listImages.Count-2)/appearance.getImgNumber()==p)&& ((listImages.Count - 2)% appearance.getImgNumber() == 0))  pdoc.SetMargins(0f, 0f, 0f, 0f);

                            pdoc.Add(table);
                            pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
                            
                        }
                        


                    }
                    if (currentImgsList.Count >0)
                    {
                        currentAppearance = new Appearance("reminder",appearance.getImgNumber());
                        table = Custom.customTable3(currentAppearance, pageSize, pdoc, currentImgsList, currentImgs);
                        currentImgsList.Clear();
                        currentImgs.Clear();

                        pdoc.Add(table);

                        pdoc.SetMargins(0f, 0f, 0f, 0f);
                        pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
                    }
                    

                    imgs.ElementAt(imgs.Count-1).SetAutoScale(true);
                    

                    table = tableStyle(coverAppearance, pageSize, pdoc);


                    table.GetCell(0, 0).SetMargins(0f, 0f, 0f, 0f);
                    table.GetCell(0, 0).SetPaddings(0f, 0f, 0f, 0f);


                    table.SetMargins(0f, 0f, 0f, 0f);
                    table.SetPaddings(0f, 0f, 0f, 0f);
                    //table.GetCell(0, 0).SetBorder(BorderStyle.FixedSingle);
                    table.GetCell(0, 0).SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    table.GetCell(0, 0).Add(imgs.ElementAt(imgs.Count-1));

                    pdoc.Add(table);


                    pdoc.Close();


                }
            }


        }


        static void cellStyle(ref Cell cell)
        {

            cell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);

        }
        static void imgStyle(ref Image img, ImageSelection image)
        {

            var directories = MetadataExtractor.ImageMetadataReader.ReadMetadata(image.getPath());
            


            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                {

                    if (tag.Name == "Orientation" && directory.Name == "Exif IFD0")
                    {

                        OrientationChecking.rotateChecking(ref img, tag.Description, ref image, setOrientation);
                        break;
                    }
                }
                if (directory.HasError)
                {
                    foreach (var error in directory.Errors)
                        Console.WriteLine($"ERROR: {error}");
                }
            }



            img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            img.SetAutoScale(true);

        }
        static void imgStyle(  Image img, ImageSelection image)
        {

            var directories = MetadataExtractor.ImageMetadataReader.ReadMetadata(image.getPath());
           

            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                {

                    if (tag.Name == "Orientation" && directory.Name == "Exif IFD0")
                    {

                        OrientationChecking.rotateChecking(ref img, tag.Description, ref image,setOrientation);
                        break;
                    }
                }
                if (directory.HasError)
                {
                    foreach (var error in directory.Errors)
                        Console.WriteLine($"ERROR: {error}");
                }
            }



            //img.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            //img.SetAutoScale(true);

        }

        static Table tableStyle(Appearance appearance, PageSize pageSize, Document pdoc)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            table.UseAllAvailableWidth().SetDocument(pdoc);

            if(appearance.getImgNumber() == 1) table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight()));
            else table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));

            for (int i = 0; i < appearance.getHeightRatio() + 1; i++)
            {
                for (int j = 0; j < appearance.getDimensions().Length; j++)
                {
                    Cell cell = new Cell();
                    if (appearance.getImgNumber() == 1) cell.SetHeight(table.GetHeight().GetValue() / appearance.getHeightRatio());
                    else cell.SetHeight(table.GetHeight().GetValue() / appearance.getHeightRatio() - 4.666f);

                    cellStyle(ref cell);
                    table.AddCell(cell);

                }
            }

            return table;
        }


        static void checkSameDocuments(ref string exportFile)
        {
            int countFiles = 0;
            while (File.Exists(exportFile.Substring(0, exportFile.Length - 4) + ((countFiles > 0) ? "(" + (countFiles + 1).ToString() + ")" : "") + ".pdf")) countFiles++;
            exportFile = exportFile.Substring(0, exportFile.Length - 4) + ((countFiles > 0) ? "(" + (countFiles + 1).ToString() + ")" : "") + ".pdf";
        }


        private static int getLandscape(List<ImageSelection> list)
        {
            int count = 0;

            for (int i = 0; i < list.Count; i++) if (list.ElementAt(i).format == "landscape") count++;

           
            return count;
        }
        private static int getPortrait(List<ImageSelection> list)
        {
            int count = 0;

            for (int i = 0; i < list.Count; i++) if (list.ElementAt(i).format == "portrait") count++;

            
            return count;
        }


        
    }
}

