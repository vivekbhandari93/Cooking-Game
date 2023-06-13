using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    KitchenObjectSO kitchenObjectSO;
    public KitchenObjectSO KitchenObjectSO { get; }


    IKitchenObjectParent kitchenObjectParent;
    public IKitchenObjectParent KitchenObjectParent
    {
        get
        {
            return kitchenObjectParent;
        }

        set
        {
            if (kitchenObjectParent != null) kitchenObjectParent.CurrentKitchenObject = null;
            kitchenObjectParent = value;
            transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransfrom();
            transform.localPosition = Vector3.zero;
            kitchenObjectParent.CurrentKitchenObject = this; 

        }
    }
}
