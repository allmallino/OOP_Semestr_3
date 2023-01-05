using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_OOP
{
    internal class PlayerWrongKeyException:Exception
    {
        public PlayerWrongKeyArgs args;
        public PlayerWrongKeyException(PlayerWrongKeyArgs args)
        {
            this.args = args;
        }
    }
    public class PlayerWrongKeyArgs
    {
        public ConsoleKey Key;
        private string Message;
        public PlayerWrongKeyArgs(ConsoleKey key)
        {
            this.Key = key;
            Message = $"Персонаж не знає такого руху. Ви натиснули на неправильну клавішу {Key}. Ходити на W,A,S,D.";
        }
        public PlayerWrongKeyArgs(string thing)
        {
            Message = $"Вибач, але там простяглися {thing}. Персонаж не може через них пройти.";
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
