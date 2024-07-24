using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Bullet
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject objectPrefab;
        public int initialPoolSize = 10;
        private List<GameObject> pool;

        [Inject] private IObjectResolver iObjResolved;
    
        void Start()
        {
            pool = new List<GameObject>();
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject obj = iObjResolved.Instantiate(objectPrefab);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }

        public GameObject GetObject()
        {
            foreach (GameObject obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }

            GameObject newObj = Instantiate(objectPrefab);
            newObj.SetActive(false);
            pool.Add(newObj);
            newObj.SetActive(true);
            return newObj;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}