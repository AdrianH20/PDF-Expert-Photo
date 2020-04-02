using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JPEGtoPDF
{
     class Format
    {
        public string id { get; set; }
        public string formatValue { get; set; }

        public List<PicturesPerPage> numberFormats { get; set; }

    }
}
