using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class Menu : MonoBehaviour
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

    private void OnTextInput(char character)
    {
        // Verificar si se presiona la tecla 1
        if (character == '1')
        {
            SceneManager.LoadScene("DemoCoyyote"); // Reemplaza "Escena1" con el nombre de tu primera escena
        }

        // Verificar si se presiona la tecla 2
        if (character == '2')
        {
            SceneManager.LoadScene("SampleScene"); // Reemplaza "Escena2" con el nombre de tu segunda escena
        }
    }

    private void Update()
    {
        // Verificar si se presiona la tecla ESC
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("salio");
            Application.Quit();
        }
    }
}
