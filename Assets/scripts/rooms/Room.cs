using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private Vector3[] initialPositions;

    private void Awake()
    {
        // Uložíme si poèiatoèné pozície všetkých nepriate¾ov v poli
        initialPositions = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                initialPositions[i] = enemies[i].transform.position;
        }
    }

    // Táto metóda sa volá zo skriptu Door (okolo 39:44)
    public void ActivateRoom(bool _status)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                // Aktivuje alebo deaktivuje nepriate¾a pod¾a stavu (_status)
                enemies[i].SetActive(_status);
                
                // [40:16] Resetuje pozíciu nepriate¾a na tú pôvodnú (ktorú sme si uložili v Awake)
                enemies[i].transform.position = initialPositions[i];
            }
        }
    }
}