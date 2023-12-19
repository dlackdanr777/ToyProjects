using UnityEngine;
using Muks.DataBind;

public class DataBindSystem : MonoBehaviour
{
    [SerializeField] private Sprite _testImage;
    [SerializeField] private string _testText = "Data Binding Test";
    private void Awake()
    {
        //ID���� TextTest�� Text, Text Mesh Pro ������Ʈ�� string�� ���ε��Ѵ�.
        DataBind.SetTextValue("TextTest", _testText);

        //ID���� SpriteTest�� Image, Sprite Renderer ������Ʈ�� Sprite�� ���ε��Ѵ�.
        DataBind.SetSpriteValue("SpriteTest", _testImage);

        //ID���� ButtonTest�� Button������Ʈ�� �Լ��� ���ε��Ѵ�.
        DataBind.SetButtonValue("ButtonTest", OnButtonClicked);
    }

    private void Update()
    {
        //ID���� TextTest�� Text, Text Mesh Pro ������Ʈ�� string�� ���ε��Ѵ�.
        //_testText�� ���� ���� ��� ����� �� ����
        DataBind.SetTextValue("TextTest", _testText);

        //ID���� SpriteTest�� Image, Sprite Renderer ������Ʈ�� Sprite�� ���ε��Ѵ�.
        // _testImage�� ���� ���� ��� ����� �� ����
        DataBind.SetSpriteValue("SpriteTest", _testImage);
    }

    private void OnButtonClicked()
    {
        Debug.Log("��ư�� ���Ƚ��ϴ�.");
    }
}


