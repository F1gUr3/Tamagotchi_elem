using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi_Library.GameManagement
{
    internal class CorruptSaveException : Exception
    {
        public CorruptSaveException () : base("Save file might be corrupted!") { }
    }
}
