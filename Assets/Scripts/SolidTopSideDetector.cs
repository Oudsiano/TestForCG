using UnityEngine;

public class TopSideDetector : MonoBehaviour
{
    public Transform[] sides; // ????? ?????

    public void DetermineTopSide()
    {
        // ???? ??????, ??????? ????????? ???? ???? (????? ????????????? ?????????, ? ??????????? ?? ????? ??????????)
        Transform topSide = FindTopSide();

        if (topSide != null)
        {
            // ???????? ?????????? ? ????? (????????, ??? ??????? ??? ?????? ??????)
            Debug.Log(topSide.name);
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