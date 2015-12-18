using System;
using SokolovSport.Dat;

namespace SokolovSport.EcuComm
{
    static class CommunicationHelper
    {
        public static void WriteCalibr(this EcuCommunication ecu, CalibrItem calibrItem)
        {
            var requests = calibrItem.CreateWriteRequest(true);

            foreach (var request in requests)
            {
                ecu.WriteRequests.Add(request);
            }
        }

        public static void SyncCalibr(this CalibrItem calibrItem)
        {
            switch (calibrItem.ItemInfo.ItemType)
            {
                case ItemTypes.Const:
                case ItemTypes.Var:
                    {
                        var requestIndex = 0;
                        calibrItem.RawValue = GetRawValue(calibrItem, ref requestIndex);
                        break;
                    }

                case ItemTypes.Table:
                case ItemTypes.Teach:
                    {
                        var count = calibrItem.Table.Count;
                        var requestIndex = 0;
                        for (int i = 0; i < count; i++)
                        {
                            calibrItem.Table.Cell(i).Source = GetRawValue(calibrItem, ref requestIndex);
                        }
                        calibrItem.Table.FillValues();
                        calibrItem.Table.DoTableChanged();
                        break;
                    }
            }
        }

        private static int GetRawValue(CalibrItem calibrItem, ref int requestIndex)
        {
            var rawValue = 0;
            switch (calibrItem.ItemInfo.SizeType)
            {
                case SizeTypes.Int:
                case SizeTypes.UInt:
                    {
                        int value = 0;
                        for (int i = 0; i < 2; i++)
                        {
                            var request = calibrItem.readRequests[requestIndex++];
                            value += request.RawValue << (1 - i)*8;
                        }
                        if (calibrItem.ItemInfo.SizeType == SizeTypes.Int)
                            rawValue = (short) value;
                        else
                            rawValue = (ushort) value;
                        break;
                    }

                case SizeTypes.Char:
                    {
                        rawValue = (sbyte)calibrItem.readRequests[requestIndex++].RawValue;
                        break;
                    }

                case SizeTypes.UChar:
                case SizeTypes.Bit:
                    {
                        rawValue = calibrItem.readRequests[requestIndex++].RawValue;
                        break;
                    }
            }

            return rawValue;
        }

        public static void FillRawBuffer(this Request request, byte[] buffer)
        {
            buffer[0] = (byte) request.Type;
            buffer[1] = request.AddrHi;
            buffer[2] = request.AddrLo;
            buffer[3] = request.RawValue;
        }
    }
}
