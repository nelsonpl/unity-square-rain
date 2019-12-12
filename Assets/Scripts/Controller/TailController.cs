using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class TailController: MonoBehaviour
    {
        void Start()
        {
            InvokeRepeating("Destroy", 0.1f, 0);
        }

        void Update()
        {

        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

    }
}
