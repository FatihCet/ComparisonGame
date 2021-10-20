using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject geriSayimObje;

    [SerializeField]
    private Text geriyeSayimText;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();

    }



    void Start()
    {

        StartCoroutine(GeriyeSayRoutine());


    }
    
    IEnumerator GeriyeSayRoutine()
    {
        geriyeSayimText.text = "3";
        yield return new WaitForSeconds(0.5f);

        geriSayimObje.GetComponent<RectTransform>().DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriyeSayimText.text = "2";
        yield return new WaitForSeconds(0.5f);

        geriSayimObje.GetComponent<RectTransform>().DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        geriyeSayimText.text = "1";
        yield return new WaitForSeconds(0.5f);

        geriSayimObje.GetComponent<RectTransform>().DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1f);
        geriSayimObje.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.6f);

        StopAllCoroutines();

        gameManager.OyunaBasla();
        


    }

   
}
