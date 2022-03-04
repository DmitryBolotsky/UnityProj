using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{
    private Button button;

    private ProgrammManager ProgrammManagerScript;

    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(AddObjectFunction);
    }

    
    void AddObjectFunction()
    {
        ProgrammManagerScript.ScrollView.SetActive(true);
    }
}
