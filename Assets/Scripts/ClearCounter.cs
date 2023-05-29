using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    const string Object_Holder = "ObjectHolder";

    [SerializeField]
    KitchenObjectSO kitchenObjectSO;
    Transform kitchenObjectHolder;

    public KitchenObject CurrentKitchenObject { get; set; }

    private void Start()
    {
        kitchenObjectHolder = transform.Find(Object_Holder);
    }

    public void Interact(Player _player)
    {
        if (CurrentKitchenObject == null)
        {
            GameObject objectInstance = Instantiate(kitchenObjectSO.prefab, kitchenObjectHolder);
            objectInstance.GetComponent<KitchenObject>().KitchenObjectParent = this;
        }
        else
        {
            CurrentKitchenObject.KitchenObjectParent = _player;
        }
    }


    public Transform GetKitchenObjectFollowTransfrom()
    {
        return kitchenObjectHolder;
    }
}
