using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Entities;

namespace Assets.Scripts
{
    internal static class Utils
    {
        internal static float GetPointX(EShapePosition ePosition)
        {
            switch (ePosition)
            {
                case EShapePosition.Left:
                    return -2.2f;
                case EShapePosition.LeftCenter:
                    return -1.1f;
                case EShapePosition.Center:
                    return 0f;
                case EShapePosition.RightCenter:
                    return 1.1f;
                case EShapePosition.Right:
                    return 2.2f;
                default:
                    return 0;
            }
        }

        internal static float GetVelocity(EShapeVelocity eVelocity)
        {
            switch (eVelocity)
            {
                case EShapeVelocity.Slow: return 0;
                case EShapeVelocity.Normal: return -2.5f;
                case EShapeVelocity.Fast: return -5f;
                case EShapeVelocity.VeryFast: return -7.5f;
                default: return 0;
            }
        }

        internal static float GetInterval(EConfigInterval eInterval)
        {
            switch (eInterval)
            {
                case EConfigInterval.Slow: return 1f;
                case EConfigInterval.Normal: return 0.75f;
                case EConfigInterval.Fast: return 0.5f;
                case EConfigInterval.VeryFast: return 0.25f;
                default: return 0;
            }
        }
    }
}
