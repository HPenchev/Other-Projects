using System;
using System.Drawing;

class CrayschaleConverter
{
    static void Main()
    {
        string filePaht = @"cats.jpg";
        Bitmap image = new Bitmap(filePaht);
        Bitmap newImage = ConvertToGreyscale(image);
        newImage.Save("catsGray.jpg");
    }

    public static Bitmap ConvertToGreyscale(Bitmap original)
    {        
        Bitmap newBitmap = new Bitmap(original.Width, original.Height);

        for (int i = 0; i < original.Width; i++)
        {
            for (int j = 0; j < original.Height; j++)
            {                
                Color originalColor = original.GetPixel(i, j);
                               
                int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59) + (originalColor.B * .11));

                Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);

                newBitmap.SetPixel(i, j, newColor);
            }
        }

        return newBitmap;
    }
}

