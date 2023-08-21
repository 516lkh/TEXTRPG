using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{

    public interface IUserInterface
    {
        char sym { get; }
        int horizontal { get; set; }
        int vertical { get; set; }

        public void Draw();
        public void Clear();
    }

    public class Background: IUserInterface
    {
        public char sym { get; set; }
        public int horizontal { get; set; }
        public int vertical { get; set; }


        public void Draw()
        {

        }


        public void Clear()
        {

        }
    }

    public class MainInterface : IUserInterface
    {
        public char sym { get; }
        public int horizontal { get; set; }
        public int vertical { get; set; }

        MainInterface()
        {

        }

        public void Draw()
        {

        }

        public void Clear()
        {

        }
    }
}
