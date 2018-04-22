%% METR4810 2018

% This code puts variables in the workspace and creates transfer functions.
% It also puts the required variables in the workspace for the
% Non-linear_simulation.slx file. The line of code below will allow you to
% plot the results of these simulations:
% plot(nonlinear.time, nonlinear.signals.values)

close all;
clear all;

%% Variables

s = tf('s');              % Laplace variable
I_craft = 0.0186805;      % MOI of spacecraft
I_flywheel = 0.000003392; % MOI of flywheel
Kt = 0.00417;             % Torque Constant of 2290kV rated motor

%% Transfer Function
num = 1;
den = I_craft*s^2;
H = num/den;
theta_current = feedback(H, 1);

%% Root Locus

%rlocus(theta_current)

%% SISO tool
controlSystemDesigner(H)

%% Compensator
%num = 0.6677*s^2 + 5.641*s + 11.512;
%den = s;
%C = tf([0.6677, 5.641, 11.512],[1,0]);
%fb=bandwidth(theta_current, -3)

