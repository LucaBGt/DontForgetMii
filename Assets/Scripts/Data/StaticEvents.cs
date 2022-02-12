using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;
using DG;
public static class StaticEvents
{
    public static ReplaceMiiPart ReplaceMiiHead = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiHair = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiWrinkles = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiSkinColor = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiDecor = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiMouth = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiMouthColor = new ReplaceMiiPart();
    public static ReplaceMiiPosition ReplaceMiiMouthPosition = new ReplaceMiiPosition();
    public static ReplaceFloat ReplaceMiiMouthPosition_OffsetPreview = new ReplaceFloat();
    public static ReplaceMiiPart ReplaceMiiHairColor = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiBody = new ReplaceMiiPart();
    public static ReplaceMiiPart ReplaceMiiNose = new ReplaceMiiPart();
    public static ReplaceMiiPosition ReplaceMiiNosePosition = new ReplaceMiiPosition();
    public static ReplaceMiiPart ReplaceMiiEyebrow = new ReplaceMiiPart();


    public static void SetCGActive(CanvasGroup _cg, bool _setActive)
    {
        if (_setActive)
            _cg.DOFade(1f, .25f);
        else
            _cg.DOFade(0f, .25f);

        _cg.interactable = _setActive;
        _cg.blocksRaycasts = _setActive;
    }

    public static void SetLayoutGroupCellSize(int size, GridLayoutGroup grid)
    {
        grid.cellSize = new Vector2(size, size);

    }

    public static Vector2 MouthTiling = new Vector2(1.5f, 1.5f);
    public static Vector2 MouthOffset = new Vector2(0, 0.1f);

}

public class ReplaceMiiHead : UnityEvent<BodyPart> { }
public class ReplaceMiiPart : UnityEvent<BodyPart> { }

public class ReplaceMiiHair : UnityEvent<BodyPart> { }
public class ReplaceMiiWrinkles : UnityEvent<BodyPart> { }
public class ReplaceMiiPosition : UnityEvent<Vector2, Vector2> { }
public class ReplaceFloat : UnityEvent<float> { }
