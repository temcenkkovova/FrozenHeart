using UnityEngine;

public class FloorController : MonoBehaviour
{
  public GameObject firstFloor;
  public GameObject secondFloor;
  public GameObject thirdFloor;
  private GameObject currentFloor;


  void Start()
  {
    currentFloor = firstFloor;
    firstFloor.SetActive(true);
    secondFloor.SetActive(false);
    thirdFloor.SetActive(false);
  }
  public void ChangeFloor(string floorName)
  {
    if (currentFloor.tag == floorName) return;
    if (floorName == firstFloor.tag)
    {
      firstFloor.SetActive(true);
      secondFloor.SetActive(false);
      thirdFloor.SetActive(false);

      currentFloor = firstFloor;

    }
    if (floorName == secondFloor.tag)
    {
      secondFloor.SetActive(true);
      firstFloor.SetActive(false);
      thirdFloor.SetActive(false);

      currentFloor = secondFloor;
    }
    if (floorName == thirdFloor.tag)
    {
      thirdFloor.SetActive(true);
      firstFloor.SetActive(false);
      secondFloor.SetActive(false);

      currentFloor = thirdFloor;
    }

  }
}