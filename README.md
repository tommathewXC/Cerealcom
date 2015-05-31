# Cerealcom
Excel based oscilloscope using Arduino and VB.NET

Demonstration at: https://www.youtube.com/watch?v=hTaZTMWb7BE


The "CerealCom" (as in Serial Communication system) interfaces an arduino board with Microsoft Excel. 
The purpose of this project was to make a basic digital oscilloscope using cheap hardware and microsoft excel.
There are three stages to
this project:

1. The Arduino hardware:
  
   The Arduino Uno is a microcontroller with hardware input and output pins. The programming of this board is done through the 
   arduino environment using C. I have defined a specific pin for the voltage input on the board. In the development framework,
  I have also defined the baud rate at which data is being streamed into the USB COM port. 
  
2. Visual Basic .NET 4.0

  This part was required so that the voltage data being streamed into the COM port of the desktop is being properly used and 
  presentetd. I used A console application in VB.NET to interface to the port, and manually handled the data. I would then need
  a predefined excel document that has a presentation format set up, so that the user of the system will know where to look
  in order to read his/her measurements.
  
3. The MS Excel template file

  This file is merely used so that the output from the VB.NET application ("Asillyscope.vb") has a target container to dump    the data to. 

Before using CerealCOm, you first have to calibrate the timing. In order to do this, you have to use a precise capacitor and a 
precise resistor, which would give you a relaxation circuit whose relaxation time is easy to calculate. this time T = R*C, where
R is the resistance, ance C is the capacitance. Since we know that when the capacitor and resistor are in parallel, and they are
energized, it takes the circuit exactly T seconds to go from the stimulation voltage, to exactly half that. USing this knowledge
we can calibrate the timing. This setup is made possible using the "captester.xls" and "captester.ino".



