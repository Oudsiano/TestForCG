using UnityEngine;

public class SolidRotateCube : MonoBehaviour
{
    private IRotationStrategy rotationStrategy;

    void Start()
    {
        rotationStrategy = new AcceleratingRotationStrategy(1800f, 100f, 4f);
    }

    void Update()
    {
        rotationStrategy.Rotate(transform);
    }
}

public interface IRotationStrategy
{
    void Rotate(Transform target);
}

public class AcceleratingRotationStrategy : IRotationStrategy
{
    private float rotationSpeed;
    private float acceleration;
    private float rotationDuration;
    private float currentRotationSpeed;

    public AcceleratingRotationStrategy(float initialSpeed, float acceleration, float duration)
    {
        rotationSpeed = initialSpeed;
        this.acceleration = acceleration;
        rotationDuration = duration;
        currentRotationSpeed = rotationSpeed;
    }

    public void Rotate(Transform target)
    {
        // Поворачиваем кубик вокруг своей оси
        target.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);

        // Увеличиваем скорость вращения
        currentRotationSpeed += acceleration * Time.deltaTime;

        // Если прошло указанное время, устанавливаем текущую скорость вращения на 0
        if (Time.timeSinceLevelLoad > rotationDuration)
        {
            currentRotationSpeed = 0f;
            OnRotationStopped();
        }
    }

    private void OnRotationStopped()
    {
        // Дополнительные действия после остановки вращения
    }
}
