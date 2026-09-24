using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _inputReader.DirectionInputing += Move;
    }

    private void OnDisable()
    {
        _inputReader.DirectionInputing -= Move;
    }

    private void Move(float horizontalDiraction, float verticalDiraction)
    {
        Vector3 diractrion = new Vector3(horizontalDiraction, 0f, verticalDiraction);

        transform.Translate(_speed * Time.deltaTime * diractrion);
    }
}
