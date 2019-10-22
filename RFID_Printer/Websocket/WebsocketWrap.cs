using Fleck;
using System;
using Newtonsoft.Json;

namespace RFID_Printer.Websocket
{
    public delegate WebsocketMessage WebsocketOnMessageRecived(WebsocketMessage message);

    public class WebsocketWrap
    {
        int port;
        string PartialURL = "ws://127.0.0.1:";
        string URL { get { return PartialURL + port; } }

        WebSocketServer ws;
        
        public WebsocketOnMessageRecived action;
        public bool IsListening
        {
            get
            {
                return (ws != null) ? ws.ListenerSocket.Connected : false;
            }
        }

        public WebsocketWrap(int port, WebsocketOnMessageRecived action)
        {
            this.port = port;
            this.action = action;
            ws = new WebSocketServer(URL);
            ws.ListenerSocket.NoDelay = false;
        }

        public void Start()
        {
            if (ws == null)
                ws = new WebSocketServer(URL);
                
            ws?.Start(socket =>
            {
                socket.OnOpen = () => { OnOpen(socket); };
                socket.OnClose = OnClose;
                socket.OnMessage = message => { MessageDispatcher(socket, message); };
            });
        }

        private void OnOpen(IWebSocketConnection socket)
        {
        }

        private void OnClose()
        {
        }

        private void MessageDispatcher(IWebSocketConnection socket, string message)
        {
            object toSend;
            if (message == "HOLA MUNDO")
                toSend = message;
            else
                toSend = action?.Invoke(JsonConvert.DeserializeObject<WebsocketMessage>(message,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));

            socket.Send(JsonConvert.SerializeObject(toSend, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
        }

        public void Stop()
        {
            ws?.Dispose();
        }
    }

    public class WebsocketMessage
    {
        public string command;
        public string tag;
        public bool success;
    }
}