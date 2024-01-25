using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class Ejemplo11Resuelto : MonoBehaviour
{
    [SerializeField]
    private GameObject markerPrefab;

    public void PlaceMarker(MixedRealityPointerEventData eventData)
    {
        if (eventData.Pointer?.Result?.CurrentPointerTarget?.layer == 31
            && CoreServices.InputSystem.FocusProvider.TryGetFocusDetails(
                eventData.Pointer, out Microsoft.MixedReality.Toolkit.Physics.FocusDetails focusDetails))
        {
            var instantiatedMarker = Instantiate(markerPrefab);
            instantiatedMarker.transform.position = focusDetails.Point;
        }
    }
}
