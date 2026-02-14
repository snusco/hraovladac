using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;

    private void Awake()
    {
        // Automaticky nájde kameru v scéne a priradí jej skript CameraController
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                // Pohyb do ïalšej miestnosti
                cam.MoveToNewRoom(nextRoom);
                
                // Aktivácia/Deaktivácia miestností (logika z 39:44)
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                previousRoom.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                // Pohyb do predchádzajúcej miestnosti
                cam.MoveToNewRoom(previousRoom);
                
                previousRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);
            }
        }
    }
}