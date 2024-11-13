# FS80H_Net8

Based on the code from https://github.com/ay29dev/futronic-FS80H, but it uses the .net 8 framework.

***Do note that in order for this to be able to use the ftrScanAPI.dll, the project needs to be compiled in x86.***

This is built specifically for the Futronic FS80H fingerprint scanner. It might work with the other Futronic models, but it is not guarenteed.
Also, apologies for the atrocious UI, but I can't be bothered to make it look pretty. I just needed it to work as a proof of concept.

## Usage
1. Obvious step, but plug in the FS80H device via USB to the device being used to run the application.
2. Run the application either through an IDE or compile the release and run the exe.
3. You will be presented with the below screen:
   
   ![image](https://github.com/user-attachments/assets/087bcad7-4b1b-453f-84e3-e1de295ec1a1)
   
   The Panel on the left is where the fingerprint will appear and the panel on the right is where the logs will appear.
   
5. Press the Initialize Connection button to connect to the device and a green light will flash on the device.
6. Capture Image will attempt to scan the fingerprint and display it on the left panel. If it was successful, a green light will light up and the fingerprint image will appear on the left. If the fingerprint scan is either too low quality or the finger is not present at all, a red light will flash.
7. You can then click the Donwload button to open a save file dialog with the file type .wsq preselected.
