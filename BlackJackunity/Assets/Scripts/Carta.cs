using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Carta
    {
        public int valor { get; set; }
        public string palo { get; set; }
        public string sprite { get; set; }
        public string nombre { get; set; } // nombre del gameobject unity 
        public GameObject gameCarta { get; set; }

        public Carta(int numero, string palo, GameObject gameBaraja)
        {

            this.palo = palo;
            this.sprite = "Sprites/" + palo + "/card_" + numero + "_" + palo;

            switch (numero)
            {
                case 1:
                    this.nombre = "A" + palo[0];
                    this.valor = numero;
                    break;
                case 11:
                    this.nombre = "J" + palo[0];
                    this.valor = 10;
                    break;
                case 12:
                    this.nombre = "Q" + palo[0];
                    this.valor = 10;
                    break;
                case 13:
                    this.nombre = "K" + palo[0];
                    this.valor = 10;
                    break;
                default:
                    this.nombre = numero.ToString() + palo[0];
                    this.valor = numero;
                    break;
            }
            this.gameCarta = new GameObject(this.nombre);
            UnityHelper.asociarPadre(this.gameCarta, gameBaraja);
            UnityHelper.asociarImagen(this.gameCarta, this.sprite);
            UnityHelper.escalarObjeto(this.gameCarta, new Vector3(1.5f, 2.0f, 0.0f));
        }



    }
}
