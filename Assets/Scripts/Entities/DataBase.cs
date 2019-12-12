using UnityEngine;

namespace Assets.Scripts.Entities
{
    internal static class DataBase
    {
        internal static int Sound
        {
            get
            {
                var sound = PlayerPrefs.GetInt("SOUND", 1);
                PlayerPrefs.Save();
                return sound;
            }
            set
            {
                PlayerPrefs.SetInt("SOUND", value);
            }
        }

    }
}
