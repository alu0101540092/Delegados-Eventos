using UnityEngine;

public class SphereMover : MonoBehaviour
{
  public enum SphereType { Type1, Type2 }
  public SphereType sphereType = SphereType.Type1;

  public float speed = 3f;

  public Transform targetShieldType1; // Escudo tipo 1
  public Transform lookTargetType2;   // Objeto hacia el que mirar

  // private Transform currentTargetTransform;
  // private bool shouldMove = false;
  private Rigidbody rb;
  private Animator animator;
  private Renderer rend;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
    rb.isKinematic = true; // asegurar movimiento manual
    animator = GetComponent<Animator>();
    rend = GetComponentInChildren<Renderer>();
  }

  private void OnEnable()
  {
    // Suscribirse al evento
    CollisionEvents.OnCubeNearReference += OnCubeNearReference;
  }

  private void OnDisable()
  {
    // Desuscribirse del evento
    CollisionEvents.OnCubeNearReference -= OnCubeNearReference;
  }

  private void OnCubeNearReference()
  {
    if (sphereType == SphereType.Type1)
    {
      if (targetShieldType1 != null)
      {
        transform.position = targetShieldType1.position;
      }
    }
    else if (sphereType == SphereType.Type2)
    {
      if (lookTargetType2 != null)
      {
        Vector3 direction = lookTargetType2.position - transform.position;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
          transform.rotation = Quaternion.LookRotation(direction);
        }
      }
    }
  }

  // private void Update()
  // {
  //   if (!shouldMove || currentTargetTransform == null)
  //   {
  //     return;
  //   }

  //   Vector3 targetPosition = currentTargetTransform.position;
  //   transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
  //   transform.LookAt(targetPosition);


  //   if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
  //   {
  //     shouldMove = false;
  //   }
  // }

  // private void OnCubeHitType1()
  // {
  //   // Si el cubo tocó un tipo 1, los tipo 2 van hacia los escudos tipo 2
  //   if (sphereType == SphereType.Type2 && targetShieldsType2.Length > 0)
  //   {
  //     // Elegir uno al azar
  //     currentTargetTransform = targetShieldsType2[Random.Range(0, targetShieldsType2.Length)];
  //     shouldMove = true;
  //   }
  // }

  // private void OnCubeHitType2()
  // {
  //   // Si el cubo tocó un tipo 2, los tipo 1 van hacia el escudo tipo 1
  //   if (sphereType == SphereType.Type1 && targetShieldType1 != null)
  //   {
  //     currentTargetTransform = targetShieldType1;
  //     shouldMove = true;
  //   }
  // }

  // private void OnTriggerEnter(Collider other)
  // {
  //   if (other.CompareTag("Shield"))
  //   {
  //     // Cambiar color al tocar un escudo
  //     if (rend != null)
  //     {
  //       rend.material.color = Random.ColorHSV();
  //     }
  //   }
  // }
}
