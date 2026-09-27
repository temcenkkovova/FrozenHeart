using UnityEngine;

public class SoundController : MonoBehaviour
{
  public AudioSource audioSource;
  private bool isActivated;

  void OnEnable()
  {
    isActivated = false;
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      if (isActivated) return;
      audioSource.Play();
      isActivated = true;
    }
  }
}