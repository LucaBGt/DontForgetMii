using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mii.UI;

namespace Mii
{
    public class MiiMakerNoseUI : MonoBehaviour
    {
        public BodyPartList AllBodyParts;
        [Header("Mouth Stuff")]
        public Transform ButtonCanvasParent;
        public GridLayoutGroup GridLayoutGroup;
        public GameObject MouthSelectButton;
        public GameObject PositionOptions;

        [Header("Settings")]
        public float OffsetFactor = .1f;
        public float TilingFactor = .1f;

        [Header("Position Stuff")]
        public Slider Y_Slider;
        float Y_value;
        public Slider Size_Slider;
        float Size_Value;
        void Start()
        {
            ShowNoseOptions();
        }

        public void ShowNoseOptions()
        {
            ButtonCanvasParent.gameObject.SetActive(true);

            foreach (Transform t in ButtonCanvasParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.Noses)
            {
                GameObject newNoseSelector = Instantiate(MouthSelectButton, ButtonCanvasParent);
                HeadSelector myNoseSelector = newNoseSelector.GetComponent<HeadSelector>();
                myNoseSelector.Setup(bp);
            }

            StaticEvents.SetLayoutGroupCellSize(80, GridLayoutGroup);
            GridLayoutGroup.constraintCount = 6;
            PositionOptions.SetActive(false);
        }

        public void ShowPositionOptions()
        {
            ButtonCanvasParent.gameObject.SetActive(false);
            PositionOptions.SetActive(true);
        }

        public void ReplaceNosePosition_Y(float f)
        {
            Y_value = f * OffsetFactor;
            SendPositionData();
        }

        void updateNoseYPreview(float f)
        {
            Debug.Log("Setting Slider Value...");
            Y_value = f / OffsetFactor;
            Y_Slider.value = Y_value;
        }

        public void ReplaceNoseScale(float f)
        {
            Size_Value = f * TilingFactor;
            SendPositionData();
        }

        void SendPositionData()
        {
            Vector2 newOffset = new Vector2(0, Y_value);
            Vector2 newTiling = new Vector2(Size_Value, Size_Value);
            StaticEvents.ReplaceMiiNosePosition.Invoke(newTiling, newOffset);
        }
    }
}