using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Management;
using Windows.Graphics.Display;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;


namespace Screen_Brightness_Adjuster
{
    public sealed class BrightnessOverride
    {
        private static int a;
        private static int espInput;

        public int Algorithm1(int i)
        {
            return a = 100 - (i / 4000) * 100;
        }


    }



}
