using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
  public PlayerConfig playerConfig;
  private PlayerMovement playerMovement;


  void Awake()
  {
    playerMovement = GetComponent<PlayerMovement>();
  }
  void Start()
  {
    playerMovement.Init(playerConfig.moveSpeed);
  }
}
