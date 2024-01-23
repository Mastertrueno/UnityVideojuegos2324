using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class UnityHelper
    { 

        public static void asociarPadre(GameObject objetoHijo, GameObject objetoPadre)
        {
            objetoHijo.transform.SetParent(objetoPadre.transform);
            objetoHijo.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }

        public static void asociarImagen(GameObject gameObject, string sprite)
        {
            gameObject.AddComponent<SpriteRenderer>();
            /*
            SpriteRenderer imagen = gameObject.GetComponent<SpriteRenderer>();
            imagen.sprite = Resources.Load<Sprite>(sprite);
            */
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite); ;
        }

        public static void escalarObjeto(GameObject gameObject, Vector3 escalado)
        {
            gameObject.transform.localScale = escalado;
        }

        public static void cambiarTextoTMPro (string nombre, string texto)
        {
            TMPro.TextMeshProUGUI tmpro = GameObject.Find(nombre).GetComponent<TMPro.TextMeshProUGUI>();
            tmpro.SetText(texto);
        }

        public static void cambiarColorTMPro(string nombre, Color color)
        {
            TMPro.TextMeshProUGUI tmpro = GameObject.Find(nombre).GetComponent<TMPro.TextMeshProUGUI>();
            tmpro.color = color;
        }

    }
}
