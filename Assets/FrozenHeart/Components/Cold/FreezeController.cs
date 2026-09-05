using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class FreezeController : MonoBehaviour
{


  public Material material;
  string propertyName = "_enabled";

  private bool isEnabled = true;

  public float alphaValue;

  private static readonly int AlphaId = Shader.PropertyToID("_Alpha");
  private Coroutine transition;

  private void OnValidate()
  {

    FadeTo(alphaValue, 2);
  }

  private void Update()
  {
    // if (!Application.isPlaying)
    // {
    FadeTo(alphaValue, 2);
    // }
  }

  private void OnEnable()
  {
    isEnabled = true;
    FadeTo(alphaValue, 2);
  }

  private void OnDisable()
  {
    isEnabled = false;
    FadeTo(alphaValue, 2);
  }

  public void FadeTo(float targetAlpha, float duration)
  {
    if (transition != null)
      StopCoroutine(transition);

    transition = StartCoroutine(
        Fade(Mathf.Clamp01(targetAlpha), duration));
  }

  private IEnumerator Fade(float target, float duration)
  {


    float start = material.GetFloat(AlphaId);
    float elapsed = 0f;

    while (elapsed < duration)
    {
      elapsed += Time.deltaTime;
      float t = Mathf.Clamp01(elapsed / duration);

      material.SetFloat(
          AlphaId, Mathf.Lerp(start, target, t));

      yield return null;
    }

    material.SetFloat(AlphaId, target);
    transition = null;
  }

  public void ChangeAlphaValue(float value)
  {
    alphaValue = value;
  }

}
