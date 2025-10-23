using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeMovement : MonoBehaviour
{
  public float moveSpeed = 5f;
  public float rotationSpeed = 180f;

  private Rigidbody rb;
  private Vector3 inputDir;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    // Leer entrada del teclado
    float h = Input.GetAxis("Horizontal"); // A/D o ←/→
    float v = Input.GetAxis("Vertical");   // W/S o ↑/↓

    // Dirección de movimiento en el plano XZ
    inputDir = new Vector3(h, 0, v).normalized;
  }

  private void FixedUpdate()
  {
    // Aplicar movimiento físico
    if (inputDir.sqrMagnitude > 0.01f)
    {
      Vector3 move = inputDir * moveSpeed * Time.fixedDeltaTime;
      rb.MovePosition(rb.position + move);

      // Rotar suavemente en la dirección de movimiento
      Quaternion targetRot = Quaternion.LookRotation(inputDir);
      rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime));
    }
  }
}
