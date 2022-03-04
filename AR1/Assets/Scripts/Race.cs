using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Race : MonoBehaviour
{
    private Button button;

    private ProgrammManager ProgrammManagerScript;

    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(StartRaceFunction);
    }


    void StartRaceFunction()
    {
        ProgrammManagerScript.ScrollView.SetActive(false);
        ProgrammManagerScript.Button1.SetActive(false);
        ProgrammManagerScript.Button1.SetActive(false);
        ProgrammManagerScript.Button2.SetActive(false);
        ProgrammManagerScript.Joystic.SetActive(true);
    }
}
