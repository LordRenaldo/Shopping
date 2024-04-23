using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gestordelista : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBotton;
    [SerializeField]
    GameObject content;
    Vector3 ultimaPosicion;
    [SerializeField]
    float diferencia = 400f;

    // Start is called before the first frame update
    void Start ()
    {

        ultimaPosicion = Vector3.zero;
        List<string> listaFrutas = CreateListOfFruitsAndVegetables ();
        List<string> listaMercado = CreateAListOfNonPerishable ();
        List<string> todosLosProductos = CreateListOfAllArticles (listaMercado, listaFrutas);

        foreach (string articulos in todosLosProductos) 
        {
           
            StartCoroutine (InstanciarBoton (articulos));
         
        }

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

        List<string> ListaTotal= SortAlphabetically (newlist);
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
    IEnumerator InstanciarBoton ( string nombreArticulo )
    {
        yield return new WaitForSeconds (1);

        GameObject boton = Instantiate (prefabBotton,content.transform);

        TextMeshProUGUI textoBoton = boton.GetComponentInChildren<TextMeshProUGUI> ();
        textoBoton.text = nombreArticulo;

        boton.transform.localPosition = ultimaPosicion;
        ultimaPosicion -= new Vector3 (0f, diferencia, 0f);
    }

}

