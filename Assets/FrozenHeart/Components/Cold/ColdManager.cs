using UnityEngine;

public class ColdManager : MonoBehaviour
{

  public Transform enemyTr;
  public Transform playerTr;
  public float distanceBetween = 3f;
  public FreezeController freezeController;

  private bool isInsideHouse;
  private float lastAlpha = float.NaN;
  public void SetInsideHouse(bool value)
  {
    isInsideHouse = value;

    if (value)
      UpdateAlpha();
    else
      ApplyAlpha(0f);
  }
  private void Update()
  {
    if (isInsideHouse)
      UpdateAlpha();
  }
  private void UpdateAlpha()
  {
    Vector3 distance = new Vector3(enemyTr.position.x, 0f, enemyTr.position.z) - new Vector3(playerTr.position.x, 0f, playerTr.position.z);
    bool isNear = distance.sqrMagnitude
                  <= distanceBetween * distanceBetween;

    ApplyAlpha(isNear ? 6f : 0.3f);
  }

  private void ApplyAlpha(float value)
  {
    if (value == lastAlpha)
      return;

    lastAlpha = value;
    freezeController.ChangeAlphaValue(value);
  }
}