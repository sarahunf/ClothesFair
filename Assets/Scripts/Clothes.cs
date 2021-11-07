using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Clothes", order = 1)]
public class Clothes : ScriptableObject
{
    public Sprite sprite;
    public string displayName;
    public float value;
    public Color32 color;

}
