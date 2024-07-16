using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Q_and_A : MonoBehaviour
{
    public GameObject Quiz_Q;
    public Material Q_1;
    public Material A_1;
    public Material A_2;
    public Material A_3;

    public AudioClip explosionSound_Correct; // 正解音
    public AudioClip explosionSound_Incorrect; // 不正解音

    private AudioSource audioSource;

    private Image quizImage;

    void Start()
    {
        quizImage = Quiz_Q.GetComponent<Image>();

        // AudioSourceコンポーネントを取得または追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnButtonClick()
    {
        _ = AnswerAsync();
    }

    private async Task AnswerAsync()
    {
        if (this.gameObject.CompareTag("Correct"))
        {
            AudioSource.PlayClipAtPoint(explosionSound_Correct, transform.position);
            quizImage.material = A_1;
            await Task.Delay(2000); // 2秒間待機
            quizImage.material = A_2;
        }
        else if (this.gameObject.CompareTag("Incorrect"))
        {
            AudioSource.PlayClipAtPoint(explosionSound_Incorrect, transform.position);
        }
        
    }
}