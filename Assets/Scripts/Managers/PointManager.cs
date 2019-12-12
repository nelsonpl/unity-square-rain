using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Managers
{
    internal class PointManager
    {
        private RandomList<float> _listX;

        public PointManager()
        {
            _listX = new RandomList<float>();
            _listX.Add(-2.2f);
            _listX.Add(-1.1f);
            _listX.Add(0f);
            _listX.Add(1.1f);
            _listX.Add(2.2f);
        }

        internal float GetX()
        {
            return _listX.Get();
        }

        internal float GetY()
        {
            return 5.5f;
        }
    }
}
