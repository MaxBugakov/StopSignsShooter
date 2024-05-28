using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float sens = 700f;
    public Transform transformCamera;
    
    private Vector2 _turn;
    private static int score;
    private string pathToData = Application.streamingAssetsPath + "PlayerData.json";
    
    private void Awake()
    {
        if (File.Exists(pathToData))
        {
            string jsonText = File.ReadAllText(pathToData);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonText);
            score = playerData.Score;
            sens = playerData.Sensitivity;
        }
        else
        {
            PlayerData playerData = new PlayerData { Score = score, Sensitivity = sens };
            string json = JsonUtility.ToJson(playerData);
            File.WriteAllText(pathToData, json);
        }
        PointController.UpdateScore();
    }

    private void Start()
    {
        // Блокировка курсора.
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        if (!MenuController.isMenuOpen)
        {
            Movement(speed);
            Turn(sens);
        }
        Sensivity();
    }
    
    // Сенса.
    private void Sensivity()
    {
        if (Input.GetKeyDown(KeyCode.Minus) && sens > 100)
        {
            sens -= 100;
        }
        if (Input.GetKeyDown(KeyCode.Equals) && sens < 2000)
        {
            sens += 100;
        }
    }
    
    // Передвижение.
    private void Movement(float speed)
    {
        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.forward;
          
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
        }
        transform.Translate(velocity.normalized * speed * Time.deltaTime);
    }
    
    // Поворот.
    private void Turn(float sens)
    {
        _turn.x += Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        _turn.y += Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        _turn.y = Mathf.Clamp(_turn.y, -90f, 90f);
        transform.localRotation = Quaternion.Euler(0, _turn.x, 0);
        transformCamera.localRotation = Quaternion.Euler(-_turn.y, 0, 0);
    }
    
    // Добавление очка.
    public void AddScore()
    {
        score += 1;
        PlayerData playerData = new PlayerData { Score = score, Sensitivity = sens };
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(pathToData, json);
        PointController.UpdateScore();
    }

    public int Score
    { 
        get { return score; }
    }
}


