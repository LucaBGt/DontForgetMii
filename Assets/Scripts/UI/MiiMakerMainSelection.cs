using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mii.UI;
using UnityEngine.UI;

namespace Mii
{
    public class MiiMakerMainSelection : MonoBehaviour
    {
        public BodyPartList AllBodyParts;
        [Space]

        [Header("External References")]
        public CanvasGroup MyCG;
        public CanvasGroup FaceCG;
        public CanvasGroup MouthCG;
        public CanvasGroup HairCG;
        public CanvasGroup NoseCG;
        public CanvasGroup GenderCG;
        public CanvasGroup EyebrowCG;
        public CanvasGroup BodyCG;

        [Space]
        public Button BackButton;
        public GameObject MainCinemachineCam;
        List<CanvasGroup> allCGs;

        [Header("Head Stuff")]
        MiiMakerHeadUI HeadUI;
        [Header("Mouth Stuff")]
        MiiMakerMouthUI MouthUI;
        [Header("Hair Stuff")]
        MiiMakerMouthUI HairUI;
        [Header("Gender Stuff")]
        //MiiMakerMouthUI GenderUI;
        [Header("Mii")]

        public Mii MyMii;

        private void Awake()
        {
            HeadUI = GetComponent<MiiMakerHeadUI>();
            MouthUI = GetComponent<MiiMakerMouthUI>();
            setAllCGs();

            SetMainCGActive();
        }

        private void Start()
        {
            createEmptyMii();
        }
        void createEmptyMii()
        {
            //Body
            StaticEvents.ReplaceMiiBody.Invoke(AllBodyParts.Bodies[0]);

            //Head
            StaticEvents.ReplaceMiiHead.Invoke(AllBodyParts.HeadParts[0]);
            StaticEvents.ReplaceMiiWrinkles.Invoke(AllBodyParts.Wrinkles[0]);
            StaticEvents.ReplaceMiiDecor.Invoke(AllBodyParts.Decorations[0]);

            //Mouth
            StaticEvents.ReplaceMiiMouth.Invoke(AllBodyParts.Mouths[0]);
            StaticEvents.ReplaceMiiMouthPosition.Invoke(Vector2.zero, new Vector2(0, -5 * -.06f));

            //Nose
            StaticEvents.ReplaceMiiNose.Invoke(AllBodyParts.Noses[0]);

            //Hair
            StaticEvents.ReplaceMiiHair.Invoke(AllBodyParts.Hairs[0]);

            //Eyebrow
            StaticEvents.ReplaceMiiEyebrow.Invoke(AllBodyParts.Eyebrows[0]);

            //Colors
            StaticEvents.ReplaceMiiHairColor.Invoke(AllBodyParts.HairColors[1]);
            StaticEvents.ReplaceMiiMouthColor.Invoke(AllBodyParts.LipColors[0]);
            StaticEvents.ReplaceMiiSkinColor.Invoke(AllBodyParts.SkinColors[0]);
        }

        void setAllCGs()
        {
            allCGs = new List<CanvasGroup>();
            allCGs.Add(MyCG);
            allCGs.Add(FaceCG);
            allCGs.Add(MouthCG);
            allCGs.Add(HairCG);
            allCGs.Add(NoseCG);
            allCGs.Add(GenderCG);
            allCGs.Add(BodyCG);
            allCGs.Add(EyebrowCG);
        }

        public void SetFaceCGActive()
        {
            setActiveCG(FaceCG);
            BackButton.gameObject.SetActive(true);
            MainCinemachineCam.SetActive(false);

        }

        public void SetMouthCGActive()
        {
            setActiveCG(MouthCG);
            BackButton.gameObject.SetActive(true);
            MainCinemachineCam.SetActive(false);
            StaticEvents.ReplaceMiiMouthPosition_OffsetPreview.Invoke(MyMii.MyMii.MouthOffset.y);
        }

        public void SetMainCGActive()
        {
            setActiveCG(MyCG);
            BackButton.gameObject.SetActive(false);
            MainCinemachineCam.SetActive(true);
        }

        public void SetHairCGActive()
        {
            setActiveCG(HairCG);
            BackButton.gameObject.SetActive(true);
            MainCinemachineCam.SetActive(false);
        }

        public void SetBodyCGActive()
        {
            setActiveCG(BodyCG);
            BackButton.gameObject.SetActive(true);
            //MainCinemachineCam.SetActive(false);
        }

        public void SetGenderCGActive()
        {
            setActiveCG(GenderCG);
            BackButton.gameObject.SetActive(true);
            //MainCinemachineCam.SetActive(false);
        }

        public void SetNoseCGActive()
        {
            setActiveCG(NoseCG);
            BackButton.gameObject.SetActive(true);
            MainCinemachineCam.SetActive(false);
        }

        public void SetEyebrowCGActive()
        {
            setActiveCG(EyebrowCG);
            BackButton.gameObject.SetActive(true);
            MainCinemachineCam.SetActive(false);
        }

        void setActiveCG(CanvasGroup toSetActive)
        {
            foreach (CanvasGroup cg in allCGs)
            {
                if (cg == toSetActive)
                    StaticEvents.SetCGActive(cg, true);
                else
                    StaticEvents.SetCGActive(cg, false);
            }
        }

    }
}