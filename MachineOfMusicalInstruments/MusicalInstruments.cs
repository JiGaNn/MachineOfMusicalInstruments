using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineOfMusicalInstruments
{
    public enum MusInstType { acoustic, electronic }
    abstract public class MusInst
    {
        public MusInstType type;
        public virtual String GetInfo()
        {
            String str = String.Format("\nТип: {0}", type);
            return str;
        }
    }
    public class Guitar : MusInst
    {
        public int amountOfString;// от 4 до 12
        public string builds;// много строев
        public override string GetInfo()
        {
            var str = "Струнный инструмент";
            str += base.GetInfo();
            str += String.Format("\nКоличество струн: {0}\nСтрой: {1}", amountOfString, builds);
            return str;
        }
    }
    public class Piano : MusInst
    {
        public int amountOfKeys;// 49, 61, 88 (от 32 до 88)
        public int amountOfFullOctaves;// 4, 5, 7 октав
        public override string GetInfo()
        {
            var str = "Клавишный инструмент";
            str += base.GetInfo();
            str += String.Format("\nКоличество клавиш: {0}\nКоличество полных октав: {1}", amountOfKeys, amountOfFullOctaves);
            return str;
        }
    }
    public enum DrumType { big, small, timpani, tom }
    public class Drum : MusInst
    {
        public int radius;// 4 - 12 дюймов
        public DrumType typeOfDrum;
        public override string GetInfo()
        {
            var str = "Барабан";
            str += base.GetInfo();
            str += String.Format("\nРадиус: {0}\nТип барабана: {1}", radius, typeOfDrum);
            return str;
        }
    }
}