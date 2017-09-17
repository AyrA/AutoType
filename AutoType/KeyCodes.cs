using System.Collections.Generic;
using System.Linq;

namespace AutoType
{
    public static class KeyCodes
    {
        private static Dictionary<string, Dictionary<string, string>> KeyGroups;

        public static string[] Groups
        {
            get
            {
                return KeyGroups.Keys.ToArray();
            }
        }

        static KeyCodes()
        {
            KeyGroups = new Dictionary<string, Dictionary<string, string>>();
            AddGroup("Modifiers", new string[] {
                "Shift|+",
                "Shift multiple|+(...)",
                "Control|^",
                "Control multiple|^(...)",
                "Alt|%",
                "Alt multiple|%(...)"
            });

            AddGroup("Text editing", new string[] {
                "Tab|{TAB}",
                "Backspace|{BS}",
                "Delete|{DEL}",
                "Insert|{INS}",
                "Enter/Return|{ENTER}"
            });

            AddGroup("Cursor positioning", new string[] {
                "Up|{UP}",
                "Down|{DOWN}",
                "Left|{LEFT}",
                "Right|{RIGHT}",
                "Home|{HOME}",
                "End|{END}",
                "Page Up|{PGUP}",
                "Page Down|{PGDN}"
            });

            AddGroup("Number block",new string[] {
                "Add (+)|{ADD}",
                "Subtract (-)|{SUBTRACT}",
                "Multiply (*)|{MULTIPLY}",
                "Divide (/)|{DIVIDE}",

            });

            AddGroup("F Keys", new string[] {
                "F1|{F1}",
                "F2|{F2}",
                "F3|{F3}",
                "F4|{F4}",
                "F5|{F5}",
                "F6|{F6}",
                "F7|{F7}",
                "F8|{F8}",
                "F9|{F9}",
                "F10|{F10}",
                "F11|{F11}",
                "F12|{F12}",
                "F13|{F13}",
                "F14|{F14}",
                "F15|{F15}",
                "F16|{F16}"
            });

            AddGroup("Status Keys", new string[] {
                "Num lock|{NUMLOCK}",
                "Caps lock|{CAPSLOCK}",
                "Scroll lock|{SCROLLLOCK}"
            });

            AddGroup("Special Symbols", new string[] {
                "{|{{}",
                "}|{}}",
                "[|{[}",
                "]|{]}",
                "+|{+}",
                "^|{^}",
                "~|{~}",
                "%|{%}",
                "(|{(}",
                ")|{)}"
            });

            AddGroup("Others", new string[] {
                "Help|{HELP}"
            });
        }

        private static void AddGroup(string key, string[] definitions)
        {
            var Dict = new Dictionary<string, string>();

            foreach (var s in definitions.Select(m => m.Split('|')))
            {
                Dict.Add(s[0], s[1]);
            }

            KeyGroups.Add(key, Dict);
        }

        public static Dictionary<string, string> GetKeys(string Group)
        {
            if (KeyGroups.ContainsKey(Group))
            {
                return KeyGroups[Group];
            }
            return null;
        }
    }
}
