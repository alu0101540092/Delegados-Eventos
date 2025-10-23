using System;

public static class CollisionEvents
{
  // Evento de los ejercicios 1 y 2
  public static event Action OnCylinderTriggered;

  // Eventos del ejercicio 3
  public static event Action OnCubeHitType1;
  public static event Action OnCubeHitType2;

  // Evento del ejercicio 4
  public static event Action OnCubeNearReference;

  public static void RaiseCylinderTriggered()
  {
    OnCylinderTriggered?.Invoke();
  }

  public static void CubeHitType1()
  {
    OnCubeHitType1?.Invoke();
  }

  public static void CubeHitType2()
  {
    OnCubeHitType2?.Invoke();
  }

  public static void CubeNearReference()
  {
    OnCubeNearReference?.Invoke();
  }
}
