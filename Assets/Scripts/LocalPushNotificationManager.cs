using UnityEngine;
using TMPro;

public class LocalPushNotificationManager : MonoBehaviour
{
    public TextMeshProUGUI actionMessage;
    public Transform panel;

    public void ScheduleNotifications()
    {
        ShowTemporaryMessage("5 NOTIFICATIONS SCHEDULED");

        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            using (AndroidJavaClass bridge = new AndroidJavaClass("com.schianodavide.miniclip.LocalPushNotificationManager"))
            {
                bridge.CallStatic("scheduleNotifications", currentActivity);
            }
        }
    }

    public void RemoveNotifications()
    {
        ShowTemporaryMessage("SCHEDULED NOTIFICATIONS REMOVED");

        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            using (AndroidJavaClass bridge = new AndroidJavaClass("com.schianodavide.miniclip.LocalPushNotificationManager"))
            {
                bridge.CallStatic("removeNotifications", currentActivity);
            }
        }
    }

    private void ShowTemporaryMessage(string message)
    {
        TextMeshProUGUI messageText = Instantiate(actionMessage, panel);
        messageText.text = message;

        Destroy(messageText.gameObject, 3f);
    }
}
