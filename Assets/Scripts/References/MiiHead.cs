using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mii
{
    public class MiiHead : MonoBehaviour
    {
        public MeshRenderer Me;
        public MeshRenderer EyeObject;
        public MeshRenderer EyebrowObject;
        public MeshRenderer MouthObject;
        public Transform NosePosition;
        public float HairOffset = 0;

        Transform _neck;
        public void Setup(Transform newNexk)
        {
        }
    }
}
