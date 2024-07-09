using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gestordearchivos : MonoBehaviour
{
    Gestordelista gestordelista;
    Gestordebotones gestordebotones;
    protected string archivo;
    private void Awake ()
    {
        gestordelista = FindObjectOfType<Gestordelista> ();
        gestordebotones = FindObjectOfType<Gestordebotones> ();
    }

    public string ConvertListAString<T> ( List<T> lista, string delimitador = "\n" )
    {
        return String.Join (delimitador, lista);
    }

    public void SaveListToFile<T> ( List<T> lista )
    {
        archivo = ConvertListAString (lista);
        CreateFile ();

        Debug.Log ("Línea 1\nLínea 2\nLínea 3");
        Debug.Log ("El contenido del archivo es " + archivo);
    }

    public void CreateFile ()
    {
        File.WriteAllText ("Lista de compras.txt", archivo);
    }

}

