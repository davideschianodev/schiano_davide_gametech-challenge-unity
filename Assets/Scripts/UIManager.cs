using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI notificationTitleText;
    public TextMeshProUGUI notificationMessageText;

    private static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ClearNotificationText();
    }

    public void HandleNotification(string notificationData)
    {
        string[] data = notificationData.Split('|');
        if (data.Length == 2)
        {
            string title = data[0];
            string message = data[1];

            if (notificationTitleText != null && notificationMessageText != null)
            {
                notificationTitleText.text = title;
                notificationMessageText.text = message;
            }
        }
    }

    public void ClearNotificationText()
    {
        if (notificationTitleText != null && notificationMessageText != null)
        {
            notificationTitleText.text = string.Empty;
            notificationMessageText.text = string.Empty;
        }
    }
}