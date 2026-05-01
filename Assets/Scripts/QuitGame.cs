using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit Game"); // เอาไว้ดูใน Editor

        Application.Quit(); // ออกเกมจริง
    }
}