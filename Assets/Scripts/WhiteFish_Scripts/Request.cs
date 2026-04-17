using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

[CreateAssetMenu(fileName = "request", menuName = "CreatRequest")]
public class Request : ScriptableObject
{
    public int Meat_Number;
    public int Vegetable_Number;
    public int Bean_Number;
    public int Mushroom_Number;
}
