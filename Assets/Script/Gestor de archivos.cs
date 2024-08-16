using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gestordearchivos : MonoBehaviour
{
    Gestordelista gestordelista;
    Gestordebotones gestordebotones;
    protected string archivo;
    public List<string> archivoLeido;
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
        gestordebotones.ChangePanel (3);
        Debug.Log ("El contenido del archivo es " + archivo);
    }

    public List<string> ReadListOfFile ()
    {
        archivoLeido = new List<string> (File.ReadAllLines ("Lista de compras.txt"));

        return archivoLeido;
    }

    public void CreateFile ()
    {
        File.WriteAllText ("Lista de compras.txt", archivo);
        gestordebotones.ChangePanel (3);
    }

}

