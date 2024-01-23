using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Jugador
    {

        public List<Carta> mano { get; set; }

        public GameObject gameJugador { get; set; }
        public int saldo { get; set; }

        //posicion de comienzo de las cartas
        public float pos_x { get; set; }
        public float pos_y { get;set; } 
        public float pos_z { get;set; }

        public Jugador (float x, float y, float z,string nombre,int dinero)
        {
            gameJugador = GameObject.Find(nombre);
            mano = new List<Carta> ();
            pos_x = x;
            pos_y = y;
            pos_z = z;
            saldo = dinero;
        }
        //public Jugador(float x, float y, float z)
        //{
        //    gameJugador = GameObject.Find("Jugador1");
        //    mano = new List<Carta>();
        //    pos_x = x;
        //    pos_y = y;
        //    pos_z = z;
        //}
        public void pedirCarta(Carta carta)
        {
            mano.Add(carta);
            UnityHelper.asociarPadre(carta.gameCarta, gameJugador);
        }
        public Carta devolverCarta()
        {
            Carta carta = mano[0];
            mano.Remove(carta);
            return carta;
        }

        public int contarMano()
        {

            int unos = 0;
            int total = 0;
            foreach (Carta carta in mano)
            {
                if (carta.valor == 1)
                {
                    unos++;
                } else
                {
                    total += carta.valor;
                }
            }

            while (unos > 0)
            {
                unos--;
                if(total + 11 + unos <= 21)
                {
                    total += 11;
                } else
                {
                    total += 1;
                }
            
            }

            return total;

        }



    }
}
