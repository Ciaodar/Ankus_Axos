using UnityEngine;
using TMPro;

public class AssignTimePanel : MonoBehaviour
{
    public static AssignTimePanel Instance;
    public TMP_InputField inputField;
    private GameObject targetObject;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Open(GameObject obj)
    {
        targetObject = obj;
        inputField.text = "";
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnConfirm()
    {
        if (inputField == null || targetObject == null || Timer.Instance == null)
            return;

        float time;
        if (float.TryParse(inputField.text, out time) && Timer.Instance.TryAssignTime(time))
        {
            var destroyScript = targetObject.AddComponent<DestroyAfterTime>();
            destroyScript.SetTime(time);
            gameObject.SetActive(false);
        }
        else
        {
            // Hatalı giriş veya yetersiz süre
            inputField.text = "Hatalı!";
        }
    }
}