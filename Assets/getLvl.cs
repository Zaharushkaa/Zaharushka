using UnityEngine;

public static class SharedData
{
    // Общая переменная
    private static bool myBool;

    // Метод для получения значения переменной
    public static bool GetMyBool()
    {
        return myBool;
    }

    // Метод для установки значения переменной
    public static void SetMyBool(bool value)
    {
        myBool = value;
    }
}
