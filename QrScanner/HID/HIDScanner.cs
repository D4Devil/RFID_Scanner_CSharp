using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public delegate void OnFlush(Object sender, string message);
public delegate void OnKeyPressed(int vKey, string key);

public class HIDScanner: IEquatable<string>
{

    string name { get; }
    bool shiftPressed;
    bool altGrPressed;
    Queue<string> buffer;
    Object _lock = new object();
    /// <summary>
    /// Shift and Control can only be set to true
    /// </summary>
    public bool Shift
    {
        get { return shiftPressed; }
        set
        {
            if (value)
                shiftPressed = true;
        }
    }
    public bool AltGr
    {
        get { return altGrPressed; }
        set
        {
            if (value)
                altGrPressed = true;
        }
    }
    public int flushVKey;
    public event OnFlush FlushEvent;
    public event OnKeyPressed onKeyPressed;

    static string scannerSecretString = "00E00000E000";
    bool imAScanner;
    public static string SecretString { get { return "A Secret Key May Not Be Shared"; } set { scannerSecretString = value; } }

    public HIDScanner(string name)
    {
        this.name = name;
        imAScanner = false;
        flushVKey = 13;
        FlushEvent += Print;
        onKeyPressed += Print;
        buffer = new Queue<string>();
    }

    void Flush()
    {
        string message = "";

        while(buffer.Count > 0)
            message += buffer.Dequeue();

        FlushEvent(null, message);

        if (imAScanner)
        {
            FlushEvent(name, message);
        }
        else if (message.Equals(scannerSecretString))
            imAScanner = true;
    }

    public void KeyPressed(int vKey)
    {
        lock (_lock)
        {
            // 'Enter' key pressed: 13
            if (vKey == flushVKey)
                Flush();
            else
            {
                string key = GetCharsFromKeys(vKey);
                buffer.Enqueue(key);
                onKeyPressed(vKey, key);
            }
        }

        shiftPressed = false;
        altGrPressed = false;
    }


    #region Helper Methods
    string GetCharsFromKeys(int keys)
    {
        var buf = new StringBuilder(256);
        var keyboardState = new byte[256];
        if (shiftPressed)
            keyboardState[(int)System.Windows.Forms.Keys.ShiftKey] = 0xff;
        if (altGrPressed)
        {
            keyboardState[(int)System.Windows.Forms.Keys.ControlKey] = 0xff;
            keyboardState[(int)System.Windows.Forms.Keys.Menu] = 0xff;
        }

        ToUnicode((uint)keys, 0, keyboardState, buf, 256, 0);
        return buf.ToString();
    }

    [DllImport("user32.dll")]
    public static extern int ToUnicode(uint virtualKeyCode, uint scanCode,
    byte[] keyboardState,
    [Out, MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
    StringBuilder receivingBuffer,
    int bufferSize, uint flags);

    private void Print(Object o, string message)
    {
        Console.WriteLine(name + " OnFlush: " + message);
    }
    
    private void Print(int vKey, string key)
    {
        Console.WriteLine(" vKey " + vKey + " key ' " + key + "'");
    }
    #endregion

    public bool Equals(string other)
    {
        return (name.Equals(other)) ? true : false;
    }
}

