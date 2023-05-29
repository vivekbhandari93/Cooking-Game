using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public KitchenObject CurrentKitchenObject { get; set; }

    public Transform GetKitchenObjectFollowTransfrom();
}
