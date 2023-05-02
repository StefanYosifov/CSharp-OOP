using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int height,int width)
        {
            this.Height = height;
            this.Widht = width;
        }
        public int Widht { get; private set; }

        public int Height { get; private set; }

        public void Draw(int height,int width)
        {
            Console.WriteLine(new String('*',this.Widht*2));
            for(int i = 0; i < this.Height; i++)
            {
                Console.WriteLine("*"+ new string(' ',this.Widht*2)+"*");
            }
            Console.WriteLine(new string('*',this.Widht));
        }
    }
}
