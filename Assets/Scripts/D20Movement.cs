using UnityEngine;
using DG.Tweening;

public class D20Movement : MonoBehaviour
{
    public Transform[] pathPoints; // Точки для движения
    public float moveDuration = 4f; // Длительность движения
    public float rotateDuration = 2f; // Длительность вращения

    public System.Action OnD20MovementComplete { get; internal set; }
    public bool IsAnimationComplete { get; internal set; }

    void Start()
    {
        // Выполняем движение и вращение при запуске сцены (или по событию)
        MoveAndRotate();
    }

    void MoveAndRotate()
    {
        // Используем DOLocalPath для движения по точкам
        transform.DOLocalPath(pathPoints.ToVector3Array(), moveDuration, PathType.CatmullRom)
            .SetOptions(false)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // Когда движение завершено, определяем, какая сторона находится сверху
                DetermineTopSide();
            });

        // Используем DORotate для вращения вокруг своей оси
        transform.DORotate(new Vector3(0f, 360f, 0f), rotateDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                Debug.Log("Вращение завершено.");
            });
    }

    void DetermineTopSide()
    {
        // Генерируем случайное число от 1 до 20 (результат броска)
        int result = Random.Range(1, 21);

        // Определение, какая сторона находится сверху, может быть реализовано, например, через цвета, теги, и т.д.
        // Здесь просто выводим результат в консоль
        Debug.Log("Строна, находящаяся сверху: " + result);
    }
}

public static class TransformExtensions
{
    public static Vector3[] ToVector3Array(this Transform[] transforms)
    {
        return System.Array.ConvertAll(transforms, t => t.position);
    }
}
