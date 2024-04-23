using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordebotones : MonoBehaviour
{
    public void ChangeOfScene (int scenaP) 
    {

        SceneManager.LoadScene (scenaP);
    }
}
