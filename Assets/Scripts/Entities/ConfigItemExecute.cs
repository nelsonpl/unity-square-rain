using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Entities
{
    class ConfigItemExecute
    {
        //internal float Velocity { get; set; }
        internal EShapeType EType { get; set; }
        internal EShapePosition EPointX { get; set; }
        internal EShapeVelocity EVelocity { get; set; }
        internal EConfigInterval EInterval { get; set; }
        internal int CountExecute { get; set; }
    }
}
