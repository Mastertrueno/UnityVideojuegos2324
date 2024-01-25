using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public TextMeshProUGUI Vida;
    public TMP_Text tiempo;
    public static float restante;
    public static bool enMarcha;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setVidastxt(int vidas)
    {
        //Vida.text = "Vidas "+vidas;
    }
    // Update is called once per frame
   
    private void Awake()
    {
        restante = 0;
        enMarcha = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            restante += Time.deltaTime;

            //enMarcha = false;

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
