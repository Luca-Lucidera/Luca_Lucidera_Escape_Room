using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    //Singleton Instance
    public static NumberPad Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI textSequence;

    [SerializeField]
    private int CorrectSequence = 1234;

    [SerializeField]
    private GameObject KeyCard;

    private string currentSequence = string.Empty;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }
    public void AddNumberToSequence(int num)
    {
        if (!KeyCard.activeSelf)
        {
            currentSequence += num.ToString();
            textSequence.SetText(currentSequence);
            if (currentSequence.Length == CorrectSequence.ToString().Length)
            {
                if (currentSequence == CorrectSequence.ToString())
                {
                    KeyCard.SetActive(true);
                    currentSequence = "";
                    textSequence.text = "Sequenza corretta!";
                }
                else
                {
                    textSequence.text = "";
                    currentSequence = "";
                }
            }
        }
    }
}
