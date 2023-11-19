using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float rotationSpeed = 1800f; // Начальная скорость вращения в градусах в секунду
    public float acceleration = 100f; // Ускорение вращения в градусах в секунду^2
    public float rotationDuration = 4f; // Длительность вращения в секундах

    private float currentRotationSpeed;

    void Start()
    {
        currentRotationSpeed = rotationSpeed;
    }

    void Update()
    {
        // Поворачиваем кубик вокруг своей оси
        transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);

        // Увеличиваем скорость вращения
        currentRotationSpeed += acceleration * Time.deltaTime;

        // Если прошло указанное время, устанавливаем текущую скорость вращения на 0
        if (Time.timeSinceLevelLoad > rotationDuration)
        {
            currentRotationSpeed = 0f;

            // Дополнительные действия после остановки вращения (например, вызов другого метода)
            OnRotationStopped();
        }
    }

    void OnRotationStopped()
    {
        // Действия, которые нужно выполнить после остановки вращения
        //Debug.Log("Вращение остановлено.");
    }
}
