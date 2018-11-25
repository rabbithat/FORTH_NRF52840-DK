# FORTH_NRF52840-DK
Enable mecrisp-sterallis FORTH to run from the NRF52840-DK built-in USB serial connection

Setup instructions:  
1.  On the nRF52840-DK, connect pin P0.25 to pin P0.08, and connect then P0.24 to pin P0.06.  
2.  Install mecrisp-sterallis for the BBC:microbit onto the nRF52840-DK by dragging the hex file onto the nRF52840-DK's virtual drive.
3.  Open a terminal to the nRF52840-DK, using baudrate 115200.
4.  Upload the file in this repository.
5.  Done!  You no longer need the jumper wires, and the nRF52840-DK will now use the proper pins for communicating over its usb interface.  The change will be automatically done every time the nRF52840-DK is rebooted.
