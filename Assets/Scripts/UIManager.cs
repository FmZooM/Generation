using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnPlayClicked()
    {
        Debug.Log("Нажали Играть!");
        // тут потом будет: загрузка сцены, старт игры и т.д.
    }

    public void OnQuitClicked()
    {
        Debug.Log("Выход");
        Application.Quit();
    }

}
