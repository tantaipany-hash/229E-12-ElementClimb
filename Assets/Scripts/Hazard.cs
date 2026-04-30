using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    public string tagName = "Lava"; // หรือ Water

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            // ตาย → รีโหลดด่าน
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}