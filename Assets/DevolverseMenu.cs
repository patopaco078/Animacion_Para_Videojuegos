using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DevolverseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        // Suscribirse a los eventos del Input System
        Keyboard.current.onTextInput += OnTextInput;
    }
    private void OnDisable()
    {
        // Desuscribirse de los eventos del Input System
        Keyboard.current.onTextInput -= OnTextInput;
    }
    // Start is called before the first frame update
    private void OnTextInput(char character)
    {
        // Verificar si se presiona la tecla 1
        if (character == (char)27)
        {
            SceneManager.LoadScene("Menu Inicial"); // Reemplaza "Escena1" con el nombre de tu primera escena
        }

    }
}
