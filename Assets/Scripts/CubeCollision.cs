using UnityEngine;

public class CubeCollision : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
    var mover = collision.gameObject.GetComponent<SphereMover>();
    if (mover == null) return;

    if (mover.sphereType == SphereMover.SphereType.Type1)
    {
      CollisionEvents.CubeHitType1();
    }
    else if (mover.sphereType == SphereMover.SphereType.Type2)
    {
      CollisionEvents.CubeHitType2();
    }
  }
}
