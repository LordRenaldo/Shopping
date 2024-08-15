using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class Gestordebotones : MonoBehaviour
{
    [Header ("Paneles")]
    [SerializeField]
    GameObject scrollView;
    [SerializeField]
    GameObject panel1;
    [SerializeField]
    GameObject panel2;
    [SerializeField]
    GameObject panel3;
    [SerializeField]
    GameObject panelSalir;
    [Space (10)]

    [Header ("Botones panel 1")]
    [SerializeField]
    Button kilogramos;
    [SerializeField]
    Button unidades;
    [Space (10)]

    [Header ("Botones panel 2")]
    [SerializeField]
    Button subir;
    [SerializeField]
    Button bajar;
    [SerializeField]
    TextMeshProUGUI textNumero;
    [Space (10)]

    [Header ("Botones panel 3")]
    [SerializeField]
    Button SI;
    [SerializeField]
    Button NO;
    [Space (10)]

    [Header ("Botones panel 4")]
    [SerializeField]
    Button salirSI;
    [SerializeField]
    Button salirNO;

    [Header ("Componentes de la U.I.")]
    [SerializeField]
    public TextMeshProUGUI titulo;
    [SerializeField]
    Transform canvas;
    [SerializeField]
    public TextMeshProUGUI textInformativo;
    [SerializeField]
    Button prefabBotton;
    [SerializeField]
    Button prefabBotton2;
    [SerializeField]
    GameObject content;
    [SerializeField]
    float diferencia = 400f;
    [SerializeField]
    GameObject BotonCrearLista;
    [HideInInspector]
    public float cantidad = 1f;
    [HideInInspector]
    public string buttonText;
    [Space (40)]
    Vector3 ultimaPosicion;
    [HideInInspector]
    public Gestordelista gestordelista;
    private List<string> todosLosProductos;
    [HideInInspector]
    public string mensaje;
    [HideInInspector]
    Gestordearchivos gestordearchivos;

    private void Awake ()
    {
        gestordelista = FindObjectOfType<Gestordelista> ();
        gestordearchivos = FindObjectOfType<Gestordearchivos> ();
    }

    public void Start ()
    {
        panel1.SetActive (false);
        panel2.SetActive (false);
        panel3.SetActive (false);
        panelSalir.SetActive (false);
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

    public void Retrea ()
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
        var botonCrearlista = GameObject.Find ("Button crear lista");
        Destroy (botonCrearlista);
        foreach (string elemento in listaRecibidaP)
        {
            Debug.Log (elemento);
        }

        var botones = GameObject.FindGameObjectsWithTag ("Button list");
        foreach (var boton in botones)
        {
            Destroy (boton);
        }
        mensaje = "";
        textInformativo.text = mensaje;
        gestordelista.DisplayFinalListItems ();

        Vector3 posicion = new Vector3 (-1.5f, -4.25f, 0f);
        Quaternion rotacion = Quaternion.identity;
        var BotonVolver = Instantiate (prefabBotton2, posicion, rotacion, canvas);
        RectTransform rectTransform = BotonVolver.GetComponent<RectTransform> ();
        rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, rectTransform.localPosition.y, 0);
        var textBotonVolver = BotonVolver.GetComponentInChildren<TextMeshProUGUI> ();
        textBotonVolver.text = "Volver a la lista";
        BotonVolver.GetComponent<Button> ().onClick.AddListener (() => { ChangeOfScene (1); });

    }

    public void instantiateExportListButton ()
    {
        Vector3 posicion = new Vector3 (1f, -4.25f, 0f);
        Quaternion rotacion = Quaternion.identity;
        var BotonExportarLista = Instantiate (prefabBotton2, posicion, rotacion, canvas);
        RectTransform rectTransform = BotonExportarLista.GetComponent<RectTransform> ();
        rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, rectTransform.localPosition.y, 0);
        BotonExportarLista.GetComponent<Button> ().onClick.AddListener (() => { gestordearchivos.SaveListToFile (gestordelista.listaFinal); });

    }

    public void InstantiateButton ( string nombreArticuloP )
    {
        Debug.Log ("entro en el ciclo de instanciar botones");

        // Verifica si es el primer botón a instanciar ajustando su posición inicial
        if (ultimaPosicion == Vector3.zero)
        {
            ultimaPosicion -= new Vector3 (0f, diferencia / 2, 0f);
        }

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

    public void ChangePanel ( int panelP )
    {
        if (panelP == 0)
        {
            BotonCrearLista.SetActive (true);
            scrollView.SetActive (true);
            panel1.SetActive (false);
            panel2.SetActive (false);
            panel3.SetActive (false);
            panelSalir.SetActive (false);
        }
        else if (panelP == 1)
        {
            BotonCrearLista.SetActive (false);
            panel1.SetActive (true);
            panel2.SetActive (false);
            panel3.SetActive (false);
            panelSalir.SetActive (false);
        }
        else if (panelP == 2)
        {
            BotonCrearLista.SetActive (false);
            panel1.SetActive (false);
            panel2.SetActive (true);
            panel3.SetActive (false);
            panelSalir.SetActive (false);
        }
        else if (panelP == 3)
        {
            BotonCrearLista.SetActive (false);
            panel1.SetActive (false);
            panel2.SetActive (false);
            panel3.SetActive (true);
            panelSalir.SetActive (false);
        }
        else if (panelP == 4)
        {
            BotonCrearLista.SetActive (false);
            panel1.SetActive (false);
            panel2.SetActive (false);
            panel3.SetActive (false);
            panelSalir.SetActive (true);
        }
    }

    public void ButtonClicked ( Button buttonP )
    {
        TextMeshProUGUI textMeshComponent = buttonP.GetComponentInChildren<TextMeshProUGUI> ();
        if (textMeshComponent != null)
        {
            // Almacenar el texto del botón en la variable de instancia
            buttonText = textMeshComponent.text;
            Debug.Log ("Texto del botón: " + buttonText);
        }
        ChangePanel (2);
    }

    public void QuantitySelector ( Button buttonP )
    {
        if (buttonP.name == "Button subir")
        {
            cantidad++;
        }
        else if (buttonP.name == "Button bajar")
        {
            cantidad--;
        }

        textNumero.text = cantidad.ToString ();

        if (cantidad <= 0)
        {
            cantidad = 0;
            bajar.interactable = false;
        }
        else
        {
            bajar.interactable = true;
        }
    }

    public void ButtonOK ()
    {
        mensaje = $"Se ha agregado  {cantidad}  {buttonText} de {gestordelista.articulo} a la lista.";

        gestordelista.listaFinal.Add (gestordelista.articulo + " " + cantidad + " " + buttonText + ".");

        textInformativo.text = mensaje;
        Debug.Log (gestordelista.articulo + " " + cantidad + " " + buttonText + " agregado a la lista.");

        ChangePanel (0);
        cantidad = 1;
        textNumero.text = "1";
    }

    public void ButtonSalir ()
    {
        ChangePanel (4);
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



