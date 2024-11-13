
namespace FS80H.Scanner;

public partial class Scanner_Interface : Form
{
    private Futronic _futronic;
    private bool _isInitialized = false;


    public Scanner_Interface()
    {
        _futronic = new Futronic();
        InitializeComponent();
    }

    private void Scanner_Interface_FormClosing(object sender, EventArgs e)
    {
        if (_isInitialized)
        {
            txtLogs.AppendText("Fingerprint scanner disconnected. \r\n");
            _futronic.SetDiodesStatus(false, false);
        }
    }

    private void btn_Start_Capture_Click(object sender, EventArgs e)
    {
        _isInitialized = _futronic.Init();
        if (_isInitialized)
        {
            txtLogs.AppendText("Fingerprint scanner connected. \r\n");

            //Double flash the green light to indicate connection
            FlashLight(true, false, 200, 50, 2);
        }
        else
        {
            txtLogs.AppendText("Failed to connect to Fingerprint scanner. \r\n");
        }
    }

    private void btn_Complete_Capture_Click(object sender, EventArgs e)
    {
        if (_isInitialized)
        {
            // Capture fingerprint
            var fingerprintBitMap = _futronic.ExportBitMap();
            if(fingerprintBitMap == null)
            {
                txtLogs.AppendText("Failed to capture fingerprint. \r\n");
                //Double flash the red light to indicate we failed to scan the fingerprint
                FlashLight(false, true, 200, 50, 2);
                return;
            }

            Fingerprint.Image = fingerprintBitMap;

            var isFingerprint = _futronic.IsFinger();
            txtLogs.AppendText(isFingerprint ?
                                "Fingerprint captured successfully. \r\n" : 
                                "Invalid fingerprint. \r\n");

            //Double flash the green or red light bases on whether the image is a valid fingerprint or not
            FlashLight(isFingerprint, !isFingerprint, 1500);
        }
        else
        {
            txtLogs.AppendText("Fingerprint scanner not connected. \r\n");
        }
    }

    private void btn_Download_Click(object sender, EventArgs e)
    {
        var image = Fingerprint.Image;
        if (image != null)
        {
            var saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                RestoreDirectory = true,
                Filter = "WSQ|*.wsq",
                Title = "Save an Image File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                image.Save(saveFileDialog.FileName);
                txtLogs.AppendText("Fingerprint saved successfully as " + saveFileDialog.FileName + ".  \r\n");
            }
        }
    }

    private void FlashLight(bool green, bool red, int durationOn, int durationOff = 0, int flashCount = 1)
    {
        do
        {
            // Switch on the light(s)
            _futronic.SetDiodesStatus(green, red);
            Thread.Sleep(durationOn);

            // Switch off the light(s)
            _futronic.SetDiodesStatus(false, false);
            if(durationOff> 0) Thread.Sleep(durationOff);

            flashCount--;
        } 
        while (flashCount > 0);
    }
}

