using UnityEngine;

public class Gestordeescena : MonoBehaviour
{
    Gestordebotones gestordebotones;
    void Awake ()
    {
        gestordebotones = FindObjectOfType<Gestordebotones> ();

    }
    public void ChangeScene ( int scenaID )
    {
        gestordebotones.ChangeOfScene (scenaID);
    }
    public void InstantiateLastList ()
    {

    }
}



