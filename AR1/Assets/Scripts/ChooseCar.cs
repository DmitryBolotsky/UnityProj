using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCar : MonoBehaviour
{
    private ProgrammManager ProgrammManagerScript;

    private Button button;

    public GameObject ChoosedCar;

    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(ChoosingCar);
    }

    void ChoosingCar()
    {
        ProgrammManagerScript.CarToSpawn = ChoosedCar;
        ProgrammManagerScript.ChooseObject = true;
        ProgrammManagerScript.ScrollView.SetActive(false);
    }
}
