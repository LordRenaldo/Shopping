using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordebotones : MonoBehaviour
{

    public void ChangeOfScene ( int scenaP )
    {
        SceneManager.LoadScene (scenaP);
    }
    public void DestroyButton ( GameObject button )
    {
        Debug.Log ("Destroy llamado");
        Destroy (button);
    }
}
