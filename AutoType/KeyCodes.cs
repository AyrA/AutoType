//Key codes can be found at https://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.send(v=vs.110).aspx
using System.Collections.Generic;
using System.Linq;

namespace AutoType
{
    /// <summary>
    /// Provides access to special key codes sorted into groups
    /// </summary>
    public static class KeyCodes
    {
        /// <summary>
        /// Holds Key Groups
        /// </summary>
        private static Dictionary<string, Dictionary<string, string>> KeyGroups;

        /// <summary>
        /// Gets all Groups
        /// </summary>
        public static string[] Groups
        {
            get
            {
                return KeyGroups.Keys.ToArray();
            }
        }

        /// <summary>
        /// Initializes Key codes
        /// </summary>
        static KeyCodes()
        {
            KeyGroups = new Dictionary<string, Dictionary<string, string>>();
            AddGroup("&Modifiers", new string[] {
                "&Shift|+",
                "S&hift multiple|+(...)",
                "&Control|^",
                "C&ontrol multiple|^(...)",
                "&Alt|%",
                "A&lt multiple|%(...)"
            });

            AddGroup("&Text editing", new string[] {
                "&Tab|{TAB}",
                "&Backspace|{BS}",
                "&Delete|{DEL}",
                "&Insert|{INS}",
                "&Enter/Return|{ENTER}"
            });

            AddGroup("&Cursor positioning", new string[] {
                "&Up|{UP}",
                "&Down|{DOWN}",
                "&Left|{LEFT}",
                "&Right|{RIGHT}",
                "&Home|{HOME}",
                "&End|{END}",
                "Page U&p|{PGUP}",
                "Page D&own|{PGDN}"
            });

            AddGroup("&Number block",new string[] {
                "&Add (+)|{ADD}",
                "&Subtract (-)|{SUBTRACT}",
                "&Multiply (*)|{MULTIPLY}",
                "&Divide (/)|{DIVIDE}",

            });

            AddGroup("&F Keys", new string[] {
                "F&1|{F1}",
                "F&2|{F2}",
                "F&3|{F3}",
                "F&4|{F4}",
                "F&5|{F5}",
                "F&6|{F6}",
                "F&7|{F7}",
                "F&8|{F8}",
                "F&9|{F9}",
                "F1&0|{F10}",
                "F11|{F11}",
                "F12|{F12}",
                "F13|{F13}",
                "F14|{F14}",
                "F15|{F15}",
                "F16|{F16}"
            });

            AddGroup("Status &Keys", new string[] {
                "&Num lock|{NUMLOCK}",
                "&Caps lock|{CAPSLOCK}",
                "&Scroll lock|{SCROLLLOCK}"
            });

            AddGroup("&Special Symbols", new string[] {
                "&{|{{}",
                "&}|{}}",
                "&[|{[}",
                "&]|{]}",
                "&+|{+}",
                "&^|{^}",
                "&~|{~}",
                "&%|{%}",
                "&(|{(}",
                "&)|{)}"
            });

            AddGroup("Others", new string[] {
                "&Help|{HELP}"
            });
        }

        /// <summary>
        /// Adds a Group of keys
        /// </summary>
        /// <param name="key">Group</param>
        /// <param name="definitions">Key Definitions</param>
        private static void AddGroup(string key, string[] definitions)
        {
            var Dict = new Dictionary<string, string>();

            foreach (var s in definitions.Select(m => m.Split('|')))
            {
                Dict.Add(s[0], s[1]);
            }

            KeyGroups.Add(key, Dict);
        }

        /// <summary>
        /// Gets a Key Group
        /// </summary>
        /// <param name="Group">Group Name</param>
        /// <returns>KeyGroup or Null if not found</returns>
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
