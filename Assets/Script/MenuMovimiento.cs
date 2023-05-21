using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuMovimiento : MonoBehaviour
{
    public GameObject objectToShow;

    private void Update()
    {
        if (Keyboard.current.iKey.isPressed)
        {
            objectToShow.SetActive(true);
        }
        else
        {
            objectToShow.SetActive(false);
        }
    }
}
