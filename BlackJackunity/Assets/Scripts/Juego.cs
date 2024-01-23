using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class Juego : MonoBehaviour
{
    // objetos unity
    public GameObject gameBaraja;
    public Canvas canvasPartida;
    public Canvas canvasOpciones;
    public Canvas c_textos2;
    public Canvas c_textos3;
    public Canvas c_textos4;
    public Canvas Ganador;
    public Canvas c_fin_partida;

    // objetos mios
    public Baraja baraja;
    public Jugador jugador;
    public List<Jugador> jugadores = new List<Jugador>();
    public int posicion = 0;
    public int gan = 0;
    public int totalj = 1;
    public int premio = 0;

    // Start is called before the first frame update
    void Start()
    {

        baraja = new Baraja(gameBaraja);
        jugador = new Jugador(0.0f, -0.1f, 0.0f, "Jugador1", 100);
        jugadores.Add(jugador);
        c_textos2.enabled = false;
        c_textos3.enabled = false;
        c_textos4.enabled = false;
        c_fin_partida.enabled = false;
        canvasPartida.enabled = false;
        Ganador.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        UnityHelper.cambiarTextoTMPro("Numjugadores", totalj.ToString());
    }

    public void comenzarJuego()
    {
        canvasOpciones.enabled = false;
        canvasPartida.enabled = true;
        jugador = new Jugador(1.51f, 0.3f, 0.0f, "Banca", 999999999);
        jugadores.Add(jugador);
        totalj++;
        premio = jugadores.Count * 10;
        UnityHelper.cambiarTextoTMPro("Premio", premio.ToString());
        switch (jugadores.Count - 1)
        {
            case 1:
                ;
                break;
            case 2:
                c_textos2.enabled = true;
                break;
            case 3:
                c_textos2.enabled = true;
                c_textos3.enabled = true;
                break;
            case 4:
                c_textos2.enabled = true;
                c_textos3.enabled = true;
                c_textos4.enabled = true;
                break;
        }

        for (int i = 0; i < jugadores.Count - 1; i++)
        {
            jugadores[i].saldo -= 10;
            UnityHelper.cambiarTextoTMPro("Dinero" + (i + 1), jugadores[i].saldo.ToString());
        }
        for (int i = 0; i < 2; i++)
        {
            sacarCarta();
        }


        mostrarTirada();
    }

    public void sacarCarta(int pos)
    {
        Carta carta = baraja.sacarCarta();
        jugadores[pos].pedirCarta(carta);

        carta.gameCarta.transform.localPosition = new Vector3(jugadores[pos].pos_x, jugadores[pos].pos_y, jugadores[pos].pos_z);
        jugadores[pos].pos_y -= 0.1f;
        jugadores[pos].pos_z -= 0.01f;

        mostrarTirada();
    }

    public void sacarCarta()
    {
        Carta carta = baraja.sacarCarta();
        jugadores[posicion].pedirCarta(carta);

        carta.gameCarta.transform.localPosition = new Vector3(jugadores[posicion].pos_x, jugadores[posicion].pos_y, jugadores[posicion].pos_z);
        jugadores[posicion].pos_y -= 0.1f;
        jugadores[posicion].pos_z -= 0.01f;

        mostrarTirada();
    }

    public void mostrarTirada()
    {
        int tirada = jugadores[posicion].contarMano();
        int pos = posicion;
        if (posicion == totalj - 1)
        {
            pos = -1;
        }
        UnityHelper.cambiarTextoTMPro("Puntos" + (pos + 1), tirada.ToString());

        if (tirada > 21)
        {
            UnityHelper.cambiarColorTMPro("Puntos" + (pos + 1), Color.red);
            if (pos > -1)
            {
                Pasar();
            }
        }
        else
        {
            UnityHelper.cambiarColorTMPro("Puntos" + (pos + 1), Color.white);
        }
    }
    //public void MasJugadores()
    //{
    //    if (num < 3)
    //    {
    //        num++;
    //        string nombre = "";
    //        switch (num)
    //        {
    //            case 1:
    //                nombre = "Jugador2";
    //                break;
    //            case 2:
    //                nombre = "Jugador3";
    //                ;
    //                break;
    //            case 3:
    //                nombre = "Jugador4";
    //                ;
    //                break;
    //            case 4:
    //                nombre = "Banca";
    //                ;
    //                break;
    //        }
    //        jugador = new Jugador(0.1f * (num + 1), -0.1f, 0.0f, nombre);
    //        jugadores[num] = jugador;
    //    }
    //}
    public void MasJugadores()
    {
        if (totalj < 4)
        {
            totalj++;
            jugador = new Jugador(jugadores[totalj - 2].pos_x + 0.4f, -0.1f, 0.0f, "Jugador" + totalj, 100);
            jugadores.Add(jugador);

        }
    }
    public void Pasar()
    {
        posicion++;
        if (posicion < totalj - 1)
        {
            for (int i = 0; i < 2; i++)
            {
                sacarCarta();
            }
        }
        else
        {
            //var a = GameObject.Find("b_pedir");
            //a.SetActive(false);
            while (jugadores[posicion].contarMano() < 16)
            {
                sacarCarta();
            }
            MostrarGanador();
        }

    }
    public void MostrarGanador()
    {
        //int banca = jugadores[totalj - 1].contarMano();
        gan = 0;
        int com = 0;
        for (int i = 0; i < jugadores.Count; i++)
        {
            if (jugadores[i].contarMano() <= 21 && com == 0)
            {
                gan = i;
                com++;
            }
            if (jugadores[i].contarMano() <= 21 && jugadores[i].contarMano() >= jugadores[gan].contarMano())
            {
                gan = i;
            }
        }
        canvasPartida.enabled = false;
        Ganador.enabled = true;
        jugadores[gan].saldo += premio;
        gan++;
        if (gan == totalj)
        {
            UnityHelper.cambiarTextoTMPro("Ganador", "Ganador Banca ");
        }
        else
        {
            UnityHelper.cambiarTextoTMPro("Ganador", "Ganador Jugador " + gan.ToString());
        }
        c_fin_partida.enabled = true;
    }
    public void reJugar()
    {
        for (int i = 0; i < jugadores.Count; i++)
        {
            posicion = i;
            while (jugadores[i].contarMano() > 0)
            {
                devolverCartas(jugadores[i]);
            }
            jugadores[i].pos_y = -0.1f;
            jugadores[i].pos_z = 0.0f;
            //jugadores[i].mano.Clear();
            //if ((i + 1) != jugadores.Count)
            //{
            //    mostrarTirada();
            //}
            //else
            //{
            //    UnityHelper.cambiarTextoTMPro("Puntos" + 0, "0");
            //}
            mostrarTirada();
        }

        c_fin_partida.enabled = false;
        canvasPartida.enabled = true;
        Ganador.enabled = false;
        UnityHelper.cambiarTextoTMPro("Premio", premio.ToString());
        for (int i = 0; i < jugadores.Count - 1; i++)
        {

            jugadores[i].saldo -= 10;
            UnityHelper.cambiarTextoTMPro("Dinero" + (i + 1), jugadores[i].saldo.ToString());
        }
        posicion = 0;
    }
    public void devolverCartas(Jugador jug)
    {
        Carta carta = jug.devolverCarta();
        baraja.devolverCarta(carta, gameBaraja);
        carta.gameCarta.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void salir()
    {
        SceneManager.LoadScene("Menu");
    }
}
