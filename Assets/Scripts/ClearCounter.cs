using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    const string Object_Holder = "ObjectHolder";

    [SerializeField]
    KitchenObjectSO kitchenObjectSO;
    GameObject objectHolder;


    KitchenObject kitchenObject;

    private void Start()
    {
        objectHolder = transform.Find(Object_Holder).gameObject;
    }

    public void Interact()
    {
        if (kitchenObject == null)
        {
            GameObject objectInstance = Instantiate(kitchenObjectSO.prefab, objectHolder.transform);
            objectInstance.transform.localPosition = Vector3.zero;

            kitchenObject = objectInstance.GetComponent<KitchenObject>();
            kitchenObject.ClearCounter = this;
        }
        else
        {
            Debug.Log(kitchenObject.ClearCounter);
        }
    }
}
