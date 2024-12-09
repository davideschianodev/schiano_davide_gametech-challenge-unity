using UnityEngine;

public class LocalPushNotificationManager : MonoBehaviour
{
    public void ScheduleNotifications()
    {
        Debug.Log("Unity: Calling scheduleNotifications");
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            using (AndroidJavaClass bridge = new AndroidJavaClass("com.schianodavide.miniclip.LocalPushNotificationManager"))
            {
                bridge.CallStatic("scheduleNotifications", currentActivity);
            }
        }
    }
}
