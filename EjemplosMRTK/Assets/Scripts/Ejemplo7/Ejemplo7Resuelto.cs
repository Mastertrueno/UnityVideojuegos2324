using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class Ejemplo7Resuelto : MonoBehaviour, IMixedRealityGestureHandler<Vector3>
{
    [SerializeField]
    private GameObject prefabToInstantiate;

    [SerializeField]
    private MixedRealityInputAction actionToInstantiate = MixedRealityInputAction.None;

    [SerializeField]
    private Transform mixedRealitySceneContent;

    private GameObject instancedPrefabCopy;
    private Vector3 initialPrefabCopyPosition;

    private void OnEnable()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
    }

    private void OnDisable()
    {
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityGestureHandler<Vector3>>(this);
    }

    private void DestroyInstancedPrefab()
    {
        if (instancedPrefabCopy != null)
        {
            Destroy(instancedPrefabCopy);
            instancedPrefabCopy = null;
        }
    }
    public void OnGestureCanceled(InputEventData eventData)
    {
        if (actionToInstantiate == eventData.MixedRealityInputAction)
        {
            DestroyInstancedPrefab();
        }
    }

    public void OnGestureCompleted(InputEventData<Vector3> eventData)
    {
        if (actionToInstantiate == eventData.MixedRealityInputAction)
        {
            DestroyInstancedPrefab();
        }
    }

    public void OnGestureCompleted(InputEventData eventData)
    {
        if (actionToInstantiate == eventData.MixedRealityInputAction)
        {
            DestroyInstancedPrefab();
        }
    }

    public void OnGestureStarted(InputEventData eventData)
    {
        if (actionToInstantiate == eventData.MixedRealityInputAction && prefabToInstantiate != null)
        {
            instancedPrefabCopy = Instantiate(prefabToInstantiate);
            instancedPrefabCopy.transform.parent = mixedRealitySceneContent;
            Vector3 newPosition = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
            instancedPrefabCopy.transform.position = newPosition;
            initialPrefabCopyPosition = newPosition;
        }
    }

    public void OnGestureUpdated(InputEventData<Vector3> eventData)
    {
        if (actionToInstantiate == eventData.MixedRealityInputAction && instancedPrefabCopy != null)
        {
            instancedPrefabCopy.transform.position = initialPrefabCopyPosition + eventData.InputData;
        }
    }

    public void OnGestureUpdated(InputEventData eventData)
    {
        // No hacemos nada
    }
}
