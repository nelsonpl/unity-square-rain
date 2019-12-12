using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Entities
{
    internal class ConfigExecute
    {
        internal int ID { get; set; }
        internal EConfigInterval EInterval { get; set; }
        //internal float Interval { get; set; }
        internal bool IsEmpty { get; set; }
        internal List<ConfigItemExecute> Items { get; set; }

    }
}
