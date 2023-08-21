using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TEXTRPG
{
    public interface ICharacter
    {
        string name { get; }
        int health { get; set; }
        int attack { get; set; }
        bool isDead { get; }

        void TakeDamage(int damage);
    }


    public class NonPlayableCharacter : ICharacter
    {
        public string name { get; }
        public int health { get; set; }
        public int attack { get; set; }
        public bool isDead { get; }
        public List<Item> items;

        public void TakeDamage(int damage)
        {

        }

        public NonPlayableCharacter(string _name)
        {
            name = _name;
        }
    }

    public class PlayerCharacter : ICharacter
    {
        public string name { get; }
        public int health { get; set; }
        public int attack { get; set; }
        public bool isDead { get; }

        public void TakeDamage(int damage)
        {

        }
        public PlayerCharacter()
        {
            name = _name;
        }
    }

    public class Monster : ICharacter
    {
        public string name { get; }
        public int health { get; set; }
        public int attack { get; set; }
        public bool isDead { get; }

        public void TakeDamage(int damage)
        {

        }

        public Monster()
        {
            name = _name;
        }
    }
}
