using UnityEngine;

public class CylinderTrigger : MonoBehaviour
{
  private void OnTriggerEnter(Collider other)
  {
    // Comprobar que el que colisionó sea el Cube
    if (other.CompareTag("Cube") || other.name == "Cube")
    {
      CollisionEvents.RaiseCylinderTriggered();
    }
  }
}
