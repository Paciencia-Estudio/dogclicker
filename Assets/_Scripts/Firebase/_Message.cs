using System;

[Serializable]
public class _Message
{
    public string sender;
    public string text;

    public _Message(string sender, string text)
    {
        this.sender = sender;
        this.text = text;
    }
}
