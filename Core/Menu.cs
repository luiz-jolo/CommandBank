using System;

namespace CommandBank.Core
{
    public class Menu
    {
        public string Title { get; set; }
        public List<MenuOption> MenuOptions {  get; set; }
        public string Parent { get; set; }
    }
}
