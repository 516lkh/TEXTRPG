using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class Point
    {
        int x, y;
        char sym;

        public Point(int _x, int _y, char _sym)
        {
            x= _x;
            y= _y;
            sym = _sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public void DeepCopy(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

    }
}
