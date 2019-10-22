using RawInput_dll;
using System;
using System.Collections.Generic;
using System.Linq;


public static class HIDKeyboardControler
{
    static Dictionary<string, HIDScanner> scanners = new Dictionary<string, HIDScanner>();
    static RawInput raw;
    static OnFlush eventHandlerFlush;
    static OnKeyPressed eventhandlerKey;

    public static void SetupFor(IntPtr Handle, OnFlush onFlushEventHandler, OnKeyPressed onKeyPressedHandler)
    {
        eventHandlerFlush = onFlushEventHandler;
        eventhandlerKey = onKeyPressedHandler;
        raw = new RawInput(Handle, true);
        raw.AddMessageFilter();
        raw.KeyPressed += OnKeyPressed;
    }

    static void OnKeyPressed(object sender, RawInputEventArg e)
    {
        if (!scanners.Keys.Contains(e.KeyPressEvent.Source))
        {
            scanners.Add(e.KeyPressEvent.Source, new HIDScanner(e.KeyPressEvent.Source));
            scanners[e.KeyPressEvent.Source].FlushEvent += eventHandlerFlush;
            scanners[e.KeyPressEvent.Source].onKeyPressed += eventhandlerKey;
        }

        // Code 256 in e.KeyPressEvent.Message means key pressed
        if (e.KeyPressEvent.Message == 256)
        {
            // 16(0xA0) is for LShift and 17 (0xA1) is for RShift on microsoft Vkey code
            if (e.KeyPressEvent.VKey == 16 || e.KeyPressEvent.VKey == 0xA1)
            {
                scanners[e.KeyPressEvent.Source].Shift = true;
                return;
            }

            // 165(0xA5 is for AltGr or right menu
            if (e.KeyPressEvent.VKey == 165)
            {
                scanners[e.KeyPressEvent.Source].AltGr = true;
                return;
            }

            scanners[e.KeyPressEvent.Source].KeyPressed(e.KeyPressEvent.VKey);
        }
    }
}

