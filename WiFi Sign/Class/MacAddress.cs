using PacketDotNet;
using PacketDotNet.Ieee80211;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WiFi_Sign.Class
{
    class MacAddress
    {
        private string macaddr = string.Empty;
        private bool valid = false;

        // 获取设备的 MAC 地址，如果是 AP 则返回 Null
        public string GetWlanSa(CaptureEventArgs e)
        {
            var p = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            MacFrame macFrame = (MacFrame)p.PayloadPacket;

            if (macFrame != null) // 只拉取 802.11 的 MAC 帧
            {
                if (macFrame.FrameControl.SubType == FrameControlField.FrameSubTypes.ManagementProbeRequest) // 如果是设备请求 AP 列表
                {
                    ProbeRequestFrame probeReqFrame = (ProbeRequestFrame)macFrame;
                    macaddr = probeReqFrame.SourceAddress.ToString();
                    valid = true;
                }
                else if (macFrame.FrameControl.SubType == FrameControlField.FrameSubTypes.DataNullFunctionNoData) // 如果是设备发送心跳
                {
                    NullDataFrame nullDataFrame = (NullDataFrame)macFrame;
                    macaddr = nullDataFrame.SourceAddress.ToString();
                    valid = true;
                }
            }

            if (valid) // 格式化 MAC 地址
            {
                macaddr = Regex.Replace(macaddr, @"^(..)(..)(..)(..)(..)(..)$", "$1-$2-$3-$4-$5-$6");
            }
            else
            {
                return null; //是 AP 则返回 Null
            }

            return macaddr;
        }
    }
}
