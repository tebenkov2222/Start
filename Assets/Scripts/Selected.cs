using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    public GameObject[] UI;
    public void EnableUI(int n)
    {
        for (int i = 0; i < UI.Length; ++i) UI[i].SetActive(false);
        UI[n].SetActive(true);
    }
}
