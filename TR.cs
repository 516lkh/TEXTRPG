using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    internal class TR
    {
        public static void Main()
        {

        }

    }

    public class TRGame
    {
        public static void GameStart()
        {
            while (true) 
            {
                

            }
        }

    }

    public interface IUserInterface
    {

    }

    public interface IItem
    {

    }

    public interface ICharacter
    {
        string Name { get; }
        int Health { get; set; }
        int Attack { get; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }

    public class NonPlayableCharacter : ICharacter
    { 
        public NonPlayableCharacter() 
        { 

        }
    }

    public class Player : ICharacter
    {
        public Player()
        {

        }
    }

    public class Monster: ICharacter
    {
        public Monster()
        {

        }
    }

}
