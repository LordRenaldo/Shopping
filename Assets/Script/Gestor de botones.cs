using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordebotones : MonoBehaviour
{
    Gestordelista Manager;
    public void ChangeOfScene ( int scenaP )
    {
        SceneManager.LoadScene (scenaP);
    }

    public void ChargeListFinal ()
    {
        SceneManager.LoadScene (2);
        Manager.DisplayFinalListItems ();
    }
}
