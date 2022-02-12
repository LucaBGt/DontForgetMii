using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mii.UI;

namespace Mii
{
    public class MiiMakerHairUI : MonoBehaviour
    {
        public BodyPartList AllBodyParts;
        [Header("Mouth Stuff")]
        public Transform ButtonCanvasParent;
        public GridLayoutGroup GridLayoutGroup;
        public GameObject HairSelectButton;
        public GameObject ColorPicker;

        void Start()
        {
            ShowHairOptions();
        }

        public void ShowHairOptions()
        {
            ButtonCanvasParent.gameObject.SetActive(true);

            foreach (Transform t in ButtonCanvasParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.Hairs)
            {
                GameObject newHairSelector = Instantiate(HairSelectButton, ButtonCanvasParent);
                HeadSelector myHairSelector = newHairSelector.GetComponent<HeadSelector>();
                myHairSelector.Setup(bp);
            }

            StaticEvents.SetLayoutGroupCellSize(80, GridLayoutGroup);
            GridLayoutGroup.constraintCount = 6;
            ColorPicker.SetActive(false);
        }

        public void ShowHairColorOptions()
        {
            ButtonCanvasParent.gameObject.SetActive(true);

            foreach (Transform t in ButtonCanvasParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.HairColors)
            {
                GameObject newHairSelector = Instantiate(HairSelectButton, ButtonCanvasParent);
                HeadSelector myHairSelector = newHairSelector.GetComponent<HeadSelector>();
                myHairSelector.Setup(bp);
            }

            StaticEvents.SetLayoutGroupCellSize(50, GridLayoutGroup);
            GridLayoutGroup.constraintCount = 5;
            ColorPicker.SetActive(true);
        }
    }
}