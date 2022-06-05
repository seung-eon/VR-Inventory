using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    # region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    //�������� ȹ���ϸ� ����UI�� �߰�
    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    //ȹ���� ������ ����Ʈ
    public List<Item>items = new List<Item>();

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set{
            slotCnt = value;
            if (onSlotCountChange != null)
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    void Start()
    {
        SlotCnt = 9; 
    }

    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if (onChangeItem != null)
            onChangeItem.Invoke(); //������ �߰��� �����ϸ� OnChangeItemȣ��
            return true;
        }
        return false;
    }

    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }

    //�÷��̾�� �ʵ�������� �浹�ϸ� AddItem�� ȣ���ؼ� Item ������ ���ڷ� �Ѱ���
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("FieldItem"))
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            if (AddItem(fieldItems.GetItem()))
                fieldItems.DestroyItem(); //������ ȹ��� �ʵ忡�� ����
        }
    }
}
