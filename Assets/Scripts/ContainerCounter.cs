using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter 
{
    [SerializeField]
    KitchenObjectSO kitchenObjectSO;
 

    public override void Interact(Player _player)
    {
        if (_player.CurrentKitchenObject) { return; }

        base.Interact(_player);

        GameObject objectInstance = Instantiate(kitchenObjectSO.prefab);
        objectInstance.GetComponent<KitchenObject>().KitchenObjectParent = _player;
    }

}
