using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.Callbacks;

public class GizmoIconUtility
{
    [DidReloadScripts]
    static GizmoIconUtility()
    {
        EditorApplication.projectWindowItemOnGUI = ItemOnGUI;
    }

    static void ItemOnGUI(string guid, Rect rect)
    {
        string assetPath = AssetDatabase.GUIDToAssetPath(guid);

        BodyPart obj = AssetDatabase.LoadAssetAtPath(assetPath, typeof(BodyPart)) as BodyPart;

        if (obj != null && obj.MySprite != null)
        {
            if (rect.height > rect.width)
                rect.height = rect.width;
            else
                rect.width = rect.height;

            //Texture iconTexture = obj.MySprite.texture;

            GUIDrawSprite(rect, obj.MySprite);
        }
    }

    public static void GUIDrawSprite(Rect rect, Sprite sprite)
    {
        Rect spriteRect = sprite.rect;
        Texture2D tex = sprite.texture;
        GUI.DrawTextureWithTexCoords(rect, tex, new Rect(spriteRect.x / tex.width, spriteRect.y / tex.height, spriteRect.width / tex.width, spriteRect.height / tex.height));
    }

}