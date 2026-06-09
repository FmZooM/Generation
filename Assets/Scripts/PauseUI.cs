using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PauseUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pauseMenuPanel;   // главное меню паузы
    [SerializeField] private GameObject settingsPanel;    // второе окно с 7 полями

    [Header("Input fields (7 штук)")]
    [SerializeField] private TMP_InputField field1;
    [SerializeField] private TMP_InputField field2;
    [SerializeField] private TMP_InputField field3;
    [SerializeField] private TMP_InputField field4;
    [SerializeField] private TMP_InputField field5;
    [SerializeField] private TMP_InputField field6;
    [SerializeField] private TMP_InputField field7;

    [Header("Сохранённые значения (сюда всё пишется)")]
    public string value1;
    public string value2;
    public string value3;
    public string value4;
    public string value5;
    public string value6;
    public string value7;

    private bool isPaused;

    private void Start()
    {
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        isPaused = false;

        Time.timeScale = 1f;
        LockCursor(true);
    }

    private void Update()
    {
        // Esc – открыть/закрыть паузу
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                OpenPauseMenu();
        }
    }

    // ================= ПАУЗА =================

    public void OpenPauseMenu()
    {
        isPaused = true;
        pauseMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);

        Time.timeScale = 0f;
        LockCursor(false);

        // Чтобы можно было сразу кликать по кнопкам
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);

        Time.timeScale = 1f;
        LockCursor(true);
    }

    public void QuitGame()
    {
        // В редакторе ничего не произойдёт, но в билде закроет игру
        Application.Quit();
    }

    private void LockCursor(bool locked)
    {
        Cursor.visible = !locked;
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    // ================= ПЕРЕКЛЮЧЕНИЕ ОКОН =================

    public void OpenSettingsWindow()
    {
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);

        // Фокус в первое поле
        EventSystem.current.SetSelectedGameObject(field1.gameObject);
        field1.ActivateInputField();
    }

    public void BackToMainMenuFromSettings()
    {
        settingsPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
    }

    // ================= СОХРАНЕНИЕ 7 ПОЛЕЙ =================

    public void SaveSettings()
    {
        // Сохраняем введённый текст в переменные
        value1 = field1.text;
        value2 = field2.text;
        value3 = field3.text;
        value4 = field4.text;
        value5 = field5.text;
        value6 = field6.text;
        value7 = field7.text;

        Debug.Log($"Сохранено: {value1}, {value2}, {value3}, {value4}, {value5}, {value6}, {value7}");

        

        // тут можно сразу вызвать метод другого скрипта, если нужно
        // myOtherScript.ApplyValues(value1, value2, value3, ...);
    }
}