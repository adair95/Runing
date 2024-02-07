using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena : MonoBehaviour
{
    public void CambiarEscena(int valor)
    {
       SceneManager.LoadScene(valor);
    }
}
