using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fusee.Tutorial.Core
{
    public static class Player
    {
        private static int money = 1000;
        private static int villageHealth = 100;

        private static bool gameOver = false;

        public static int Money { get { return money; } set { money = value; } }
        public static int VillageHealth { get { return villageHealth; } set {
            villageHealth = value;
            if(villageHealth <= 0)
                {
                    if (!gameOver)
                    {
                        gameOver = true;
                        MessageBox.Show("You lose! Please exit the application and restart it to play again.", "GAME OVER!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Tutorial.ListWuggys.Clear();
                    }
                }
            } }

    }
}
