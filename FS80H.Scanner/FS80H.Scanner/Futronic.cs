

using System.Runtime.InteropServices;

namespace FS80H.Scanner;

public class Futronic
{
    public struct _FTRSCAN_FAKE_REPLICA_PARAMETERS
    {
        public bool bCalculated { get; set; }
        public int nCalculatedSum1 { get; set; }
        public int nCalculatedSumFuzzy { get; set; }
        public int nCalculatedSumEmpty { get; set; }
        public int nCalculatedSum2 { get; set; }
        public double dblCalculatedTremor { get; set; }
        public double dblCalculatedValue { get; set; }
    }

    public struct _FTRSCAN_IMAGE_SIZE
    {
        public int nWidth { get; set; }
        public int nHeight { get; set; }
        public int nImageSize { get; set; }
    }

    public struct _FTRSCAN_FRAME_PARAMETERS
    {
        public int nContrastOnDose2 { get; set; }
        public int nContrastOnDose4 { get; set; }
        public int nDose { get; set; }
        public int nBrightnessOnDose1 { get; set; }
        public int nBrightnessOnDose2 { get; set; }
        public int nBrightnessOnDose3 { get; set; }
        public int nBrightnessOnDose4 { get; set; }
        public _FTRSCAN_FAKE_REPLICA_PARAMETERS FakeReplicaParams { get; set; }
        public _FTRSCAN_FAKE_REPLICA_PARAMETERS Reserved { get; set; }

        public bool isOK { get { return nDose != -1; } }
    }

    [DllImport("ftrScanAPI.dll")]
    static extern bool ftrScanIsFingerPresent(IntPtr ftrHandle, out _FTRSCAN_FRAME_PARAMETERS pFrameParameters);
    [DllImport("ftrScanAPI.dll")]
    static extern IntPtr ftrScanOpenDevice();
    [DllImport("ftrScanAPI.dll")]
    static extern void ftrScanCloseDevice(IntPtr ftrHandle);
    [DllImport("ftrScanAPI.dll")]
    static extern bool ftrScanSetDiodesStatus(IntPtr ftrHandle, byte byGreenDiodeStatus, byte byRedDiodeStatus);
    [DllImport("ftrScanAPI.dll")]
    static extern bool ftrScanGetDiodesStatus(IntPtr ftrHandle, out bool pbIsGreenDiodeOn, out bool pbIsRedDiodeOn);
    [DllImport("ftrScanAPI.dll")]
    static extern bool ftrScanGetImageSize(IntPtr ftrHandle, out _FTRSCAN_IMAGE_SIZE pImageSize);
    [DllImport("ftrScanAPI.dll")]
    static extern bool ftrScanGetImage(IntPtr ftrHandle, int nDose, byte[] pBuffer);


    static IntPtr device;
    public bool Init()
    {
        if (!Connected)
            device = ftrScanOpenDevice();
        return Connected;
    }

    public bool Connected
    {
        get { return (device != IntPtr.Zero); }
    }

    public void Dispose()
    {
        if (Connected)
        {
            ftrScanCloseDevice(device);
            device = IntPtr.Zero;
        }
    }

    public Bitmap ExportBitMap()
    {
        if (!Connected)
            return null;

        var t = new _FTRSCAN_IMAGE_SIZE();
        ftrScanGetImageSize(device, out t);
        byte[] arr = new byte[t.nImageSize];
        ftrScanGetImage(device, 4, arr);

        var bmp = new Bitmap(t.nWidth, t.nHeight);
        for (int x = 0; x < t.nWidth; x++)
        {
            for (int y = 0; y < t.nHeight; y++)
            {
                int a = 255 - arr[y * t.nWidth + x];
                bmp.SetPixel(x, y, Color.FromArgb(a, a, a));
            }
        }
        return bmp;
    }
    
    public bool IsFinger()
    {
        var t = new _FTRSCAN_FRAME_PARAMETERS();
        bool dedo = ftrScanIsFingerPresent(device, out t);
        if (!t.isOK)
        {
            Dispose();
            return false;
        }
        else
            return dedo;
    }

    public void GetDiodesStatus(out bool green, out bool red)
    {
        ftrScanGetDiodesStatus(device, out green, out red);
    }

    public void SetDiodesStatus(bool green, bool red)
    {
        ftrScanSetDiodesStatus(device, (byte)(green ? 255 : 0), (byte)(red ? 255 : 0));
    }
}
