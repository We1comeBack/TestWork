using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseObject : MonoBehaviour
{
    private AimPointScript AimPointScript;

    private Button button;

    public GameObject ChoosedObject;
    void Start()
    {
        AimPointScript = FindObjectOfType<AimPointScript>();

        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseObjectFunction);
    }

    void Update()
    {
        
    }

    void ChooseObjectFunction()
    {
        AimPointScript.ObjectToPlace = ChoosedObject;
    }
}
