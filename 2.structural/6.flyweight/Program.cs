using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Flyweight
{
        public class Program
    {
        public static void Main(string[] args)
        {
            string document = "AagGBbGBaaBBgGabG";
            char[] chars = document.ToCharArray();

            CharacterFactory factory = new CharacterFactory();
            
            CharacterDrawProperties props = new CharacterDrawProperties(10, 50);

            foreach (char c in chars)
            {
                Character character = factory.GetCharacter(c);
                character.Display(props);
            }
        }
    }
    
    public class CharacterFactory
    {
        private Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            Character character = null;
            if (characters.ContainsKey(key))
            {
                character = characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A': character = new CharacterA(); break;
                    case 'B': character = new CharacterB(); break;
                    case 'G': character = new CharacterG(); break;
                    case 'a': character = new CharacterLowerA(); break;
                    case 'b': character = new CharacterLowerB(); break;
                    case 'g': character = new CharacterLowerG(); break;
                }
                characters.Add(key, character);
            }
            return character;
        }
    }
    
    public class CharacterDrawProperties
    {
        public int Width;
        public int Height;

        public CharacterDrawProperties(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }
    }

    public abstract class Character
    {
        public char Symbol;
        public bool IsAscented;
        public bool IsDescented;

        public void Display(CharacterDrawProperties props)
        {
            CharacterDrawer.Draw(this, props);
        }
    }

    public class CharacterDrawer
    {
        public static void Draw(Character c, CharacterDrawProperties props)
        {
            string verticalAlignment = c.IsAscented ? "ascented" : (c.IsDescented ? "descent" : "none");
            Console.WriteLine("Display '" + c.Symbol 
                + "' with width: " + props.Width + ", height: " 
                + props.Height + " and vertical alignment: " + verticalAlignment
            );
        }
    }
    
    public class CharacterA : Character
    {
        public CharacterA()
        {
            Symbol = 'A';
            IsAscented = true;
            IsDescented = false;
        }
    }

    public class CharacterLowerA : Character
    {
        public CharacterLowerA()
        {
            Symbol = 'a';
            IsAscented = false;
            IsDescented = false;
        }
    }
    
    public class CharacterB : Character
    {
        public CharacterB()
        {
            Symbol = 'B';
            IsAscented = true;
            IsDescented = false;
        }
    }

    public class CharacterLowerB : Character
    {
        public CharacterLowerB()
        {
            Symbol = 'b';
            IsAscented = true;
            IsDescented = false;
        }
    }
    
    public class CharacterG : Character
    {
        public CharacterG()
        {
            Symbol = 'G';
            IsAscented = true;
            IsDescented = false;
        }
    }

    public class CharacterLowerG : Character
    {
        public CharacterLowerG()
        {
            Symbol = 'g';
            IsAscented = false;
            IsDescented = true;
        }
    }
}