using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mii.UI;

namespace Mii
{
    public class MiiMakerMouthUI : MonoBehaviour
    {
        public BodyPartList AllBodyParts;
        [Header("Mouth Stuff")]
        public Transform ButtonCanvasParent;
        public GridLayoutGroup GridLayoutGroup;
        public GameObject MouthSelectButton;
        public GameObject ColorPicker;
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
            ShowMouthOptions();
        }

        private void Awake()
        {
            StaticEvents.ReplaceMiiMouthPosition_OffsetPreview.AddListener(updateMouthYPreview);
        }

        public void ShowMouthOptions()
        {
            ButtonCanvasParent.gameObject.SetActive(true);

            foreach (Transform t in ButtonCanvasParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.Mouths)
            {
                GameObject newMouthSelector = Instantiate(MouthSelectButton, ButtonCanvasParent);
                HeadSelector myMouthSelector = newMouthSelector.GetComponent<HeadSelector>();
                myMouthSelector.Setup(bp);
            }

            StaticEvents.SetLayoutGroupCellSize(80, GridLayoutGroup);
            GridLayoutGroup.constraintCount = 6;
            ColorPicker.SetActive(false);
            PositionOptions.SetActive(false);
        }

        public void ShowPositionOptions()
        {
            ColorPicker.SetActive(false);
            ButtonCanvasParent.gameObject.SetActive(false);
            PositionOptions.SetActive(true);
        }

        public void ShowColorOptions()
        {
            ButtonCanvasParent.gameObject.SetActive(true);

            foreach (Transform t in ButtonCanvasParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.LipColors)
            {
                GameObject newMouthSelector = Instantiate(MouthSelectButton, ButtonCanvasParent);
                HeadSelector myMouthSelector = newMouthSelector.GetComponent<HeadSelector>();
                myMouthSelector.Setup(bp);
            }

            StaticEvents.SetLayoutGroupCellSize(50, GridLayoutGroup);
            GridLayoutGroup.constraintCount = 5;
            ColorPicker.SetActive(true);
            PositionOptions.SetActive(false);
        }

        public void ReplaceMouthPosition_Y(float f)
        {
            Y_value = f * OffsetFactor;
            SendPositionData();
        }

        void updateMouthYPreview(float f)
        {
            Debug.Log("Setting Slider Value...");
            Y_value = f / OffsetFactor;
            Y_Slider.value = Y_value;
        }

        public void ReplaceMouthScale(float f)
        {
            Size_Value = f * TilingFactor;
            SendPositionData();
        }

        void SendPositionData()
        {
            Vector2 newOffset = new Vector2(0, Y_value);
            Vector2 newTiling = new Vector2(Size_Value, Size_Value);
            StaticEvents.ReplaceMiiMouthPosition.Invoke(newTiling, newOffset);
        }
    }
}