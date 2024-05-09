using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gestordebotones : MonoBehaviour
{
    [SerializeField]
    Button prefabBotton;
    [SerializeField]
    GameObject content;
    Vector3 ultimaPosicion;
    [SerializeField]
    float diferencia = 400f;
    private Gestordelista gestordelista;
    private List<string> todosLosProductos;
    private void Awake ()
    {
        gestordelista = FindObjectOfType<Gestordelista> ();
    }

    public void Start ()
    {
        ultimaPosicion = Vector3.zero;
        todosLosProductos = gestordelista.CreateListOfAllArticles (gestordelista.CreateAListOfNonPerishable (), gestordelista.CreateListOfFruitsAndVegetables ());

        foreach (var articulos in todosLosProductos)
        {
            InstantiateButton (articulos);
        }
    }
    public void ChangeOfScene ( int scenaP )
    {
        SceneManager.LoadScene (scenaP);
    }
    public void Retrea ()//aqui genio, el problema es aqui!!!
    {
        SceneManager.LoadScene (1);
        todosLosProductos = gestordelista.CreateListOfAllArticles (gestordelista.CreateAListOfNonPerishable (), gestordelista.CreateListOfFruitsAndVegetables ());
        foreach (var articulos in todosLosProductos)
        {
            Debug.Log ("entro el el ciclo de retrea");
            InstantiateButton (articulos);
        }
    }
    public void ReceiveAndPrintList ( List<string> listaRecibidaP )
    {
        foreach (string elemento in listaRecibidaP)
        {
            Debug.Log (elemento);
        }

        var botones = GameObject.FindGameObjectsWithTag ("Button list");
        foreach (var boton in botones)
        {
            Destroy (boton);
        }

        gestordelista.DisplayFinalListItems ();
        var BotonCrearLista = GameObject.Find ("Button crear lista");
        var textNewBoton = BotonCrearLista.GetComponentInChildren<TextMeshProUGUI> ();
        textNewBoton.text = "Volver a la lista";
        BotonCrearLista.GetComponent<Button> ().onClick.AddListener (() => { ChangeOfScene (1); });

    }
    private void InstantiateButton ( string nombreArticuloP )
    {
        Debug.Log ("entro en el ciclo de instanciar botones");
        var newButton = Instantiate (prefabBotton, content.transform);
        newButton.onClick.AddListener (() =>
        {
            gestordelista.addToNewList (nombreArticuloP);
            Destroy (newButton.gameObject);
        });

        var textNewBoton = newButton.GetComponentInChildren<TextMeshProUGUI> ();
        textNewBoton.text = nombreArticuloP;

        newButton.transform.localPosition = ultimaPosicion;
        ultimaPosicion -= new Vector3 (0f, diferencia, 0f);
    }

    public void ExitApp ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        Debug.Log ("Aplicación cerrada");
    }
}



