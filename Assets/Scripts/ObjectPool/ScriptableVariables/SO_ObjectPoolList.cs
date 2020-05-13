using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ObjectPoolList", menuName = "ScriptableObjects/Variables/ObjectPoolList", order = 1)]
public class SO_ObjectPoolList : ScriptableObject
{
    public List<PoolItem> objectPoolList = new List<PoolItem>();


    //Check for duplicate objects
    

    //Check for duplicate tags

}




[System.Serializable]
public struct PoolItem
{
    public GameObject poolObject;
    public string poolTag;
    public int poolAmount;
    public bool poolExpand;
}
