using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    [SerializeField]
    private GameObject Lock;

    private Transform keyCardTransform = null;

    private Vector3 enterPosition;
    private Vector3 exitPosition;

    private bool validSwap;


    //DEBUG
    public TextMeshProUGUI dotText;
    public TextMeshProUGUI etoText;
    private void Update()
    {
        /* 
         * Ogni frame devo controllare che
         * 1) La carta sia entrata nel lettore (valorizza KeyCardTransform)
         * 2) Devo controllare che la punti verso la direzione del lettore (dall'alto verso il basso) (Vector3.Dot)
         * 3) Se non è parallela lo swap non è valido
         * NB UTILIZZA IL SISTEMA GLOBALE E NON QUELLO LOCALE
        */
        if(keyCardTransform != null)
        {
            Vector3 keyCardUp = keyCardTransform.forward;
            float dot = Vector3.Dot(keyCardUp, Vector3.up);
            dotText.SetText($"DOT: ${dot}");
            if (dot < 0.90)
            {
                validSwap = false;
            }
        }
    }

    //questo disabilita la funziona di attach della socket
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return false;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        //Salvo i dati globali della carta
        keyCardTransform = args.interactableObject.transform;

        //Prendo la posizione globale della carta
        enterPosition = keyCardTransform.position;
        validSwap = true;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        //Prendo la posizione di uscita a livello globale
        exitPosition = args.interactableObject.transform.position;
        Vector3 entryToExit = exitPosition - enterPosition;
        etoText.SetText($"ETO: {entryToExit.y}");
        if(validSwap && entryToExit.y < -0.15f)
        {
            Lock.gameObject.SetActive(false);
        }
        keyCardTransform = null;
    }
}
