using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    [SerializeField] private PauseUI pauseMenu;   // сюда перетащить объект с PauseUI
    public GameObject[] objs;                    // PREFABS

    // дефолтные значени€, если пол€ в меню пустые
    [Header("Defaults")]
    public int defaultCount = 10;   // сколько объектов
    public int defaultMaxX = 25;
    public int defaultMaxY = 10;
    public int defaultMaxZ = 10;
    public int defaultMaxRotX = 180;
    public int defaultMaxRotY = 180;
    public int defaultMaxRotZ = 180;

    private GameObject[] spawnedObjects;

    private void Start()
    {
        // Ќ≈ ќЅя«ј“≈Ћ№Ќќ спавнить сразу в Start.
        // ≈сли хочешь Ч оставь. ≈сли нет Ч вызывай SpawnObjects с кнопки.
        SpawnObjects();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroySpawnedObjects();
            SpawnObjects();
        }
    }

    public void SpawnObjects()
    {
        if (pauseMenu == null)
        {
            Debug.LogError("PauseUI (pauseMenu) не назначен в CreateObjects!");
            return;
        }

        if (objs == null || objs.Length == 0)
        {
            Debug.LogError("ћассив objs пуст Ц нет префабов дл€ спавна!");
            return;
        }

        // читаем значени€ из полей, если не получилось Ц берЄм дефолт
        int count = GetInt(pauseMenu.value1, defaultCount);
        int maxX = GetInt(pauseMenu.value2, defaultMaxX);
        int maxY = GetInt(pauseMenu.value3, defaultMaxY);
        int maxZ = GetInt(pauseMenu.value4, defaultMaxZ);
        int maxRX = GetInt(pauseMenu.value5, defaultMaxRotX);
        int maxRY = GetInt(pauseMenu.value6, defaultMaxRotY);
        int maxRZ = GetInt(pauseMenu.value7, defaultMaxRotZ);

        spawnedObjects = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            GameObject prefab = objs[UnityEngine.Random.Range(0, objs.Length)];

            Vector3 pos = new Vector3(
                UnityEngine.Random.Range(0, maxX),
                UnityEngine.Random.Range(0, maxY),
                UnityEngine.Random.Range(0, maxZ)
            );

            Quaternion rot = Quaternion.Euler(
                UnityEngine.Random.Range(0, maxRX),
                UnityEngine.Random.Range(0, maxRY),
                UnityEngine.Random.Range(0, maxRZ)
            );

            GameObject newObj = Instantiate(prefab, pos, rot);
            spawnedObjects[i] = newObj;
        }
    }

    private int GetInt(string text, int fallback)
    {
        if (int.TryParse(text, out int result))
            return result;

        return fallback;
    }

    private void DestroySpawnedObjects()
    {
        if (spawnedObjects == null) return;

        for (int i = 0; i < spawnedObjects.Length; i++)
        {
            if (spawnedObjects[i] != null)
                Destroy(spawnedObjects[i]);
        }

        spawnedObjects = null;
    }
}