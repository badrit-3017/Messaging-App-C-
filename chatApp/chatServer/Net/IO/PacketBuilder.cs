// class for the the server to build packets (exactly like the client side)
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatServer.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        public void WriteString(string msg)
        {
            //msg = Crypto.Encrypt(msg, "Password123"); //Uncomment this line for AES encryption
            //msg = Crypto.TrivialEncryption(msg); //Uncomment this line for trivial encryption
            var msgLength = msg.Length;
            _ms.Write(BitConverter.GetBytes(msgLength));
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        public byte[] getPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
