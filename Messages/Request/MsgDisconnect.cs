﻿using Kaenx.Konnect.Addresses;
using Kaenx.Konnect.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kaenx.Konnect.Messages.Request
{
    /// <summary>
    /// Creates a telegram to disconnect from device
    /// </summary>
    public class MsgDisconnect : IMessageRequest
    {
        private byte _channelId;
        private int _sequenzeNumb;
        private byte _sequenzeCount;
        private UnicastAddress _address;

        /// <summary>
        /// Creates a telegram to disconnect from device
        /// </summary>
        /// <param name="address">Unicast Address from device</param>
        public MsgDisconnect(UnicastAddress address)
        {
            _address = address;
        }

        public byte[] GetBytesCemi()
        {
            TunnelRequest builder = new TunnelRequest();
            builder.Build(UnicastAddress.FromString("0.0.0"), _address, Parser.ApciTypes.Disconnect, 255);
            return builder.GetBytes();
        }

        public byte[] GetBytesEmi1()
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytesEmi2()
        {
            throw new NotImplementedException();
        }

        public void SetInfo(byte channel, byte seqCounter)
        {
            _channelId = channel;
            _sequenzeCount = seqCounter;
        }

        public void SetSequenzeNumb(int seq)
        {
            _sequenzeNumb = seq;
        }
    }
}