using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectedCounterVisual : MonoBehaviour
{
    const string KitchenCounter = "KitchenCounter";

    [SerializeField]
    Material defaultMaterial;
    [SerializeField]
    Material selectedMaterial;

    ClearCounter clearCounter;

    private void Awake()
    {
        clearCounter = gameObject.GetComponent<ClearCounter>();
    }

    private void Start()
    {
        Player.Instance.OnSelectedCounterVisualChanged += Instance_OnSelectedCounterVisualChanged;
    }

    private void Instance_OnSelectedCounterVisualChanged(ClearCounter counter)
    {

        MeshRenderer meshRenderer = clearCounter.transform.Find(KitchenCounter).GetComponent<MeshRenderer>();
        meshRenderer.materials = new Material[] { };
        if (counter == clearCounter)
        {
            meshRenderer.materials = new Material[] { defaultMaterial, selectedMaterial };

        }
        else
        {
            clearCounter.transform.Find(KitchenCounter).GetComponent<MeshRenderer>().material = defaultMaterial;
        }
        
    }
}
