
using TMPro;
using UnityEngine;

public class WuiPlayer : MonoBehaviour
{
    public TextMeshProUGUI textStatus;
    public float timeShow = 5f;

    public void SetTextStatus(string text)
    {
        textStatus.gameObject.SetActive(true);  
        textStatus.text = text;

        CancelInvoke("OffTextStatus");
        Invoke("OffTextStatus", timeShow);
    }

    void OffTextStatus()
    {
        textStatus.gameObject.SetActive(false);
    }
}
