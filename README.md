# FORTH_NRF52840-DK
Enable mecrisp-sterallis FORTH to run from the NRF52840-DK built-in USB serial connection

Setup instructions:

0.  Upload the hex file in this repository to the nRF52840-DK by dragging it to the virtual JLINK drive that appears on your computer when the nRF52840-DK is attached.  This is the microbit hex file, but it has been recompiled to encompass the 256K RAM and 1MB of flash that the nRF52840 has.
1.  On the nRF52840-DK, connect pin P0.25 to pin P0.08, and connect P0.24 to pin P0.06.  
2.  Install mecrisp-sterallis for the BBC:microbit onto the nRF52840-DK by dragging the hex file onto the nRF52840-DK's virtual drive.
3.  Open a terminal to the nRF52840-DK, using baudrate 115200.
4.  Upload the file in this repository.
5.  Done!  The change will now be  made automatically every time the nRF52840-DK is rebooted.  You no longer need the jumper wires, and the nRF52840-DK will now use the proper pins for communicating over its usb interface.  
