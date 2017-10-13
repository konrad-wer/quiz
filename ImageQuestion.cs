using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Quiz
{
    class ImageQuestion : Question , IDisposable
    {
        Bitmap image;
        public ImageQuestion(string question, string a, string b, string c, string d, int rightAnswer, Bitmap image)
            : base(question, a, b, c, d, rightAnswer)
        {
            this.image = image;
        }

        public Bitmap Image
        {
            get { return image; }
        }

        public void Dispose()
        {
            image.Dispose();
        }
    }
}