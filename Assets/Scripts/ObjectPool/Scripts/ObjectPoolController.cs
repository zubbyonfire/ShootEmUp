using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectPoolController : MonoBehaviour
{
    public static ObjectPoolController SharedInstance;

    [Header("Object List To Use")]
    [SerializeField]
    private SO_ObjectPoolList objectList = null;

    private Dictionary<string, List<GameObject>> poolDictionary = new Dictionary<string, List<GameObject>>();
    [SerializeField]
    private List<PoolItem> listItems = new List<PoolItem>();

    private void Awake()
    {
        SharedInstance = this;

        if (objectList == null)
        {
            Debug.LogError("No object list assigned to " + this.gameObject);
        }
        else
        {
            //Take the list and setup the pool with all the valid objects
            //Ignore objects with no object set or with no tag included - error log any that do have this issue
            PoolObjects();
        }
    }

    /// <summary>
    /// Setup the object pool
    /// </summary>
    private void PoolObjects()
    {
        //Reset the poolDictionary
        poolDictionary.Clear();

        //Get a reference to the objectList
        listItems = objectList.objectPoolList;

        for (int i = 0; i < listItems.Count; i++)
        {
            //If the list item has a object and has a tag
            if (listItems[i].poolObject != null && !string.IsNullOrEmpty(listItems[i].poolTag))
            {
                for (int j = 0; j < listItems[i].poolAmount; j++)
                {
                    //If it's the first object then we add a new key to the dictionary (based on the tag)
                    if (j == 0)
                    {
                        GameObject obj = (GameObject)Instantiate(listItems[i].poolObject);

                        obj.transform.parent = this.gameObject.transform;

                        obj.SetActive(false);

                        obj.transform.DOScale(0, 0);

                        List<GameObject> objList = new List<GameObject>();

                        objList.Add(obj);

                        poolDictionary.Add(listItems[i].poolTag, objList);
                    }
                    else //Add it to the dictionary as part of the existing key
                    {
                        GameObject obj = (GameObject)Instantiate(listItems[i].poolObject);
                        obj.transform.parent = this.gameObject.transform;
                        obj.SetActive(false);

                        obj.transform.DOScale(0, 0);

                        List<GameObject> list = poolDictionary[listItems[i].poolTag];
                        list.Add(obj);
                        poolDictionary[listItems[i].poolTag] = list;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Return an inactive object that has the tag that is passed
    /// If there's not a valid object check to see if the object can be expanded, create one and return it
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    public GameObject GetPooledObjects(string tag)
    {
        //Check the dictionary for the passed tag
        if (poolDictionary.ContainsKey(tag))
        {
            //Loop through the values of the key and find an inactive object
            foreach (GameObject item in poolDictionary[tag])
            {
                if (!item.activeInHierarchy)
                {
                    return item;
                }
            }

            //Else check if we can spawn extra of the object and do so if we can
            //Go through the pool list
            foreach (PoolItem poolItem in listItems)
            {
                //Check if the items tag is the same of the tag
                if (poolItem.poolTag == tag)
                {
                    if (poolItem.poolExpand == true)
                    {
                        GameObject obj = (GameObject)Instantiate(poolItem.poolObject);
                        obj.SetActive(false);

                        List<GameObject> list = poolDictionary[tag];
                        list.Add(obj);
                        poolDictionary[tag] = list;

                        return obj;
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Pool dictionary does not contain key: " + tag);
        }

        //Return null as their is no valid object passed
        return null;
    }

    /// <summary>
    /// Reparent the passed object and set it to false 
    /// </summary>
    /// <param name="obj"></param>
    public void ReturnPooledObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.DOScale(0, 0);
        obj.transform.SetParent(this.gameObject.transform);
    }
}
