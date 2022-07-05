namespace _1.ClassBoxData
{
    using System;
    using System.Text;
    public class Box
    {

        public Box(double lenght,double width,double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        private double lenght;
        private double width;
        private double height;

        private const string ArgException = "{0} cannot be zero or negative.";

        public double Lenght 
        {
           get 
            {
                return this.lenght;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ArgException, nameof(this.Lenght)));
                }
                this.lenght = value;
            }
          
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ArgException, nameof(this.Width)));
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ArgException, nameof(this.Height)));
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return (2*Lenght*Width)+(2*Lenght*Height)+(2*Width*Height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * Lenght * Height) + (2 * Width * Height);
        }

        public double Volume()
        {
            return Lenght*Width*Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {SurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {Volume():F2}");
            return sb.ToString().Trim();
        }
    }
}
