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

    void Start ()
    {

    }

    void Awake ()
    {

    }

    public List<string> CreateListOfAllArticles ( List<string> list1P, List<string> list2P )
    {
        var newlist = new List<string> (list1P);
        newlist.AddRange (list2P);
        newlist.Sort ();
        newlist.Reverse ();
        return newlist;
    }

    public List<string> CreateAListOfNonPerishable ()
    {
        var articles = new List<string>
            {
                "Arroz", "Fideos", "Laminas de pasticho", "Azucar", "Sal", "Leche liquida", "Leche en polvo", "Harina pan",
                "Harina maiz", "Harina pizza", "Harina leudante", "Pure de tomate", "Yogur Liquido", "Yogur firme", "Salchicha",
                "Pan de pancho", "Mostaza", "Mayonesa", "Ketchup", "Manteca", "Margarina", "Grasa vegetal", "Poroto", "Pochoclo"
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
                "Papaya", "Papin", "Pepinillo", "Oregano", "Pepino", "Pera", "Perejil", "Pimiento amarillo", "Pimiento Rojo",
                "Pimiento verde", "Platano", "Pomelo", "Puerro", "Rabanito", "Remolacha", "Repollo blanco", "Repollo morado",
                "Romero", "Rucula", "Tomate perita", "Tomate", "Tomillo", "Menta", "Uva red globe", "Uva moscatela", "Uva blanca",
                "Apio españa", "Verdeo", "Zanahoria", "Zanahoria bb", "Zanahoria ", "Leña"
            };
        fruitsAndVegetables.Sort ();
        return fruitsAndVegetables;
    }

    public void addToNewList ( string ArticuloP )
    {
        listaFinal.Add (ArticuloP);
        Debug.Log (ArticuloP + " Agregado a la lista de compras");
    }

    public void PrintFinalListItems ()
    {
        Debug.Log ("Lista de compras final");
        foreach (var item in listaFinal)
        {
            Debug.Log (item);
        }
    }

    public void DisplayFinalListItems ()
    {
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

    public void SendList ()
    {
        var gestordebotones = FindObjectOfType<Gestordebotones> ();
        gestordebotones.ReceiveAndPrintList (listaFinal);
    }
}







