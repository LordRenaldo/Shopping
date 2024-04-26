using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordebotones : MonoBehaviour
{

    public void ChangeOfScene ( int scenaP )
    {
        SceneManager.LoadScene (scenaP);
    }

    //necesita un metodo para destruir un boton
    public void DestroyButton ( GameObject botonP )
    {
        Destroy (botonP);
    }
}
