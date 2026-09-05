using UnityEngine;

public class FreezeController : MonoBehaviour
{
  public Material material;

  [Range(0f, 1f)]
  public float alphaValue;

  [SerializeField, Min(0f)]
  private float fadeDuration = 2f;

  // Проверь Reference свойства в Shader Graph.
  private static readonly int AlphaId =
      Shader.PropertyToID("_Alpha");

  private float startAlpha;
  private float targetAlpha;
  private float elapsed;
  private float transitionDuration;
  private bool isTransitioning;

  private void OnEnable()
  {
    if (material == null)
      return;

    isTransitioning = false;
    targetAlpha = material.GetFloat(AlphaId);
    FadeTo(alphaValue, fadeDuration);
  }

  private void Update()
  {
    if (material == null)
      return;

    // Позволяет менять Alpha Value в Inspector во время игры.
    if (!Mathf.Approximately(
            Mathf.Clamp01(alphaValue), targetAlpha))
    {
      FadeTo(alphaValue, fadeDuration);
    }

    if (!isTransitioning)
      return;

    elapsed += Time.deltaTime;

    float t = Mathf.Clamp01(elapsed / transitionDuration);
    material.SetFloat(
        AlphaId, Mathf.Lerp(startAlpha, targetAlpha, t));

    if (t >= 1f)
      isTransitioning = false;
  }

  public void ChangeAlphaValue(float value)
  {
    FadeTo(value, fadeDuration);
  }

  public void FadeTo(float value, float duration)
  {
    alphaValue = Mathf.Clamp01(value);

    if (material == null)
      return;

    // Повторные вызовы с той же целью не сбрасывают переход.
    if (isTransitioning &&
        Mathf.Approximately(alphaValue, targetAlpha))
    {
      return;
    }

    startAlpha = material.GetFloat(AlphaId);
    targetAlpha = alphaValue;
    elapsed = 0f;
    transitionDuration = Mathf.Max(0f, duration);

    if (transitionDuration == 0f)
    {
      material.SetFloat(AlphaId, targetAlpha);
      isTransitioning = false;
      return;
    }

    isTransitioning =
        !Mathf.Approximately(startAlpha, targetAlpha);
  }

  private void OnDisable()
  {
    isTransitioning = false;
  }
}