using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.Core
{
    public class MenuOption
    {
        public string Label { get; set; }
        public string Action { get; set; }
        public string TargetMenu { get; set; }

        public MenuOption(string label, string action, string targetMenu)
        {
            Label = label;
            Action = action;
            TargetMenu = targetMenu;
        }

    }
}
