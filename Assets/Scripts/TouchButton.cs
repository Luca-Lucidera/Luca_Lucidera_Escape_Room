using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    [SerializeField]
    private int Value;

    private MeshRenderer ButtonMeshRenderer;
    private Material BaseMaterial;
    [SerializeField]
    private Material OnHoverMaterial;


    protected override void Awake()
    {
        base.Awake();
        BaseMaterial = GetComponent<MeshRenderer>().materials.ElementAt(0);
        ButtonMeshRenderer = GetComponent<MeshRenderer>();
    }
    /**
        1) Cambiare il colore del pulsante quando lo tocchi
    */

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        NumberPad.Instance.AddNumberToSequence(Value);
        ButtonMeshRenderer.material = OnHoverMaterial;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        ButtonMeshRenderer.material = BaseMaterial;
    }
}
