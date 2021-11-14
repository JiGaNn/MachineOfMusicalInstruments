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
        public int amountOfString;
        public string builds;
    }
    public class Piano : MusInst
    {
        public int amountOfKeys;
        public int amountOfFullOctaves;
    }
    public enum DrumType { big, small, timpani, tom }
    public class Drum : MusInst
    {
        public int radius;
        public DrumType typeOfDrum;
    }
}