using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.Core
{
    public class NavigationController
    {

        List<MenuOption> submenus;
        
        MenuOption menuUm = new MenuOption("Inicio", "Ação 1", "Menu 2");
        MenuOption menuDois = new MenuOption("Menu 2", "Ação 2", "Menu Sair");
        MenuOption menuSair = new MenuOption("Menu Sair", "Ação 3", "Menu 1");

    }
}
