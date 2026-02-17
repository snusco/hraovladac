using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject PauseUI; // Tu v Inspectore priradíš tvoje UI menu

    private void Awake()
    {
        // Na zaèiatku hry sa uistíme, že menu je vypnuté
       PauseUI.SetActive(false);
    }

    private void Update()
    {
        // Kontrola stlaèenia klávesy Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Ak je menu aktívne, vypneme ho (unpause), ak nie je, zapneme ho (pause)
            if (PauseUI.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

    // Hlavná metóda na prepínanie pauzy
    public void PauseGame(bool status)
    {
        // 1. Aktivujeme/deaktivujeme objekt menu v UI
        PauseUI.SetActive(status);

        // 2. Logika zastavenia èasu
        if (status)
        {
            Time.timeScale = 0; // Èas v hre sa zastaví
        }
        else
        {
            Time.timeScale = 1; // Èas sa vráti do normálu
        }
    }

    // Metóda pre tlaèidlo Quit (ako ukazoval vo videu)
    public void Quit()
    {
        Application.Quit();

        // Ak testuješ v Unity editore, toto ho zastaví (volite¾né):
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
