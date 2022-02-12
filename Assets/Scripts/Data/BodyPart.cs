using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(fileName = "BodyPart", menuName = "Data/BodyParts")]
public class BodyPart : ScriptableObject
{
    public GameObject MyObject;
    public Texture MyTexture;
    public Sprite MySprite;
    public Color MyColor;
    public PartCategory MyCategory;
}

public enum PartCategory
{
    head, hair, wrinkles, skinColor, faceDecor, mouth, mouthColor, hairColor, body, nose, eyebrow
}