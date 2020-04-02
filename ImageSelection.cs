using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGtoPDF
{
    class ImageSelection
    {


        private string name { get; set; }
        private string path;

        public  string format;
        private float width;
        private float height;
        
      
        public ImageSelection (string name, string path)
        {
            this.name = name;
            this.path = path;
            

        }

        public override string ToString()
        {
            return name;
        }

        public string getPath()
        {
            return path;
        }

        public void  setWidth(float width)
        {
            this.width = width;

        }

        public void setHeight(float height)
        {
            this.height = height;

        }

        public float getWidth()
        {
            return width;
        }

        public float getHeight()
        {
            return height;
        }
    }
}
