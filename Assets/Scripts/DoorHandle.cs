using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    [SerializeField]
    private GameObject Door;
    [SerializeField]
    private GameObject Lock;
    [SerializeField]
    private TextMeshProUGUI dot2;

    private Transform handTransform = null;

    private bool lockActive = true;
    private bool canMove = false;

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
       
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
    }
}
