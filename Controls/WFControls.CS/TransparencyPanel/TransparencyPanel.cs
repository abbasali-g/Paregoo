using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class TransparencyPanel : DrawingArea
{
    protected override void OnDraw()
    {
        // Gets the image from the global resources
       // Image broculoImage = global::WFControls.Properties.Resources.broculo;

        Image broculoImage = global::WFControls.CS.Properties.Resources.Tree;
        
        // Sets the images' sizes and positions
        int width = broculoImage.Size.Width;
        int height = broculoImage.Size.Height;
        Rectangle big = new Rectangle(0, 0, width, height);
      //  Rectangle small = new Rectangle(50, 50, (int)(0.75 * width), (int)(0.75 * height));

        // Draws the two images
        this.graphics.DrawImage(broculoImage, big);
       // this.graphics.DrawImage(broculoImage, small);

        // Sets the text's font and style and draws it
      //  float fontSize = 8.25f;
      //  Point textPosition = new Point(50, 100);
      //  DrawText("http://www.broculos.net", "Microsoft Sans Serif", fontSize
     //       , FontStyle.Underline, Brushes.Blue, textPosition);
    }
}
