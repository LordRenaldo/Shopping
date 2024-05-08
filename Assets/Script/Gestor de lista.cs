using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gestordelista : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPrefab;
    [SerializeField]
    Button prefabBotton;
    [SerializeField]
    GameObject content;
    Vector3 ultimaPosicion;
    [SerializeField]
    float diferencia = 400f;

    [HideInInspector]
    public List<string> listaFinal = new List<string> ();

    public TextMeshProUGUI TextPrefab { get => textPrefab; set => textPrefab = value; }
    public Button PrefabBotton { get => prefabBotton; set => prefabBotton = value; }
    public GameObject Content { get => content; set => content = value; }
    public Vector3 UltimaPosicion { get => ultimaPosicion; set => ultimaPosicion = value; }
    public float Diferencia { get => diferencia; set => diferencia = value; }
    public List<string> ListaFinal { get => listaFinal; set => listaFinal = value; }


    // Start is called before the first frame update
    void Start ()
    {
        ultimaPosicion = Vector3.zero;
        List<string> listaFrutas = CreateListOfFruitsAndVegetables ();
        List<string> listaMercado = CreateAListOfNonPerishable ();
        List<string> todosLosProductos = CreateListOfAllArticles (listaMercado, listaFrutas);

        foreach (string articulos in todosLosProductos)
        {
            InstantiateButton (articulos);
        }

    }
    void Awake ()
    {

        DontDestroyOnLoad (this.gameObject);

    }

    // Update is called once per frame
    void Update ()
    {

    }
    private List<string> CreateListOfAllArticles ( List<string> list1P, List<string> list2P )
    {
        List<string> newlist = new List<string> ();

        newlist.AddRange (list1P);
        newlist.AddRange (list2P);

        List<string> ListaTotal = SortAlphabetically (newlist);
        ListaTotal.Reverse ();
        return ListaTotal;
    }
    private List<string> CreateAListOfNonPerishable ()
    {
        List<string> articles = new List<string> ();

        articles.Add ("Arroz");
        articles.Add ("Fideos");
        articles.Add ("Laminas de pasticho");
        articles.Add ("Azucar");
        articles.Add ("Sal");
        articles.Add ("Leche liquida");
        articles.Add ("Leche en polvo");
        articles.Add ("Harina pan");
        articles.Add ("Harina maiz");
        articles.Add ("Harina pizza");
        articles.Add ("Harina leudante");
        articles.Add ("Pure de tomate");
        articles.Add ("Yogur Liquido");
        articles.Add ("Yogur firme");
        articles.Add ("Salchicha");
        articles.Add ("Pan de pancho");
        articles.Add ("Mostaza");
        articles.Add ("Mayonesa");
        articles.Add ("Ketchup");
        articles.Add ("Manteca");
        articles.Add ("Margarina");
        articles.Add ("Grasa vegetal");
        articles.Add ("Poroto");
        articles.Add ("Pochoclo");

        articles = SortAlphabetically (articles);

        return articles;
    }
    private List<string> CreateListOfFruitsAndVegetables ()
    {
        List<string> fruitsAndVegetables = new List<string> ();

        fruitsAndVegetables.Add ("Acelga");
        fruitsAndVegetables.Add ("Aji amarillo");
        fruitsAndVegetables.Add ("Aji jalapeño");
        fruitsAndVegetables.Add ("Aji picante");
        fruitsAndVegetables.Add ("Aji rocoto");
        fruitsAndVegetables.Add ("Aji rojo");
        fruitsAndVegetables.Add ("Ajo");
        fruitsAndVegetables.Add ("Albahaca");
        fruitsAndVegetables.Add ("Alfalfa");
        fruitsAndVegetables.Add ("Anana");
        fruitsAndVegetables.Add ("Arandanos");
        fruitsAndVegetables.Add ("Banana");
        fruitsAndVegetables.Add ("Berenjena");
        fruitsAndVegetables.Add ("Berros");
        fruitsAndVegetables.Add ("Brocoli");
        fruitsAndVegetables.Add ("Bruselas");
        fruitsAndVegetables.Add ("Camote");
        fruitsAndVegetables.Add ("Cebolla blanca");
        fruitsAndVegetables.Add ("Cebolla escabeche");
        fruitsAndVegetables.Add ("Cebolla morada");
        fruitsAndVegetables.Add ("Cereza");
        fruitsAndVegetables.Add ("Chirimoya");
        fruitsAndVegetables.Add ("Choclo");
        fruitsAndVegetables.Add ("Cilantro");
        fruitsAndVegetables.Add ("Ciruela");
        fruitsAndVegetables.Add ("Coco");
        fruitsAndVegetables.Add ("Huevo codorniz");
        fruitsAndVegetables.Add ("Coliflor");
        fruitsAndVegetables.Add ("Zapallo Coreano");
        fruitsAndVegetables.Add ("Zapallo italiano");
        fruitsAndVegetables.Add ("Zapallo redondo");
        fruitsAndVegetables.Add ("Nispero");
        fruitsAndVegetables.Add ("Sandia");
        fruitsAndVegetables.Add ("Damasco");
        fruitsAndVegetables.Add ("Durazno blanco");
        fruitsAndVegetables.Add ("Durazno amarillo");
        fruitsAndVegetables.Add ("Durazno chato");
        fruitsAndVegetables.Add ("Durazno pelon");
        fruitsAndVegetables.Add ("Durazno prisco");
        fruitsAndVegetables.Add ("Echalote");
        fruitsAndVegetables.Add ("Escarola");
        fruitsAndVegetables.Add ("Esparragos");
        fruitsAndVegetables.Add ("Espinaca");
        fruitsAndVegetables.Add ("Berenjena BB");
        fruitsAndVegetables.Add ("Espinaca BB");
        fruitsAndVegetables.Add ("Franbuesa");
        fruitsAndVegetables.Add ("Frutilla");
        fruitsAndVegetables.Add ("Jengibre");
        fruitsAndVegetables.Add ("Habas");
        fruitsAndVegetables.Add ("Kiwi");
        fruitsAndVegetables.Add ("Laurel");
        fruitsAndVegetables.Add ("Lechuga mante");
        fruitsAndVegetables.Add ("Lechuga morada");
        fruitsAndVegetables.Add ("Lechuga repollada");
        fruitsAndVegetables.Add ("Lechuga romana");
        fruitsAndVegetables.Add ("Lechuga rulito");
        fruitsAndVegetables.Add ("Lima");
        fruitsAndVegetables.Add ("Limon");
        fruitsAndVegetables.Add ("Limon regilla");
        fruitsAndVegetables.Add ("Mandarina");
        fruitsAndVegetables.Add ("Mandioca");
        fruitsAndVegetables.Add ("Mango");
        fruitsAndVegetables.Add ("Manzana roja");
        fruitsAndVegetables.Add ("Manzana verde");
        fruitsAndVegetables.Add ("Melon");
        fruitsAndVegetables.Add ("Menbrillo");
        fruitsAndVegetables.Add ("Moras");
        fruitsAndVegetables.Add ("Nabos");
        fruitsAndVegetables.Add ("Naranja jugo");
        fruitsAndVegetables.Add ("Naranja");
        fruitsAndVegetables.Add ("Palta");
        fruitsAndVegetables.Add ("Papa");
        fruitsAndVegetables.Add ("Papa lavada");
        fruitsAndVegetables.Add ("Papa resto");
        fruitsAndVegetables.Add ("Papa roja");
        fruitsAndVegetables.Add ("Papaya");
        fruitsAndVegetables.Add ("Papin");
        fruitsAndVegetables.Add ("Pepinillo");
        fruitsAndVegetables.Add ("Oregano");
        fruitsAndVegetables.Add ("Pepino");
        fruitsAndVegetables.Add ("Pera");
        fruitsAndVegetables.Add ("Perejil");
        fruitsAndVegetables.Add ("Pimiento amarillo");
        fruitsAndVegetables.Add ("Pimiento Rojo");
        fruitsAndVegetables.Add ("Pimiento verde");
        fruitsAndVegetables.Add ("Platano");
        fruitsAndVegetables.Add ("Pomelo");
        fruitsAndVegetables.Add ("Puerro");
        fruitsAndVegetables.Add ("Rabanito");
        fruitsAndVegetables.Add ("Remolacha");
        fruitsAndVegetables.Add ("Repollo blanco");
        fruitsAndVegetables.Add ("Repollo morado");
        fruitsAndVegetables.Add ("Romero");
        fruitsAndVegetables.Add ("Rucula");
        fruitsAndVegetables.Add ("Tomate perita");
        fruitsAndVegetables.Add ("Tomate");
        fruitsAndVegetables.Add ("Tomillo");
        fruitsAndVegetables.Add ("Menta");
        fruitsAndVegetables.Add ("Uva red globe");
        fruitsAndVegetables.Add ("Uva moscatela");
        fruitsAndVegetables.Add ("Uva blanca");
        fruitsAndVegetables.Add ("Apio españa");
        fruitsAndVegetables.Add ("Verdeo");
        fruitsAndVegetables.Add ("Zanahoria");
        fruitsAndVegetables.Add ("Zanahoria bb");
        fruitsAndVegetables.Add ("Zanahoria ");
        fruitsAndVegetables.Add ("Leña");

        fruitsAndVegetables = SortAlphabetically (fruitsAndVegetables);

        return fruitsAndVegetables;
    }
    private List<string> SortAlphabetically ( List<string> listP )
    {
        return listP.OrderBy (x => x).ToList ();
    }
    private void InstantiateButton ( string nombreArticulo )
    {
        GameObject manager = GameObject.Find ("Manager");
        Gestordelista script = manager.GetComponentInChildren<Gestordelista> ();
        Button newButton = Instantiate (PrefabBotton, Content.transform);
        newButton.onClick.AddListener (() =>
        {
            addToNewList (nombreArticulo);
            Destroy (newButton.gameObject);
        });

        TextMeshProUGUI textNewBoton = newButton.GetComponentInChildren<TextMeshProUGUI> ();
        textNewBoton.text = nombreArticulo;

        newButton.transform.localPosition = UltimaPosicion;
        UltimaPosicion -= new Vector3 (0f, Diferencia, 0f);
    }
    public void addToNewList ( string Articulo )
    {
        ListaFinal.Add (Articulo);
        Debug.Log (Articulo + " Agregado a la lista de compras");
    }
    public void PrintFinalListItems ()
    {
        Debug.Log ("Lista de compras final");
        foreach (string item in ListaFinal)
        {
            Debug.Log (item);
        }
    }
    public void DisplayFinalListItems ()
    {
        PrintFinalListItems ();

        foreach (string item in ListaFinal)
        {
            TextMeshProUGUI newText = Instantiate (TextPrefab, Content.transform);
            newText.transform.localPosition = UltimaPosicion;
            UltimaPosicion -= new Vector3 (0f, Diferencia, 0f);
            newText.text = item;
            Debug.Log ("DisplayFinalListItems llamado");
        }

    }
    public void SendList ()
    {
        Gestordebotones gestordebotones = FindObjectOfType<Gestordebotones> ();

        gestordebotones.ReceiveAndPrintList (listaFinal);

    }
}







