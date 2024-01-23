using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Baraja
    {

        public List<Carta> cartas { get; set; }
        public GameObject gameBaraja { get; set; }
        public GameObject reversoBaraja { get; set; }


        public Baraja (GameObject gameBaraja)
        {
            string[] palos = new string[4];
            palos[0] = "clover";
            palos[1] = "diamond";
            palos[2] = "heart";
            palos[3] = "spade";
            
            this.gameBaraja = gameBaraja;

            reversoBaraja = GameObject.Find("bk");

            cartas = new List<Carta> ();

            for (int i = 1; i <= 13; i++)
            {
                foreach (string palo in palos)
                {
                    cartas.Add(new Carta(i, palo, this.gameBaraja));
                }
            }
            // barajamos las cartas para  tener la baraja lista desde el comienzo
            barajar();
        }

        public void barajar()
        {
            int j;
            for (int i=0; i< cartas.Count; i++)
            {
                j = Random.Range(0, cartas.Count);
                Carta aux = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = aux;
            }
        }

        public Carta sacarCarta()
        {
            Carta carta = cartas[0];
            cartas.Remove(carta);
            return carta;
        }
        public void devolverCarta(Carta carta,GameObject baraja)
        {
            cartas.Add(carta);
            UnityHelper.asociarPadre(carta.gameCarta, baraja);
        }
    }

}