using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CounterMeshData
{
    public CounterMeshRenderer meshRenderer;
    public CounterMeshMaterial meshMaterial;
    
}

[System.Serializable]
public class CounterMeshRenderer
{
    public MeshRenderer kitchenCounterRenderer;
}

[System.Serializable]
public class CounterMeshMaterial
{
    public Material defaultMaterial;
    public Material selectedMaterial;
}

[System.Serializable]
public class CounterInteractAnimation
{
    public Animator animator;
    public string name;
}



public class SelectedCounterVisualAnimation : MonoBehaviour
{

    public List<CounterMeshData> counterMeshData = new List<CounterMeshData>();
    public CounterInteractAnimation counterInteractAnimation;


    BaseCounter selectedCounter;

    private void Awake()
    {
        selectedCounter = gameObject.GetComponent<BaseCounter>();
    }

    private void Start()
    {
        Player.Instance.OnSelectedCounterVisualChanged += Instance_OnSelectedCounterVisualChanged;
        selectedCounter.OnCounterPlayerInteractAnimation += SelectedCounter_OnCounterPlayerInteractAnimation;
    }

    private void Instance_OnSelectedCounterVisualChanged(BaseCounter counter)
    {

        foreach(CounterMeshData meshData in counterMeshData)
        {
            meshData.meshRenderer.kitchenCounterRenderer.materials = new Material[] { };
            if (counter == selectedCounter)
            {
                meshData.meshRenderer.kitchenCounterRenderer.materials = new Material[] { meshData.meshMaterial.defaultMaterial, meshData.meshMaterial.selectedMaterial };

            }
            else
            {
                meshData.meshRenderer.kitchenCounterRenderer.material = meshData.meshMaterial.defaultMaterial;
            }
        }
    }

    private void SelectedCounter_OnCounterPlayerInteractAnimation()
    {
        counterInteractAnimation.animator.SetBool(counterInteractAnimation.name, counterInteractAnimation.animator);
    }

}
