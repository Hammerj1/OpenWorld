using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Tools {
    public static Vector3 RandomVector()
    {
        return new Vector3(Random.Range(0, 10), 5, Random.Range(0, 10));
    }
    public static string RandomString(int size)
    {
        StringBuilder builder = new StringBuilder();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = System.Convert.ToChar(System.Convert.ToInt32(Mathf.Floor(Random.Range(97,122))));
            builder.Append(ch);
        }

        return builder.ToString();
    }
    public static string CombineStrings(string[] msg)
    {
        return string.Join(" ", msg);
    }

}
