using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdsDemo : MonoBehaviour
{
    private BannerView bannerView;
    private RewardBasedVideoAd rewardBasedVideo;
    private InterstitialAd interstitial;

    public string appId = "ca-app-pub-...........................";
    public string bannerId = "ca-app-pub-ca-app-pub-...........................";
    public string interstitialId = "ca-app-pub-...........................";
    public string rewarededId = "ca-app-pub-...........................";

    private AddRequest request;
    private int npa;
       
    public void InitializeAdmob(int npa)
    {
        this.npa = npa;
        MobileAds.Initialize(appId);
           
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        interstitial = new InterstitialAd(interstitialId);
        bannerView = new BannerView(bannerId, AdSize.Banner, AdPosition.BottomLeft);
        
        //Add extra to request for GDPR.  0 = consent   1 = not consent
        request = new AdRequest.Builder().AddExtra("npa",npa.ToString()).Build();
    }
    
   
    public void RequestInterstitial()
    {
        interstitial.LoadAd(request);
    }

    private void RequestBanner()
    {
        bannerView.LoadAd(request);
        bannerView.Show();
    }
   
    private void RequestRewarded()
    {
        rewardBasedVideo.LoadAd(request, rewarededId);
    }
}
