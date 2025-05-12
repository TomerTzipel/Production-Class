using MoreMountains.Feedbacks;
using UnityEngine;
public class WeaponVisual : MonoBehaviour
{
    [SerializeField] public MMF_Player ShotGunShotFeedback;

    public void ShotgunShot()
    {
        ShotGunShotFeedback.PlayFeedbacks();
    }
}
