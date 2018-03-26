%% PAA4

% This code puts variables in the workspace and creates transfer functions.
% It also puts the required variables in the workspace for the
% Non-linear_simulation.slx file. The line of code below will allow you to
% plot the results of these simulations:
% plot(nonlinear.time, nonlinear.signals.values)

close all;
clear all;

%% Variables

Lp = 0.33655;     
lp = Lp/2  ;    %half length of pendulum
mp = 0.127;     %mass of pendulum
Jp = 0.0012;    %Pendulum moment of intertia about centre
r = .216;       %length of arm
Jarm = .0020;   %moment of inertia of arm about end  
Jeq = 2.087e-3; %gearbox inertia as seen at motor 
G = 70;         %gear ratio back to motor
Jarm = (Jarm + Jeq/G^2); % Add in inertia of gear box and rotor
Ra = 2.6;       %motor armature resistance
kt = 7.68e-3;   %motor current-torque constant
Kb = kt;        %back emf   
g=9.81;         %gravity
s=tf('s');      %
La = .18e-3;    %Motor inductance

% Variables for non-linear simulation 
Bp = 0.0024;     % Viscous damping coefficients as seen at the 
Beq = 0.02  ;    % pivot axis;
eta_m = 0.69;    % motor efficiency
eta_g = 0.9;     % gearbox efficiency
Kg = G;
Rm = Ra;


%
% Initialise replayer.
%
lengthOfReplay = 20; % Seconds.
frameRate = 50; % Make this higher if playback is too fast. Make this lower if playback is laggy.
[armPartPatchHandle, armPartVertices, pendPartPatchHandle, pendPartVertices, drivePartPatchHandle, drivePartVertices, thetaPlotHandle, alphaPlotHandle] = initialiseVisualiser(lengthOfReplay);


%% transfer functions
%theta_tau = (4*lp*s^2 - 3*g)/((4*lp*Jarm + lp*mp*r^2)*s^4 - (3*g*(Jarm + mp*r^2))*s^2);
num = ((mp*lp^2 + Jp)*s^2 - mp*lp*g);
den = (((Jarm + mp*r^2)*(mp*lp^2 + Jp ) - (mp*lp*r)^2)*s^4 - (Jarm + mp*r^2)*mp*lp*g*s^2);
theta_tau = num/den;
block1 = 1/(Ra + La*s);
block2 = kt*G;
sys1 = theta_tau * block1 * block2;
sys2 = Kb*G*s;
num2 = mp*lp*r*s^2;
den2 = ((mp*lp^2 + Jp)*s^2 - mp*lp*g);
a_theta = num2/den2;
theta_va = feedback(sys1,sys2)
theta_va2 = minreal(theta_va)
a_va = series(theta_va2,a_theta)
a_va2 = minreal(a_va)
%theta_alpha = ((4*lp*s^2)/3-g)/(r*s^2);
%alpha_theta = (r*s^2)/((4*lp*s^2)/3-g);

%% SISO & PID (Task 3)
num3 = 2.1753*s^2 + 133.2936*s + 1851.3;
den3 = s;
sys3 = num3/den3;
a_aref = minreal(feedback(series(sys3, a_va2), 1))

%% SISO & PD (Task 5)
theta_a = minreal(den2/num2);
theta_aref = minreal(series(a_aref,theta_a));
num4 = -0.023048 - 0.0530104*s;
den4 = 1 + 0.14*s;
sys4 = num4/den4;
theta_thetaref = minreal(feedback(series(sys4, theta_aref), 1))






