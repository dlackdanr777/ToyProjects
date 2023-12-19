using UnityEngine;
using Muks.DataBind;

public class DataBindSystem : MonoBehaviour
{
    [SerializeField] private Sprite _testImage;
    [SerializeField] private string _testText = "Data Binding Test";
    private void Awake()
    {
        //ID값이 TextTest인 Text, Text Mesh Pro 컴포넌트에 string을 바인딩한다.
        DataBind.SetTextValue("TextTest", _testText);

        //ID값이 SpriteTest인 Image, Sprite Renderer 컴포넌트에 Sprite를 바인딩한다.
        DataBind.SetSpriteValue("SpriteTest", _testImage);

        //ID값이 ButtonTest인 Button컴포넌트에 함수를 바인딩한다.
        DataBind.SetButtonValue("ButtonTest", OnButtonClicked);
    }

    private void Update()
    {
        //ID값이 TextTest인 Text, Text Mesh Pro 컴포넌트에 string을 바인딩한다.
        //_testText의 값이 변할 경우 변경된 값 전달
        DataBind.SetTextValue("TextTest", _testText);

        //ID값이 SpriteTest인 Image, Sprite Renderer 컴포넌트에 Sprite를 바인딩한다.
        // _testImage의 값이 변할 경우 변경된 값 전달
        DataBind.SetSpriteValue("SpriteTest", _testImage);
    }

    private void OnButtonClicked()
    {
        Debug.Log("버튼이 눌렸습니다.");
    }
}


