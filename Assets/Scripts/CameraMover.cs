using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.CameraInputing += RotateCamera;
    }

    private void OnDisable()
    {
        _inputReader.CameraInputing -= RotateCamera;
    }

    private void RotateCamera(float xInputDiraction, float yInputDiraction)
    {
        _camera.Rotate(_speed * -yInputDiraction * Time.deltaTime * Vector3.right);
        _body.Rotate(_speed * xInputDiraction * Time.deltaTime * Vector3.up);
    }
}
