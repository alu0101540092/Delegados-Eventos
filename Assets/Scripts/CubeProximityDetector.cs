using UnityEngine;

public class CubeProximityDetector : MonoBehaviour
{
  [SerializeField] private Transform referenceObject;
  [SerializeField] private float triggerDistance = 3f;
  private bool hasTriggered = false;

  private void Update()
  {
    if (referenceObject == null) return;

    float distance = Vector3.Distance(transform.position, referenceObject.position);
    if (distance <= triggerDistance && !hasTriggered)
    {
      hasTriggered = true;
      CollisionEvents.CubeNearReference();
    }
    else if (distance >= triggerDistance && hasTriggered)
    {
      hasTriggered = false;
    }
  }
}
