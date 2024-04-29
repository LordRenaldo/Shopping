using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordebotones : MonoBehaviour
{
    public void ChangeOfScene ( int scenaP )
    {
        SceneManager.LoadScene (scenaP);
    }

}
