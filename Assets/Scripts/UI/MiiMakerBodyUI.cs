using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mii
{
    public class MiiMakerBodyUI : MonoBehaviour
    {
        public float BodyWeight;
        public float BodyHeight;
        Vector2 _heightWeightVector;

        public void SetBodyHeight(float f)
        {
            BodyHeight = f;
            sendBodyValue();
        }

        public void SetBodyWeight(float f)
        {
            BodyWeight = f;
            sendBodyValue();
        }

        void sendBodyValue()
        {
            _heightWeightVector.x = BodyHeight;
            _heightWeightVector.y = BodyWeight;

            StaticEvents.ReplaceMiiHeightWeight.Invoke(_heightWeightVector, Vector2.zero);
        }
    }
}