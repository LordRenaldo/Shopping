using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordebotones : MonoBehaviour
{
    public void ChangeOfScene ( int scenaP )
    {
        SceneManager.LoadScene (scenaP);
    }

    public void ReceiveAndPrintList ( List<string> listaRecibida )
    {
        foreach (string elemento in listaRecibida)
        {
            Debug.Log (elemento);
        }

        GameObject [] botones = GameObject.FindGameObjectsWithTag ("Button list");

        foreach (GameObject boton in botones)
        {
            Debug.Log (boton + " destruido");
            Destroy (boton);
        }
        Gestordelista gestordelista = FindObjectOfType<Gestordelista> ();
        gestordelista.DisplayFinalListItems ();

    }

    public void ExitApp ()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit ();
        }
        Debug.Log ("Aplicación cerrada");
    }
}



