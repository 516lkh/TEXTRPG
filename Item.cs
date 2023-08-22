using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public interface IItem
    {
        string name { get; }
        string toolTip { get; }
        int price { get; set; }

        void Use(ICharacter ch);
        void Remove(ICharacter ch);
    }
}
