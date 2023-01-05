using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_5_1
{
    internal class TextEditor
    {
        private IAction action;
        public string adress;
        public void Save(string text)
        {
            StreamWriter sw = new StreamWriter(adress);
            sw.Write(action.execute(text));
            sw.Close();
        }
        public TextEditor(string adress)
        {
            this.adress = adress;
            action = new PlainText();
        }
        public void setAction(IAction action)
        {
            this.action = action;
        }
    }
}
