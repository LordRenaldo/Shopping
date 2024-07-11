using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gestordelista : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textPrefab;
    [SerializeField]
    float diferencia = 400f;
    [SerializeField]
    GameObject content;
    [HideInInspector]
    Vector3 ultimaPosicion;
    [HideInInspector]
    public List<string> listaFinal = new List<string> ();
    Gestordebotones gestordebotones;
    [HideInInspector]
    public Gestordearchivos gestordearchivos;
    [SerializeField]
    public GameObject dropdown;
    [HideInInspector]
    public string articulo;

    void Awake ()
    {
        gestordebotones = FindObjectOfType<Gestordebotones> ();
        gestordearchivos = FindObjectOfType<Gestordearchivos> ();
    }

    public List<string> CreateListOfAllArticles ( List<string> list1P, List<string> list2P )
    {
        var newlist = new List<string> (list1P);
        newlist.AddRange (list2P);
        newlist.Sort ();
        return newlist;
    }

    public List<string> CreateAListOfNonPerishable ()
    {
        var articles = new List<string>
            {
                "Arroz", "Fideos", "Laminas de pasticho", "Azucar", "Sal", "Leche liquida", "Leche en polvo", "Harina pan",
                "Harina maiz", "Harina pizza", "Harina leudante", "Pure de tomate", "Yogur Liquido", "Yogur firme", "Salchicha",
                "Pan de pancho", "Mostaza", "Mayonesa", "Ketchup", "Manteca", "Margarina", "Grasa vegetal", "Poroto", "Pochoclo","Leña","Carbon","Alcohol en gel","Alcohol","Papel higienico","Jabon","Detergente","Desodorante","Shampoo","Acondicionador","Crema dental","Cepillo de dientes","Pasta dental","Pasta","ajo en polvo","Cebolla en polvo","Pimienta","Pimenton en polvo","Oregano","Comino","Curry","Canela","7 Especies","Sal fina","Sal gruesa","Azucar impalpable","Azucar negra","Azucar rubia","Azucar comun","Azucar light","Azucar de panela","fosforos","Pure de tomate"
            };
        articles.Sort ();
        return articles;
    }

    public List<string> CreateListOfFruitsAndVegetables ()
    {
        var fruitsAndVegetables = new List<string>
            {
                "Acelga", "Aji amarillo", "Aji jalapeño", "Aji picante", "Aji rocoto", "Aji rojo", "Ajo", "Albahaca", "Alfalfa",
                "Anana", "Arandanos", "Banana", "Berenjena", "Berros", "Brocoli", "Bruselas", "Camote", "Cebolla blanca",
                "Cebolla escabeche", "Cebolla morada", "Cereza", "Chirimoya", "Choclo", "Cilantro", "Ciruela", "Coco",
                "Huevo codorniz", "Coliflor", "Zapallo Coreano", "Zapallo italiano", "Zapallo redondo", "Nispero", "Sandia",
                "Damasco", "Durazno blanco", "Durazno amarillo", "Durazno chato", "Durazno pelon", "Durazno prisco", "Echalote",
                "Escarola", "Esparragos", "Espinaca", "Berenjena BB", "Espinaca BB", "Franbuesa", "Frutilla", "Jengibre", "Habas",
                "Kiwi", "Laurel", "Lechuga mante", "Lechuga morada", "Lechuga repollada", "Lechuga romana", "Lechuga rulito",
                "Lima", "Limon", "Limon regilla", "Mandarina", "Mandioca", "Mango", "Manzana roja", "Manzana verde", "Melon",
                "Menbrillo", "Moras", "Nabos", "Naranja jugo", "Naranja", "Palta", "Papa", "Papa lavada", "Papa resto", "Papa roja",
                "Papaya", "Papin", "Pepinillo","Pepino", "Pera", "Perejil", "Pimiento amarillo", "Pimiento Rojo",
                "Pimiento verde", "Platano", "Pomelo", "Puerro", "Rabanito", "Remolacha", "Repollo blanco", "Repollo morado",
                "Romero", "Rucula", "Tomate perita", "Tomate", "Tomillo", "Menta", "Uva red globe", "Uva moscatela", "Uva blanca",
                "Apio españa", "Verdeo", "Zanahoria", "Zanahoria bb", "Zanahoria "
            };
        fruitsAndVegetables.Sort ();
        return fruitsAndVegetables;
    }

    public void addToNewList ( string ArticuloP )
    {
        var ScrollView = GameObject.Find ("Scroll View");
        ScrollView.SetActive (false);
        gestordebotones.ChangePanel (1);
        articulo = ArticuloP;
    }

    public void PrintFinalListItems ( List<string> listaFinalP )
    {
        Debug.Log ("Lista de compras final");
        foreach (var item in listaFinalP)
        {
            Debug.Log (item);
        }
    }

    public void DisplayFinalListItems ()
    {
        string mensaje = "Lista";

        gestordebotones.titulo.text = mensaje;


        if (content == null)
        {
            Debug.LogError ("El objeto 'content' no existe.");
            return;
        }

        foreach (var item in listaFinal)
        {
            if (textPrefab == null)
            {
                Debug.LogError ("textPrefab no está asignado.");
                return;
            }

            var newText = Instantiate (textPrefab, content.transform);
            newText.transform.localPosition = ultimaPosicion;
            ultimaPosicion -= new Vector3 (0f, diferencia, 0f);
            newText.text = item;
        }
    }

    public void DisplayLastList ()
    {
        gestordebotones.ChangeOfScene (2);
        Destroy (dropdown);
        Gestordearchivos gestordearchivos = FindObjectOfType<Gestordearchivos> ();
        List<string> ultimaLista = gestordearchivos.ReadListOfFile ();


        foreach (string elemento in ultimaLista)
        {
            Debug.Log (elemento);
        }

        foreach (var item in ultimaLista)
        {
            if (textPrefab == null)
            {
                Debug.LogError ("textPrefab no está asignado.");
                return;
            }
            Debug.Log ("entro en instanciar lista");
            var newText = Instantiate (textPrefab, content.transform);
            newText.transform.localPosition = ultimaPosicion;
            ultimaPosicion -= new Vector3 (0f, diferencia, 0f);
            newText.text = item;
        }

    }

    public void SendList ()
    {

        gestordebotones.ReceiveAndPrintList (listaFinal);
        gestordebotones.instantiateExportListButton ();
    }

    public void Dropdown ()
    {
        var dropdown = GameObject.Find ("Dropdown");
        var dropdownComponent = dropdown.GetComponent<TMP_Dropdown> ();
        var selectedValue = dropdownComponent.options [dropdownComponent.value].text;
        var list1 = CreateAListOfNonPerishable ();
        var list2 = CreateListOfFruitsAndVegetables ();
        var list3 = CreateListOfAllArticles (list1, list2);

        foreach (Transform child in content.transform)
        {
            GameObject.Destroy (child.gameObject);
        }

        if (selectedValue == "Todos los articulos")
        {

            foreach (var item in list3)
            {
                gestordebotones.InstantiateButton (item);
            }
        }

        else if (selectedValue == "Super mercado")
        {

            foreach (var item in list1)
            {
                gestordebotones.InstantiateButton (item);
            }
        }
        else if (selectedValue == "Frutas y verduras")
        {

            foreach (var item in list2)
            {
                gestordebotones.InstantiateButton (item);
            }
        }
    }
}







