using UnityEngine;
using UnityEditor;

public class CreaterWindow : EditorWindow
{
    [MenuItem("Window/Creater")]
    public static void ShowWindow()
    {
        GetWindow<CreaterWindow>("Creater");
    }
    private void OnGUI()
    {
        if (GUILayout.Button("EmptyBullet"))
        {
            GameObject bullet = new GameObject("EmptyBullet");
            bullet.AddComponent<SpriteRenderer>();
            Rigidbody2D a = bullet.AddComponent<Rigidbody2D>();
            a.gravityScale = 0;
            bullet.AddComponent<BoxCollider2D>();
            bullet.AddComponent<PlayerBullet>();
        }
        if (GUILayout.Button("EmptyEnemy"))
        {
            GameObject enemy = new GameObject("EmptyEnemy");
            enemy.tag = "Enemy";
            enemy.layer = 8;
            enemy.AddComponent<SpriteRenderer>();
            BoxCollider2D b = enemy.AddComponent<BoxCollider2D>();
            b.isTrigger = true;
            enemy.AddComponent<EnemyController>();
            Debug.Log("Ýçinde IEnemyAttack interface'si olan bi saldýrý kodu yazmalýsýn");
        }
    }
}
