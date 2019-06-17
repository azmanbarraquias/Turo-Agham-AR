using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneController : MonoBehaviour {

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 4f;
    public const float offsetY = 5f;

    public GameObject resultUI;
    public AudioSource audioSource;
    public AudioClip correctSound, wrongSound, finishSound;

    [SerializeField] private MainCardO originalCard;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        Vector3 startPos = originalCard.transform.position; //The position of the first card. All other cards are offset from here.

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3};
        numbers = ShuffleArray(numbers); //This is a function we will create in a minute!

        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                MainCardO card;
                if(i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCardO;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------

    private MainCardO _firstRevealed;
    private MainCardO _secondRevealed;

    private int _score = 0;
    [SerializeField] private TextMeshProUGUI scoreLabel;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCardO card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if(_firstRevealed.id == _secondRevealed.id)
        {
            audioSource.Stop();
            audioSource.clip = correctSound;
            audioSource.Play();
            _score++;
            scoreLabel.text = _score + "/4";
            if (_score == 4)
            {
                audioSource.Stop();
                audioSource.clip = finishSound;
                audioSource.Play();
                resultUI.SetActive(true);
            }
        }
        else
        {
            audioSource.Stop();
            audioSource.clip = wrongSound;
            audioSource.Play();
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;

    }

}
