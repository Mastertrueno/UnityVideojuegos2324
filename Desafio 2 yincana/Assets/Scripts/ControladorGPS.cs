using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ControladorGPS : MonoBehaviour
{
    public float puntoLat, puntoLong;
    public float actualLat, actualLong;
    public decimal distancia;

    public static decimal FormulaHaversine(double lat1, double long1, double lat2, double long2)
    {
        decimal earthRad = 6371000;
        double lRad1 = lat1 * Mathf.Deg2Rad;
        double lRad2 = lat2 * Mathf.Deg2Rad;
        double dLat = (lat2 - lat1) * Mathf.Deg2Rad;
        double dLong = (long2 - long1) * Mathf.Deg2Rad;
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        Math.Cos(lRad1) * Math.Cos(lRad2) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
        decimal c = Convert.ToDecimal(2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)));
        return earthRad * c;
    }
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }
    // Update is called once per frame
    void Update()
    {
        actualLat = Input.location.lastData.latitude; 
        actualLong = Input.location.lastData.longitude;
        //actualLat = 38.988941f;
        //actualLong = -3.939325f;
        //distancia = FormulaHaversine(ControladorModelos.modelo1.GetComponent<PosicionModelo>().Latitud, 
        //    ControladorModelos.modelo1.GetComponent<PosicionModelo>().Longitud,
        distancia = ControladorModelos.distancia;

    }
    private void OnGUI()
    {
        string mensaje = "Latitud: " + actualLat
        + "\nLongitud: " + actualLong
        + "\nDistancia: " + distancia;
        GUI.contentColor = Color.red;
        GUI.skin.label.fontSize = 60;
        GUI.Label(new Rect(30, 300, 1200, 600), mensaje);
    }


}
