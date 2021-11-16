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
        public static Random rnd = new Random();
        public MusInstType type;
        public virtual String GetInfo()
        {
            String str = String.Format("\nТип: {0}", type);
            return str;
        }
    }
    public enum BuildType { standard, drop, open, drone }
    public class Guitar : MusInst
    {
        public int amountOfString;// от 4 до 12
        public BuildType builds;// много строев
        public override string GetInfo()
        {
            var str = "Струнный инструмент";
            str += base.GetInfo();
            str += String.Format("\nКоличество струн: {0}\nСтрой: {1}", amountOfString, builds);
            return str;
        }
        public static Guitar Generate()
        {
            return new Guitar()
            {
                type = (MusInstType)rnd.Next(2),
                amountOfString = 4 + rnd.Next() % 9,
                builds = (BuildType)rnd.Next(4)
            };
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
        public static Piano Generate()
        {
            return new Piano()
            {
                type = (MusInstType)rnd.Next(2),
                amountOfFullOctaves = 4 + rnd.Next() % 4,
                amountOfKeys = 32 + rnd.Next() % 57
            };
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
            str += String.Format("\nРадиус: {0}\"\nВид барабана: {1}", radius, typeOfDrum);
            return str;
        }
        public static Drum Generate()
        {
            return new Drum()
            {
                type = (MusInstType)rnd.Next(2),
                radius = 4 + rnd.Next() % 9,
                typeOfDrum = (DrumType)rnd.Next(4)
            };
        }
    }
}