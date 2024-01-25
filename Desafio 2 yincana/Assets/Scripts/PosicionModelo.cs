using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionModelo : MonoBehaviour
{
    public double Latitud, Longitud;
    public double actualLat, actualLong;
    public decimal distancia;
    //decimal FormulaHaversine(double lat1, double long1, double lat2, double long2)
    //{
    //    decimal earthRad = 6371000;
    //    double lRad1 = lat1 * Mathf.Deg2Rad;
    //    double lRad2 = lat2 * Mathf.Deg2Rad;
    //    double dLat = (lat2 - lat1) * Mathf.Deg2Rad;
    //    double dLong = (long2 - long1) * Mathf.Deg2Rad;
    //    double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
    //    Math.Cos(lRad1) * Math.Cos(lRad2) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
    //    decimal c = Convert.ToDecimal(2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)));
    //    return earthRad * c;
    //}

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }
    void Update()
    {
        Debug.Log("Distancia de " + Latitud + ", " + Longitud + " " + distancia);
        actualLat =Convert.ToDouble( Input.location.lastData.latitude);
        actualLong = Convert.ToDouble(Input.location.lastData.longitude);
        //distancia = FormulaHaversine(Latitud, Longitud, actualLat, actualLong);
        distancia =ControladorGPS.FormulaHaversine(Latitud, Longitud, 38.988941, -3.939325);
        Debug.Log("Distancia de "+Latitud+", "+Longitud+" "+distancia);

    }// entrada 38.990624, -3.920826
    //cancha 38.991155, -3.920251
    //casa 38.988941, -3.939325
    //cafeteria 38.990938, -3.921120
    //mecanica 38.990819, -3.921263
    //prueba desde clase 38.990914, -3.920763
}
