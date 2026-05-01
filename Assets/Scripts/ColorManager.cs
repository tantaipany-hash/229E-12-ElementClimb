using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static Color selectedColor = Color.white;

    public void SetRed()
    {
        selectedColor = Color.red;
    }

    public void SetBlue()
    {
        selectedColor = Color.blue;
    }

    public void SetGreen()
    {
        selectedColor = Color.green;
    }
}