using UnityEngine;

public static class SharedData
{
    // ����� ����������
    private static bool myBool;

    // ����� ��� ��������� �������� ����������
    public static bool GetMyBool()
    {
        return myBool;
    }

    // ����� ��� ��������� �������� ����������
    public static void SetMyBool(bool value)
    {
        myBool = value;
    }
}
