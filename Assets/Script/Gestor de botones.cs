using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordebotones : MonoBehaviour
{

    public void ChangeOfScene ( int scenaP )
    {
        SceneManager.LoadScene (scenaP);
    }
    public void addToNewList ()
    {
        Debug.Log ("lo logre!!!!");
    }


    private void OnMouseDown ()
    {

    }
}
