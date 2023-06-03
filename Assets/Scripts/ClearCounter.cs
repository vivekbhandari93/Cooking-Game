using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{

    public override void Interact(Player _player)
    {
        if(!CurrentKitchenObject && _player.CurrentKitchenObject)
        {
            _player.CurrentKitchenObject.KitchenObjectParent = this;
        }
        else if(CurrentKitchenObject && !_player.CurrentKitchenObject)
        {
            CurrentKitchenObject.KitchenObjectParent = _player;
        }
    }
}
