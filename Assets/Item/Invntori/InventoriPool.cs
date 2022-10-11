using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RPG.InventorySystem
{
    public class InventoriPool
    {
        private List<GameObject> _items;

        public InventoriPool(GameObject[] item)
        {
            foreach (var obj in item)
            {
                _items.Add(obj.gameObject);
            }
            _items = new List<GameObject>(item);
        }

        public GameObject Get()
        {
            foreach (var obj in _items)
            {
                if (obj.activeSelf == false)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
            throw new InvalidOperationException("no items in pull");
        }

        public void Push(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}
