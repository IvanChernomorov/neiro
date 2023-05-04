A = [-0.2 0.5 1.2;-0.2 0.6 1.5];
B =[-1.0 -1.5 -1.8;-1.6 -1.3 -1.8];
C = [3.2 2.6 3.8 ; 2.4 2.1 3.5];
plot(A(1,:),A(2,:),'bs')
hold on
grid on
plot(B(1,:),B(2,:),'r+')
plot(C(1,:),C(2,:),'go')
% определение выходных кодировок классов
a = [0 1]';
b = [0 0]';
c = [1 1]';
P = [A B C];
T = [repmat(a,1,length(A)) repmat(b,1,length(B)) ...
repmat(c,1,length(C))];
net = perceptron;
net = configure(net,P,T);
% обучение персептрона в цикле
E = 1;
net.adaptParam.passes = 1;
linehandle = plotpc(net.IW{1},net.b{1});
n = 0;
while (sse(E) & n<1000) 
n = n+1;
[net,Y,E] = adapt(net,P,T);
linehandle = plotpc(net.IW{1},net.b{1},linehandle);
drawnow;
end
% визуализируем структуру ИНС

view(net);
hold on
plot(0,0,'bs')
hold on
plot(-1,-1,'r+')
hold on
plot(1,1,'bs')

