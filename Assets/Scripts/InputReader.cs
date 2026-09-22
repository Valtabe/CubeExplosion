using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    public bool MouseLeftButtonClicked
    {
        get
        {
            return Input.GetMouseButtonDown(0); 
        }
    }

    public float InputHorizontalDiraction()
    {
        return Input.GetAxis(Horizontal);
    }

    public float InputVerticalDiraction()
    {
        return Input.GetAxis(Vertical);
    }
}
