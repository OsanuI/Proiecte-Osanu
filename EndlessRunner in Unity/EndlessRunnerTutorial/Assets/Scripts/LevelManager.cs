using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string nume)
    {
        Debug.Log("Se incarca level-ul " + nume);
        Application.LoadLevel(nume);
    }

    public void CerereInchidere()
    {
        Debug.Log("Cerere de inchidere");
        Application.Quit();
    }
}

