using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mii.UI
{
    public class HeadSelector : MonoBehaviour
    {
        public BodyPart MyHead;
        public Image preview;

        public void Setup(BodyPart newObject)
        {
            MyHead = newObject;
            preview.sprite = newObject.MySprite;

            if (newObject.MyCategory == PartCategory.skinColor || newObject.MyCategory == PartCategory.mouthColor || newObject.MyCategory == PartCategory.hairColor)
            {
                preview.color = MyHead.MyColor;
            }
            else if (newObject.MyCategory == PartCategory.nose || newObject.MyCategory == PartCategory.eyebrow)
                preview.color = Color.black;
        }

        public void SelectThisHead()
        {
            switch (MyHead.MyCategory)
            {
                case PartCategory.head:
                    StaticEvents.ReplaceMiiHead.Invoke(MyHead);
                    break;
                case PartCategory.hair:
                    StaticEvents.ReplaceMiiHair.Invoke(MyHead);
                    break;
                case PartCategory.wrinkles:
                    StaticEvents.ReplaceMiiWrinkles.Invoke(MyHead);
                    break;
                case PartCategory.skinColor:
                    StaticEvents.ReplaceMiiSkinColor.Invoke(MyHead);
                    break;
                case PartCategory.faceDecor:
                    StaticEvents.ReplaceMiiDecor.Invoke(MyHead);
                    break;
                case PartCategory.mouth:
                    StaticEvents.ReplaceMiiMouth.Invoke(MyHead);
                    break;
                case PartCategory.mouthColor:
                    StaticEvents.ReplaceMiiMouthColor.Invoke(MyHead);
                    break;
                case PartCategory.hairColor:
                    StaticEvents.ReplaceMiiHairColor.Invoke(MyHead);
                    break;
                case PartCategory.body:
                    StaticEvents.ReplaceMiiBody.Invoke(MyHead);
                    break;
                case PartCategory.nose:
                    StaticEvents.ReplaceMiiNose.Invoke(MyHead);
                    break;
                case PartCategory.eyebrow:
                    StaticEvents.ReplaceMiiEyebrow.Invoke(MyHead);
                    break;
            }
        }
    }
}