using UnityEngine;

public class CameraObstacle : MonoBehaviour
{
  [SerializeField] private Renderer[] renderers;

  private bool[] previousStates;
  private bool hidden;

  private void Awake()
  {
    if (renderers == null || renderers.Length == 0)
      renderers = GetComponentsInChildren<Renderer>(true);

    previousStates = new bool[renderers.Length];
  }

  public void Hide()
  {
    if (hidden) return;

    hidden = true;

    for (int i = 0; i < renderers.Length; i++)
    {
      if (renderers[i] == null) continue;

      previousStates[i] = renderers[i].enabled;
      renderers[i].enabled = false;
    }
  }

  public void Restore()
  {
    if (!hidden) return;

    for (int i = 0; i < renderers.Length; i++)
    {
      if (renderers[i] != null)
        renderers[i].enabled = previousStates[i];
    }

    hidden = false;
  }

  private void OnDisable()
  {
    Restore();
  }
}