using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Packet_libirary
{
    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;


        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 54);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }
        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 54);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }
    [Serializable]
    public class PMessage : Packet
    {
        public int Data = 0;
        public string UserName;
        public string command;
        public string message;
        public int[] pX;
        public int[] py;
        public int[] eX;
        public int[] eY;
        public int[] thick;
        public string[] Color;
        public int[] Rec = Enumerable.Repeat<int>(-1, 1000).ToArray<int>();
        public int[] Cir = Enumerable.Repeat<int>(-1, 1000).ToArray<int>();
        public int[] Line;
        public PMessage()
        {
            pX = new int[1000];
            py = new int[1000];
            eX = new int[1000];
            eY = new int[1000];       
            Line = new int[1000];
            thick = new int[1000];
            Color = new string[1000];          
        }

    }
}
