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
    }
    public class Guitar : MusInst
    {
        public int amountOfString;// от 4 до 12
        public string builds;// много строев
    }
    public class Piano : MusInst
    {
        public int amountOfKeys;// 49, 61, 88 (от 32 до 88)
        public int amountOfFullOctaves;// 4, 5, 7 октав
    }
    public enum DrumType { big, small, timpani, tom }
    public class Drum : MusInst
    {
        public int radius;// 4 - 12 дюймов
        public DrumType typeOfDrum;
    }
}