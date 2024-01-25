using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;

public class ControladorModelos : MonoBehaviour
{
    public GameObject modelo1, modelo2, modelo3, modelo4;
    public int radioDeAccion1, radioDeAccion2, radioDeAccion3, radioDeAccion4;
    public bool vencido1 = false, vencido2 = false, vencido3 = false, vencido4 = false;
    private string[] pistas = new string[4];
    public static decimal cercano, cercano2, cercano3, cercano4;
    public decimal a = cercano, b = cercano2, c = cercano3, d = cercano4;
    public int pista = 0;
    public int obj = 0;
    public int numobjetos = 4;
    public static decimal distancia;

    //public Touch touch;

    void Start()
    {
        pistas[0] = "Una zona en la que se juega con pelotas";
        pistas[1] = "El lugar mas concurrido";
        pistas[2] = "Donde las maquinas vuelven a moverse";
        pistas[3] = "Tengo hambre";
    }

    // Update is called once per frame
    void Update()
    {

        cercano = ControladorGPS.FormulaHaversine(modelo1.GetComponent<PosicionModelo>().Latitud, modelo1.GetComponent<PosicionModelo>().Longitud,
            Convert.ToDouble(Input.location.lastData.latitude), Convert.ToDouble(Input.location.lastData.longitude));
            //modelo1.GetComponent<PosicionModelo>().distancia;
        cercano2 = ControladorGPS.FormulaHaversine(modelo2.GetComponent<PosicionModelo>().Latitud, modelo2.GetComponent<PosicionModelo>().Longitud,
            Convert.ToDouble(Input.location.lastData.latitude), Convert.ToDouble(Input.location.lastData.longitude));
        //modelo2.GetComponent<PosicionModelo>().distancia;
        cercano3 = ControladorGPS.FormulaHaversine(modelo3.GetComponent<PosicionModelo>().Latitud, modelo3.GetComponent<PosicionModelo>().Longitud,
            Convert.ToDouble(Input.location.lastData.latitude), Convert.ToDouble(Input.location.lastData.longitude)); ;
        //modelo3.GetComponent<PosicionModelo>().distancia;
        cercano4 = ControladorGPS.FormulaHaversine(modelo4.GetComponent<PosicionModelo>().Latitud, modelo4.GetComponent<PosicionModelo>().Longitud,
            Convert.ToDouble(Input.location.lastData.latitude), Convert.ToDouble(Input.location.lastData.longitude)); ;
        //modelo4.GetComponent<PosicionModelo>().distancia;
        Debug.Log("Cercano 1 " + modelo1.name+" latidud" + modelo1.GetComponent<PosicionModelo>().Latitud + 
            " Longitud" + modelo1.GetComponent<PosicionModelo>().Longitud + " " + cercano);
        Debug.Log("Cercano 2 " + modelo2.name + " latidud" + modelo2.GetComponent<PosicionModelo>().Latitud +
            " Longitud" + modelo2.GetComponent<PosicionModelo>().Longitud + " " + cercano2);
        Debug.Log("Cercano 3 " + modelo3.name + " latidud" + modelo3.GetComponent<PosicionModelo>().Latitud +
            " Longitud" + modelo3.GetComponent<PosicionModelo>().Longitud + " " + cercano3);
        Debug.Log("Cercano 4 " + modelo4.name + " latidud" + modelo4.GetComponent<PosicionModelo>().Latitud +
            " Longitud" + modelo4.GetComponent<PosicionModelo>().Longitud + " " + cercano4);

        if (vencido1)
        {
            cercano = 10000000;
        }
        if (vencido2)
        {
            cercano2 = 10000000;
        }
        if (vencido3)
        {
            cercano3 = 10000000;
        }
        if (vencido4)
        {
            cercano4 = 10000000;
        }
        if (!vencido1 && cercano < cercano2 && cercano3 > cercano && cercano4 > cercano)
        {
            Debug.Log("En cercano 1 " + cercano);
            pista = 0;
            distancia = cercano;
            if (distancia < radioDeAccion1)
            {
                modelo1.SetActive(true);
                modelo2.SetActive(false);
                modelo3.SetActive(false);
                modelo4.SetActive(false);
                Derrotar(1);
            }
            else
            {
                modelo1.SetActive(false);
            }
        }
        else
        {
            modelo1.SetActive(false);
        }
        if (!vencido2 && cercano > cercano2 && cercano3 > cercano2 && cercano4 > cercano2)
        {
            Debug.Log("En cercano 2 " + cercano);
            pista = 1;
            distancia = cercano2;
            if (distancia < radioDeAccion2)
            {
                modelo1.SetActive(false);
                modelo2.SetActive(true);
                modelo3.SetActive(false);
                modelo4.SetActive(false);
                Derrotar(2);
            }
            else
            {
                modelo2.SetActive(false);
            }
        }
        else
        {
            modelo2.SetActive(false);
        }
        if (!vencido3 && cercano > cercano3 && cercano2 > cercano3 && cercano4 > cercano3)
        {
            Debug.Log("En cercano 3 " + cercano);
            pista = 2;
            distancia = cercano3;
            if (distancia < radioDeAccion2)
            {
                modelo1.SetActive(false);
                modelo2.SetActive(false);
                modelo3.SetActive(true);
                modelo4.SetActive(false);
                Derrotar(3);
            }
            else
            {
                modelo3.SetActive(false);
            }
        }
        else
        {
            modelo3.SetActive(false);
        }
        if (!vencido4 && cercano > cercano4 && cercano2 > cercano4 && cercano3 > cercano4)
        {
            Debug.Log("En cercano 4 " + cercano);
            pista = 3;
            distancia = cercano4;
            if (distancia < radioDeAccion2)
            {
                modelo1.SetActive(false);
                modelo2.SetActive(false);
                modelo3.SetActive(false);
                modelo4.SetActive(true);
                Derrotar(4);
            }
            else
            {
                modelo4.SetActive(false);
            }
        }
        else
        {
            modelo4.SetActive(false);
        }
    }
    private void OnGUI()
    {
        string mensaje = "Pista: " + pistas[pista];
        GUI.contentColor = Color.black;
        GUI.skin.label.fontSize = 60;
        GUI.Label(new Rect(30, 50, 600, 600), mensaje);
        string objetos = "Objetos conseguidos: " + obj;
        GUI.contentColor = Color.black;
        GUI.skin.label.fontSize = 60;
        GUI.Label(new Rect(1550, 50, 650, 650), objetos);
    }
    private void Derrotar(int modelo)
    {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                switch (modelo)
                {
                    case 1:
                        vencido1 = true;
                        break;
                    case 2:
                        vencido2 = true;
                        break;
                    case 3:
                        vencido3 = true;
                        break;
                    case 4:
                        vencido4 = true;
                        break;
                }
                obj++;
            }
        }
        if (obj == numobjetos)
        {
            TimeController.enMarcha = false;
            Menu.CargarVictoria();
        }
    }
}