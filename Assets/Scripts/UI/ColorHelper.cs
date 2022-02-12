using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHelper : MonoBehaviour
{

    public FlexibleColorPicker ColorPicker;
    public FlexibleColorPicker LipColorPicker;
    public FlexibleColorPicker HairColorPicker;

    private void Awake()
    {
        StaticEvents.ReplaceMiiSkinColor.AddListener(ReplacePickerPreviewColor);
        StaticEvents.ReplaceMiiMouthColor.AddListener(ReplaceLipPickerPreviewColor);
        StaticEvents.ReplaceMiiHairColor.AddListener(ReplaceHairPickerPreviewColor);
    }

    public void FreeStyleSkinColor(Color color)
    {
        BodyPart bp = BodyPart.CreateInstance<BodyPart>();
        bp.MyCategory = PartCategory.skinColor;
        bp.MyColor = color;
        ColorPicker.startingColor = color;

        StaticEvents.ReplaceMiiSkinColor.Invoke(bp);
    }

    void ReplacePickerPreviewColor(BodyPart bp)
    {
        Color color = bp.MyColor;

        if (ColorPicker.color != color)
        {
            ColorPicker.startingColor = color;
            ColorPicker.SetColorNoAlpha(color);
        }
    }

    public void FreeStyleLipColor(Color color)
    {
        BodyPart bp = BodyPart.CreateInstance<BodyPart>();
        bp.MyCategory = PartCategory.mouthColor;
        bp.MyColor = color;
        LipColorPicker.startingColor = color;

        StaticEvents.ReplaceMiiMouthColor.Invoke(bp);
    }

    void ReplaceLipPickerPreviewColor(BodyPart bp)
    {
        Color color = bp.MyColor;

        if (LipColorPicker.color != color)
        {
            LipColorPicker.startingColor = color;
            LipColorPicker.SetColorNoAlpha(color);
        }
    }

    public void FreeStyleHairColor(Color color)
    {
        BodyPart bp = BodyPart.CreateInstance<BodyPart>();
        bp.MyCategory = PartCategory.hairColor;
        bp.MyColor = color;
        HairColorPicker.startingColor = color;

        StaticEvents.ReplaceMiiHairColor.Invoke(bp);
    }

    void ReplaceHairPickerPreviewColor(BodyPart bp)
    {
        Color color = bp.MyColor;

        if (HairColorPicker.color != color)
        {
            HairColorPicker.startingColor = color;
            HairColorPicker.SetColorNoAlpha(color);
        }
    }
}
