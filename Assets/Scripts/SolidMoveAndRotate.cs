using UnityEngine;
using DG.Tweening;

public class SolidMoveAndRotate : MonoBehaviour
{
    [SerializeField]
    private Transform[] pathObjects; // Объекты для движения

    void Start()
    {
        PerformMoveAndRotate();
    }

    void PerformMoveAndRotate()
    {
        if (pathObjects == null || pathObjects.Length < 2)
        {
            Debug.LogError("Необходимо задать как минимум два объекта для движения.");
            return;
        }

        Vector3[] pathPoints = new Vector3[pathObjects.Length];

        for (int i = 0; i < pathObjects.Length; i++)
        {
            pathPoints[i] = pathObjects[i].position;
        }

        float moveDuration = 4f;
        float rotateDuration = 2f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalPath(pathPoints, moveDuration, PathType.CatmullRom)
            .SetOptions(false)
            .SetEase(Ease.Linear));

        Vector3 randomRotation = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        sequence.Append(transform.DORotate(randomRotation, rotateDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear));

        sequence.OnComplete(() =>
        {
            Invoke("CallDetermineTopSide", 3f);
        });
    }

    void CallDetermineTopSide()
    {
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
