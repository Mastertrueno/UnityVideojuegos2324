using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ejemplo1 : MonoBehaviour
{
    [SerializeField]
    private TextMesh toggleSwitchLabel;

    [SerializeField]
    private string toggleSwitchOffLabel = "Off";

    [SerializeField]
    private string toggleSwitchOnLabel = "On";

    [SerializeField]
    private float amplitude = 0.2f;

    [SerializeField]
    private float frequency = 1f;

    private bool animationStatus = false;
    private Vector3 scaleAtStart = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        scaleAtStart = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (animationStatus)
        {
            transform.localScale = Mathf.PingPong(Time.time * frequency, amplitude) * Vector3.one + scaleAtStart;
        }


    }

    public void OnSliderEvent(SliderEventData eventData)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (eventData.NewValue - 0.5f) * 360);
    }

    public void OnToggleSwitch()
    {
        animationStatus = !animationStatus;

        if (!animationStatus)
        {
            transform.localScale = new Vector3(scaleAtStart.x, scaleAtStart.y, scaleAtStart.z);
        }

        toggleSwitchLabel.text = animationStatus ? toggleSwitchOnLabel : toggleSwitchOffLabel;


    }


    public void OnButtonClick()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
    }
}
