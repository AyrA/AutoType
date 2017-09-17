using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AutoType
{
    public class Syntax
    {
        public struct ColorInstruction
        {
            public Color ForeColor
            { get; set; }
            public Regex Expression
            { get; set; }
            public ColorInstruction(Color c, Regex r)
            {
                ForeColor = c;
                Expression = r;
            }
        }

        public struct Settings
        {
            public List<ColorInstruction> Colors
            { get; set; }
            public string Language
            { get; set; }
            public string About
            { get; set; }
            public Settings(List<ColorInstruction> c, string l, string a)
            {
                Language = l;
                Colors = c;
                About = a;
            }
        }

        public Settings Configuration
        { get; private set; }

        public Syntax()
        {
            const string Hotkeys = @"[a-zA-Z0-9]|{|}|\(|\)|\[|\]|\+|\^|%|~|BACKSPACE|BSP?|BREAK|CAPSLOCK|DELETE|DEL|DOWN"+
                @"|END|ENTER|ESC|HELP|HOME|INSERT|INS|LEFT|NUMLOCK|PGDN|PGUP|RIGHT|SCROLLLOCK|TAB"+
                @"|UP|F[1-9]|F1[0-6]|ADD|SUBTRACT|MULTIPLY|DIVIDE";
            List<ColorInstruction> Keywords = new List<ColorInstruction>();

            //Modifiers with optional key group
            Keywords.Add(new ColorInstruction(Color.Yellow, new Regex(@"(\^|\+|%)+([^(]|\(.*?\))")));
            //single braces
            Keywords.Add(new ColorInstruction(Color.Fuchsia, new Regex(@"({|})")));
            //Invalid Sequences
            Keywords.Add(new ColorInstruction(Color.Red, new Regex(@"{.*?}")));
            //Hotkeys
            Keywords.Add(new ColorInstruction(Color.Cyan, new Regex(@"{(" + Hotkeys + @")}")));
            //Hotkeys with repetition
            Keywords.Add(new ColorInstruction(Color.Purple, new Regex(@"{(" + Hotkeys + @") \d*}")));

            Configuration = new Settings(Keywords, "SendKeys (internal)", "AyrA");
        }
    }
}
