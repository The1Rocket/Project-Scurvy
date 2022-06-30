using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetCard : MonoBehaviour
{
    [SerializeField] RectTransform fleetUICard;

    public void MoveCardUpInterpreter()
    {
        StartCoroutine(MoveCardUp());
    }

    public void MoveCardDownInterpreter()
    {
        StartCoroutine(MoveCardDown());
    }

    public IEnumerator MoveCardUp()
    {
        yield return new WaitForSeconds(1);
        //-400 to -480
        float waitTime = .3f;
        float elapsedTime = 0;

        while (elapsedTime < waitTime)
        {
            fleetUICard.anchoredPosition = new Vector2(fleetUICard.anchoredPosition.x, Mathf.Lerp(-495, -400, (elapsedTime / waitTime)));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        fleetUICard.anchoredPosition = new Vector2(fleetUICard.anchoredPosition.x, -400);
        yield return null;
    }

    public IEnumerator MoveCardDown()
    {
        float waitTime = .3f;
        float elapsedTime = 0;

        while (elapsedTime < waitTime)
        {
            fleetUICard.anchoredPosition = new Vector2(fleetUICard.anchoredPosition.x, Mathf.Lerp(-400, -495, (elapsedTime / waitTime)));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        fleetUICard.anchoredPosition = new Vector2(fleetUICard.anchoredPosition.x, -495);
        yield return null;
    }
}
