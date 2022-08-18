using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers
{
    public class AreaController : MonoBehaviour
    {
        float dotUp;
        float dotForward;

        public enum Area { Up, Right, Down, Left };
        public Area area;
        public int  AreaDecider()
        {
            dotUp = Vector3.Dot(Vector3.up, transform.forward);
            dotForward = Vector3.Dot(Vector3.forward, transform.forward);
            if (dotUp > 0.45f)
            {
                area = Area.Up;
                return 0;
            }
            else if (dotForward > 0.45f)
            {
                area = Area.Right;
                return 1;
            }
            else if (dotUp < -0.45f)
            {
                area = Area.Down;
                return 2;
            }
            else if (dotForward < -0.45f)
            {
                area = Area.Left;
                return 3;
            }
            return 5;
        }
    }
}
