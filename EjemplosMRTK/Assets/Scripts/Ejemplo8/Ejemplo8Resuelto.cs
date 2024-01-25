using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class Ejemplo8Resuelto : MonoBehaviour, IMixedRealityFocusHandler, IMixedRealityPointerHandler
{
    // Las capas que se ignoran al hacer el raycast.
    [SerializeField] private LayerMask layersToIgnore;

    [SerializeField] private FollowMeToggle followMeToggle;

    private void DoRaycast()
    {
        RaycastHit hit;

        Vector3 focusPosition = new Vector3();

        // Intentamos sacar la posicion del puntero principal.
        // Si no es posible usamos transform.position
        try
        {
            if (CoreServices.InputSystem.FocusProvider.TryGetFocusDetails(CoreServices.InputSystem.FocusProvider.PrimaryPointer, out Microsoft.MixedReality.Toolkit.Physics.FocusDetails focusDetails))
            {
                focusPosition = focusDetails.Point;
            }
            else
            {
                focusPosition = transform.position;
            }
        }
        catch
        {
            focusPosition = transform.position;
        }

        // Calculamos la direccion del rayo (de la camara al objeto)
        Vector3 direction = focusPosition - Camera.main.transform.position;

        // Lanzamos el rayo
        if (Physics.Raycast(Camera.main.transform.position, direction, out hit))
        {
            // Comprobamos si la capa del objeto NO se incluye en layersToIgnore
            // https://discussions.unity.com/t/check-if-layer-is-in-layermask/16007
            if (layersToIgnore != (layersToIgnore | (1 << hit.collider.gameObject.layer)))
            {
                followMeToggle.SetFollowMeBehavior(true);
            }
        }
    }

    void IMixedRealityFocusHandler.OnFocusEnter(FocusEventData eventData)
    {
        DoRaycast();
    }

    void IMixedRealityFocusHandler.OnFocusExit(FocusEventData eventData)
    {
        DoRaycast();
    }

    void IMixedRealityPointerHandler.OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        DoRaycast();
    }

    void IMixedRealityPointerHandler.OnPointerDown(MixedRealityPointerEventData eventData)
    {
        DoRaycast();
    }

    void IMixedRealityPointerHandler.OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        DoRaycast();
    }

    void IMixedRealityPointerHandler.OnPointerUp(MixedRealityPointerEventData eventData)
    {
        DoRaycast();
    }
}