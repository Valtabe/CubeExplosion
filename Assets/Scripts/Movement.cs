using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _inputReader.DiractionInputing += Move;
    }

    private void OnDisable()
    {
        _inputReader.DiractionInputing -= Move;
    }

    private void Move(float horizontalDiraction, float verticalDiraction)
    {
        Vector3 diractrion = new Vector3(horizontalDiraction, 0f, verticalDiraction);

        transform.Translate(_speed * Time.deltaTime * diractrion);
    }
}
