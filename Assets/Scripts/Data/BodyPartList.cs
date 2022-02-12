using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "BodyPartList", menuName = "Data/One Time Use/Body Part List", order = 0)]
public class BodyPartList : ScriptableObject
{
    public List<BodyPart> Bodies;
    public List<BodyPart> HeadParts;
    public List<BodyPart> SkinColors;
    public List<BodyPart> Wrinkles;
    public List<BodyPart> Decorations;
    public List<BodyPart> Mouths;
    public List<BodyPart> LipColors;
    public List<BodyPart> Hairs;
    public List<BodyPart> HairColors;
    public List<BodyPart> Noses;
    public List<BodyPart> Eyebrows;
}