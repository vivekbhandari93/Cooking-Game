using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public delegate void CounterPlayerInteractAnimation();
    public event CounterPlayerInteractAnimation OnCounterPlayerInteractAnimation;

    [SerializeField]
    Transform kitchenObjectHolder;

    public KitchenObject CurrentKitchenObject { get; set; }

    public virtual void Interact(Player player)
    {
        OnCounterPlayerInteractAnimation?.Invoke();
    }

    public Transform GetKitchenObjectFollowTransfrom()
    {
        return kitchenObjectHolder;
    }
}
