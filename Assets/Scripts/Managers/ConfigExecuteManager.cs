using System;
using Assets.Scripts.Entities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    internal class ConfigExecuteManager
    {
        private List<ConfigExecute> _list;
        private int _count;
        internal float IntervalStart { get { return 2f; } }

        public ConfigExecuteManager()
        {
            _list = new List<ConfigExecute>();
            TextAsset txt = Resources.Load("level") as TextAsset;
            ConfigExecute config = null;
            var removeR = txt.text.ReplaceStringEmpty("\r");
            var configList = removeR.Split('\n');

            for (int i = 0; i < configList.Length; i++)
            {
                var array = configList[i].Split(',');

                var id = Convert.ToInt16(array[0]);

                if (config == null || config.ID != id)
                {
                    if (config != null) _list.Add(config);

                    config = new ConfigExecute();
                    config.ID = id;
                    config.EInterval = (EConfigInterval)Enum.Parse(typeof(EConfigInterval), array[1]);
                    config.Items = new List<ConfigItemExecute>();
                }

                var item = new ConfigItemExecute();
                item.EPointX = (EShapePosition)Enum.Parse(typeof(EShapePosition), array[2]);
                item.EType = (EShapeType)Enum.Parse(typeof(EShapeType), array[3], true);
                item.EVelocity = (EShapeVelocity)Enum.Parse(typeof(EShapeVelocity), array[4]);

                config.Items.Add(item);
            }

            _list.Add(config);
        }
        internal ConfigExecute GetConfig()
        {
            if (_count == _list.Count)
                //_count = 0;
                return new ConfigExecute { IsEmpty = true };

            var config = _list[_count];

            _count++;
            return config;
        }

        internal List<ConfigItemExecute> GetConfigs()
        {
            return new List<ConfigItemExecute>
           {
               new ConfigItemExecute { CountExecute = 10, EInterval = EConfigInterval.Slow, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 10, EInterval = EConfigInterval.Slow, EVelocity = EShapeVelocity.Normal },
               new ConfigItemExecute { CountExecute = 10, EInterval = EConfigInterval.Slow, EVelocity = EShapeVelocity.Fast },
               new ConfigItemExecute { CountExecute = 10, EInterval = EConfigInterval.Slow, EVelocity = EShapeVelocity.VeryFast },

               new ConfigItemExecute { CountExecute = 20, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 20, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.Normal },
               new ConfigItemExecute { CountExecute = 20, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.Fast },
               new ConfigItemExecute { CountExecute = 20, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.VeryFast },

               new ConfigItemExecute { CountExecute = 30, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 30, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Normal },
               new ConfigItemExecute { CountExecute = 30, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Fast },
               new ConfigItemExecute { CountExecute = 30, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.VeryFast },

               new ConfigItemExecute { CountExecute = 40, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 40, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.Normal },
               new ConfigItemExecute { CountExecute = 40, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.Fast },
               new ConfigItemExecute { CountExecute = 40, EInterval = EConfigInterval.Normal, EVelocity = EShapeVelocity.VeryFast },

               new ConfigItemExecute { CountExecute = 50, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 50, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Normal },
               new ConfigItemExecute { CountExecute = 50, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Fast },
               new ConfigItemExecute { CountExecute = 50, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.VeryFast },

               new ConfigItemExecute { CountExecute = 60, EInterval = EConfigInterval.VeryFast, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 60, EInterval = EConfigInterval.VeryFast, EVelocity = EShapeVelocity.Normal },

               new ConfigItemExecute { CountExecute = 70, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 70, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Normal },
               new ConfigItemExecute { CountExecute = 70, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.Fast },
               new ConfigItemExecute { CountExecute = 70, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.VeryFast },

               new ConfigItemExecute { CountExecute = 80, EInterval = EConfigInterval.VeryFast, EVelocity = EShapeVelocity.Slow },
               new ConfigItemExecute { CountExecute = 80, EInterval = EConfigInterval.VeryFast, EVelocity = EShapeVelocity.Normal },

               new ConfigItemExecute { CountExecute = 10000, EInterval = EConfigInterval.Fast, EVelocity = EShapeVelocity.VeryFast },
           };
        }
    }
}
