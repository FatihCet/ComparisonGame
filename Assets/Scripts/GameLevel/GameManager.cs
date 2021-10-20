using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puanSurePaneli;

    [SerializeField]
    private GameObject pausePaneli,sonucPaneli;

    [SerializeField]
    private GameObject puaniKapYazisi,buyukOlanSayiyiSec;

    [SerializeField]
    private GameObject ustDikdortgen, altDikdortgen;

    [SerializeField]
    private Text ustText, altText;

    int oyunSayac, kacinciOyun;

    int altDeger, ustDeger;

    int buyukDeger;

    int butonDegeri;
    int dogruAdet, yanlısAdet;
    int toplamPuan, artisMiktari;

    [SerializeField]
    private AudioClip baslangicSesi,dogruSesi,bitisSesi,yanlısSesi;

    private AudioSource audioSource;

    TrueFalseManager trueFalseManager;
    TimerManager timerManager;
    DairelerManager dairelerManager;
    SonucManager sonucManager;






    private void Awake()
    {
        
        timerManager = Object.FindObjectOfType<TimerManager>();
        dairelerManager = Object.FindObjectOfType<DairelerManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();
        audioSource = GetComponent<AudioSource>();
        
        
    }
    void Start()
    {

        kacinciOyun = 0;
        oyunSayac = 0;

        ustText.text = "";
        altText.text = "";
        SahneEkraniniGuncelle();

    }
    
        


    void SahneEkraniniGuncelle()
    {

        puanSurePaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);

        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(2, 2f);

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(5f, 0.7f).SetEase(Ease.OutBack);

        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX(0f, 0.7f).SetEase(Ease.OutBack);

        OyunaBasla();
        


    }

    public void OyunaBasla()
    {

        audioSource.PlayOneShot(baslangicSesi);

        puaniKapYazisi.GetComponent<CanvasGroup>().DOFade(0, 1f);
        buyukOlanSayiyiSec.GetComponent<CanvasGroup>().DOFade(3, 2f);
        

        KacinciOyun();
        timerManager.SureyiBaslat();
    }

    void KacinciOyun()
    {
        if (oyunSayac < 5)
        {
            kacinciOyun = 1;
        }
        else if (oyunSayac >= 5 && oyunSayac <= 10)
        {
            kacinciOyun = 2;
        }
        else if (oyunSayac >= 10 && oyunSayac < 15)
        {
            kacinciOyun = 3;
        }
        else if (oyunSayac >= 15 && oyunSayac < 20)
        {
            kacinciOyun = 4;
        }
        else if(oyunSayac>=20 && oyunSayac < 25)
        {
            kacinciOyun = 5;
        }
        else
        {
            kacinciOyun = Random.Range(1, 6);
        }
           

        switch (kacinciOyun)
        {
                case 1:
                BirinciFonksiyon();
                break;

                case 2:
                IkinciFonksiyon();

                break;

                case 3:
                UcuncuFonksiyon();
                break;

                case 4:
                DortuncuFonksiyon();
                break;

                case 5:
                BesinciFonksiyon();
                break;

        }

    }

    void BirinciFonksiyon()
    {

        int rasgeleDeger = Random.Range(1, 50);

        if (rasgeleDeger <= 25)
        {
            ustDeger = Random.Range(2, 50);
            altDeger = ustDeger + Random.Range(1, 15);
        }
        else
        {
            ustDeger = Random.Range(2, 50);
            altDeger = Mathf.Abs(ustDeger - Random.Range(1, 15));
        }
        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger = altDeger;
        }

        if (ustDeger == altDeger)
        {
            BirinciFonksiyon();
            return;
        }

        ustText.text = ustDeger.ToString();
        altText.text = altDeger.ToString();

    }

    void IkinciFonksiyon()
    {
        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 20);
        int ucuncuSayi = Random.Range(1, 10);
        int dortuncuSayi = Random.Range(1, 20);

        ustDeger = birinciSayi + ikinciSayi;
        altDeger = ucuncuSayi + dortuncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }


        if (buyukDeger == altDeger)
        {

            IkinciFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "+" + ikinciSayi;
        altText.text = ucuncuSayi + "+" + dortuncuSayi;




    }

    void UcuncuFonksiyon()
    {
        int birinciSayi = Random.Range(11, 30);
        int ikinciSayi = Random.Range(1, 11);
        int ucuncuSayi = Random.Range(11, 40);
        int dortuncuSayi = Random.Range(1, 11);

        ustDeger = birinciSayi - ikinciSayi;
        altDeger = ucuncuSayi - dortuncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }


        if (buyukDeger == altDeger)
        {

            UcuncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "-" + ikinciSayi;
        altText.text = ucuncuSayi + "-" + dortuncuSayi;

    }

    void DortuncuFonksiyon()
    {

        int birinciSayi = Random.Range(1, 10);
        int ikinciSayi = Random.Range(1, 10);
        int ucuncuSayi = Random.Range(1, 10);
        int dortuncuSayi = Random.Range(1, 10);

        ustDeger = birinciSayi * ikinciSayi;
        altDeger = ucuncuSayi * dortuncuSayi;

        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }


        if (buyukDeger == altDeger)
        {

            DortuncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "x" + ikinciSayi;
        altText.text = ucuncuSayi + "x" + dortuncuSayi;

    }

    void BesinciFonksiyon()
    {
        int bolen1 = Random.Range(2, 10);
        ustDeger = Random.Range(2, 10);
        int bolunen1 = bolen1 * ustDeger;

        int bolen2 = Random.Range(2, 10);
        altDeger = Random.Range(2, 10);
        int bolunen2 = bolen2 * altDeger;


        if (ustDeger > altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if (ustDeger < altDeger)
        {
            buyukDeger = altDeger;
        }


        if (buyukDeger == altDeger)
        {

            BesinciFonksiyon();
            return;
        }

        ustText.text = bolunen1 + "/" + bolen1;
        altText.text = bolunen2 + "/" + bolen2;

    }

    public void ButonDegeriniBelirle(string butonAdi)
    {
        if (butonAdi == "ustButon")
        {
            butonDegeri = ustDeger;
        }
        else if (butonAdi == "altButon")
        {
            butonDegeri = altDeger;
        }

        if (butonDegeri == buyukDeger)
        {

            trueFalseManager.TrueFalseScaleAc(true);
            dairelerManager.DaireninScaleAc(oyunSayac % 5);
            
            oyunSayac++;
            dogruAdet++;
            audioSource.PlayOneShot(dogruSesi);

            KacinciOyun();
        }
        else 
        {
            HatayaGoreSayaciAzalt();
            KacinciOyun();
            yanlısAdet--;
            audioSource.PlayOneShot(yanlısSesi);
            trueFalseManager.TrueFalseScaleAc(false);
        }
        void HatayaGoreSayaciAzalt()
        {
            oyunSayac -= (oyunSayac % 5 + 5);

            if (oyunSayac < 0)
            {
                oyunSayac = 0;
            }

            dairelerManager.DairelerinScaleKapat();
        }


    }

    public void PausePaneliniAc()
    {
        pausePaneli.SetActive(true);
    }

    public void OyunuBitir()
    {

        audioSource.PlayOneShot(bitisSesi);
        sonucPaneli.SetActive(true);
        sonucManager = Object.FindObjectOfType<SonucManager>();
        sonucManager.SonuclariGoster(dogruAdet,yanlısAdet,toplamPuan);
        
    }
    
}
