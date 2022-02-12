using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mii
{
    public class Mii : MonoBehaviour
    {
        public MiiSaveFile MyMii = new MiiSaveFile();
        public BodyPartList AllBodyParts;
        public Color SkinColor;
        [Header("Head Stuff")]
        public Transform MyHeadObject;
        public MiiHead MyHead;
        Material _headMaterial;
        Material _mouthMaterial;
        float _darkerAmount = .7f;
        public Transform NeckBone;

        [Header("NoseStuff")]
        public MiiNose MyNose;

        [Header("HairStuff")]
        public MiiHair MyHair;
        Material _hairMaterial;
        [Header("BodyStuff")]
        public MiiBody MyBody;
        Material _bodyMaterial;
        Animator _animator;

        [Header("EyebrowStuff")]
        Material _eyebrowMaterial;

        public float OffsetScale = 1.333333f;

        private void Awake()
        {
            StaticEvents.ReplaceMiiBody.AddListener(ReplaceBody);

            StaticEvents.ReplaceMiiHead.AddListener(ReplaceHead);
            StaticEvents.ReplaceMiiWrinkles.AddListener(ReplaceWrinkles);
            StaticEvents.ReplaceMiiDecor.AddListener(ReplaceDeco);
            StaticEvents.ReplaceMiiMouth.AddListener(ReplaceMouth);
            StaticEvents.ReplaceMiiEyebrow.AddListener(ReplaceEyebrow);
            StaticEvents.ReplaceMiiHair.AddListener(ReplaceHair);
            StaticEvents.ReplaceMiiNose.AddListener(ReplaceNose);

            StaticEvents.ReplaceMiiNosePosition.AddListener(ReplaceNosePosition);
            StaticEvents.ReplaceMiiMouthPosition.AddListener(ReplaceMouthPosition);

            StaticEvents.ReplaceMiiSkinColor.AddListener(ReplaceSkinColor);
            StaticEvents.ReplaceMiiHairColor.AddListener(ReplaceHairColor);
            StaticEvents.ReplaceMiiMouthColor.AddListener(ReplaceLipColor);


        }

        public void ReplaceBody(BodyPart newHead)
        {
            if (MyBody != null)
                Destroy(MyBody.gameObject);

            if (MyHead != null)
                MyHead.transform.parent = null;

            if (MyHair != null)
                MyHair.transform.parent = null;

            GameObject _newBody = Instantiate(newHead.MyObject, this.transform);

            _newBody.transform.localScale = Vector3.one;

            MyBody = _newBody.GetComponent<MiiBody>();
            MyMii.Body = AllBodyParts.Bodies.IndexOf(newHead);
            _animator = MyBody.Animator;
            if (_bodyMaterial == null)
            {
                _bodyMaterial = MyBody.UpperBody.material;
            }
            else
            {
                MyBody.UpperBody.material = _bodyMaterial;
            }

            MyHeadObject = MyBody.NeckBone;

            if (MyHead != null)
            {
                MyHead.transform.parent = MyHeadObject;
                MyHead.transform.localPosition = Vector3.zero;
                MyHead.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

            if (MyHair != null)
            {
                MyHair.transform.parent = MyHeadObject;
                Vector2 hairPosition = MyHair.transform.localPosition;
                hairPosition.y = MyHead.HairOffset;
                MyHair.transform.localPosition = hairPosition;
                MyHair.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        public void ReplaceHead(BodyPart newHead)
        {

            if (MyNose != null)
                MyNose.transform.parent = null;

            if (MyHead != null)
                Destroy(MyHead.gameObject);

            GameObject _newHead = Instantiate(newHead.MyObject, MyHeadObject);

            _newHead.transform.parent = null;
            _newHead.transform.localScale = Vector3.one;
            _newHead.transform.parent = MyHeadObject.transform;

            MyHead = _newHead.GetComponent<MiiHead>();
            MyMii.Head = AllBodyParts.HeadParts.IndexOf(newHead);

            if (_headMaterial == null)
            {
                _headMaterial = MyHead.Me.material;
            }
            else
            {
                MyHead.Me.material = _headMaterial;
            }

            if (_mouthMaterial != null)
                MyHead.MouthObject.material = _mouthMaterial;
            else
                _mouthMaterial = MyHead.MouthObject.material;

            if (_eyebrowMaterial != null)
                MyHead.EyebrowObject.material = _eyebrowMaterial;
            else
                _eyebrowMaterial = MyHead.EyebrowObject.material;

            if (MyHair != null)
            {
                Vector2 hairPosition = MyHair.transform.localPosition;
                hairPosition.y = MyHead.HairOffset;
                MyHair.transform.localPosition = hairPosition;
            }

            if (MyNose != null)
            {
                MyNose.transform.parent = MyHead.NosePosition;
                MyNose.transform.localPosition = Vector3.zero;
            }
        }

        public void ReplaceHair(BodyPart newHead)
        {
            if (MyHair != null)
                Destroy(MyHair.gameObject);

            GameObject _newHair = Instantiate(newHead.MyObject, MyHeadObject);

            _newHair.transform.parent = null;
            _newHair.transform.localScale = Vector3.one;
            _newHair.transform.parent = MyHeadObject.transform;

            MyHair = _newHair.GetComponent<MiiHair>();
            MyMii.Hair = AllBodyParts.Hairs.IndexOf(newHead);

            if (_hairMaterial == null)
            {
                _hairMaterial = MyHair.HairRenderer.material;
            }
            else
            {
                MyHair.HairRenderer.material = _hairMaterial;
            }

            if (MyHead != null)
            {
                Vector2 hairPosition = MyHair.transform.localPosition;
                hairPosition.y = MyHead.HairOffset;
                MyHair.transform.localPosition = hairPosition;
            }
        }

        public void ReplaceNose(BodyPart newHead)
        {
            if (MyNose != null)
                Destroy(MyNose.gameObject);

            GameObject _newNose = Instantiate(newHead.MyObject, MyHead.NosePosition);

            _newNose.transform.parent = null;
            _newNose.transform.localScale = Vector3.one;
            _newNose.transform.parent = MyHead.NosePosition;

            MyNose = _newNose.GetComponent<MiiNose>();
            MyMii.Nose = AllBodyParts.Noses.IndexOf(newHead);

            MyNose.NoseObject.material = _headMaterial;
        }

        public void ReplaceSkinColor(BodyPart newHead)
        {
            _headMaterial.SetColor("_skinColor", newHead.MyColor);
            MyMii.SkinColor = newHead.MyColor;
        }

        public void ReplaceWrinkles(BodyPart newHead)
        {
            _headMaterial.SetTexture("_wrinkleTexture", newHead.MyTexture);
            MyMii.Wrinkles = AllBodyParts.Wrinkles.IndexOf(newHead);
        }

        public void ReplaceDeco(BodyPart newHead)
        {
            _headMaterial.SetTexture("_decorationTexture", newHead.MyTexture);
            MyMii.Decoration = AllBodyParts.Decorations.IndexOf(newHead);
        }

        public void ReplaceMouth(BodyPart newHead)
        {
            _mouthMaterial.SetTexture("_mouthTexture", newHead.MyTexture);
            MyMii.Mouth = AllBodyParts.Mouths.IndexOf(newHead);
        }

        public void ReplaceEyebrow(BodyPart newHead)
        {
            _eyebrowMaterial.SetTexture("_eyebrowTexture", newHead.MyTexture);
            MyMii.Eyebrow = AllBodyParts.Eyebrows.IndexOf(newHead);
        }

        public void ReplaceMouthPosition(Vector2 tiling, Vector2 offset)
        {
            MyMii.MouthTiling = tiling;
            MyMii.MouthOffset = offset;

            offset.x += 0;
            offset.y += StaticEvents.MouthOffset.y;

            _mouthMaterial.SetVector("_mouthOffset", offset);
            _mouthMaterial.SetFloat("_scale", tiling.x + StaticEvents.MouthTiling.x);
        }

        public void ReplaceNosePosition(Vector2 tiling, Vector2 offset)
        {
            MyMii.NoseTiling = tiling;
            MyMii.NoseOffset = offset;

            MyNose.transform.localScale = Vector3.one + Vector3.one * (1 * tiling.y);
            MyNose.transform.localPosition = Vector3.zero + Vector3.up * offset.y;
            MyNose.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }

        public void ReplaceLipColor(BodyPart newHead)
        {
            Color darkerColor = newHead.MyColor * _darkerAmount;
            darkerColor.a = 1;

            _mouthMaterial.SetColor("_lowerLipColor", newHead.MyColor);
            _mouthMaterial.SetColor("_upperLipColor", darkerColor);

            MyMii.LipColor = newHead.MyColor;
        }

        public void ReplaceHairColor(BodyPart newHead)
        {
            _hairMaterial.SetColor("_BaseColor", newHead.MyColor);
            MyMii.HairColor = newHead.MyColor;
        }
    }

    [System.Serializable]
    public class MiiSaveFile
    {
        public int Body;
        public int Head;
        public Color SkinColor;
        public int Wrinkles;
        public int Decoration;
        public int Mouth;
        public Color LipColor;
        public Vector2 MouthTiling;
        public Vector2 MouthOffset;
        public int Hair;
        public Color HairColor;
        public MiiGender Gender;
        public int Nose;
        public Vector2 NoseTiling;
        public Vector2 NoseOffset;
        public int Eyebrow;
    }

    [System.Serializable]
    public class MiiGender
    {
        public string Pronouns = "They";
        public string OhHeyIts = "Them";
        public string PossessivePronouns = "Theirs";
    }
}