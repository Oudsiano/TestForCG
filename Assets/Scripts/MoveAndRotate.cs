using UnityEngine;
using DG.Tweening;

public class MoveAndRotate : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathObjects; // Объекты для движения

    void Start()
    {
        // Вызываем метод для движения и вращения
        PerformMoveAndRotate();
    }

    void PerformMoveAndRotate()
    {
        // Используйте ваш код для движения и вращения
        if (pathObjects == null || pathObjects.Length < 2)
        {
            Debug.LogError("Необходимо задать как минимум два объекта для движения.");
            return;
        }

        Vector3[] pathPoints = new Vector3[pathObjects.Length];

        // Получаем позиции из объектов
        for (int i = 0; i < pathObjects.Length; i++)
        {
            pathPoints[i] = pathObjects[i].position;
        }

        float moveDuration = 4f;
        float rotateDuration = 2f;

        // Используйте ваш код для движения и вращения
        Sequence sequence = DOTween.Sequence();

        // Добавляем движение по точкам
        sequence.Append(transform.DOLocalPath(pathPoints, moveDuration, PathType.CatmullRom)
            .SetOptions(false)
            .SetEase(Ease.Linear));

        // Добавляем вращение вокруг своей оси
        sequence.Append(transform.DORotate(new Vector3(0f, 360f, 0f), rotateDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear));

        // Вызываем метод после завершения анимации с задержкой в 3 секунды
        sequence.OnComplete(() =>
        {
            // Вызываем метод в объекте TopSideDetector через 3 секунды
            Invoke("CallDetermineTopSide", 3f);
        });
    }

    void CallDetermineTopSide()
    {
        // Вызываем метод в объекте TopSideDetector
        TopSideDetector topSideDetector = GetComponent<TopSideDetector>();
        if (topSideDetector != null)
        {
            topSideDetector.DetermineTopSide();
        }
        else
        {
            Debug.LogError("Скрипт TopSideDetector не найден на этом объекте.");
        }
    }
}
