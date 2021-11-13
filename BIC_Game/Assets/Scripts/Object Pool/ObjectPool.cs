using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<ObjectData> objDatas = new List<ObjectData>();

    private Dictionary<string, Queue<GameObject>> pooledDic =
    new Dictionary<string, Queue<GameObject>>();

    #region Singleton
    public static ObjectPool Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private void Start()
    {
        foreach (ObjectData data in objDatas)
        {
            Queue<GameObject> generatedObjs = new Queue<GameObject>();
            for (int i = 0; i < data.maxCount; i++)
            {
                GameObject temp = Instantiate(data.prefab, Vector3.zero, Quaternion.identity);
                temp.transform.parent = this.transform;
                temp.SetActive(false);
                generatedObjs.Enqueue(temp);
            }

            pooledDic.Add(data.tag, generatedObjs);
        }
    }

    public GameObject SpawnObject(string tag, Vector3 position)
    {
        Queue<GameObject> objs = new Queue<GameObject>();
        pooledDic.TryGetValue(tag, out objs);

        GameObject obj = objs.Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;

        objs.Enqueue(obj);

        return obj;
    }
}


