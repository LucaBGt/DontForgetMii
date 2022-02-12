using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mii.UI;

namespace Mii
{
    public class MiiMakerHeadUI : MonoBehaviour
    {
        public BodyPartList AllBodyParts;

        [Header("Head Stuff")]
        public Transform HeadParent;
        public GridLayoutGroup GridLayoutGroup;
        public GameObject HeadSelectButton;
        public GameObject ColorPicker;
        // Start is called before the first frame update
        void Start()
        {
            ShowFaceOptions();
        }

        public void ShowFaceOptions()
        {
            foreach (Transform t in HeadParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.HeadParts)
            {
                GameObject newHeadSelector = Instantiate(HeadSelectButton, HeadParent);
                HeadSelector myHeadSelector = newHeadSelector.GetComponent<HeadSelector>();
                myHeadSelector.Setup(bp);
            }

            StaticEvents.SetLayoutGroupCellSize(100, GridLayoutGroup);
            ColorPicker.SetActive(false);
        }

        public void ShowWrinkleOptions()
        {
            foreach (Transform t in HeadParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.Wrinkles)
            {
                GameObject newHeadSelector = Instantiate(HeadSelectButton, HeadParent);
                HeadSelector myHeadSelector = newHeadSelector.GetComponent<HeadSelector>();
                myHeadSelector.Setup(bp);
            }
            StaticEvents.SetLayoutGroupCellSize(100, GridLayoutGroup);
            ColorPicker.SetActive(false);
        }

        public void ShowFaceDecoOptions()
        {
            foreach (Transform t in HeadParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.Decorations)
            {
                GameObject newHeadSelector = Instantiate(HeadSelectButton, HeadParent);
                HeadSelector myHeadSelector = newHeadSelector.GetComponent<HeadSelector>();
                myHeadSelector.Setup(bp);
            }
            StaticEvents.SetLayoutGroupCellSize(100, GridLayoutGroup);
            ColorPicker.SetActive(false);
        }

        public void ShowSkinColorOptions()
        {
            foreach (Transform t in HeadParent)
            {
                Destroy(t.gameObject);
            }
            foreach (BodyPart bp in AllBodyParts.SkinColors)
            {
                GameObject newHeadSelector = Instantiate(HeadSelectButton, HeadParent);
                HeadSelector myHeadSelector = newHeadSelector.GetComponent<HeadSelector>();
                myHeadSelector.Setup(bp);
            }

            StaticEvents.SetLayoutGroupCellSize(50, GridLayoutGroup);
            ColorPicker.SetActive(true);
        }
    }
}