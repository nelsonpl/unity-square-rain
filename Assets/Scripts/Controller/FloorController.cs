using System.Security;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class FloorController : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            var script = other.GetComponent<ShapeController>();
            if (script == null) return;

            switch (script.EType)
            {
                case EShapeType.Normal:
                    GameController.Instance.RemoveLife();
                    break;
                case EShapeType.DangerGameOver:
                    //GameController.Instance.GameOver();
                    break;
            }

            //GameController.Instance.AddScore();
            script.Destroy();
        }
    }
}
