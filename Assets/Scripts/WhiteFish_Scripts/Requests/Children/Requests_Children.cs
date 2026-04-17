using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "request", menuName = "Orders_Children")]
public class Requests_Children : ScriptableObject
{
    public List<Request> Children;
}