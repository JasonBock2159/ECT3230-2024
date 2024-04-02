using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //Public Variables for Menu to quick reference
    //Creating Property values. Encapulation variable
    //Get Accessor (read)
    //Set Accessor (write)

    [field: SerializeField]
    public Button ResumeButton {  get; set; }
    [field: SerializeField]
    public Button RestartButton { get; set; }

    [field: SerializeField]
    public TextMeshProUGUI SolvedText { get; set; }
}
