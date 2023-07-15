using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour,IEndDragHandler,IDragHandler,IDataPersistance
{
    
    [SerializeField] Canvas canvas;
    [SerializeField] Transform player;
    public float maxRadius;
    RectTransform rectTransform;
    Vector2 startPos;
    Vector3 differance = Vector3.zero;
    float angle;
    float moveSpeed;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }
    public void MoveSpeedUp(float speedAmount)
    {
        moveSpeed += speedAmount;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += 2*eventData.delta/canvas.scaleFactor;
        differance = rectTransform.anchoredPosition - startPos;
        angle = Mathf.Atan2(differance.y, differance.x);
        player.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle - 90);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = startPos;
        differance = Vector3.zero;

    }
    private void Update()
    {
        
        if(differance.magnitude != 0)
        {
            if (differance.magnitude <= maxRadius)
            {
                MovePlayer(differance, angle);
            }
            else
            {

                Vector2 other = new Vector2(Mathf.Cos(angle) * maxRadius, Mathf.Sin(angle) * maxRadius);
                MovePlayer(other, angle);
            }
        }

    }
    public void MovePlayer(Vector3 moveVector,float angle)
    {
        player.transform.position += moveVector * Time.deltaTime * moveSpeed * 0.0005f;
        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
    }

    public void LoadData(GameData data)
    {
        moveSpeed = data.MoveSpeed;
    }

    public void SaveData(ref GameData data)
    {
        data.MoveSpeed = moveSpeed;
    }
}