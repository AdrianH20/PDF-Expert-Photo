using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGtoPDF
{
    class PicturesPerPage
    {
        public string idPage { get; set; }
        public string numberPages { get; set; }
       
        public PicturesPerPage (string id, string numberPages)
        {
            this.idPage = id;
            this.numberPages = numberPages;
        }
        public override string ToString()
        {
            return numberPages;
        }
    }
}
