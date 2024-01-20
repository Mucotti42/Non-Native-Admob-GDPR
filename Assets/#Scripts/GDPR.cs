using UnityEngine;
public class GDPR : MonoBehaviour
{
    [SerializeField] private GameObject gdprPanel;
    private const string privacyUrl = "http://example.com/privacy-policy";
    
    public GoogleAdsDemo admob;
    private void Awake()
    {
        CheckGDRPAnswer();
    }

    private void CheckGDRPAnswer()
    {
        if(!PlayerPrefs.HasKey("npa"))
        {
            Time.timeScale = 0f;
            gdprPanel.SetActive(true);
        }
        else
        {
            var npa = PlayerPrefs.GetInt("npa");
            admob.InitializeAdmob(npa);
        }
    }
    
    //-1 npa = default    0 = consent   1 = not consent
    //Button
    public void AcceptGDPR()
    {
        PlayerPrefs.SetInt("npa",0);
        gdprPanel.SetActive(false);
        Time.timeScale = 1f;
        
        admob.InitializeAdmob(0);
    }
    //Button
    public void RejectGDPR()
    {
        PlayerPrefs.SetInt("npa",1);
        gdprPanel.SetActive(false);
        Time.timeScale = 1f;
        admob.InitializeAdmob(1);
    }
    //Button
    public void PrivacyPolicy()
    {
        Application.OpenURL(privacyUrl);
    }
}