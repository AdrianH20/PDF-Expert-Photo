using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace JPEGtoPDF
{
    

    public partial class FormImageToPDF : Form
    {
        
        public string saveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        int imgNumber = 1;

        List<ImageSelection> listImages = new List<ImageSelection>();

        List<Format> formats = new List<Format>();
        Appearance appearance;

        public FormImageToPDF()
        {
            InitializeComponent();
           
            textBoxOutputPath.Text = saveLocation;
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            populateComboBox();
            
            imgNumber = int.Parse(comboBoxPages.SelectedItem.ToString());

        }

        void populateComboBox()
        {
            

            formats.Add(
            new Format()
            {
                id = "01",
                formatValue = "20x20 (cm)",
                numberFormats = new List<PicturesPerPage>
                    {
                        new PicturesPerPage("01","3"),
                        new PicturesPerPage("01","4")
                    }
            });

            formats.Add(
            new Format()
            {
                    id = "02",
                    formatValue = "21x30 (cm)",
                    numberFormats = new List<PicturesPerPage>
                    {
                        new PicturesPerPage("02","4"),
                        new PicturesPerPage("02","6")
                    }
            });

            formats.Add(
            new Format()
            {
                    id = "03",
                    formatValue = "21x15 (cm)",
                    numberFormats = new List<PicturesPerPage>
                     {
                        new PicturesPerPage("03","4")
                     }
            });

            
            comboBoxFormat.DataSource = formats;
            comboBoxFormat.ValueMember = "id";
            comboBoxFormat.DisplayMember = "formatValue";

            comboBoxPages.DataSource = comboBoxFormat.DataSource;


            
            comboBoxPages.DisplayMember = "numberFormats.numberPages";
            comboBoxFormat.SelectedIndex = 0;
            comboBoxAppearance.SelectedIndex = 0;
        }

        private void addFiles_Click(object sender, EventArgs e)
        {
            string[] pathToImages;
            string[] fileNames;
            ImageSelection currentImageSelection;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image file| " + " *.png; *.jpg; *.jpeg; *.jfif; *.bmp; *.tif; *.tiff; *.gif";
            
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToImages = openFileDialog.FileNames.ToArray();
                fileNames = openFileDialog.SafeFileNames.ToArray();


                for (int i = 0; i < fileNames.Length; i++)
                    if (checkingDuplicates(fileNames.ElementAt(i)))
                    {
                        currentImageSelection = new ImageSelection(fileNames.ElementAt(i), pathToImages.ElementAt(i));
                        Dimensions.getDim(ref currentImageSelection);
                        listImages.Add(currentImageSelection);
                        listBoxImageFile.Items.Add(listImages.Last());
                    }
                    else MessageBox.Show("An image with this name already exists. Please rename or choose another image !");
                labelNrImages.Text = "Images :      " + listImages.Count;
                labelFullPages.Text = "Full Pages : " + (listImages.Count / imgNumber).ToString();
            }

           

        }

        bool checkingDuplicates(string fileName)
        {
            foreach (ImageSelection image in listImages)
                if (image.ToString() == fileName) return false;

            return true;
        }

        private void removeSelected_Click(object sender, EventArgs e)
        {


            List<ImageSelection> imagesToDelete = new List<ImageSelection>();

            foreach (ImageSelection garbage in listBoxImageFile.SelectedItems)
                imagesToDelete.Add(garbage);

            foreach (ImageSelection imageToDelete in imagesToDelete)
            {
                listBoxImageFile.Items.Remove(imageToDelete);

                foreach (ImageSelection image in listImages)
                {
                    if (image.ToString() == imageToDelete.ToString())
                    {
                        listImages.Remove(image);
                        break;
                    }
                }
            }
            labelNrImages.Text = "Images :      " + listImages.Count;
            labelFullPages.Text = "Full Pages : " + (listImages.Count / imgNumber).ToString();
        }


        private void ButtonOutputPath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    textBoxOutputPath.Text = fbd.SelectedPath;
            }
        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            string pdfName ;
            PageSize pageSize =  new PageSize(567f, 567f);

            pdfName = textBoxPDFName.Text;
            if (!(textBoxPDFName.Text.EndsWith(".pdf"))) pdfName += ".pdf";
            
            AppearanceType appearanceType= AppearanceType.Portrait;

           
            string exportFile = Path.Combine(textBoxOutputPath.Text, pdfName);

            Format format = formats.ElementAt(0);
            
                
                switch (comboBoxPages.Text)
                {
                    case "3": imgNumber = 3;  break;
                    case "4": imgNumber = 4;  break;
                    case "6": imgNumber = 6;  break;
                }
                
                switch(comboBoxAppearance.Text)
                {
                    case "Portrait": appearanceType = AppearanceType.Portrait;      break;
                    case "Landscape": appearanceType = AppearanceType.Landscape;    break;
                    case "Magic Appearance": appearanceType = AppearanceType.Magic; break;
                }

            switch (comboBoxFormat.Text)
            {
                case "20x20 (cm)": 
                    pageSize = new PageSize(583.999f, 583.999f);
                    format = formats.ElementAt(0);
                    appearance = new Appearance(appearanceType, formats.ElementAt(0), imgNumber); break;
                case "21x30 (cm)": 
                    pageSize = new PageSize(611.999f, 867.666f);
                    format = formats.ElementAt(1);
                    appearance = new Appearance(appearanceType, formats.ElementAt(1), imgNumber); break;
                case "21x15 (cm)": 
                    pageSize = new PageSize(611.999f, 441.999f);
                    format = formats.ElementAt(2);
                    appearance = new Appearance(appearanceType, formats.ElementAt(2), imgNumber); break;
            }

            if(checkBoxAppearance.Checked) PDFMaker.createDocument(listImages, appearance, pageSize, exportFile, format);
            else  PDFMaker.createDocument(listImages, appearance, pageSize, exportFile, format,true);


            List<ImageSelection> imagesToDelete = new List<ImageSelection>();

            foreach (ImageSelection garbage in listBoxImageFile.Items)
                imagesToDelete.Add(garbage);

            foreach (ImageSelection imageToDelete in imagesToDelete)
            {
                listBoxImageFile.Items.Remove(imageToDelete);

                foreach (ImageSelection image in listImages)
                {
                    if (image.ToString() == imageToDelete.ToString())
                    {
                        listImages.Remove(image);
                        break;
                    }
                }
            }
            labelNrImages.Text = "Images :      " + listImages.Count;
            labelFullPages.Text = "Full Pages : " + (listImages.Count / imgNumber).ToString();
            PDFMaker.setOrientation = false;
           

        }
        

        private void listBoxImageFile_MouseClick(object sender, MouseEventArgs e)
        {
            int count = 0;

            foreach (ImageSelection img in listBoxImageFile.SelectedItems) count++;
            if (count == 1)
            {
                foreach (ImageSelection img in listImages)
                    if (img.ToString() == listBoxImageFile.SelectedItem.ToString())
                    {
                        System.Drawing.Image imgPreview = System.Drawing.Image.FromFile(img.getPath());
                        OrientationChecking.rotateCheckingPreview(ref imgPreview, img.getPath());
                        pictureBoxPreview.Image = imgPreview; break;
                    }
            }

            else { pictureBoxPreview.Image = null; }
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAppearance.SelectedItem = "Landscape";
            if ((comboBoxFormat.Text == "21x30 (cm)" || comboBoxFormat.Text == "21x15 (cm)"))
                if (!comboBoxAppearance.Items.Contains("Magic Appearance")) comboBoxAppearance.Items.Add("Magic Appearance");
                else return;
            else comboBoxAppearance.Items.Remove("Magic Appearance");
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formatInformation formatInformation = new formatInformation();
            formatInformation.TopMost = true;
            formatInformation.Show();
        }

        private void comboBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPages.Text)
            {
                case "3": imgNumber = 3; break;
                case "4": imgNumber = 4; break;
                case "6": imgNumber = 6; break;
            }

            labelFullPages.Text = "Full Pages : " + (listImages.Count /imgNumber ).ToString();
        }

        private void removeAll_btn_Click(object sender, EventArgs e)
        {
            List<ImageSelection> imagesToDelete = new List<ImageSelection>();

            foreach (ImageSelection garbage in listBoxImageFile.Items)
                imagesToDelete.Add(garbage);

            foreach (ImageSelection imageToDelete in imagesToDelete)
            {
                listBoxImageFile.Items.Remove(imageToDelete);

                foreach (ImageSelection image in listImages)
                {
                    if (image.ToString() == imageToDelete.ToString())
                    {
                        listImages.Remove(image);
                        break;
                    }
                }
            }
            labelNrImages.Text = "Images :      " + listImages.Count;
            labelFullPages.Text = "Full Pages : " + (listImages.Count / imgNumber).ToString();
            PDFMaker.setOrientation = false;
        }

        private void checkBoxAppearance_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAppearance.Visible = (checkBoxAppearance.Checked) ? true : false;
        }
    }
    }

