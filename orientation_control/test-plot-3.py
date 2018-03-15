import matplotlib
matplotlib.use("qt4agg")
#!/usr/bin/env python

"""test-imu-plot.py: Ask multiwii for raw IMU and plot it using matplotlib."""

__author__ = "Aldo Vargas"
__copyright__ = "Copyright 2016 Altax.net"

__license__ = "GPL"
__version__ = "1"
__maintainer__ = "Aldo Vargas"
__email__ = "alduxvm@gmail.com"
__status__ = "Development"

from pymultiwii import MultiWii
import matplotlib.pyplot as plt

serialPort = "COM4"
board = MultiWii(serialPort)

fig = plt.figure()

sb = 0
gxbuf, gybuf, gzbuf = 0, 0, 0
senses = 0
    
while True:
    board.getData(MultiWii.RAW_IMU)
	#print board.rawIMU
    t = float(board.rawIMU['timestamp'])
    gx = board.rawIMU['gx']
    gy = board.rawIMU['gy']
    gz = board.rawIMU['gz']
    senses += 1
    plt.plot([sb, senses], [gxbuf, gx], color='y', label='GX')
    plt.plot([sb, senses], [gybuf, gy], color='black', label='GY')
    plt.plot([sb, senses], [gzbuf, gz], color='pink', label='GZ')
    sb, gxbuf, gybuf, gzbuf = senses, gx, gy, gz
    plt.pause(0.05)
    