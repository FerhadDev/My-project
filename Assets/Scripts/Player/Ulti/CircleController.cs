using UnityEngine;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public Image staticCircle;
    public Image shrinkingCircle;

    public float shrinkDuration = 5f;
    public float interval = 10f;
    
    private float shrinkTimer;
    private float intervalTimer;

    private bool isActive = false;

    private Vector2 staticPos;
    private float staticRadius;

    void Start()
    {
        // Başlanğıcda dairələri gizlədirik
        staticCircle.gameObject.SetActive(false);
        shrinkingCircle.gameObject.SetActive(false);

        staticPos = staticCircle.rectTransform.position;
        staticRadius = staticCircle.rectTransform.rect.width / 2f;

        intervalTimer = 0f;
    }

    void Update()
    {
        intervalTimer += Time.deltaTime;

        if (!isActive)
        {
            // Hər 10 saniyədən bir dairələri aktiv edirik
            if (intervalTimer >= interval)
            {
                ActivateCircles();
            }
        }
        else
        {
            // Kiçilən dairəni animasiya edirik
            shrinkTimer += Time.deltaTime;
            float scale = Mathf.Lerp(1f, 0f, shrinkTimer / shrinkDuration);
            shrinkingCircle.rectTransform.localScale = new Vector3(scale, scale, 1f);

            // Shift basılması yoxlanılır
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                if (IsOverlapping())
                {
                    Debug.Log("Uğurlu saldırı!");
                    DeactivateCircles();
                }
                else
                {
                    Debug.Log("Uğursuz, vaxtında basılmadı.");
                    DeactivateCircles();
                }
            }

            // Kiçilən dairə tam kiçilib bitibsə
            if (scale <= 0f)
            {
                Debug.Log("Vaxt bitdi, saldırı olmadı.");
                DeactivateCircles();
            }
        }
    }

    void ActivateCircles()
    {
        staticCircle.gameObject.SetActive(true);
        shrinkingCircle.gameObject.SetActive(true);
        shrinkingCircle.rectTransform.localScale = Vector3.one;
        shrinkTimer = 0f;
        intervalTimer = 0f;
        isActive = true;
    }

    void DeactivateCircles()
    {
        staticCircle.gameObject.SetActive(false);
        shrinkingCircle.gameObject.SetActive(false);
        isActive = false;
    }

    bool IsOverlapping()
    {
        Vector2 shrinkingPos = shrinkingCircle.rectTransform.position;
        float shrinkingRadius = (shrinkingCircle.rectTransform.rect.width / 2f) * shrinkingCircle.rectTransform.localScale.x;

        float distance = Vector2.Distance(staticPos, shrinkingPos);

        if (distance + shrinkingRadius <= staticRadius)
            return true;
        else
            return false;
    }
}
