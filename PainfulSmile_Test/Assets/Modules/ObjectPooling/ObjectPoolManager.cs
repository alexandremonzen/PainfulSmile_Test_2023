using System.Collections.Generic;

using UnityEngine;

public abstract class ObjectPoolManager<T> : ObjectPoolManager where T : Component
{
    [SerializeField] protected List<T> _prefabsToPool;
    [SerializeField] protected int _initialPoolSize = 10;

    protected Dictionary<T, List<T>> _objectPool = new Dictionary<T, List<T>>();

    protected void Awake()
    {
        InitializePool();
    }

    protected void InitializePool()
    {
        foreach (var prefab in _prefabsToPool)
        {
            List<T> prefabList = new List<T>();
            for (int i = 0; i < _initialPoolSize; i++)
            {
                T obj = Instantiate(prefab);
                obj.gameObject.SetActive(false);
                prefabList.Add(obj);
            }

            _objectPool[prefab] = prefabList;
        }
    }

    public T GetPooledObject(T prefab)
    {
        if (_objectPool.ContainsKey(prefab))
        {
            for (int i = 0; i < _objectPool[prefab].Count; i++)
            {
                if (!_objectPool[prefab][i].gameObject.activeInHierarchy)
                {
                    _objectPool[prefab][i].gameObject.SetActive(true);
                    return _objectPool[prefab][i];
                }
            }
        }

        T newObj = Instantiate(prefab);
        _objectPool[prefab].Add(newObj);
        newObj.gameObject.SetActive(true);
        return newObj;
    }

    public T GetPooledObject(T prefab, Transform spawnPosition)
    {
        if (_objectPool.ContainsKey(prefab))
        {
            for (int i = 0; i < _objectPool[prefab].Count; i++)
            {
                if (!_objectPool[prefab][i].gameObject.activeInHierarchy)
                {
                    _objectPool[prefab][i].transform.position = spawnPosition.position;
                    _objectPool[prefab][i].gameObject.SetActive(true);
                    return _objectPool[prefab][i];
                }
            }
        }

        T newObj = Instantiate(prefab);
        _objectPool[prefab].Add(newObj);
        newObj.gameObject.SetActive(true);
        return newObj;
    }
}

public abstract class ObjectPoolManager : MonoBehaviour
{
    
}