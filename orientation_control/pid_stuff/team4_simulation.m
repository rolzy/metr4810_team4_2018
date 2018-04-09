%% METR4810 2018

% This code puts variables in the workspace and creates transfer functions.
% It also puts the required variables in the workspace for the
% Non-linear_simulation.slx file. The line of code below will allow you to
% plot the results of these simulations:
% plot(nonlinear.time, nonlinear.signals.values)

close all;
clear all;

%% Variables

s = tf('s');    %Laplace variable
I = 0.0186805;  %MOI of spacecraft 
Kt = 0.00417;   %Torque Constant of Turnigy D1104

%% Transfer Function
num = Kt;
den = I*s^2;
H = num/den;
theta_current = feedback(H, 1);

%% Root Locus

%rlocus(theta_current)

%% SISO tool
controlSystemDesigner(theta_current)
