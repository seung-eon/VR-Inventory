using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    //�ٸ� Ŭ�������� ���ٰ����ؾ���
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    //������ ����Ʈ
    public List<Item> itemDB = new List<Item>();
    [Space(9)]
    public GameObject fieldItemPrefab; //�ʵ������ ����(����) ����
    public Vector3[] pos; //������ ������ ��ġ

    private void Start()
    {
        for(int i = 0; i<4; i++)
        {
            GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[i]); //Random.Range(0,5)
        }
    }
}
