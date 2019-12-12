using System;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class ShapeController : MonoBehaviour
    {
        internal EShapeType EType { get; private set; }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        internal void Init(EShapeType eShapeType, EShapePosition eShapePosition, EShapeVelocity eShapeVelocity)
        {
            EType = eShapeType;
            transform.position = new Vector3(Utils.GetPointX(eShapePosition), Consts.PointY);

            var rigidbody2D = GetComponent<Rigidbody2D>();
            if (rigidbody2D != null)
            {
                rigidbody2D.velocity = new Vector2(0, Utils.GetVelocity(eShapeVelocity));
            }
            MultimediaController.ExecuteCreate();
        }

        internal void Init(ConfigItemExecute item)
        {
            Init(item.EType, item.EPointX, item.EVelocity);
        }
    }
}
