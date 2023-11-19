using UnityEngine;

public class TopSideDetector : MonoBehaviour
{
    public Transform[] sides; // ????? ?????

    void Start()
    {
        // ???????? ? ?????????????? ?? ??????? ? ??????? ? ??????? MoveAndRotate
        D20Movement  moveAndRotateScript = GetComponent<D20Movement>();
        if (moveAndRotateScript != null)
        {
            // ????????? ???????? ????? ?????????? ???????? ? ????????
            StartCoroutine(WaitForMoveAndRotateCompletion(moveAndRotateScript));
        }
        else
        {
            Debug.LogError("?????? MoveAndRotate ?? ?????? ?? ???? ???????.");
        }
    }

    private System.Collections.IEnumerator WaitForMoveAndRotateCompletion(D20Movement moveAndRotateScript)
    {
        // ????, ???? ???????? ?? ??????????
        yield return new WaitUntil(() => moveAndRotateScript.IsAnimationComplete);

        // ????? ?????????? ????????, ?????????? ??????? ?????
        DetermineTopSide();
    }

    void DetermineTopSide()
    {
        // ???? ??????, ??????? ????????? ???? ???? (????? ????????????? ?????????, ? ??????????? ?? ????? ??????????)
        Transform topSide = FindTopSide();

        if (topSide != null)
        {
            // ???????? ?????????? ? ????? (????????, ??? ??????? ??? ?????? ??????)
            Debug.Log("?????, ??????????? ??????: " + topSide.name);
        }
        else
        {
            Debug.LogError("?? ??????? ?????????? ??????? ?????.");
        }
    }

    Transform FindTopSide()
    {
        // ????????????, ??? ??????? ????? - ??? ????? ? ???????????? ??????????? Y
        Transform topSide = null;
        float maxY = float.MinValue;

        foreach (Transform side in sides)
        {
            float sideY = side.position.y;
            if (sideY > maxY)
            {
                maxY = sideY;
                topSide = side;
            }
        }

        return topSide;
    }
}