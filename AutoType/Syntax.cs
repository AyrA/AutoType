using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AutoType
{
    /// <summary>
    /// Provides Syntax Highlighting
    /// </summary>
    public class Syntax
    {
        /// <summary>
        /// Colors an Instruction
        /// </summary>
        public struct ColorInstruction
        {
            /// <summary>
            /// Foregroud Color
            /// </summary>
            public Color ForeColor
            { get; set; }
            /// <summary>
            /// Regular expression to match String Against
            /// </summary>
            public Regex Expression
            { get; set; }

            /// <summary>
            /// Initializes a new Instruction Color
            /// </summary>
            /// <param name="c">Color</param>
            /// <param name="r">Instruction Pattern</param>
            public ColorInstruction(Color c, Regex r)
            {
                ForeColor = c;
                Expression = r;
            }
        }

        /// <summary>
        /// Holds Instruction Settings
        /// </summary>
        public struct Settings
        {
            /// <summary>
            /// Settings
            /// </summary>
            public List<ColorInstruction> Colors
            { get; set; }
            /// <summary>
            /// name of Language
            /// </summary>
            public string Language
            { get; set; }
            /// <summary>
            /// Informative Text
            /// </summary>
            public string About
            { get; set; }
            /// <summary>
            /// Initializes the Instruction set
            /// </summary>
            /// <param name="c">Instruction set</param>
            /// <param name="l">Language name</param>
            /// <param name="a">Informative Text</param>
            public Settings(List<ColorInstruction> c, string l, string a)
            {
                Language = l;
                Colors = c;
                About = a;
            }
        }

        /// <summary>
        /// Gets the current Language Configuration
        /// </summary>
        public Settings Configuration
        { get; private set; }

        /// <summary>
        /// Initializes the default Language
        /// </summary>
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
